using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    //ITself, to use outside this class
    public static Spawner instance;

    public float spawnInterval = 2f; // Time in seconds between spawns
    private float spawnTimer = 0;

    private int stakes = 0;
    private int waveTotalValue = 100;
    internal int waveCurrentValue = 0;

    public GameObject enemyPrefab; // The enemy prefab to spawn
    private GameObject player;

    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> bosses = new List<GameObject>();


    //To make a static version that can easily be accesed by others
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RiseTheStakes();
    }

    void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval && waveCurrentValue < waveTotalValue)
        {
            spawnTimer = 0;
            while (waveCurrentValue < waveTotalValue)
            {
                int rndIndex = Random.Range(0, enemies.Count);
                GameObject enemyToSpawn = enemies[rndIndex];
                int enemyLevel = enemyToSpawn.GetComponent<Killable>().level;
                if (enemyLevel<= stakes)
                {
                    Spawn(enemies[rndIndex]);
                }
            }
        }
    }

    //MAke the spawning harder with character level
    internal void RiseTheStakes()
    {
        stakes++;
        waveTotalValue = 100 + stakes*20;
        if(stakes % 5 == 0)
        {
            int rndIndex = Random.Range(0, bosses.Count);
            Spawn(bosses[rndIndex],true,true);
        }
    }

    public void EnemyDown(GameObject enemy)
    {
        waveCurrentValue-= enemy.GetComponent<Killable>().waveValue;
    }

    internal void Spawn(GameObject enemy, bool isBoss = false, bool dispersion = true)
    {
        Vector3 rndVector = Vector3.zero;
        if (dispersion)
        {
            rndVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        }
        Instantiate(enemy, player.transform.position + 6f * rndVector, Quaternion.identity);
        if (!isBoss)
        {
            waveCurrentValue += enemy.GetComponent<Killable>().waveValue;
        }
    }

}
