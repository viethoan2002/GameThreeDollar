using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Dog;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Player.transform.position.y >= -6)
        {
            camera1();
        }
        if (Player.transform.position.y <= -19 && Player.transform.position.y >= -45)
        {
            if (Player.transform.position.x >= -49.7 && Player.transform.position.x <= -32.3)
            {
                camera2();
            }
            if (Player.transform.position.x >= 5)
            {
                if (Player.GetComponent<PlayerController>().enabled == true)
                {
                    camera3(Player.transform.position);
                }
                else
                { 
                    camera3(new Vector3(Dog.transform.position.x, Dog.transform.position.y + 0.33431f, Dog.transform.position.z));
                }

            }
        }


    }
    void camera1()
    {
        if (Player.transform.position.x >= -36 && Player.transform.position.x <= 45.8)
        {
            transform.position = new Vector3(Player.transform.position.x, 2.31f, transform.position.z);
        }
        else
        {
            if (Player.transform.position.x < -36)
            {
                transform.position = new Vector3(-36, 2.31f, transform.position.z);
            }
            if (Player.transform.position.x > 45.8)
            {
                transform.position = new Vector3(45.8f, 2.31f, transform.position.z);
            }
        }

    }
    void camera2()
    {
        transform.position = new Vector3(-40.9f, -24, transform.position.z);
    }
    void camera3(Vector3 trans)
    {
        if (trans.x >= 21.06 && trans.x <= 67)
        {
            transform.position = new Vector3(trans.x, trans.y, transform.position.z);
        }
        if (trans.x < 21.06)
        {
            transform.position = new Vector3(21.06f, trans.y, transform.position.z);
        }
        if (trans.x > 67)
        {
            transform.position = new Vector3(67f, trans.y, transform.position.z);
        }
    }
}
