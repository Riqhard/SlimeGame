using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject upgradeMenu;
    public GameObject startScreen;


    public void StartGame()
    {
        FindObjectOfType<PauseMenu>().inStartScreen = false;
        startScreen.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToggleOptions()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }


    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ToggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
    }
}
