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
    

    private void start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            spawnEnemy(enemyTypes);
        }
    }


    private void spawnEnemy(GameObject[] enemyPool)
    {
        posY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2 (posX, posY);

        enemyIndex = (int)(Random.Range(0, enemyPool.Length));

        newSpawnedEnemy = Instantiate(enemyTypes[enemyIndex]);
        //Move to enemy holder
 
        newSpawnedEnemy.transform.SetParent(enemyHolder.transform);

        newSpawnedEnemy.transform.position = spawnPos;
        newSpawnedEnemy.SetActive(true);

        timeSinceLastSpawn = 0;
    }
}
