using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    public float worldTime = 30f;
    public float nextWaveTime = 30f;

    float curTime = 0;
    int seconds = 0;
    int minutes = 0;
    public TMPro.TextMeshProUGUI timeText;

    [Space]
    public int worldModifiersCount = 1;

    // Update is called once per frame
    void Update()
    {

        curTime += Time.deltaTime;
        if (curTime > 1)
        {
            curTime--;
            seconds++;
        }
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes++;
        }

        
        if (minutes > 0)
        {
            timeText.text = minutes + ":";
        }
        else
        {
            timeText.text = "";
        }

        if (seconds < 10)
        {
            timeText.text += "0" + seconds;
        }
        else
        {
            timeText.text += "" + seconds;
        }

        

        worldTime += Time.deltaTime;

        if (worldTime >= nextWaveTime)
        {

            worldTime = 0;
            FindObjectOfType<Spawner>().IncreaseWaveCount();
            
        }
    }
    public int GetCurSeconds()
    {
        return seconds;
    }
    public int GetCurMinutes()
    {
        return minutes;
    }
}
