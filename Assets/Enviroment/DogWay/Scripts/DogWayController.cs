using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWayController : MonoBehaviour
{
    GameObject Dog;
    Rigidbody2D rb;
    public Transform WayOut;
    public float poswayx, poswayy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Dog = GameObject.FindWithTag("Dog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dog")
        {
            Dog.GetComponent<Transform>().position = new Vector3(WayOut.position.x + poswayx, WayOut.position.y + poswayy, Dog.transform.position.z);
        }
    }
}
