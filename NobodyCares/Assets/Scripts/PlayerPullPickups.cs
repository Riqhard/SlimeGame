using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPullPickups : MonoBehaviour
{
    public float updateRate;

    public float range;
    public float pullForce;
    public float forcePullForce;

    public bool isActive;

    GameObject[] targetsInRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdatePickup", 0f, updateRate);
    }


    void UpdatePickup()
    {
        if (!isActive)
        {
            return;
        }

        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject pickup in pickups)
        {
            float distanceToIt = Vector2.Distance(transform.position, pickup.transform.position);
            if (distanceToIt <= range)
            {
                // Activate pull    
                pickup.GetComponent<PickUp>().ActivatePull(pullForce);
            }
            else
            {
                pickup.GetComponent<PickUp>().DeactivatePull();
            }
        }
    }

    public void CollectAllEXP()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject pickup in pickups)
        {

            XpPickup xpPickup = null;
            xpPickup = pickup.GetComponent<XpPickup>();

            if (xpPickup != null)
            {
                pickup.GetComponent<PickUp>().ActivateForcePull(forcePullForce);
            }

        }
    }
}
