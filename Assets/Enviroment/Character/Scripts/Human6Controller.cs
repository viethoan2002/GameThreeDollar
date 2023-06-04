using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Human6Controller : MonoBehaviour
{
    public GameObject ekey;
    Rigidbody2D rb;
    public GameObject chunha;
    public GameObject ui;
    public TMP_Text text;
    string thoai = "The shop is temporarily closed because the owner is fishing with his friends by the lake. You can go to the lake to ask him.";
    bool Controll = false;
    AudioSource audio;
    public AudioClip aclip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Controll)
        {
            audio.PlayOneShot(aclip);
            ekey.SetActive(false);
            chunha.GetComponent<Collider2D>().enabled = true;
            ui.SetActive(true);
            text.text = thoai;
        }
    }
    public void SetThoai(string thoai)
    {
        this.thoai = thoai;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ekey.SetActive(true);
            Controll = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ekey.SetActive(false);
            Controll = false;
            ui.SetActive(false);
        }
    }
}
