using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    private float time = 0.0f;
    public float waitTime = 3;

    // Wave spawning
    public List<WaveScriptableObject> waves;
    private int currentEnemyIndex = 0, currentEnemyCount = 0;
    public int enemiesAlive = 0;
    public Vector3 spawnPosition;
    private bool running;
    public WaveScriptableObject currentWave;
    private EnemyScriptableObject currentEnemy;
    public GameObject upgradeMenu;
    public Vector3 cube;



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
            Instantiate(currentEnemy.prefab, spawnPosition, Quaternion.identity);
            enemiesAlive++;
            currentEnemyCount++;
            time = 0;
        }
        if (currentEnemyCount >= currentEnemy.amount)
        {
            Debug.Log("Enemy Count reached: " + currentEnemy);
            if(currentEnemyIndex == currentWave.enemies.Count -1)
            {
                //stops when it is the last wave

                Debug.Log("Last Enemy in wave: ");
               /* if (currentWaveIndex == waves.Count - 1)
                {
                    Debug.Log("last wave completed");
                    this.enabled = false;
                }*/

                // Go to next wave when last enemy
                /*else
                {
                    StartCoroutine(WaitForNextWave(waitTime));
                    
                }*/
                StartCoroutine(WaitForNextWave(waitTime));
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
        currentEnemyIndex = 0;
        currentEnemyCount = 0;
        WaveDirector.instance.purchaseNext();
    }
    private void getCurrentEnemy()
    {
        currentEnemy = currentWave.enemies[currentEnemyIndex];
        spawnPosition = transform.position + new Vector3(Random.Range(-cube.x/2,cube.x/2), Random.Range(-cube.y / 2, cube.y / 2), Random.Range(-cube.z / 2, cube.z / 2));
    }

    public void spawnWave(WaveScriptableObject wave)
    {
        currentWave = wave;
        running = true;
        getCurrentEnemy();


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, cube);
    }



}


    