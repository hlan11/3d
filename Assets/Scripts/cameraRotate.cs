using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    [SerializeField] private float sensitivityX;
    [SerializeField]private float sensitivityY;
    [SerializeField] private Transform playerPos;
    [SerializeField]private Vector3 offset;
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.left * mouseY * sensitivityY, Space.World);
            transform.Rotate(Vector3.up * mouseX * sensitivityX, Space.Self);
        }
        followPlayer();
    }
    void followPlayer()
    {
        transform.position = playerPos.position + offset;
    }
}
