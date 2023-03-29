using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldModifiers : MonoBehaviour
{
    public int amountMultiplier;
    public int speedMultiplier;
    public int healthMultiplier;
    public int dmgMultiplier;

    public float worldTimer = 0f;
    public float minutes = 0f;
    public bool paused;

    public float tickTimer = 10000f;
    float nextTimerTick;


    public void Update()
    { 
        if (!paused)
        {
            if (Time.time > nextTimerTick)
            {
                nextTimerTick = Time.time + tickTimer / 100;
                worldTimer += 1;
                if (worldTimer >= 60)
                {
                    worldTimer = 0;
                    minutes++;
                    FindObjectOfType<Spawner>().IncreaseWaveCount();
                    Debug.Log("Increasing the Wave count: " + minutes);
                }
            }
        }
    }
}
