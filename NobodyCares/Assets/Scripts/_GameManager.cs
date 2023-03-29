using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class _GameManager : MonoBehaviour
{
    public GameObject globalLight;
    public GameObject centerPointLight;

    BuildPoint[] buildPoints;
    UpgradeLight lightUp;

    PlayerWeapon playerWeapon;

    private void Start()
    {
        playerWeapon = FindObjectOfType<PlayerWeapon>();
        buildPoints = FindObjectsOfType<BuildPoint>();
        lightUp = FindObjectOfType<UpgradeLight>();
    }

    public void ChangeToDayTime()
    {

        // Lights off
        // centerPointLight.GetComponent<Light2D>().enabled = false;
        // Global Light On
        //globalLight.GetComponent<Light2D>().enabled = true;
        // Attacking off
        playerWeapon.canShoot = false;
        // Building Enabled
        foreach (BuildPoint buildPoint in buildPoints)
        {
            buildPoint.ToggleDayTime();
        }
        // Upgrading Enabled
        lightUp.ToggleDayTime();
        FindObjectOfType<StartNextNight>().isDay = true;

    }
    public void ChangeToNightTime()
    {

        // Lights on
        // centerPointLight.GetComponent<Light2D>().enabled = true;
        // Global Light Off
        //globalLight.GetComponent<Light2D>().enabled = false;
        // Attacking On
        playerWeapon.canShoot = true;
        // Building Disabled
        foreach (BuildPoint buildPoint in buildPoints)
        {
            buildPoint.ToggleDayTime();
        }
        // Upgrading Disabled
        lightUp.ToggleDayTime();

        // Start next Combat night
    }


    








}
