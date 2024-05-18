using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveByKey1 : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField]private float movingSpeed;
    [SerializeField] private Animator anim;
    private Vector3 targetPos;
    private void Start()
    {
        targetPos = transform.position;
    }
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        characterController.SimpleMove(direction * movingSpeed);
        CheckAnimation();
        if (Input.GetAxisRaw("Horizontal") < 0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        if (Input.GetAxisRaw("Vertical") < 0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            anim.SetBool("isWalking", false);
        }
    }
    void CheckAnimation()
    {
        bool Attack = Input.GetMouseButtonDown(0);
        bool isScrolling = Input.GetKeyDown(KeyCode.Space);
        if (Attack)
        {
            anim.SetBool("isAttacking", true);
        }
        if (!Attack)
        {
            anim.SetBool("isAttacking", false);
        }
        if (isScrolling)
        {
            anim.SetBool("isRolling", true);
        }
        if(!isScrolling)
        {
            anim.SetBool("isRolling", false);
        }
    }
}
