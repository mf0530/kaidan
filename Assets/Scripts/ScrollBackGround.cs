using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScrollBackGround : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = -1;
    Vector3 cameraRectMin;
    void Start()
    {
        //カメラの範囲を取得
        cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);   //X軸方向にスクロール
        //カメラの左端から完全に出たら、右端に瞬間移動
        if(transform.position.y < (cameraRectMin.y - Camera.main.transform.position.y) * 2)
        {
            transform.position = new Vector2(transform.position.x, (Camera.main.transform.position.y - cameraRectMin.y) * 2);
        }
    }
}
