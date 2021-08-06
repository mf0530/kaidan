using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    public bool isOn = false;

    private string wallTag = "Wall";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == wallTag)
        {
            isOn = false;
        }
    }
}