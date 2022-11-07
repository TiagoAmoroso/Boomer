using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int poolOneMaxWave;
    [SerializeField] private int poolTwoMaxWave;
    [SerializeField] private int poolThreeMaxWave;
    [SerializeField] private int poolFourMaxWave;

    [SerializeField] private float timeBetweenWaves;
    private float timeSinceLastWave = 0;

    [Header("Pools")]
    [SerializeField] private GameObject[] enemyPoolOne;
    [SerializeField] private GameObject[] enemyPoolTwo;
    [SerializeField] private GameObject[] enemyPoolThree;
    [SerializeField] private GameObject[] enemyPoolFour;
    [SerializeField] private GameObject[] enemyPoolFinal; //This will be infinite just increase in spawn rate and amount and change probabilities

    private GameObject[] currentEnemyPool;
    
    private int currentWave;

    //Need to do this!!!
    private float spawnMultiplier;
    [SerializeField] private int spawnMax;

    private Spawner spawner;

    private void Start()
    {
        spawner = GetComponent<Spawner>();
        spawner.changeEnemyPool(enemyPoolOne);
        currentWave = 1;
        timeSinceLastWave = timeBetweenWaves;
    }


    private void Update()
    {
        //Trash code... I know...

        if(currentWave <= poolOneMaxWave)
        {
            currentEnemyPool = enemyPoolOne;
        }
        else if(currentWave <= poolTwoMaxWave)
        {
            currentEnemyPool = enemyPoolTwo;
        }
        else if(currentWave <= poolThreeMaxWave)
        {
            currentEnemyPool = enemyPoolThree;
        }
        else if(currentWave <= poolFourMaxWave)
        {
            currentEnemyPool = enemyPoolFour;
        }
        else
        {
            currentEnemyPool = enemyPoolFinal;
        }

        spawner.changeEnemyPool(currentEnemyPool);


        if(spawner.getEnemiesSpawned() >= spawnMax)
        {
            spawner.stopSpawning();

            if(!spawner.areEnemiesSpawnedAlive())
            {
                nextWave();
            }
        }
        else
        {
            if(timeSinceLastWave >= timeBetweenWaves)
            {
                spawner.startSpawning();
            }
        }

        timeSinceLastWave += Time.deltaTime;
    }



    private void nextWave()
    {
        currentWave += 1;
        spawner.resetEnemiesSpawned();
        //Debug.Log("Wave: " + currentWave);
        timeSinceLastWave = 0;
    }

    private void changeWave(int newWave)
    {
        currentWave = newWave;
    }


}
