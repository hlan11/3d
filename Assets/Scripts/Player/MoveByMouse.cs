using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMouse : MonoBehaviour
{
    private LayerMask ground;
    private Vector3 targetPosition;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator anim;
    [SerializeField] private float movingSpeed;
    private void Start()
    {
        targetPosition = transform.position;
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        playerMove();
        CheckAnimation();
    }
    void playerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                anim.SetBool("isWalking", true);
            }
        }
        var p = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed * Time.deltaTime);

        Vector3 vel = targetPosition - transform.position;
        vel = Vector3.ClampMagnitude(vel, movingSpeed * Time.deltaTime);
        transform.position += vel;
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
            Debug.Log("=========== stop walking");
                anim.SetBool("isWalking", false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("isWalking", true);
            }
    }
    void CheckAnimation()
    {
        bool attack = Input.GetKeyDown(KeyCode.Space);
        if (attack)
        {
            anim.SetBool("isAttacking", true);
        }
        if (!attack)
        {
            anim.SetBool("isAttacking", false);
        }
    }
}
