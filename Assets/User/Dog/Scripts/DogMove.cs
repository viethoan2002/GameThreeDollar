using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    GameObject player; // Đối tượng đại diện cho người chơi
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator Anm;

    public bool Control = false;
    public float speed = 5f; // Tốc độ di chuyển của con chó
    float minthreshold = 0.5f; // Ngưỡng khoảng cách nhỏ nhất giữa con chó và người chơi 
    float maxthreshold = 200f;  // Ngưỡng khoảng cách lớn nhất giữa con chó và người chơi 
    float threshold = 0.5f; // Ngưỡng khoảng cách giữa con chó và người chơi 
    float velocity_x;
    public bool RuntoPlayer = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Anm = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Dogmove();
    } 

    void Dogmove()
    {
        // kiểm tra xem người chơi có gọi ko
        if (RuntoPlayer)
        {
            threshold = minthreshold;
        }
        else
        {
            threshold = maxthreshold;
        }

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance > threshold)
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, 0).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            // nếu người chơi đang gọi
            if (RuntoPlayer)
            {
                RuntoPlayer = false;
            }
        }

        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        Anm.SetFloat("velocity_x", Mathf.Abs(rb.velocity.x));
    }
}
