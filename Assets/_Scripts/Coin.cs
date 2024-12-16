using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        GameManager.gameManager.CoinCollected(25);
        Destroy(gameObject);
    }
}
