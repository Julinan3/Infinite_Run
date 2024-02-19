using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //mevcut platformun sonuna gelindiginde konumunun yeniden ayarlanmasi icin kullanilan kisim
        if (other.gameObject.name == "Road")
        {
            other.gameObject.transform.position = new Vector3(0f,0f,30f);
        }
        //oyuncunun geride biraktigi engellerin aktifliginin kapatilmasi icin kullanilan kisim
        else
        {
            other.gameObject.SetActive(false);
        }
    }
}
