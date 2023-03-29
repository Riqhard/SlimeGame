using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKnockback : MonoBehaviour
{

    float delay = 0.15f;

    public UnityEvent OnBegin, OnDone;
    bool onHit = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void KnockBack(Vector3 senderPos, float forceAmount)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();

        

        Vector2 direction = (transform.position - senderPos).normalized;
        rb.AddForce(direction * forceAmount, ForceMode2D.Impulse);
        StartCoroutine(knockBReset());
    }

    IEnumerator knockBReset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
        
    }
}
