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

    [Header("Pools")]
    [SerializeField] private GameObject[] enemyPoolOne;
    [SerializeField] private GameObject[] enemyPoolTwo;
    [SerializeField] private GameObject[] enemyPoolThree;
    [SerializeField] private GameObject[] enemyPoolFour;
    [SerializeField] private GameObject[] enemyPoolFinal; //This will be infinite just increase in spawn rate and amount and change probabilities

    private GameObject[] currentEnemyPool;
    
    private int currentWave;

    private float spawnMultiplier;
    private int spawnMax = 2;

    private Spawner spawner;

    private void Start()
    {
        spawner = GetComponent<Spawner>();
        currentWave = 0;
    }


    private void Update()
    {
        //Trash code... I know...

        if(currentWave >= 0)
        {
            currentEnemyPool = enemyPoolOne;
        }
        else if(currentWave > poolOneMaxWave)
        {
            currentEnemyPool = enemyPoolTwo;
        }
        else if(currentWave > poolTwoMaxWave)
        {
            currentEnemyPool = enemyPoolThree;
        }
        else if(currentWave > poolThreeMaxWave)
        {
            currentEnemyPool = enemyPoolFour;
        }
        else if(currentWave > poolFourMaxWave)
        {
            currentEnemyPool = enemyPoolFinal;
        }


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
            spawner.startSpawning();
        }

        

    }

    private void changeSpawnPool()
    {
        
    } 



    private void nextWave()
    {
        currentWave += 1;
        spawner.resetEnemiesSpawned();
    }

    private void changeWave(int newWave)
    {
        currentWave = newWave;
    }


}
