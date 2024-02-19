using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //skoru arttirip textte yazdirmak icin kullanilan kod
    public Text scoreText;
    public static float score = 0;
    private void Awake()
    {
        score = 0;
    }
    private void Update()
    {
        if(!Death.isDead)
        {
            //highscore'i gecince skorun renginin yesil yanip sonmesi icin kullanilan kisim
            //highscore 0 ise textin rengi degismez
            if((int)score > PlayerPrefs.GetInt("HighScore") && PlayerPrefs.GetInt("HighScore") != 0)
            {
                scoreText.color = Color.Lerp(Color.black, Color.green, Mathf.PingPong(Time.time, 1));
            }
            score += 5f * Time.deltaTime;
            scoreText.text = "Score: " + (int)score;
        }
    }
}
