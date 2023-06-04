using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float t = Random.RandomRange(4, 9);
        rb.AddForce(Vector2.up*100*t);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
