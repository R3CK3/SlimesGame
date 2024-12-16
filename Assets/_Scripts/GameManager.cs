using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText, PlortsText;
    public Image[] Slimes; 
    public static GameManager gameManager;
    public int plorts = 0, coins = 0;

    void Awake()
    {
        if (GameManager.gameManager != null && GameManager.gameManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.gameManager  = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlortCollected()
    {
        plorts++;
        PlortsText.text = plorts.ToString();
    }

    public void CoinCollected(int i)
    {
        coins = coins+i;
        CoinText.text = coins.ToString();
    }

    public void SlimeCollected(Sprite sprite, int id)
    {
        Slimes[id].sprite = sprite;
    }
}
