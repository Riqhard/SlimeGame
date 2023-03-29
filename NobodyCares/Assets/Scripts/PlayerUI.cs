using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    public Slider healthSlider;
    public Slider experienceSlider;
    public TextMeshProUGUI levelTxt;
    public GameObject upgradeMenu;

    public float maxExperience;
    float curExp = 0;
    public int level = 0;
    bool upgrading = false;
    [HideInInspector]
    public bool dead = false;

    public float nextLevelXpNeeded;
    public int killCount;

    public void Start()
    {
        SetMaxExperience(maxExperience);
        FindObjectOfType<PauseMenu>().ToggleUpgradePause();
        FindObjectOfType<UpgradeHandler>().ActivateChooseWeaponsUI();
    }

    public void SetMaxHealth(int maxhealth)
    {
        healthSlider.maxValue = maxhealth;
        healthSlider.value = maxhealth;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }





    public void SetMaxExperience(float exp)
    {
        experienceSlider.maxValue = exp;
        experienceSlider.value = 0;
    }
    public void SetExperience(float exp)
    {
        if (dead)
        {
            return;
        }
        curExp += exp; 
        experienceSlider.value = curExp;
        if (curExp >= maxExperience)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        curExp -= maxExperience;
        level++;
        levelTxt.text = "" + level;

        FindObjectOfType<AudioManager>().PlaySound("LevelUp");

        switch (level)
        {
            case 1:
                maxExperience = 3000;
                break;
            case 2:
                maxExperience = 4500;
                break;
            case 3:
                maxExperience = 6000;
                break;
            case 4:
                maxExperience = 7500;
                break;
            case 5:
                maxExperience = 9500;
                break;
            case 6:
                maxExperience = 12000;
                break;
            default:
                maxExperience = maxExperience + (maxExperience / 3);
                break;
        }


        
        experienceSlider.value = curExp;
        experienceSlider.maxValue = maxExperience;


        FindObjectOfType<PauseMenu>().ToggleUpgradePause();
        FindObjectOfType<UpgradeHandler>().ActivateChooseWeaponsUI();
    }

    public void ToggleUpgradeMenu()
    {
        if (upgrading)
        {
            Time.timeScale = 1;
            FindObjectOfType<PlayerWeapon>().canShoot = true;
        }
        else
        {
            Time.timeScale = 0;
            FindObjectOfType<PlayerWeapon>().canShoot = false;
        }
        
        
    }    

}
