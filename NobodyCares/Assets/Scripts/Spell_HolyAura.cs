using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_HolyAura : Spell
{



    float nextShotTime;

    // Update is called once per frame
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, spellAOE);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().TakeDamage(spellDmg);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                // Needs to be seperate script before works
                // enemyMovement.SlowDown(spellSlowAmount, spellSlowTime);
            }
        }
    }
}
