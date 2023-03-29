using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgController : MonoBehaviour
{
    Player player;
    Enemy enemy;

    public bool attackingPlayer = false;
    public bool isAlive = true;



    public void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void Update()
    {
        if (attackingPlayer)
        {
            if (enemy == null)
            {
                enemy = GetComponent<Enemy>();
            }
            player.TakeDamage(enemy.damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            if (collision.collider.CompareTag("Player"))
            {
                if (enemy == null)
                {
                    enemy = GetComponent<Enemy>();
                }
                player = collision.collider.GetComponent<Player>();
                player.TakeDamage(enemy.damage);
                attackingPlayer = true;
            }
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player = null;
            attackingPlayer = false;
        }
    }
    
}
