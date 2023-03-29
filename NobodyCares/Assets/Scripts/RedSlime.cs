using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : Enemy
{

    public GameObject poolOfAcidPrefab;

    public override void Death()
    {
        base.Death();
        Instantiate(poolOfAcidPrefab, transform.position, transform.rotation);
    }
}
