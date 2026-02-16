using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coins : MonoBehaviour
{
    [Header("Coins UI Settings")]
    [SerializeField] private TextMeshProUGUI _coinText;

    private CoinCollector _coinCollector;

    private void Start()
    {
        _coinCollector = FindAnyObjectByType<CoinCollector>();
    }
    public void UpdateGraphics(int coin)
    {
        _coinText.text = "Coin" + "" + coin;
    }
}