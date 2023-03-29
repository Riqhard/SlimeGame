using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{

    public TextMeshProUGUI scoreTextTime;
    public TextMeshProUGUI scoreTextKills;
    public TextMeshProUGUI scoreTextLevels;


    public void UpdateEndScreen(int seconds, int minutes, int killCount, int playerLevel)
    {
        scoreTextTime.text = "You survived: " + minutes + ":" + seconds;
        scoreTextKills.text = "Killed: " + killCount + " slimes";
        scoreTextLevels.text = "Level " + playerLevel;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
