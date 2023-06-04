using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChuroomController : MonoBehaviour
{
    public GameObject ekey;
    public GameObject bien;
    public GameObject ui;
    public TMP_Text text;
    Rigidbody2D rb;
    public CatController cat;
    AudioSource audio;
    public AudioClip aclip;

    bool iscontroll=false;
    bool findcat = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iscontroll)
        {
            audio.PlayOneShot(aclip);
            cat.setbat();
            ekey.SetActive(false);
            ui.SetActive(true);
            text.text = "It's true that I have a stake, you can get it back if you help me find my lost cat.";
            if (findcat)
            {
                bien.SetActive(false);
                text.text = "Thank you very much! My uncle's deposit is somewhere in the store. Come inside and get it. By the way, I saw Mr. Phu Xuyen of LAWSON holding a stake.";
            }
        }
    }

    public void CatFind()
    {
        findcat = true;
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
            iscontroll = false;
            ui.SetActive(false);
        }
    }
}
