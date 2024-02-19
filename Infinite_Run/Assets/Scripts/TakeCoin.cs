using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    //coin alinmasi ve skorun artmasi icin kullanilan kod
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            Score.score += 100;
            other.gameObject.SetActive(false);
        }
    }
}
