using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Account : MonoBehaviour
{

    public static Account instance;

    public int accountCrystalsAmount;
    public TextMeshProUGUI crystalText;

    public AccountUpgrade[] accountUpgrades;

    public GameObject[] buttons;
    public GameObject[] levelText;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        InitializeButtons();
        crystalText.text = "" + accountCrystalsAmount;


    }

    public void InitializeButtons()
    {
        int i = 0;

        foreach (GameObject button in buttons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "" + accountUpgrades[i].upgradeCost;
            levelText[i].GetComponent<TextMeshProUGUI>().text = "" + accountUpgrades[i].upgradeLevel;
            i++;
        }
    }


    public void GiveCrystals(int amount)
    {
        accountCrystalsAmount += amount;
    }

    public void UpgradeAccount(int upgradeIndex)
    {
        // Get the targeted upgrade.
        AccountUpgrade upgrade = accountUpgrades[upgradeIndex];
        if (upgrade == null)
        {
            Debug.LogWarning("Upgrade index is out of bounds. " + upgradeIndex + " indexnumber.");
            return;
        }
        if (accountCrystalsAmount < upgrade.upgradeCost)
        {
            // Not enought cyrstals.
            // Show notenought crystal popup.
            Debug.Log("Not enought crystals. " + accountCrystalsAmount + " current crystals amount. " + upgrade.upgradeCost + " upgrade cost.");
            return;
        }

        accountCrystalsAmount -= upgrade.upgradeCost;
        upgrade.upgradeLevel++;
        upgrade.upgradeCost += upgrade.upgradeCostIncrease;

        if (upgrade.upgradeLevel == upgrade.upgradeMaxLevel)
        {
            // Disable upgrade button for future.
            buttons[upgradeIndex].GetComponent<Button>().interactable = false;
            // Changing Cost text on button
            buttons[upgradeIndex].GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
        }
        else
        {

            // Changing Cost text on button
            buttons[upgradeIndex].GetComponentInChildren<TextMeshProUGUI>().text = "" + upgrade.upgradeCost;
        }

        // Changing level text
        levelText[upgradeIndex].GetComponent<TextMeshProUGUI>().text = "" + upgrade.upgradeLevel;
        crystalText.text = "" + accountCrystalsAmount;
    }






}
