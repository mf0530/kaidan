using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSE : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSource;

    private string playerTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}
