using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator Anm;

    public float speed;
    public float bienx, bieny;
    float startx;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Anm = GetComponent<Animator>();
        startx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        ConveyorMove();
    }

    void ConveyorMove()
    {
        Vector2 direction = new Vector2(bienx* speed, bieny* speed).normalized;
        rb.velocity = direction;
    }
}
