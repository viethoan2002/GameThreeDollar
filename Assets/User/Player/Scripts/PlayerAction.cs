using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Animator Anm;
    bool isattack = true;
    GameObject Dog;

    public bool isfind = true;

    private void Start()
    {
        Anm = GetComponent<Animator>();
        Dog = GameObject.FindWithTag("Dog");
        StartCoroutine(AttackCtr());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Dog.GetComponent<DogMove>().RuntoPlayer = true;
        }
    }

    IEnumerator AttackCtr()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            isattack = true;
        }
    }

    public void dauhang()
    {
        Anm.SetBool("dauhang", true);
        gameObject.GetComponent<PlayerController>().enabled = false;
        gameObject.GetComponent<ChangeUser>().enabled = false;
    }

    public void reload()
    {
        Anm.SetBool("dauhang", false);
        transform.position = new Vector3(8.2f, -37.40644f, -2);
        gameObject.GetComponent<PlayerController>().enabled = true;
        gameObject.GetComponent<ChangeUser>().enabled = true;
    }

    public void onisfind()
    {
        isfind = true;
        Debug.Log("true");
    }

    public void offisfind()
    {
        isfind = false;
        Debug.Log("false");
    }

    public bool getisfind()
    {
        return isfind;
    }
}
