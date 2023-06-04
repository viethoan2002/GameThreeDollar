using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossParkController : MonoBehaviour
{
    Animator Anm;
    SpriteRenderer sr;
    public EnemiCarController car;
    public GameObject ekey;
    public GameObject ui;
    public TMP_Text text;
    AudioSource audio;
    public AudioClip aclip;
    public bool k=false;
    float sl = 3;

    bool iscontroll = false;
    // Start is called before the first frame update
    void Start()
    {
        sl = PlayerPrefs.GetFloat("sl");
        Anm = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
            if (sl > 0)
            {
                text.text = "Oh !You still haven't found enough piles of money. Try to go back and look around again.";
            }
            else
            {
                text.text = "Oh ! Thank you NoAh, you found the lost money to help us, now I bring the money to fight Tai Xiu. Goodbye.";
                Invoke("setk", 2f);
            }
        }
        if (k) gotoCar();
    }
    void setk()
    {
        k = true;
    }

    public void setSl()
    {
        PlayerPrefs.SetFloat("sl", sl - 1);
        sl = sl - 1;
    }
    private void gotoCar()
    {
        sr.flipX = false;
        Anm.SetBool("walk", true);
        if(transform.position.x< 60.41f)
        {
            transform.Translate(Vector2.right*Time.deltaTime);
        }
        if (transform.position.x >= 60.41f)
        {
            car.getCar();
            Invoke("unActive", 0.2f);   
        }
    }
    void unActive()
    {
        gameObject.SetActive(false);
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
