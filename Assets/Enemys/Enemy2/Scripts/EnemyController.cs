using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject vision1, vision2;
    Rigidbody2D rb;
    Animator Anm;
    SpriteRenderer sr;
    Vector2 velocity=new Vector2(1,0);
    float speed;
    float bien = 4f;
    float currentpos;
    bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anm = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        currentpos = transform.position.x;
        if (sr.flipX == false)
        {
            velocity = new Vector2(1, 0);
        }
        else velocity = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.flipX == false)
        {
            vision1.SetActive(true);
            vision2.SetActive(false);
        }
        else
        {
            vision1.SetActive(false);
            vision2.SetActive(true);
        }

        if (transform.position.x > currentpos + bien && sr.flipX == false)
        {
            velocity = Vector2.zero;
            StartCoroutine(wait(-1));
        }
        if (transform.position.x < currentpos - bien && sr.flipX == true)
        {
            velocity = Vector2.zero;
            StartCoroutine(wait(1));
        }
        if(move) transform.Translate(velocity * Time.deltaTime);
        Anm.SetFloat("velocity_x", Mathf.Abs(velocity.x));
    }

    public void Find()
    {
        Anm.SetBool("find", true);
        move = false;
    }

    IEnumerator wait(float x)
    {
        yield return new WaitForSeconds(1f);
        velocity = new Vector2(x, 0);
        if (x == -1)
        {
            sr.flipX = true;
        }
        else  sr.flipX = false;
    }

    public void reload()
    {
        Anm.SetBool("find", false);
        move = true;
    }
}
