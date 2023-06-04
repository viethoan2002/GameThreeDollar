using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelEkey : MonoBehaviour
{
    public GameObject ekey;
    Rigidbody2D rb;
    public GameObject player;
    public GameObject dog;
    public GameObject Ball;

    bool Controll = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Controll)
        {
            ekey.SetActive(false);
            player.transform.position = new Vector3(-32.85078f, -26.42f, player.transform.position.z);
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerAction>().enabled = false;
            player.GetComponent<ChangeUser>().enabled = false;
            player.GetComponent<SpriteRenderer>().flipX = true;
            player.GetComponent<Collider2D>().isTrigger = true;
            Instantiate(Ball, new Vector3(-32.957F, -26.369F, -3), Ball.transform.rotation);
        }
    }

    public void endControll()
    {
        ekey.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerAction>().enabled = true;
        player.GetComponent<ChangeUser>().enabled = true;
        player.GetComponent<Collider2D>().isTrigger = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
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
        }
    }
}
