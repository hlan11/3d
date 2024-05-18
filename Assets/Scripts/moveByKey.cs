using UnityEngine;
using System.Collections;
using UnityEditor.PackageManager;

public class moveByKey : MonoBehaviour
{
    private LayerMask ground;
    private Vector3 targetPosition;
    [SerializeField] private float speed = 25;
    private bool lookRight = true;
    //private bool lookForward = true;
    //private bool lookAfter = false;
    //private bool lookRight=false;
    //private bool lookLeft = false;
    [SerializeField]private Animator anim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float turnSpeed;


    [SerializeField] private float sensitivityX = 3f;
    void Start()
    {
        targetPosition = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Flip();
        TurnCharacter();
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;

                Debug.Log("Hit point: " + hit.point);
                Debug.Log("------------Target position---------------- " + targetPosition);
            }
            if (Physics.Raycast(ray, out hit, ground))
            {
                anim.SetBool("isWalking", true);
                targetPosition = hit.point + new Vector3(0, 0, -2);
                if (hit.point == targetPosition)
                {
                    Debug.Log("---------------switch animation--------------");
                   // anim.SetBool("isWalking", false);
                }
                //targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
            //if(Random.Range(0f, 1.0f) > 0.5f)
            //    animator.SetTrigger("attack");
            //else
            //    animator.SetTrigger("special");
        }

        //if (targetPosition.x > transform.position.x && !lookRight)
        //    Flip();
        //if (targetPosition.x < transform.position.x && lookRight)
        //    Flip();

        var p = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        Vector3 vel = targetPosition - transform.position;
        vel = Vector3.ClampMagnitude(vel, speed * Time.deltaTime);
        transform.position += vel;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
             anim.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("isWalking", true);
        }

        //anim.SetFloat("speed", (transform.position - p).magnitude / Time.deltaTime);
    }
    public void Flip()
    {
        //var s = transform.localScale;
        //s.x *= -1;
        //transform.localScale = s;
        //lookRight = !lookRight;

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            //float mouseY = Input.GetAxis("Mouse Y");
            //transform.Rotate(Vector3.left * mouseY * sensitivityY, Space.World);
            transform.Rotate(-Vector3.up * mouseX * sensitivityX, Space.Self);
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
