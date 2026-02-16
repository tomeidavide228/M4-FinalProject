using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animations Settings")]
    [SerializeField] private string _forward = "forward";
    [SerializeField] private string _horizontal = "horizontal";
    [SerializeField] private string _vSpeed = "vSpeed";
    [SerializeField] private string _isGrounded = "isGrounded";
    [SerializeField] private string _jump = "jump";

    private Animator _animation;
    private Rigidbody _rb;

    private void Awake()
    {
        _animation = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        _animation.SetFloat(_forward, vertical * 2);
        _animation.SetFloat(_horizontal, horizontal);
        _animation.SetFloat(_vSpeed, _rb.velocity.y);
    }

    public void OnIsGrounded(bool isGrounded)
    {
        _animation.SetBool(_isGrounded, isGrounded);
    }
    public void OnJump()
    {
        _animation.SetTrigger(_jump);
    }

}
