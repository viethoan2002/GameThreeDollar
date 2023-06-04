using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    GameObject player;
    public GameObject Point;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeToPlayer();
    }
    void ChangeToPlayer()
    {
        if (Input.GetMouseButtonUp(1))
        {
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<PlayerAction>().enabled = true;
            player.GetComponent<ChangeUser>().enabled = true;
            GetComponent<DogController>().enabled = false;
            GetComponent<DogMove>().enabled = true;
            GetComponent<ChangePlayer>().enabled = false;
            Point.SetActive(false);
        }
    }
}
