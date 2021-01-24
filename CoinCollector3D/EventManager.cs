using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void CoinCollectedAction(string coin_name, int coin_value);
    public static event CoinCollectedAction OnCoinCollected;

    // Start is called before the first frame update

    public static void FireCoinCollected(string coin_name, int coin_value)
    {
        if (OnCoinCollected != null)
        {
            OnCoinCollected(coin_name, coin_value);
        }
    }
}
