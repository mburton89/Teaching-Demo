using System.Collections;
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
        _totalCoins = GetNumberOfCoinsInGame();
        UpdateCoinCountDisplay();
    }

    public void UpdateCoinCountDisplay()
    {
        int remainingCoins = GetNumberOfCoinsInGame();
        _collectedCoins = _totalCoins - remainingCoins;
        coinCount.SetText(_collectedCoins + " / " + _totalCoins);

        if (_collectedCoins >= _totalCoins)
        {
            YouWinMenu.Instance.Show();
        }
    }

    private int GetNumberOfCoinsInGame()
    {
        return 0; //TODO Actually get total amount of coins in game
    }
}
