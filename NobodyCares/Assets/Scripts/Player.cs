using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    private int curHealth;
    int shield;
    [HideInInspector]
    public int armor;

    int goldAmount;

    public float iFrames = 1;
    private float iFramesTimer = 0;
    bool dead = false;


    PlayerUI playerUI;
    AudioManager audioManager;

    public Animator playerAnimator;
    public Animator dmgAnimator;
    
    public NearestEnemyTarget nt;
    public GameObject endScreenGameObj;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        playerUI = FindObjectOfType<PlayerUI>();
        playerUI.SetMaxHealth(maxHealth);
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void Update()
    {
        if (iFramesTimer > 0)
        {
            iFramesTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int dmgAmount)
    {
        if (iFramesTimer > 0 || dead)
        {
            return;
        }

        iFramesTimer = iFrames;

        int totalDmg = dmgAmount - armor;
        if (totalDmg <= 0)
        {
            totalDmg = 1;
        }
        
        curHealth -= totalDmg;
        playerUI.SetHealth(curHealth);

        if (curHealth <= 0)
        {
            Dead();
        }
        else
        {
            dmgAnimator.SetTrigger("TakeDamage");
            audioManager.PlaySound("PlayerHurt");

        }
    }

    public void PoisonDamage(int dmgAmount)
    {
        if (dead)
        {
            return;
        }

        curHealth -= dmgAmount;
        playerUI.SetHealth(curHealth);

        if (curHealth <= 0)
        {
            Dead();
        }
        else
        {
            dmgAnimator.SetTrigger("TakeDamage");
            audioManager.PlaySound("PlayerHurt");
        }
    }

    public void HealDamage(int healingAmount)
    {

        

        curHealth += healingAmount;

        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }



        Debug.Log("How much we heal: " + healingAmount);

        playerUI.SetHealth(curHealth);


    }
    public void GetExperience(int expAmount)
    {
        playerUI.SetExperience(expAmount);
    }
    private void Dead()
    {

        FindObjectOfType<AudioManager>().PlaySound("PlayerDeath");
        nt.enabled = false;
        dead = true;
        GetComponent<PlayerMovement>().StopMovement();
        FindObjectOfType<PlayerUI>().dead = true;
        //Play death animation
        playerAnimator.SetTrigger("Death");
        //After animation is done show stats of the run.
        StopAllCoroutines();
        StartCoroutine(animationTimer());
    }
    IEnumerator animationTimer()
    {
        int s = FindObjectOfType<WorldTimer>().GetCurSeconds();
        int m = FindObjectOfType<WorldTimer>().GetCurMinutes();
        int k = playerUI.killCount;
        int l = playerUI.level;

        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        endScreenGameObj.SetActive(true);
        endScreenGameObj.GetComponent<EndGameUI>().UpdateEndScreen(s, m, k, l);
    }


}
