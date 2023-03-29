using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeHandler : MonoBehaviour
{
    
    public TextMeshProUGUI[] weaponDesciptions;
    public TextMeshProUGUI[] weaponStats;

    

    
    Upgrade upgrade;


    public Spell[] spells;

    public GameObject weaponsUpgradeUIGameobject;

    public GameObject weapon1CardUI;
    public GameObject weapon2CardUI;
    public GameObject weapon3CardUI;

    public void Awake()
    {
        upgrade = FindObjectOfType<Upgrade>();
    }


    public void ActivateChooseWeaponsUI()
    {
        int i = 0;
        int y = 0;
        weaponsUpgradeUIGameobject.SetActive(true);
        foreach (TextMeshProUGUI item in weaponDesciptions)
        {

            item.text = spells[i].upgradeText;
            i++;
        }
        foreach (TextMeshProUGUI item in weaponStats)
        {

            item.text = spells[y].upgradeStatsText;
            y++;
        }
    }


    public void UpgradeItem(int itemId)
    {
        upgrade.UpgradeExistingItem(itemId);
    }

}
