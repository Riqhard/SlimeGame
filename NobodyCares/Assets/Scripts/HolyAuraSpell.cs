using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyAuraSpell : Spell
{
    
    [Header("Holy Aura")]
    


    [Space]
    public int spellDmgUpgradeAmount;
    public float knockbackAmount;
    float nextShotTime;
    AudioManager audioManager;

    public override void Start()
    {
        base.Start();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + spellCD / 1000;
            TickDamage();
        }
    }
    public void TickDamage()
    {
        audioManager.PlaySound("ShootHolyAuraTick");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, spellAOE);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().TakeDamage(spellDmg);
                collider.GetComponent<EnemyMovement>().KnockBack(knockbackAmount);
            }
        }
    }
    

    public override void LevelUpSpell()
    {
        base.LevelUpSpell();
        switch (spellLevel)
        {
            case 0:
                break;
            case 1:
                upgradeText = "Knockback amount increased slightly ";
                upgradeStatsText = "(+1 knockback)\n";
                break;
            case 2:
                knockbackAmount++;
                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-50ms/CD)\n";
                break;
            case 3:
                spellCD -= 50;
                upgradeText = "Knockback amount increased slightly ";
                upgradeStatsText = "(+1 knockback)\n";
                break;
            case 4:
                knockbackAmount++;
                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-50ms/CD)\n";
                break;
            case 5:
                spellCD -= 50;
                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-50ms/CD)\n";
                break;
            case 6:
                spellCD -= 50;
                upgradeText = "Knockback amount increased slightly ";
                upgradeStatsText = "(+1 knockback)\n";
                break;
            case 7:
                knockbackAmount++;
                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-50ms/CD)\n";
                break;
            case 8:
                spellCD -= 50;
                upgradeText = "Knockback amount increased slightly ";
                upgradeStatsText = "(+1 knockback)\n";
                break;
            case 9:
                knockbackAmount++;
                upgradeText = "Knockback amount increased slightly & Decreases spell cast Cooldown.";
                upgradeStatsText = "(+1 knockback)\n(-50ms/CD)\n";
                break;
            case 10:
                knockbackAmount++;
                spellCD -= 50;
                upgradeText = "Fully upgraded!";
                upgradeStatsText = "";
                break;
            default:
                upgradeText = "";
                upgradeStatsText = "";
                break;
        }

        upgradeText += " Small increase of damage.";
        upgradeStatsText += "(+10 dmg)";
        spellDmg += spellDmgUpgradeAmount;
    }
}
