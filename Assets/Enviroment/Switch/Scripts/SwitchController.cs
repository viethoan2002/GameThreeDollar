using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    Animator Anm;
    public GameObject enviroment;

    GameObject player;
    GameObject dog;
    bool swicth = false;
    public bool reverswitch;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dog = GameObject.FindWithTag("Dog");
        Anm = GetComponent<Animator>();
        //kiểm tra cần gạt đã được gạt hay chưa
        if (reverswitch)
        {
            Anm.SetTrigger("switch");
        }
    }

    // Update is called once per frame
    void Update()
    {
        swicthaction();
    }

    void swicthaction()
    {
        float distance_player = Vector2.Distance(transform.position, player.transform.position);
        float distance_dog = Vector2.Distance(transform.position, dog.transform.position);

        if (distance_player < 0.8f && player.GetComponent<PlayerController>().enabled) // kiểm tra ngươi chơi có đang ở gần và active
        {
            swicth = true;
        }
        else
        {
            if (distance_dog < 0.8f && dog.GetComponent<DogController>().enabled) // kiểm tra chó có đang ở gần và active
            {
                swicth = true;
            }
            else
            {
                swicth = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && swicth)
        {
            flipswitch();
        }
    }

    void flipswitch()
    {
        if (!reverswitch)
        {
            Anm.SetTrigger("switch");
            enviroment.GetComponent<ConveyorController>().speed = 1;
            reverswitch = true;
        }
        else
        {
            Anm.SetTrigger("switchrever");
            enviroment.GetComponent<ConveyorController>().speed = -1;
            reverswitch = false;
        }
    }
}
