using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class human7Controller : MonoBehaviour
{
    public GameObject ekey;
    public GameObject ui;
    public TMP_Text text;
    Rigidbody2D rb;
    public GameObject player;
    AudioSource audio;
    public AudioClip aclip;


    bool iscontroll = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iscontroll)
        {
            audio.PlayOneShot(aclip);
            ekey.SetActive(false);
            ui.SetActive(true);
            text.text = "Oh ! Are you looking for lost money piles ? Maybe you should go and ask Mr. Dat Bui at the lakeside wharf.";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ekey.SetActive(true);
            iscontroll = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ekey.SetActive(false);
            ui.SetActive(false);
            iscontroll = false;
        }
    }
}
