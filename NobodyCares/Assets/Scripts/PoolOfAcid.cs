using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOfAcid : MonoBehaviour
{

    Player player;
    public float lifeTimer;
    bool attackingPlayer = false;
    float tickRate = 0.5f;
    float tickTimer;


    private void Start()
    {
        StartCoroutine(DeathTimer());
    }
    // Update is called once per frame
    void Update()
    {
        if (attackingPlayer)
        {
            tickTimer -= Time.deltaTime;
            if (tickTimer < 0)
            {
                tickTimer = tickRate;
                player.PoisonDamage(1);
            }
        } 
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(lifeTimer);
        attackingPlayer = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            attackingPlayer = true;
            tickTimer = tickRate;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attackingPlayer = false;
        }
    }

}
