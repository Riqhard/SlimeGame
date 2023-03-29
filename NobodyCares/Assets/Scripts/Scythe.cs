using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Spell
{
    // 25 Dmg/lvl

    // Levels 3,5,7,9 = -250 cd
    // Levels 1,2,4,6,8 = +1 shotsAmount;


    [Header("Scythe")]

    public Bullet bullet;

    public float muzzleVelocity = 35f;
    public float knockBackAmount;
    float nextShotTime;
    AudioManager audioManager;


    [Space]
    public int shotsAmount;
    public int spellDmgUpgradeAmount;

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

            float shotAngle = 0;
            float splicedAngles = 360 / shotsAmount;
            audioManager.PlaySound("ShootFireScythe");

            // We make shotsAmount of bullets
            for (int i = 0; i < shotsAmount; i++)
            {

                Vector3 shotRotation = new Vector3(0f, 0f, 90f + shotAngle);
                Bullet newBullet = Instantiate(bullet, playerTransform.position, Quaternion.Euler(0f, 0f, shotRotation.z), bulletParent) as Bullet;
                newBullet.SetSpeed(muzzleVelocity);
                newBullet.SetDmg(spellDmg);
                newBullet.SetAOE(spellAOE);
                newBullet.SetKnockBackAmount(knockBackAmount);
                shotAngle += splicedAngles;
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
                upgradeText = "Increases amount of Fire Scythes shot on every cast. ";
                upgradeStatsText = "(+1 Scythe cast)\n";
                break;
            case 2:
                shotsAmount++;

                upgradeText = "Increases amount of Fire Scythes shot on every cast.";
                upgradeStatsText = "(+1 Scythe cast)\n";
                break;
            case 3:
                shotsAmount++;

                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-250ms/CD)\n";
                break;
            case 4:
                spellCD -= 250;

                upgradeText = "Increases amount of Fire Scythes shot on every cast.";
                upgradeStatsText = "(+1 Scythe cast)\n";
                break;
            case 5:
                shotsAmount++;

                upgradeText = "Decreases spell cast Fire Cooldown.";
                upgradeStatsText = "(-250ms/CD)\n";
                break;
            case 6:
                spellCD -= 250;

                upgradeText = "Increases amount of Fire Scythes shot on every cast.";
                upgradeStatsText = "(+1 Scythe cast)\n";
                break;
            case 7:
                shotsAmount++;

                upgradeText = "Decreases spell cast Cooldown.";
                upgradeStatsText = "(-250ms/CD)\n";
                break;
            case 8:
                spellCD -= 250;

                upgradeText = "Increases amount of Fire Scythes shot on every cast.";
                upgradeStatsText = "(+1 Scythe cast)\n";
                break;
            case 9:
                shotsAmount++;

                upgradeText = "Decreases spell cast Cooldown & increases amount of Fire Scythes shot on every cast.";
                upgradeStatsText = "(+1 Scythe cast)\n(-250ms/CD)\n";
                break;
            case 10:
                spellCD -= 250;
                shotsAmount++;
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
