using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveInput : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float addSpeed;
    [SerializeField] private float multiplier = 2f;
    private bool isJumping;
    private bool isOnGround;
    [SerializeField] private float turnSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        SimpleMove();
        CheckAnimation();
        attack();
        checkDie();
    }
    void SimpleMove()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
    }
    void attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }
    void checkDie()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Die");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
             isOnGround = true;
        }
        else
        {
             isOnGround = false;
        }
    }
    void CheckAnimation()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("MoveBack");
        }
    }
    void TurnCharacter()
    {
        var horizontal = Input.GetAxis("Horizontal");
        float turn = horizontal * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
