using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : Interactable
{


    public float rangeToInteract;
    Transform player;

    public int buildCost;

    public int lampUpgradesNeeded;

    public GameObject costUI;
    public TMPro.TextMeshProUGUI coinText;
    public GameObject buildingButtons;

    public GameObject targetDummy;
    public GameObject light;
    public GameObject coinGenerator;

    bool showingCostUI = true;
    bool buildPointIsShowing = false;
    bool itsDayTime = true;
    bool buildingButtonsShow = false;

    SpriteRenderer sprite;


    public override void Interac()
    {
        base.Interac();

    }
    public void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        sprite = GetComponent<SpriteRenderer>();

        LampUpgraded();
    }

    public void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance > rangeToInteract && buildingButtonsShow)
        {
            buildingButtonsShow = false;
            showingCostUI = false;

            buildingButtonsShow = false;
            buildingButtons.SetActive(false);
            costUI.SetActive(false);
        }

        if (!buildPointIsShowing || !itsDayTime || buildingButtonsShow)
        {
            return;
        }
        
        
        if (distance <= rangeToInteract)
        {
            costUI.SetActive(true);
            showingCostUI = true;
            coinText.text = "" + buildCost;
        }
        else if (distance > rangeToInteract && showingCostUI)
        {
            costUI.SetActive(false);
            showingCostUI = false;
        }

        
    }
    public void ShowOptions()
    {
        // Toggle BuildingList of options;
        buildingButtonsShow = true;
        buildingButtons.SetActive(true);
        costUI.SetActive(false);
    }

    public void BuildToThisPoint(int numb)
    {
        //FindObjectOfType<PlayerUI>().GiveGold(-buildCost);

        switch (numb)
        {
            case 1:
                Instantiate(targetDummy, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            case 2:
                Instantiate(light, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            case 3:
                Instantiate(coinGenerator, transform.position, transform.rotation);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public void LampUpgraded()
    {
        if (FindObjectOfType<UpgradeLight>().upgradesAmount < lampUpgradesNeeded)
        {
            // Can't show Buildpoint yet.
            sprite.enabled = false;
            buildPointIsShowing = false;
        }
        else
        {
            // Show Buildpoint point;
            sprite.enabled = true;
            buildPointIsShowing = true;

        }
    }
    public void ToggleDayTime()
    {
        itsDayTime = !itsDayTime;
    }
}
