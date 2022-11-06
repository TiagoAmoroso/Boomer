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

    private void Start()
    {
        currentWave = 0;
    }


    private void Update()
    {
        if(currentWave >= poolOneMaxWave)
        {
            currentEnemyPool = enemyPoolOne;
        }
    }

    private void nextWave()
    {
        currentWave += 1;
    }

    private void changeWave(int newWave)
    {
        currentWave = newWave;
    }


}
