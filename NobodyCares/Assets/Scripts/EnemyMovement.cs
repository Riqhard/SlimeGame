using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{

    Transform player;
    Rigidbody2D rb;
    [HideInInspector]
    public float speed;
    float normalSpeed;
    public float attackRange;

    float delay = 0.15f;

    public UnityEvent OnBegin, OnDone;
    bool onHit = false;
    public bool bossEnemy = false;
    public bool canHaveBacklash;
    public Animator newAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        rb = GetComponent<Rigidbody2D>();
        speed = GetComponent<Enemy>().movementSpeed;
        attackRange = GetComponent<Enemy>().attackRange;
        normalSpeed = speed;
    }

    void FixedUpdate()
    {
        if (onHit)
        {
            return;
        }
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            AttackPlayer();
            newAnimator.SetBool("Moving", false);
            return;
        }

        newAnimator.SetBool("Moving", true);
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }



    // Move to different scripts ------------->
    // Move to different scripts ------------->
    // Move to different scripts ------------->
    // Move to different scripts ------------->
    // Move to different scripts ------------->


    public void KnockBack(float forceAmount)
    {
        if (bossEnemy || onHit)
        {
            return;
        }
        StopAllCoroutines();
        OnBegin?.Invoke();
        newAnimator.SetBool("Moving", false);
        Vector2 direction = (transform.position - player.position).normalized;
        onHit = true;

        if (canHaveBacklash)
            KnockBacklash(direction, forceAmount);



        rb.AddForce(direction * forceAmount, ForceMode2D.Impulse);
        StartCoroutine(knockBReset());
    }

    public void KnockBacklash(Vector2 direction, float forceAmount)
    {

        float xPos;
        float yPos;

        if (direction.x > 0)
        {
            xPos = 1f;

        }
        else
        {
            xPos = -1f;
        }
        if (direction.y > 0)
        {
            yPos = 1f;

        }
        else
        {
            yPos = -1f;
        }

        Vector3 circlePos = new Vector3(transform.position.x + xPos, transform.position.y + yPos, 0f);


        Collider2D[] colliders = Physics2D.OverlapCircleAll(circlePos, 1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<EnemyMovement>().KnockBack(forceAmount / 2);
            }
        }
    }


    IEnumerator knockBReset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
        onHit = false;
    }

    public void AttackPlayer()
    {

    }
}
