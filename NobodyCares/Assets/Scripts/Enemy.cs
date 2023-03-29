using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [Space]
    private int curHealth;
    public int maxHealth;
    public int damage;
    public float movementSpeed;
    public float expGiven;
    PlayerUI pUI;

    Animator animator;

    public GameObject xpDropPrefab;

    [HideInInspector]
    public int shield;
    [HideInInspector]
    public int armor;
    [HideInInspector]
    public float attackRange;

    Transform xpParent;

    private bool invulnerable = false;
    WorldTimer wTimer;

    public Animator newAnimator;


    public void Start()
    {
        animator = GetComponent<Animator>();
        xpParent = GameObject.FindGameObjectWithTag("XPParent").transform;

        Transform player = FindObjectOfType<PlayerMovement>().transform;
        pUI = FindObjectOfType<PlayerUI>();
        wTimer = FindObjectOfType<WorldTimer>();

        SetEnemyHealth();
        SetEnemyXP();

    }

    public void MultiplyStats(int healthMulti = 1, int massMulti = 0, int speedMulti = 0)
    {
        maxHealth = maxHealth * healthMulti;
        curHealth = maxHealth;
        GetComponent<Rigidbody2D>().mass += massMulti;
        GetComponent<EnemyMovement>().speed += speedMulti;
    }

    public void SetEnemyHealth()
    {
        switch (wTimer.worldModifiersCount)
        {
            case 1:
                curHealth = maxHealth;
                break;
            case 2:
                curHealth = maxHealth + 200;
                break;
            case 3:
                curHealth = maxHealth + 400;
                break;
            case 4:
                curHealth = maxHealth + 800;
                break;
            case 5:
                curHealth = maxHealth * 10;
                break;

            default:
                curHealth = maxHealth * (wTimer.worldModifiersCount * 2);
                break;
        } 
    }
    public void SetEnemyXP()
    {
        switch (wTimer.worldModifiersCount)
        {
            case 1:
                
                break;
            case 2:
                expGiven = expGiven + 1;
                break;
            case 3:
                expGiven = expGiven + 2;
                break;
            case 4:
                expGiven = expGiven + 4;
                break;
            case 5:
                expGiven = expGiven + 6;
                break;

            case 10:
                expGiven = expGiven + wTimer.worldModifiersCount * 2;
                break;

            default:
                expGiven = expGiven + (wTimer.worldModifiersCount + 6);
                break;
        }
    }


    public void TakeDamage(int damageAmount)
    {
        if (invulnerable)
        {
            return;
        }
        curHealth -= damageAmount;
        if (curHealth <= 0)
        {
            Death();

        }
        else
        {
            newAnimator.SetTrigger("Hurt");
            //animator.SetTrigger("HitMarker");
        }
    }
    public virtual void Death()
    {
        // Give xp
        DropXp();
        // Give other drops
        invulnerable = true;
        // Increase Killcount +1
        pUI.killCount++;

        // Play deathsound
        // FindObjectOfType<AudioManager>().PlaySound("EnemyDeath");
        GetComponent<AudioSource>().Play();

        //Remove 1 from GameManager/enemiesAmountCounter
        FindObjectOfType<Spawner>().curEnemiesAmount--;
        // Setting tag so deadbodies wont collide
        gameObject.tag = "DeadEnemy";
        // Telling dmg controller it's dead so that player wont take dmg when running into dead bodies
        GetComponent<EnemyDmgController>().isAlive = false;
        // Disableing collider so that other enemies don't get stuck behind dead enemies.
        GetComponent<CircleCollider2D>().enabled = false;
        // Freesing movement.
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        newAnimator.SetTrigger("Death");

        // DeathAnimations starts.
        GetComponentInChildren<EnemyGraphix>().DeathAnimation();
        // Start coroutine when to destroy dead enemy.
        StartCoroutine(DeathTimer());

        
    }
    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }

    public void DropXp()
    {
        

        for (int i = 0; i <= expGiven-1; i++)
        {
            Instantiate(xpDropPrefab, transform.position, transform.rotation, xpParent);
        }
    }

    public void RemoveEnemy()
    {

        Destroy(gameObject);
    }


}
