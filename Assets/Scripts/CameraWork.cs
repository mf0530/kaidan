using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //横方向だけ追従
        transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
    }
}