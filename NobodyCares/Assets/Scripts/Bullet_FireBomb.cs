using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_FireBomb : Bullet
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Explode();
            
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusAOE);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().TakeDamage(dmg);
            }
        }
    }
}
