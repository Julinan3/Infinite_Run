using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //oyun alanin ve engellerin hareketi icin kullanilan kod
    private int gameSpeed = 10;
    private int carSpeed = 20;
    private void Awake()
    {
        carSpeed = 20;
        gameSpeed = 10;
    }
    private void Update()
    {
        if (!Death.isDead)
        {
            //oyunun ilerledikce hizinin artmasi icin kullanilan kisim
            if (Score.score > 4000 && Score.score < 8000)
            {
                carSpeed = 25;
                gameSpeed = 15;
            }
            else if (Score.score > 8000)
            {
                carSpeed = 30;
                gameSpeed = 20;
            }
            //araba engelinin hizinin digerlerinden farkli olmasi icin kullanilan kisim
            if (gameObject.name == "Car")
            {
                transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.back * gameSpeed * Time.deltaTime);
            }
        }
    }
}
