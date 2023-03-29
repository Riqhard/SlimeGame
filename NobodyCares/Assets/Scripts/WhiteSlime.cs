using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSlime : Enemy
{

    public GameObject splitEnemyPrefab;
    Transform enemyParent;

    public override void Death()
    {
        base.Death();
        enemyParent = GameObject.FindGameObjectWithTag("EnemyParent").transform;


        Vector2 pos1 = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 pos2 = new Vector2(transform.position.x - 1, transform.position.y);
        GameObject slime1 = Instantiate(splitEnemyPrefab, pos1, transform.rotation, enemyParent);
        GameObject slime2 = Instantiate(splitEnemyPrefab, pos2, transform.rotation, enemyParent);

        //slime1.GetComponent<EnemyMovement>().Stop(1f);
        //slime2.GetComponent<EnemyMovement>().Stop(1f);
    }
}
