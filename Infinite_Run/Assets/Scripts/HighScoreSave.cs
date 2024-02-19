using UnityEngine;

public class HighScoreSave : MonoBehaviour
{
    //en yuksek skoru kaydeden kod
    private bool isSaved;
    private int highScore;
    private void Start()
    {
        //PlayerPrefs.DeleteKey("HighScore"); eger yuksek skoru sifirlamak isterseniz bu satiri kullanabilirsiniz
        highScore = PlayerPrefs.GetInt("HighScore");
        isSaved = false;
    }
    private void Update()
    {
        if (Death.isDead && !isSaved)
        {
            isSaved = true;
            if(highScore < (int)Score.score)
            {
                highScore = (int)Score.score;
                print("New High Score!");
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
    }
}
