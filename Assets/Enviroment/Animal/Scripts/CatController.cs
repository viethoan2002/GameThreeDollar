using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform player;
    public GameObject ekey;
    public ChuroomController churoom;
    bool bat = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ekey.active && Input.GetKeyDown(KeyCode.E))
        {
            churoom.CatFind();
            Destroy(gameObject);
        }
    }

    public void setbat()
    {
        bat = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(bat&& collision.gameObject.tag == "Player")
        {
            ekey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ekey.SetActive(false);
    }
}
