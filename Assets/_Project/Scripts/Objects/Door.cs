using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioSource _Sound;
    [SerializeField] private AudioClip _winSound;

    private Animator _animation;

    public void Start()
    {
        _animation = GetComponentInChildren<Animator>();
    }

    public void OpenDoor()
    {
        _Sound.PlayOneShot(_winSound);
        _animation.SetBool("Open", true);
    }
}
