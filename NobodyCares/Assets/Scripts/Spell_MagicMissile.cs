using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_MagicMissile : Spell
{
    // 35 speed + 5 perlvl
    // 3 dmg + 1 perlvl
    // 800ms cd - 50ms perlvl

    // Levels 3, 5, 7, 9 = +1Piercing
    // Levels 1,2,4,6,8 = -50 ms cd


    [Header("Magic Missle")]
    
    public Bullet bullet;
    public int piercingAmount;

    public float muzzleVelocity = 35f;
    public float knockBackAmount;

    float nextShotTime;
    [Space]
    public int spellDmgUpgradeAmount;
    int upgradeAmount = 0;
    AudioManager audioManager;

    public override void Start()
    {
        base.Start();
        audioManager = FindObjectOfType<AudioManager>();
    }

    

    public void Update()
    {

        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + spellCD / 1000;
            audioManager.PlaySound("ShootMagicBolt");
            Bullet newBullet = Instantiate(bullet, wandTipPoint.position, wandTipPoint.rotation, bulletParent) as Bullet;
            newBullet.SetSpeed(muzzleVelocity);
            newBullet.SetDmg(spellDmg);
            newBullet.SetAOE(spellAOE);
            newBullet.SetPiercing(piercingAmount);
            newBullet.SetKnockBackAmount(knockBackAmount);
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
                upgradeText = "Decreases spell cast Cooldown. Gives magic missiles +1 piercing.";
                upgradeStatsText = "(-50ms/CD)\n(+1 pierce)";
                break;
            case 2:
                spellCD -= 50;
                piercingAmount++;
                upgradeText = "Gives magic missiles +1 piercing.";
                upgradeStatsText = "(+1 pierce)";
                break;
            case 3:
                piercingAmount++;
                upgradeText = "Decreases spell cast Cooldown. Gives magic missiles +1 piercing.";
                upgradeStatsText = "(-50ms/CD)\n(+1 pierce)";
                break;
            case 4:
                spellCD -= 50;
                piercingAmount++;
                upgradeText = "Gives magic missiles +1 piercing.";
                upgradeStatsText = "(+1 pierce)";
                break;
            case 5:
                piercingAmount++;
                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-50ms/CD)";
                break;
            case 6:
                spellCD -= 50;
                upgradeText = "Gives magic missiles +1 piercing.";
                upgradeStatsText = "(+1 pierce)";
                break;
            case 7:
                piercingAmount++;
                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-50ms/CD)";
                break;
            case 8:
                spellCD -= 50;
                upgradeText = "Gives magic missiles +1 piercing.";
                upgradeStatsText = "(+1 pierce)";
                break;
            case 9:
                piercingAmount++;
                upgradeText = "Decreases spell cast Cooldown. Gives magic missiles +1 piercing.";
                upgradeStatsText = "(-100ms/CD)\n(+1 pierce)";
                break;
            case 10:
                spellCD -= 100;
                piercingAmount++;
                upgradeText = "Fully upgraded!";
                upgradeStatsText = "";
                break;
            default:
                upgradeText = "";
                upgradeStatsText = "";
                break;
        }

        upgradeText += " Increase of damage.";
        upgradeStatsText += "(+40 dmg)";
        spellDmg += spellDmgUpgradeAmount;
    }
}
