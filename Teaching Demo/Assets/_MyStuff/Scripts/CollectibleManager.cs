using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    private int _totalCoins;
    private int _collectedCoins;

    public TextMeshProUGUI coinCount;

    public string winPhrase;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
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
            YouWinMenu.Instance.Show(winPhrase);
        }

        //SoundManager.Instance.PlayCoinCollectSound();
    }
}
