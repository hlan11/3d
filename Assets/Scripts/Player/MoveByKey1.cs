using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveByKey1 : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField]private float movingSpeed;
    [SerializeField] private Animator anim;
    private Vector3 playerPos;
    private void Start()
    {
        playerPos = transform.position;
        Debug.Log("new position = "+ playerPos);
    }
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        characterController.SimpleMove(direction * movingSpeed);
        CheckAnimation();
        savePosition();
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
    void savePosition()
    {
        playerPos=transform.position;
        bool isWalking = transform.position.x != playerPos.x || transform.position.z != playerPos.z;
        anim.SetBool("isWalking", isWalking);
        Debug.Log("Saved Position = "+playerPos);
    }
}
