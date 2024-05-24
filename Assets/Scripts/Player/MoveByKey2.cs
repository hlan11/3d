using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey2 : MonoBehaviour
{
    public float movingSpeed = 5f;   // Tốc độ di chuyển
    public float rotationSpeed = 720f;  // Tốc độ quay của nhân vật
    private Animator anim;
    private CharacterController characterController;
    private Vector3 movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Lấy input từ bàn phím
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Tạo vector di chuyển dựa trên input
        movement = new Vector3(horizontal, 0, vertical).normalized;

        // Cập nhật parameter "Speed" của Animator dựa trên độ lớn của vector movement
        anim.SetFloat("Speed", movement.magnitude);

        // Nếu có di chuyển, thực hiện quay nhân vật theo hướng di chuyển
        if (movement.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        CheckAnimation();
    }

    void FixedUpdate()
    {
        // Di chuyển nhân vật sử dụng CharacterController
        characterController.Move(movement * movingSpeed * Time.fixedDeltaTime);

    }
    void CheckAnimation()
    {
        bool isAttacking = Input.GetMouseButtonDown(0);
        anim.SetBool("isAttacking", isAttacking);
        bool isRolling = Input.GetKeyDown(KeyCode.Space);
        if (isRolling)
        {
            anim.SetBool("isRolling", true);
            anim.SetTrigger("Roll");
        }
        if (!isRolling)
        {
            anim.SetBool("isRolling", false);
        }
    }
}
