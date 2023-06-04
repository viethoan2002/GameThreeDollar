using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;

    public GameObject BALL;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void DesBALL()
    {
        Destroy(BALL);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(BALL);
    }
}
