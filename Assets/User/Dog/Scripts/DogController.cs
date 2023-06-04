using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DogController : MonoBehaviour
{
    GameObject player; // Đối tượng đại diện cho người chơi
    public GameObject Point;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator Anm;

    public float speed = 5f; // Tốc độ di chuyển của con chó
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
        Point.SetActive(true);
        velocity_x = Input.GetAxis("Horizontal");

        if (velocity_x > 0)
        {
            sr.flipX = false;
        }
        if (velocity_x < 0)
        {
            sr.flipX = true;
        }
        rb.velocity = new Vector2(velocity_x * speed, rb.velocity.y);
        Anm.SetFloat("velocity_x", Mathf.Abs(rb.velocity.x));
    }
}
