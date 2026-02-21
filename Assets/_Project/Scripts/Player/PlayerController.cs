using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _rotationSpeed = 500f;

    [Header("Ground Settings")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.2f;
    [SerializeField] private UnityEvent<bool> _onIsGrounded;

    [Header("Camera")]
    [SerializeField] private Camera _mainCamera;

    [Header("Sound Settings")]
    [SerializeField] private AudioManager _sound;

    private Rigidbody _rb;
    private Vector3 _direction;
    private float _h;
    private float _v;
    private Vector3 _moveDirection;
    private bool _isGrounded;
    private PlayerAnimation _animation;

    private void Awake()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
        _animation = GetComponent<PlayerAnimation>();
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _sound = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        bool wasGrounded = _isGrounded;
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayer);
        if (wasGrounded != _isGrounded)
        {
            _onIsGrounded?.Invoke(_isGrounded);
        }

        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        _direction = new Vector3(_h, 0f, _v).normalized;
        float sqrtLength = _direction.sqrMagnitude;
        if (sqrtLength > 1)
        {
            _direction /= Mathf.Sqrt(sqrtLength);
        }
        _moveDirection = Vector3.zero;
        _moveDirection.x = _direction.x;
        _moveDirection.z = _direction.z;

        if (_moveDirection.sqrMagnitude > 0)
        {
            _moveDirection = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_direction.x, 0.0f, _direction.z);
            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        Vector3 velocity = _moveDirection * _speed;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }

    private void Jump()
    {
        _sound.Jump();
        _rb.AddForce(Vector3.up * Mathf.Sqrt(_jumpForce * -2f * Physics.gravity.y), ForceMode.Impulse);
        _animation.OnJump();
    }
}