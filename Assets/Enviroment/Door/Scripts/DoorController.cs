using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator Anm;
    public Transform DoorOut;
    public GameObject player;
    public GameObject dog;

    public bool log;
    public bool open = false;
    bool change = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anm = GetComponent<Animator>();
        Anm.SetBool("log", log);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && open && change)
        {
            Anm.SetBool("log", false);
            Invoke("openDoor", 1);
        }
        if (dog != null)
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && change && !log)
            {
                player.transform.position = new Vector3(DoorOut.position.x - 0.32f, DoorOut.position.y - 0.56f, player.transform.position.z);
                dog.transform.position = new Vector3(DoorOut.position.x + 0.25f, DoorOut.position.y - 0.8f, dog.transform.position.z);
            }
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && change && !log)
            {
                player.transform.position = new Vector3(DoorOut.position.x - 0.32f, DoorOut.position.y - 0.56f, player.transform.position.z);
            }
        }
        
    }

    void openDoor()
    {
        log = false;
        open = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            change = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        change = false;
    }
}
