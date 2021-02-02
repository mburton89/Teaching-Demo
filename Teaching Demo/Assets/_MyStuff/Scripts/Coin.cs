using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    public override void GetCollected()
    {
        print("COIN COLLECTED");
        CoinManager.Instance.IncrementCollectedCoinCount();
    }

    // Start is called before the first frame update
    void Start()
    {
        print("hello");
    }
}
