using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medalliong : Spell 
{

    // Set armor +1 / LvL
    // Set Speed +1 / LvL

    [Header("Medaliong")]
    public int curArmor = 0;

    public override void Start()
    {
        base.Start();
        LevelUpSpell();
    }

    public override void LevelUpSpell()
    {
        base.LevelUpSpell();

        FindObjectOfType<Player>().armor += 1;
        curArmor++;
        FindObjectOfType<PlayerMovement>().moveSpeed += 1;
    }
}
