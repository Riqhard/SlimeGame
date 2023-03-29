using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XpPickup : PickUp
{

    int xpToGive;

    float delay = 0.15f;
    Rigidbody2D rb;

    public UnityEvent OnBegin, OnDone;

    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        RandomKnockBack();
        xpToGive = 100;
    }
    public void RandomKnockBack()
    {
        StopAllCoroutines();
        OnBegin?.Invoke();

        Vector2 randomDirection = new Vector2(Random.Range(-1,1), Random.Range(-1, 1)).normalized;

        rb.AddForce(randomDirection * 20f, ForceMode2D.Impulse);
        StartCoroutine(knockBReset());
    }

    IEnumerator knockBReset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GetExperience(xpToGive);
            Destroy(gameObject);
        }
    }


    public override void PickUpItem()
    {
        base.PickUpItem();

        Destroy(gameObject);
    }
}
