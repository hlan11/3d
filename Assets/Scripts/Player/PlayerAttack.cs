using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    [SerializeField] private Animator anim;
    public bool isAttacking = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("=========Enemy Ahead=============");
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
            _enemyHealth.TakeDamage(10);
        }
    }
    public void TakeDamageEvent()
    {
        Debug.Log("Trigger Event");
    }
}
