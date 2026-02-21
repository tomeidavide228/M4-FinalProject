using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float _time = 300f;

    [Header("Unity Events Settings")]
    [SerializeField] private UnityEvent<float, float> _onTimerChanged;
    [SerializeField] private UnityEvent _onTimerEnd;

    void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else
        {
            _time = 0;
            _onTimerEnd.Invoke();
        }
        int minutes = Mathf.FloorToInt(_time / 60);
        int seconds = Mathf.FloorToInt(_time % 60);
        _onTimerChanged.Invoke(minutes, seconds);
    }
    public void AddTime(float amount)
    {
        _time += amount;
    }
}
