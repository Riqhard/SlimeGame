using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    //[HideInInspector]
    public bool gameIsPaused = false;
    //[HideInInspector]
    public bool canShoot = true;

    bool autoshooting = false;

    public GameObject weapon;

    [HideInInspector]
    public bool hasShootingWeapon = false;

    public void Update()
    {
        if (!hasShootingWeapon)
        {
            return;
        }

        if (autoshooting && canShoot && !gameIsPaused)
        {
            //Shoot
            weapon.GetComponent<Spell>().Shoot();
        }

        // Autoshooting Toggle
        if (Input.GetKeyDown(KeyCode.Q) && canShoot && !gameIsPaused)
        {
            ToggleAutoShooting();
        }

        if (Input.GetButton("Fire1") && canShoot && !gameIsPaused)
        {
            //Shoot
            weapon.GetComponent<Spell>().Shoot();
        }
    }

    public void ToggleAutoShooting()
    {
        autoshooting = !autoshooting;
    }

}
