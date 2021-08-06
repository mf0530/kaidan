using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public float gravity;
    public bool nonVisibleAct;
    public EnemyCollisionCheck checkCollision;

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (sr.isVisible || nonVisibleAct)
        {
            if (checkCollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }
            int xVector = 1;
            if (rightTleftF)
            {
                xVector = -1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            rb.Sleep();
        }
    }
}
