using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //menularin acilmasi,kapanmasi ve textlerinin gosterilmesi icin kullanilan kod
    public GameObject pauseMenu;
    public GameObject deathMenu;
    public Text highScoreText;
    public Text deathMenuScoreText, deathMenuHighScoreText;
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy)
            {
                ClosePauseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
        if(Death.isDead)
        {
            OpenDeathMenu();
        }
    }
    public void OpenPauseMenu()
    {
        highScoreText.text = "High Score:\n\n" + PlayerPrefs.GetInt("HighScore");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void OpenDeathMenu()
    {
        deathMenuHighScoreText.text = "High Score:\n\n" + PlayerPrefs.GetInt("HighScore");
        deathMenuScoreText.text = "Score:\n\n" + (int)Score.score;
        deathMenu.SetActive(true);
    }
    public void RestartGame()
    {
        Death.isDead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
