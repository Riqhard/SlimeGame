using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_MagicMissile : Bullet
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            pierceAmount--;
            collision.GetComponent<Enemy>().TakeDamage(dmg);
            collision.GetComponent<EnemyMovement>().KnockBack(knockbackAmount);
            if (pierceAmount <= 0)
            {
                StopAllCoroutines();
                Destroy(gameObject);
            }

        }
    }
}
