using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionController : MonoBehaviour
{
    public PlayerAction playerAction;
    public EnemyController Enm;
    bool invision=false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(invision && playerAction.getisfind() == true)
        {
            playerAction.dauhang();
            Enm.Find();
            Invoke("reload",1f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            invision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            invision = false;
        }
    }

    void reload()
    {
        playerAction.reload();
        Enm.reload();
    }
}
