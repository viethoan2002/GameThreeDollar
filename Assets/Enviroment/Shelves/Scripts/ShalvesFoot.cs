using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShalvesFoot : MonoBehaviour
{
    public ShalvesBody shalvesBody;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shalvesBody.quanternionZ();
        collision.gameObject.GetComponent<Ball>().DesBALL();
        Destroy(gameObject);
    }
}
