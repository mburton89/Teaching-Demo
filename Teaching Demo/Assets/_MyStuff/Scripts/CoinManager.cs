﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    private int _totalCoins;
    private int _collectedCoins;

    public TextMeshProUGUI coinCount;

    private void Awake()
    {
        Instance = this;
        //TODO Get _totalCoins amount
        _totalCoins = FindObjectsOfType<Coin>().Length;
        DisplayCoinCount();
    }

    void DisplayCoinCount()
    {
        coinCount.SetText(_collectedCoins + " / " + _totalCoins);
    }

    public void IncrementCollectedCoinCount()
    {
        _collectedCoins++;
        DisplayCoinCount();

        if (_collectedCoins >= _totalCoins)
        {
            YouWinMenu.Instance.Show();
        }
    }
}