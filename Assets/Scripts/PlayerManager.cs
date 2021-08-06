using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer = default;

    private float xSpeed;
    private float xScale;
    private float jumpPower = 900f;
    private float time;
    private bool pressJump = false;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 vector;

    private bool pressP = false;
    private bool isJump = false;



    private void Start()
    {
        rb       = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        xSpeed = Input.GetAxisRaw("Horizontal");
        xScale = Mathf.Sign(transform.localScale.x);

        //Debug.DrawLine(transform.position - (transform.right * 0.18f * xScale) - transform.up * 1.85f, transform.position - (transform.right * 0.18f * xScale) - transform.up * 1.95f, Color.red);

        // ジャンプ判定
        if (Input.GetKeyDown("space")) {
            pressJump = true;
        } else if (Input.GetKeyUp("space")) {
            pressJump = false;
        }

        // アニメーション遷移
        animator.SetFloat("Speed", Mathf.Abs(xSpeed));
        if (HitGround() && animator.GetBool("Jump")) {
            animator.SetBool("Jump", false);
        } else if (!HitGround() && !animator.GetBool("Jump")) {
            animator.SetBool("Jump", true);
        }

        // デバッグ用　オートジャンプ
        if (Input.GetKeyDown(KeyCode.P)) {
            StartCoroutine("AutoJump");
        }

        // デバッグ用　のけぞり
        if (Input.GetKeyDown(KeyCode.U)) {
            animator.SetTrigger("Miss");
        }
    }

    private void FixedUpdate()
    {
        // プレイヤーの向き
        if (xSpeed != 0) {
            transform.localScale = new Vector2(xSpeed * 1.25f, 1.25f);
        }

        // ジャンプ処理
        if (pressJump && HitGround()) {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
            pressJump = false;
        }

        // 移動処理
        vector.x = xSpeed * 5f;
        vector.y = rb.velocity.y;

        if (pressP && HitGround()) {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
        } else if (pressP && !HitGround()) {
            pressP = false;
            isJump = true;
        }

        if (isJump && HitGround()) {
            xSpeed = 0f;
            isJump = false;
        } else if (isJump) {
            xSpeed = Mathf.Sign(transform.localScale.x);
            vector.x = xSpeed * 9.4f;
        }

        // 移動処理
        rb.velocity = vector;
    }

    private bool HitGround()
    {
        return Physics2D.Linecast(transform.position - (transform.right * 0.18f * xScale) - transform.up * 1.85f, transform.position - (transform.right * 0.18f * xScale) - transform.up * 1.95f, groundLayer);
    }

    IEnumerator AutoJump()
    {
        time = 0.70588235294f;
        for (int i = 0; i < 4; i++) {
            pressP = true;
            if (i == 3) {
                time = 0.35f;
                yield return new WaitForSeconds(time);

                transform.localScale = new Vector2(transform.localScale.x * -1f, 1.25f);
                time = 0.70588235294f - 0.35f;
            }
            yield return new WaitForSeconds(time);
        }

        time = 0.70588235294f;
        for (int i = 0; i < 4; i++) {
            pressP = true;
            if (i == 3) {
                time = 0.35f;
                yield return new WaitForSeconds(time);

                transform.localScale = new Vector2(transform.localScale.x * -1f, 1.25f);
                time = 0.70588235294f - 0.35f;
            }
            yield return new WaitForSeconds(time);
        }

        time = 0.70588235294f;
        for (int i = 0; i < 4; i++) {
            pressP = true;
            if (i == 3) {
                time = 0.35f;
                yield return new WaitForSeconds(time);

                transform.localScale = new Vector2(transform.localScale.x * -1f, 1.25f);
                time = 0.70588235294f - 0.35f;
            }
            yield return new WaitForSeconds(time);
        }

        time = 0.70588235294f;
        for (int i = 0; i < 4; i++) {
            pressP = true;
            if (i == 3) {
                time = 0.35f;
                yield return new WaitForSeconds(time);

                transform.localScale = new Vector2(transform.localScale.x * -1f, 1.25f);
                time = 0.70588235294f - 0.35f;
            }
            yield return new WaitForSeconds(time);
        }

        time = 0.70588235294f;
        for (int i = 0; i < 4; i++) {
            pressP = true;
            if (i == 3) {
                time = 0.35f;
                yield return new WaitForSeconds(time);

                transform.localScale = new Vector2(transform.localScale.x * -1f, 1.25f);
                time = 0.70588235294f - 0.35f;
            }
            yield return new WaitForSeconds(time);
        }

    }
}
