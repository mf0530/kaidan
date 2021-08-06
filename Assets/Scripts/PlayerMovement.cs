using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour {
 
    Rigidbody2D rb;
 
    public float jumpForce = 390.0f;       // ジャンプ時に加える力
    public float jumpThreshold = 2.0f;    // ジャンプ中か判定するための閾値
    public float runForce = 3.0f;       // 走り始めに加える力
    public float runSpeed = 3f;       // 走っている間の速度
    public float runThreshold = 2.0f;   // 速度切り替え判定のための閾値
    bool isGround = true;        // 地面と接地しているか管理するフラグ
    int key = 0;                 // 左右の入力管理
 
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        GetInputKey();          // 入力を取得
        Move();                 // 入力に応じて移動する
    }
 
    void GetInputKey()
    {
        key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;
    }
 
    void Move()
    {
        // 接地している時にSpaceキー押下でジャンプ
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rb.AddForce(transform.up * this.jumpForce);
                isGround = false;
            }
        }
 
        // 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
        float speedX = Mathf.Abs(this.rb.velocity.x);
        if (speedX < this.runThreshold)
        {
            this.rb.AddForce(transform.right * key * this.runForce); //未入力の場合は key の値が0になるため移動しない
        }
        else
        {
            this.transform.position += new Vector3(runSpeed * Time.deltaTime * key, 0, 0);
        }
 
    }
 
     //着地判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround)
                isGround = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
       {
            if (!isGround)
                isGround = true;
        }
    }
 
}