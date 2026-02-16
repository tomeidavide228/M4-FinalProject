using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    [Header("Respawn Point Settings")]
    [SerializeField] private Transform _respawnPoint;

    private LifeController _player;

    private void OnTriggerEnter(Collider collided)
    {
        if (collided.CompareTag("Player"))
        {
            Rigidbody rb = collided.GetComponent<Rigidbody>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LifeController>();
            if (_player != null)
            {
                _player.TakeDamage(10);
            }

            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
            collided.transform.position = _respawnPoint.position;
        }
    }
}

