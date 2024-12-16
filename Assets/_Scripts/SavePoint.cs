using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Coge la posición del player cuando hace colisión
        LoadPlayerPosition(new Vector3(other.GetComponent<Transform>().position.x,other.GetComponent<Transform>().position.y,other.GetComponent<Transform>().position.z), Quaternion.Euler(new Vector3(other.GetComponent<Transform>().rotation.x, other.GetComponent<Transform>().rotation.y, other.GetComponent<Transform>().rotation.z)));
    }
   
   public void LoadPlayerPosition(Vector3 P, Quaternion Q)
    {
        //Define la posición en el playerPos
        PlayerPrefs.SetFloat("playerPosX", P.x);
        PlayerPrefs.SetFloat("playerPosY", P.y);
        PlayerPrefs.SetFloat("playerPosZ", P.z);
        //Define la posición en el playerRot
        PlayerPrefs.SetFloat("playerRotX", Q.x);
        PlayerPrefs.SetFloat("playerRotY", Q.y);
        PlayerPrefs.SetFloat("playerRotZ", Q.z);
        Debug.Log("Posicion Gurldala");
    }
}
