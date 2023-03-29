using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheBullet : Bullet
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(dmg);
            collision.GetComponent<EnemyMovement>().KnockBack(knockbackAmount);
        }
    }
}
