using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float sensitivityX;
    [SerializeField] private Transform cameraRo;
    [SerializeField] private Vector3 offset;
    public float anglePerSecond;
    public float minPitch;
    public float maxPitch;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void updateYaw()
    {
        float mouseX = Input.GetAxis("MouseX");
        float yaw = mouseX * anglePerSecond;
        transform.Rotate(0, yaw, 0);
    }
    void updatePitch()
    {
        float mouseY = Input.GetAxis("MouseY");
        float pitch = mouseY * anglePerSecond;
        transform.Rotate(pitch, 0, 0);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            updateYaw();
            updatePitch();
        }
        rotateFollowCamera();
    }
    void rotateFollowCamera()
    {
        transform.position = cameraRo.position + offset;
    }
}
