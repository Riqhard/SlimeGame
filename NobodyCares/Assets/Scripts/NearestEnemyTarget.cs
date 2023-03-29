using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyTarget : MonoBehaviour
{


    public float updateTargetRate;
    Transform target;
    public string enemyTag = "Enemy";

    public float range = 50;
    public float rotationSpeed;

    public bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, updateTargetRate);
    }

    public void Update()
    {
        if (target != null)
        {
            Vector3 difference = target.position - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion newRotation = Quaternion.Euler(0f, 0f, rotZ);
            Vector3 desiredRotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed).eulerAngles;

            transform.rotation = Quaternion.Euler(0f, 0f, desiredRotation.z);
        }
    }

    void UpdateTarget()
    {
        if (!isActive)
        {
            target = null;
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
