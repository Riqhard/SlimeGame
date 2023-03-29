using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AccountUpgrade
{
    public string upgradeName;

    public int upgradeCost;
    public int upgradeCostIncrease;
    public int upgradeLevel;
    public int upgradeMaxLevel;

    public AccountUpgradeType upgradeType;


}
public enum AccountUpgradeType { PassiveBodyUpgrade, PassiveWeaponUpgrade, PassiveEnemyUpgrade, GameStartUpgrade }