using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _damageSound;
    [SerializeField] private AudioClip _winSound;

    public void Coin()
    {
        _sound.PlayOneShot(_coinSound);
    }

    public void Jump()
    {
        _sound.PlayOneShot(_jumpSound);
    }

    public void Damage()
    {
        _sound.PlayOneShot(_damageSound);
    }
    public void Win()
    {
        _sound.PlayOneShot(_winSound);
    }
}
