using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Health :  MonoBehaviour
{
    [SerializeField] private UnityEvent onDie;
    public UnityEvent<int, int> OnHealthChanged;
    public int maxHP;
    private int _healthpoint;

    public int HealthPoint
    {
        get => _healthpoint;
        set
        {
            _healthpoint = value;
            OnHealthChanged.Invoke(_healthpoint, maxHP);
        }
    }
    private bool isDead=> _healthpoint <= 0;
    protected virtual void Start()
    {
        _healthpoint = maxHP;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            _healthpoint -= 10;
        }
    }
}
