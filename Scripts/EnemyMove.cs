using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time % 2 == 0)
        {
            Move();
        }
    }

    void Move()
    {
        //“G‚ð2ƒ}ƒXˆÚ“®
    }
}
