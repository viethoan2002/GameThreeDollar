using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomLadder : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    public TopLadder topladder;

    bool isplayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float inputy = Input.GetAxis("Vertical");
        float inputx = Input.GetAxis("Horizontal");
        if (isplayer && inputy != 0)
        {
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
            player.GetComponent<PlayerController>().Climb = true;
        }
        if (isplayer && inputx != 0)
        {
            player.GetComponent<PlayerController>().Climb = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = true;
        }

        topladder.setclimp();
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isplayer = false;
        }
    }
}
