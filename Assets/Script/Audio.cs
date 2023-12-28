using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audio;

    private bool isMusicStart;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isMusicStart)
        {
            if (other.tag == "Note")
            {
                audio.Play();
                isMusicStart = true;
            }
        }
    }
}
