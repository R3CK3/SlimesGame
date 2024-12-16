using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Bro no te salgas porfa. Te juro que el jueguito esta bueno.");
    }
}
