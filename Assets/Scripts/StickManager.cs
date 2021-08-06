using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    [SerializeField] Sprite stickBig = default;

    //deathTime * speed = 6000f
    private float speed;
    private float totalTime = 0f;
    private float deathTime = 120f / 170f * 2500f;

    private float startTime;
    private float endTime;
    private float successTime;
    private float perfectSTime;
    private float perfectETime;

    private Vector2 vector;
    private Rigidbody2D rb;
    private SpriteRenderer sprRend;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();

        speed = 6000f / deathTime;
        startTime = deathTime * 0.65f;
        endTime = deathTime * 0.9f;

        successTime = deathTime * 0.7f;
        perfectSTime = deathTime * 0.76f;
        perfectETime = deathTime * 0.84f;
    }

    private void Update()
    {
        totalTime += Time.deltaTime * 1000;

        if (totalTime >= endTime) {
            Destroy(gameObject);
        } else if (totalTime >= successTime) {
            sprRend.sprite = stickBig;
        }

        if (totalTime >= endTime) {
            Debug.Log("MISS");
        } else if (totalTime >= successTime) {
            sprRend.sprite = stickBig;
        }
        if (totalTime >= perfectSTime && totalTime <= perfectETime) {
            Debug.Log("NICE!!");
        } else if (totalTime >= successTime) {
            Debug.Log("OK");
        } else if (totalTime >= startTime) {
            Debug.Log("MISS");
        } else {
            return;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vector.x = -speed;
        rb.velocity = vector;
    }
}
