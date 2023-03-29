using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float radiusAOE;
    [HideInInspector]
    public int dmg;
    [HideInInspector]
    public float knockbackAmount;
    [HideInInspector]
    public int pierceAmount;
    public float lifeTimer;

    CircleCollider2D circle;

    public void Start()
    {
        StartCoroutine(LiveTimer());
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
    public void SetAOE(float radius)
    {
        radiusAOE = radius;
        //circle.radius = radius;
        transform.localScale = new Vector3(radius, radius, radius);
    }
    public void SetDmg(int DMGToSet)
    {
        dmg = DMGToSet;
    }
    public void SetPiercing(int pierc)
    {
        pierceAmount = pierc;
    }
    public void SetKnockBackAmount(float kback)
    {
        knockbackAmount = kback;
    }


    IEnumerator LiveTimer()
    {
        yield return new WaitForSeconds(lifeTimer);

        Destroy(gameObject);
    }
}
