using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    //coinin donmesi icin kullanilan kod
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 10);
    }
}
