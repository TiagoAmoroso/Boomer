using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*
    Spawn on x position
    Spawn on random y position within range
    Spawn enemy based on a probability to be spawned
    Spawn amount based on difficulty
    Spawn interval based on ???
    */

    [Header("Settings")]
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float posX;
    [SerializeField] private float spawnInterval;
    private float timeSinceLastSpawn ;

    [Header("Enemies")]
    [SerializeField] private GameObject[] enemyTypes;
    [SerializeField] private GameObject enemyHolder;

    private int enemyIndex;
    private float posY;
    private GameObject newSpawnedEnemy;

    private int enemiesSpawned;
    private bool spawning = true;
    

    private void start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(spawning){
            if (timeSinceLastSpawn >= spawnInterval)
            {
                spawnEnemy(enemyTypes);
            }
        }
    }

    public int getEnemiesSpawned()
    {
        return enemiesSpawned;
    }

    public void resetEnemiesSpawned()
    {
        enemiesSpawned = 0;
    }

    public void startSpawning()
    {
        spawning = true;
    }

    public void stopSpawning()
    {
        spawning = false;
    }

    public bool areEnemiesSpawnedAlive()
    {
        for (int i = 0; i< enemyHolder.transform.childCount; i++)
        {

            if(enemyHolder.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }


    private void spawnEnemy(GameObject[] enemyPool)
    {
        posY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2 (posX, posY);

        enemyIndex = (int)(Random.Range(0, enemyPool.Length));

        newSpawnedEnemy = Instantiate(enemyTypes[enemyIndex]);
 
        newSpawnedEnemy.transform.SetParent(enemyHolder.transform);

        newSpawnedEnemy.transform.position = spawnPos;
        newSpawnedEnemy.SetActive(true);

        timeSinceLastSpawn = 0;
        enemiesSpawned += 1;
    }
}

