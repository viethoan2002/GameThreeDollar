using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyControll : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject ekey;
    public GameObject ui;
    public TMP_Text text;
    public GameObject Doorin,Doorout;
    public Human6Controller human6;
    bool getkey = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && getkey)
        {
            Doorin.GetComponent<DoorController>().open = true;
            Doorout.GetComponent<DoorController>().open = true;
            human6.GetComponent<Human6Controller>().SetThoai("So you have the key, this dog will follow you into the store, it will help you a lot.");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ekey.SetActive(true);
            getkey = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ekey.SetActive(false);
            getkey = false;
            if (text != null)
            {
                ui.SetActive(false);
            }
        }
    }
}
