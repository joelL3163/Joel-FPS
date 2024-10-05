using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private float time = 0.0f;
    public List<WaveScriptableObject> waves;
    private int currentWaveIndex = 0;
    private int currentEnemyIndex = 0;
    private int currentEnemyCount = 0;
    private EnemyScriptableObject currentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        getCurrentEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > currentEnemy.timeBetween)
        {
            Instantiate(currentEnemy.prefab);
            currentEnemyCount++;
            time = 0;
        }
        if (currentEnemyCount >= currentEnemy.amount)
        {
            Debug.Log("Enemy Count reached: " + currentEnemy);
            if(currentEnemyIndex == waves[currentWaveIndex].enemies.Count -1)
            {
                //stops when it is the last wave

                Debug.Log("Last Enemy in wave: ");
                if (currentWaveIndex == waves.Count - 1)
                {
                    Debug.Log("last wave completed");
                    this.enabled = false;
                }
                // Go to next wave when last enemy
                else
                {
                    currentWaveIndex++;
                    currentEnemyIndex = 0;
                    getCurrentEnemy();
                }
            }
            else 
            {
                currentEnemyIndex++;
                currentEnemyCount = 0;
                getCurrentEnemy();
            }
        }
    }

    private void getCurrentEnemy()
    {
        currentEnemy = waves[currentWaveIndex].enemies[currentEnemyIndex];
    }
}
