using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float sensitivityX;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float mouseX = Input.GetAxis("MouseX");
            transform.Rotate(Vector3.up * mouseX * sensitivityX, Space.Self);
        }
    }
}
