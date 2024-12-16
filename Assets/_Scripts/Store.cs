using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public ItemScriptableObject Item1, Item2;
    public Image Image1, Image2;
    public TextMeshProUGUI textItem1, textItem2;
    public Button Buy1, Buy2;
    // Start is called before the first frame update
    void OnEnable()
    {
        Image1.sprite = Item1.image;
        Image2.sprite = Item2.image;
        CheckIfCanBuy(Item1, textItem1, Buy1);
        CheckIfCanBuy(Item2, textItem2, Buy2);
    }
    public void BuyItem1()
    {
        GameManager.gameManager.SlimeCollected(Item1.image, 6);
        GameManager.gameManager.CoinCollected(-Item1.price);
        CheckIfCanBuy(Item1, textItem1, Buy1);
        CheckIfCanBuy(Item2, textItem2, Buy2);
    }
    public void BuyItem2()
    {
        GameManager.gameManager.SlimeCollected(Item2.image, 7);
        GameManager.gameManager.CoinCollected(-Item2.price);
        CheckIfCanBuy(Item1, textItem1, Buy1);
        CheckIfCanBuy(Item2, textItem2, Buy2);
    }
    private void CheckIfCanBuy(ItemScriptableObject item, TextMeshProUGUI insuCoins, Button buyButton)
    {
        if (GameManager.gameManager.coins >= item.price)
            {
                insuCoins.text = "" + item.price;
                insuCoins.color = Color.yellow;
                buyButton.interactable = true;
            }
            else
            {
                insuCoins.text = "Insuficient coins:" + item.price;
                insuCoins.color = Color.red;
                buyButton.interactable = false;
            }
    }
}
