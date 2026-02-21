using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private int _currentHP = 100;
    [SerializeField] private int _maxHP = 100;

    [Header("UI Settings")]
    [SerializeField] private UnityEvent<int, int> _onHPChanged;
    [SerializeField] private UnityEvent _onDefeated;

    [Header("Sound Settings")]
    [SerializeField] private AudioManager _sound;

    private void Start()
    {
        SetHP(_maxHP);
        _sound = FindObjectOfType<AudioManager>();
    }

    public int GetMaxHP() => _maxHP;
    public int GetHP() => _currentHP;

    public void SetHP(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHP);

        if (hp != _currentHP)
        {
            _currentHP = hp;
            _onHPChanged.Invoke(_currentHP, _maxHP);

            if (_currentHP == 0)
            {
                _onDefeated.Invoke();
            }
        }
    }

    public void AddHP(int amount) => SetHP(_currentHP + amount);

    public void TakeDamage(int damage)
    {
        _sound.Damage();
        AddHP(-damage);
    }
}
