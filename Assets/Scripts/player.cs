using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 物理演算をしたい場合はFixedUpdateを使うのが一般的
    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        //右入力で左向きに動く
        if (horizontalKey > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        //左入力で左向きに動く
        else if (horizontalKey < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        //ボタンを話すと止まる
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
