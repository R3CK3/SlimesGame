using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : MonoBehaviour
{
    public int ID;
    public bool restored;
    private void Awake()
    {
        if(restored)
                CoinRestore();
        else    
        {
        if (PlayerPrefs.HasKey("Coin" + ID) && PlayerPrefs.GetInt("Coin" + ID) == 1)
        {
            LoadCoin();
        }
        }

    }
    private void OnTriggerEnter(Collider other)
   {
        PlayerPrefs.SetInt("Coin" + ID, 1);
   }
   public void CoinRestore()
   {
        PlayerPrefs.SetInt("Coin" + ID, 0);
   }
   public void LoadCoin()
   {
        GameManager.gameManager.CoinCollected(25);
        gameObject.SetActive(false);
   }
}
