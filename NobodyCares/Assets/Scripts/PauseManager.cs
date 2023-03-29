using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public event System.Action OnPause;
    public event System.Action OnUnPause;

    public void PauseGame()
    {
        if (OnPause != null)
            OnPause();

        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        if (OnUnPause != null)
            OnUnPause();

        Time.timeScale = 1;
    }
}
