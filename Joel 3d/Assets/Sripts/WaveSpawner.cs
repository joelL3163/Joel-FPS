using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    private float time = 0.0f;
    public float waitTime = 3;

    // Wave spawning
    public List<WaveScriptableObject> waves;
    private int currentWaveIndex = 0, currentEnemyIndex = 0, currentEnemyCount = 0;
    public int enemiesAlive = 0;
    private bool running;
    private EnemyScriptableObject currentEnemy;
    public GameObject upgradeMenu;

    

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        running = true;
        getCurrentEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            return;
        }
        time += Time.deltaTime;
        if (time > currentEnemy.timeBetween)
        {
            Instantiate(currentEnemy.prefab);
            enemiesAlive++;
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
                    StartCoroutine(WaitForNextWave(waitTime));
                    
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

    public IEnumerator WaitForNextWave(float seconds)
    {
        running = false;
        while(enemiesAlive > 0)
        {
            yield return null;
        }
        upgradeMenu.SetActive(true);
        
        while (upgradeMenu.activeSelf)
        {
            yield return null;
        }
        yield return new WaitForSecondsRealtime(seconds);
        currentWaveIndex++;
        currentEnemyIndex = 0;
        getCurrentEnemy();
        running = true;
    }
    private void getCurrentEnemy()
    {
        currentEnemy = waves[currentWaveIndex].enemies[currentEnemyIndex];
    }
}
