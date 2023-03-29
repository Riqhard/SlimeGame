using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    // Name that appears when picking the spell
    public string spellName;
    // Base dmg of the spell
    public int spellDmg;
    // Base cd of the spell (ms Between Shots)
    public float spellCD;
    // Base AOE of the spell in world units
    public float spellAOE;

    [HideInInspector]
    public int spellLevel;

    [TextArea(10, 20)]
    public string upgradeText;
    public string upgradeStatsText;

    [HideInInspector]
    public Transform bulletParent;
    [HideInInspector]
    public Transform wandTipPoint;
    [HideInInspector]
    public Transform playerTransform;
    [HideInInspector]
    public Player player;

    public virtual void Start()
    {
        bulletParent = FindObjectOfType<BulletParent>().transform;
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        player = FindObjectOfType<Player>();
    }
    public void SetWandPoint(Transform rotationPoint)
    {
        wandTipPoint = rotationPoint;
    }




    public virtual void LevelUpSpell()
    {
        spellLevel++;
    }
    public virtual void Shoot()
    {
        
    }


}
