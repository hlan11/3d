using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    [SerializeField] private Animator anim;
    public bool isAttacking = false;
    [Header("Spherecast")]
    [SerializeField] private float sphereRadius;
    [SerializeField] private float maxDistance;
    private Vector3 origin;
    private Vector3 direction;
    public LayerMask enemyLayer;
    public GameObject currentHitObject;
    private float currentHitDistance;

    private Health playerHealth;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin+direction*currentHitDistance,sphereRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Debug.Log("=========Enemy Ahead=============");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("---------------Attack Enemy-------------");
                isAttacking = true;
                OnAttack();
            }
        }
    }
    public void OnAttack()
    {
        if (_enemyHealth != null && isAttacking)
        {
            Debug.Log("-------------Attack Enemies======================");
            _enemyHealth.TakeDamage(10);
        }
    }
    public void TakeDamageEvent()
    {
            // Lưu trữ vị trí và hướng của đối tượng
            origin = transform.position;
            direction = transform.forward;

            RaycastHit hit;

            // Sử dụng SphereCast để kiểm tra va chạm
            if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, enemyLayer, QueryTriggerInteraction.Collide))
            {
                Debug.Log("Attack enemy");

                // Lưu trữ thông tin về đối tượng bị trúng
                currentHitObject = hit.transform.gameObject;
                currentHitDistance = hit.distance;

                // Kiểm tra nếu playerHealth không phải là null trước khi gọi TakeDamage
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10);
                }
                else
                {
                    Debug.LogWarning("Player health is not set!");
                }
            }
            else
            {
                // Nếu không có va chạm, reset thông tin về đối tượng trúng và khoảng cách
                currentHitObject = null;
                currentHitDistance = maxDistance;
        }
        //origin = transform.position;
        //direction = transform.forward;
        //RaycastHit hit;
        //if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, enemyLayer, QueryTriggerInteraction.Collide))
        //{
        //    Debug.Log("Attack enemy");
        //    currentHitObject = hit.transform.gameObject;
        //    currentHitDistance = hit.distance;
        //    playerHealth.TakeDamage(10);
        //}
        //else
        //{
        //    currentHitDistance = maxDistance;
        //    currentHitObject = null;
        //}
    }
}
