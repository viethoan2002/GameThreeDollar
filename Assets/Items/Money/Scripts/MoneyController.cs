using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    public Sprite sprite;
    public Image image;
    public BossParkController bb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bb.setSl();
            image.GetComponent<Image>().sprite = sprite;
            Destroy(gameObject);
        }
    }
}
