using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator Anm;
    SpriteRenderer Sr;
    public GameObject Dog;
    public GameObject Point;
    AudioSource audio;
    public AudioClip jumpclip,stepclip;

    Vector2 velocity;

    public bool Climb = false;
    public bool Hang = false;
    float speed = 3, heightforce = 3.5f;
    public float velocity_x,velocity_y; 
    bool isGround = true;
    float enviromentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anm = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Sr = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        transform.position=new Vector3(PlayerPrefs.GetFloat("player_x"), PlayerPrefs.GetFloat("player_y"),-2);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerCtr();
       Point.SetActive(true);
    }
   

    void PlayerCtr()
    {
        if (Climb)
        {
            PlayerClimb();
        }
        else
        {
            if (Hang)
            {
                PlayerHang();
            }
            else
            {
                PlayerMove();
            }
        }  
        Anm.SetBool("climb", Climb);
        Anm.SetBool("hang", Hang);
        Anm.SetFloat("velocity_X", Mathf.Abs(velocity_x));
        Anm.SetFloat("velocity_Y", rb.velocity.y);
    }

    void PlayerHang()
    {
        velocity_x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(velocity_x * speed + enviromentSpeed, rb.velocity.y);
        Anm.SetFloat("velocity_X", velocity_x);
    }

    //leo thang
    void PlayerClimb()
    {
        rb.gravityScale = 0;
        velocity_y = Input.GetAxis("Vertical");
        velocity = new Vector2(0, velocity_y);
        rb.velocity = velocity;
    }

    void PlayerMove()
    {
        rb.gravityScale = 1;
        velocity_x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.F))
        {
            speed = speed * 5;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            speed = 3;
        }
        //kiểm tra có đang trạm đất không
        if (isGround)
        {
            Anm.SetBool("jump", false);
            Anm.SetBool("double_jump", false);
        }

        if (velocity_x > 0)
        {
            Sr.flipX = false;
        }
        if (velocity_x < 0)
        {
            Sr.flipX = true;
        }
        velocity = new Vector2(velocity_x * speed + enviromentSpeed, rb.velocity.y);

        //xử lý nhảy
        if (isGround && Input.GetButtonDown("Jump"))
        {
            audio.PlayOneShot(jumpclip);
            isGround = false;
            velocity = new Vector2(rb.velocity.x, heightforce);
            Anm.SetBool("jump", true);
        }

        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void stepsound()
    {
        audio.PlayOneShot(stepclip);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // kiểm tra va chạm thang máy
        if (collision.gameObject.tag == "Conveyor")
        {
            enviromentSpeed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Conveyor")
        {
            enviromentSpeed = 0;
        }
    }
}
