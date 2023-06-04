using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audio;
    public Transform player;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.position, transform.position);
        audio.volume = 1f - Mathf.Abs(distance) / 10;
    }
}
