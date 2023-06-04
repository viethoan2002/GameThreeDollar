using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class miniparkController : MonoBehaviour
{
    public GameObject ekey;
    public GameObject Cong;
    public GameObject ui;
    public TMP_Text text;
    public Sprite sprite;
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
            Cong.GetComponent<Collider2D>().isTrigger = true;
            Cong.GetComponent<SpriteRenderer>().sprite = sprite;
            text.text = "NoAh ! I have lost three dollars in the park. Please help me collect it and give it to Quang Thuan who is waiting at the other gate.";
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
