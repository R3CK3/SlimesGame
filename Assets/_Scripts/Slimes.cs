using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimes : MonoBehaviour, ICollectable
{
    public int ID;
    public Sprite Sprite;
    public void Collect()
    {
        GameManager.gameManager.SlimeCollected(Sprite, ID);
        Destroy(gameObject);
    }
}
