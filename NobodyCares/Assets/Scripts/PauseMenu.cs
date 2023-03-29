using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool gameIsPaused = false;
    bool choosingUpgrade = false;
    public bool inStartScreen = true;

    public GameObject optionsMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !choosingUpgrade && !inStartScreen)
        {
            PauseGame();
            Debug.Log("PauseButton");
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused){
            gameIsPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            FindObjectOfType<PlayerWeapon>().gameIsPaused = false;
        }
        else{
            gameIsPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            FindObjectOfType<PlayerWeapon>().gameIsPaused = true;
        }

        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleUpgradePause()
    {
        choosingUpgrade = !choosingUpgrade;

        if (choosingUpgrade)
        {
            Time.timeScale = 0;
            FindObjectOfType<PlayerWeapon>().gameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            FindObjectOfType<PlayerWeapon>().gameIsPaused = false;
        }
    }

    public void OptionsMenu()
    {
        if (!inStartScreen)
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        else
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
        
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
