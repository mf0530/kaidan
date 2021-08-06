using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    private string playerTag = "Player";

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("GameScene");
        }
    }
}
