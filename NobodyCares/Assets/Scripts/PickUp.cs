using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    Transform player;
    float pullForce = 5f;
    bool isPulling = false;
    bool forcePull = false;

    public virtual void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }
    public void FixedUpdate()
    {

        if (forcePull)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 force = direction * pullForce * Time.deltaTime;

            transform.Translate(force);
        }


        if (isPulling)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 force = direction * pullForce * Time.deltaTime;

            transform.Translate(force);
        }


    }

    public virtual void PickUpItem()
    {

    }
    public void ActivateForcePull(float force)
    {
        pullForce = force;
        forcePull = true;
    }
    public void ActivatePull(float force)
    {
        pullForce = force;
        isPulling = true;
    }
    public void DeactivatePull()
    {
        isPulling = false;
    }
}
