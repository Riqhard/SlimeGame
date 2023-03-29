using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    public GameObject[] weaponsList;
    [Space]
    public GameObject listHolder;




    [Space]
    public SpriteRenderer wandSprite;
    public Transform wandPoint;

    [Space]

    public Spell_MagicMissile Spell_MagicMissile;
    public Scythe Spell_Scythe;
    public HolyAuraSpell Spell_HolyAura;

    
    public void UpgradeExistingItem(int itemId)
    {
        switch (itemId)
        {
            case 0:
                if (Spell_MagicMissile.spellLevel == 0)
                {
                    weaponsList[0].gameObject.SetActive(true);
                    wandSprite.enabled = true;
                    FindObjectOfType<NearestEnemyTarget>().isActive = true;
                    Spell_MagicMissile.SetWandPoint(wandPoint);
                }
                Spell_MagicMissile.LevelUpSpell();
                break;
            case 1:
                if (Spell_Scythe.spellLevel == 0)
                {
                    weaponsList[1].gameObject.SetActive(true);
                }
                Spell_Scythe.LevelUpSpell();
                break;
            case 2:
                if (Spell_HolyAura.spellLevel == 0)
                {
                    weaponsList[2].gameObject.SetActive(true);
                }
                Spell_HolyAura.LevelUpSpell();
                break;
            default:
                break;
        }

        FindObjectOfType<PauseMenu>().ToggleUpgradePause();
        listHolder.SetActive(false);

    }




}
