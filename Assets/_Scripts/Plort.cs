using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plort : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        GameManager.gameManager.PlortCollected();
        Destroy(gameObject);
    }
}
