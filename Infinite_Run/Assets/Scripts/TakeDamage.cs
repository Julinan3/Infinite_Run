using System.Collections;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    //hasar almak icin kullanilan kod
    public GameObject colorObject1, colorObject2;
    public static bool unToachable = false;
    public static int heal = 3;
    private void Awake()
    {
        unToachable = false;
        heal = 3;
    }
    private void FixedUpdate()
    {
        //hasar alindiginda karakterin dokunulmaz oldugunu belirtmek icin kullanilan kisim
        if(unToachable)
        {
            colorObject1.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            colorObject2.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        }
        else
        {
            colorObject1.GetComponent<Renderer>().material.color = Color.white;
            colorObject2.GetComponent<Renderer>().material.color = Color.white;
        }
        //can 0 oldugunda karakterin olmesi icin kullanilan kisim
        if(heal <= 0)
        {
            Death.isDead = true;
        }
    }
    //engele carpildiginda hasar almak icin kullanilan kisim
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !unToachable)
        {
            heal--;
            if(heal > 0)
            {
                StartCoroutine(UnToachable());
            }
        }
    }
    //karakterin dokunulmaz olmasi icin kullanilan kisim
    IEnumerator UnToachable()
    {
        unToachable = true;
        yield return new WaitForSeconds(2.5f);
        unToachable = false;
    }
}
