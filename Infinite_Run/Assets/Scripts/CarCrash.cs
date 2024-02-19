using UnityEngine;

public class CarCrash : MonoBehaviour
{
    //Arabalarin tam bariyer kuplerin icinden gecmesini engelleyen kod
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Barrier" || other.gameObject.name == "BarrierCoin")
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.name == "HighPlatform" || other.gameObject.name == "HighPlatformCoin")
        {
            gameObject.SetActive(false);
        }
    }
}
