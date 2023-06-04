using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShalvesBody : MonoBehaviour
{
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

    public void quanternionZ()
    {
        transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,transform.rotation.eulerAngles.y, -30), 1.25f);
    }
}
