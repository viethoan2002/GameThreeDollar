using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishermanController : MonoBehaviour
{
    public GameObject ekey;
    Rigidbody2D rb;
    public GameObject key;
    public GameObject ui;
    public TMP_Text text;
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
            key.SetActive(true);
            ui.SetActive(true);
            text.text = "Ah ! Yes, I picked up a stake, I left it in the store and I left the key with it, but I remember it somewhere in the lawn." +
                "When entering the store be careful with the store's security, they are quite aggressive.";
        }
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
