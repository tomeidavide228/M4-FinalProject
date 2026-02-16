using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [Header("Trap Damage Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _damageInterval = 1f;

    private float timer = 0f;
    private LifeController _player;

    private void OnCollisionEnter(Collision collided)
    {

        if (collided.gameObject.CompareTag("Player"))
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LifeController>();
            if (_player != null)
            {
                _player.TakeDamage(_damage);
                timer = 0f;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_player == null) return;

        timer += Time.deltaTime;

        if (timer >= _damageInterval)
        {
            _player.TakeDamage(_damage);
            timer = 0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<LifeController>() != null)
        {
            _player = null;
            timer = 0f;
        }
    }
}