using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ChangeUser : MonoBehaviour
{
    GameObject Dog;
    Animator Anm;
    public GameObject Point;

    // Start is called before the first frame update
    void Start()
    {
        Dog = GameObject.FindWithTag("Dog");
        Anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeToDog();
    }
    void ChangeToDog()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Dog.GetComponent<DogController>().enabled = true;
            Dog.GetComponent<DogMove>().enabled = false;
            Dog.GetComponent<ChangePlayer>().enabled = true;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerAction>().enabled = false;
            GetComponent<ChangeUser>().enabled = false;
            Anm.SetFloat("velocity_X", 0);
            Point.SetActive(false);
        }
    }
}
