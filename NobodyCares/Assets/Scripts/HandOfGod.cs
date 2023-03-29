using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOfGod : Spell
{
    // Healing spell with 60s cd - 5s CD perlvl
    // +5 Max HP + 5 perlvl

    [Header("Hand Of God")]
    // HealAmount in %
    public int healAmount;
    float spellCooldownTimer;

    bool cooldownDone = true;

    public void Update()
    {
        if (Time.time > spellCooldownTimer)
        {
            spellCooldownTimer = Time.time + spellCD;
            cooldownDone = true;
        }
        if (cooldownDone && Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellCooldownTimer = Time.time + spellCD;
            CastSpell();
        }
    }

    public override void LevelUpSpell()
    {
        base.LevelUpSpell();
        FindObjectOfType<Player>().maxHealth += 5;
    }

    public void CastSpell()
    {
        
        cooldownDone = false;
        player.HealDamage(healAmount);

    }

}
