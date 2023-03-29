using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Enemy/Wave")]
public class EnemyWaves : ScriptableObject
{
    new public string name = "New wave";

    [Header("Enemies")]
    public Transform[] enemyPrefabs;
    public int countOfEnemies;
    [Space]
    public int massMulti;
    [Range(1,100)]
    public int healthMulti;
    public int speedMulti;
    [Space]
    public bool bossWave;

}
