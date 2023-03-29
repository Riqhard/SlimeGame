using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int nextWave = 0;
    public int maxEnemyAmount;
    public int curEnemiesAmount;

    public float updatePositionRate = 1f;

    public int waveSplitIndex;

    [Header("Lists")]

    public EnemyWaves[] wavesList;
    public Transform[] spawnpoints;

    [Space]
    public Transform target;
    public GameObject enemyParent;

    EnemyWaves currentWave;

    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
        InvokeRepeating("UpdateTarget", 0f, updatePositionRate);
    }

    void UpdateTarget()
    {
        transform.position = target.position;
    }

    IEnumerator SpawnWave(EnemyWaves _wave)
    {
        for (int i = 0; i < waveSplitIndex; i++)
        {

            
            if (_wave.bossWave)
            {
                i = waveSplitIndex;
                SpawnBoss(_wave.enemyPrefabs[0]);
            }
            else
            {


                // Random Enemy
                int nextEnemy = Random.Range(0, _wave.enemyPrefabs.Length);
                int enemiesCount = _wave.countOfEnemies * FindObjectOfType<WorldTimer>().worldModifiersCount;
                int enemySet = enemiesCount / waveSplitIndex;

                // Spawn that Enemy
                SpawnEnemy(_wave.enemyPrefabs[nextEnemy], enemySet);
            }
            



            // Spawn next set ever 1s
            yield return new WaitForSeconds(60 / waveSplitIndex);
        }
        yield break;
        
    }

    void SpawnBoss(Transform _enemy)
    {
        Transform nextSpawnPoint = spawnpoints[0];
        Instantiate(_enemy, nextSpawnPoint.position, nextSpawnPoint.rotation, enemyParent.transform);
    }

    void SpawnEnemy(Transform _enemy, int amountToSpawn)
    {

        if (curEnemiesAmount < maxEnemyAmount)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                curEnemiesAmount++;
                // Random SpawnPoint
                int index = Random.Range(0, spawnpoints.Length);

                // Set spawnpoint
                Transform nextSpawnPoint = spawnpoints[index];

                // Random position
                float randomSpoty = Random.Range(-10f, 10f);
                float randomSpotx = Random.Range(-10f, 10f);
                Vector3 spawnPos = new Vector3(nextSpawnPoint.position.x + randomSpotx, nextSpawnPoint.position.y + randomSpoty, 0f);

                //Spawn in 
                Transform enemy = Instantiate(_enemy, spawnPos, nextSpawnPoint.rotation, enemyParent.transform);

                enemy.GetComponent<Enemy>().MultiplyStats(currentWave.healthMulti, currentWave.massMulti, currentWave.speedMulti);
            }
        }

    }
    public void IncreaseWaveCount()
    {
        nextWave++; 
        if (nextWave < wavesList.Length)
        {
            currentWave = wavesList[nextWave];
            StartCoroutine(SpawnWave(wavesList[nextWave]));
        }
        else
        {
            // NG + 1
            FindObjectOfType<WorldTimer>().worldModifiersCount++;
            nextWave = 1;
            currentWave = wavesList[nextWave];
            StartCoroutine(SpawnWave(wavesList[nextWave]));
        }
        
    }
    
}
