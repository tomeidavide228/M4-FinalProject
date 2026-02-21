using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, -5);
    [SerializeField] private float _sensitivity = 3;
    [SerializeField] private float _bottomClamp = -30f;
    [SerializeField] private float _topClamp = 60f;

    private float _yaw;
    private float _pitch;

    private void Start()
    {
        if (_target == null)
        {
            _target = GameObject.FindWithTag("PlayerHead");
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (MenuState.IsMenuShowing == false)
        {
            _yaw += Input.GetAxis("Mouse X") * _sensitivity;
            _pitch -= Input.GetAxis("Mouse Y") * _sensitivity;
            _pitch = Mathf.Clamp(_pitch, _bottomClamp, _topClamp);

            Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
            Vector3 desiredPosition = _target.transform.position + rotation * _offset;

            Vector3 lookAt = _target.transform.position + Vector3.up * 2;
            Quaternion lookRotation = Quaternion.LookRotation(lookAt - desiredPosition);
            transform.SetPositionAndRotation(desiredPosition, lookRotation);
        }

    }
}