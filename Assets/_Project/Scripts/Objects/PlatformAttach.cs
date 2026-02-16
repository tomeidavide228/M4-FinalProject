using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    [Header("Platform Settings")]
    [SerializeField] GameObject _target;

    private void Start()
    {
        if (_target == null)
        {
            _target = GameObject.FindWithTag("Player");
        }
    }

    private void OnTriggerEnter(Collider collided)
    {
        collided.transform.parent = transform;
    }
    private void OnTriggerExit(Collider collided)
    {
        collided.transform.parent = null;
    }
}
