using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioSource _Sound;
    [SerializeField] private AudioClip _winSound;

    [Header("Sound Settings")]
    [SerializeField] private AudioManager _sound;

    private Animator _animation;

    public void Start()
    {
        _animation = GetComponentInChildren<Animator>();
        _sound = FindObjectOfType<AudioManager>();
    }

    public void OpenDoor()
    {
        _sound.Win();
        _animation.SetBool("Open", true);
    }
}
