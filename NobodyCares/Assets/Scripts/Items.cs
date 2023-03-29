using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Create / New Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public int itemID;

    [TextArea(10, 20)]
    public string itemDescription;
    [Space]
    public int maxUpgradeAmount;
    [HideInInspector]
    public int currentUpgradeLevel;

    public GameObject itemPrefab;
}

