using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    [Header("Coin Numer Settings")]
    [SerializeField] private int _coinNumber = 0;

    [Header("Events Settings")]
    [SerializeField] private UnityEvent<int> _onCoinChanged;
    [SerializeField] private UnityEvent _onDoorOpen;

    [Header("Sound Settings")]
    [SerializeField] private AudioSource _Sound;
    [SerializeField] private AudioClip _coinSound;

    private bool _doorOpened = false;

    private void OnTriggerEnter(Collider coin)
    {
        if (coin.transform.tag == "Coin Point")
        {
            _coinNumber++;
            _onCoinChanged.Invoke(_coinNumber);
            _Sound.PlayOneShot(_coinSound);
            Debug.Log("Coin Collected");
            Destroy(coin.gameObject);
        }
        if (coin.transform.tag == "Large Coin Point")
        {
            _coinNumber += 10;
            _onCoinChanged.Invoke(_coinNumber);
            _Sound.PlayOneShot(_coinSound);
            Debug.Log("Large Coin Collected");
            Destroy(coin.gameObject);
        }
        if (coin.transform.tag == "Coin Time")
        {
            Timer timer = FindObjectOfType<Timer>();
            timer.AddTime(5f);
            _Sound.PlayOneShot(_coinSound);
            Debug.Log("Time Coin Collected");
            Destroy(coin.gameObject);
        }
        if (coin.transform.tag == "Coin Heal")
        {
            LifeController timer = FindObjectOfType<LifeController>();
            timer.AddHP(10);
            _Sound.PlayOneShot(_coinSound);
            Debug.Log("Heal Coin Collected");
            Destroy(coin.gameObject);
        }
        if ((_coinNumber >= 100) && (_doorOpened == false))
        {
            _doorOpened = true;
            _onDoorOpen.Invoke();
        }
    }
}
