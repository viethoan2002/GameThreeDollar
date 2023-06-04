using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy05Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject mine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("spawnmine", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * 3;
    }

    void spawnmine()
    {
        Instantiate(mine,new Vector3(transform.position.x - 0.44f,transform.position.y + 1.24f, -0.1f), mine.transform.rotation);
    }
}
