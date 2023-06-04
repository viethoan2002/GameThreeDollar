using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiCarController : MonoBehaviour
{
    Animator Anm;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*Time.deltaTime);
        if (transform.position.x > 64)
        {
            SceneManager.LoadScene("SceneMenu");
        }
    }

    public void getCar()
    {
        Anm.SetBool("get", true);
        Invoke("go", 1f);
    }

    private void go()
    {
        Anm.SetBool("run", true);
        direction = new Vector2(4f, 0);
    }
}
