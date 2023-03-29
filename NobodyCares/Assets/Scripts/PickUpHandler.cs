using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour
{

    // -234x -130y 

    float minMaxYPos = 130f;
    float minMaxXPos = 234f;
    public float spawnRate = 20f;
    public GameObject[] pickUpPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPickup", 10f, spawnRate);
    }

    public void SpawnRandomPickup()
    {
        int rI = Random.Range(0, pickUpPrefabs.Length);
        // pickUpPrefabs[rI];
        float randomXPos = Random.Range(-minMaxXPos, minMaxXPos);
        float randomYPos = Random.Range(-minMaxYPos, minMaxYPos);

        Vector3 spawnPos = new Vector3(randomXPos, randomYPos, 0f);

        GameObject pickup = Instantiate(pickUpPrefabs[rI], spawnPos, transform.rotation);

        Debug.Log("Spawned new pickup: " + pickup.name + " In A position: " + spawnPos);

    }
}
