using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRadius : MonoBehaviour
{


    public Transform target;

    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        // Vector3 pos = new Vector3(target.position.x, target.position.y, 0);
        transform.position = target.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().RemoveEnemy();
            FindObjectOfType<Spawner>().curEnemiesAmount--;
        }
    }
}
