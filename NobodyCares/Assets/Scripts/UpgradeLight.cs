using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;

public class UpgradeLight : Interactable
{

    public float rangeToInteract;
    Transform player;

    public int upgradesAmount = 0;
    public int upgradeCost;
    public GameObject costUI;
    public TMPro.TextMeshProUGUI coinText;

    SpriteMask theDarkness;

    
    bool showingCostUI = true;
    bool lampUpgradesShowing = true;
    bool itsDayTime = true;

    Light2D light2D;
    PlayerUI playerUI;
    BuildPoint[] buildPoints;
    

    public override void Interac()
    {
        base.Interac();
        
    }

    public void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerUI = FindObjectOfType<PlayerUI>();
        light2D = GetComponentInChildren<Light2D>();

        buildPoints = FindObjectsOfType<BuildPoint>();
        theDarkness = GetComponentInChildren<SpriteMask>();
    }

    public void Update()
    {
        if (!lampUpgradesShowing || !itsDayTime)
        {
            return;
        }
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= rangeToInteract)
        {
            ShowCoins();
            showingCostUI = true;
        }
        else if (distance > rangeToInteract && showingCostUI)
        {
            costUI.SetActive(false);
            showingCostUI = false;
        }
        if (showingCostUI && Input.GetKeyDown(KeyCode.E))
        {

        }
    }
    void ShowCoins()
    {
        costUI.SetActive(true);
        coinText.text = "" + upgradeCost;
    }
    void UpgradeItem()
    {
        //playerUI.GiveGold(-upgradeCost);
        upgradeCost++;

        Vector3 newScale = new Vector3(theDarkness.transform.localScale.x + 0.2f, theDarkness.transform.localScale.y + 0.2f, theDarkness.transform.localScale.z + 0.2f);

        theDarkness.transform.localScale = newScale;
    }
    public void ToggleDayTime()
    {
        itsDayTime = !itsDayTime;
    }

}
