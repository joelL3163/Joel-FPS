using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    float timeRunning = 0f;
    public float spawnTime = 1f;
    public GameObject targetPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeRunning += Time.deltaTime;
        if(timeRunning > spawnTime)
        {
            timeRunning = 0f;
            GameObject target = Instantiate(targetPrefab);
            target.transform.position = new Vector3(Random.Range(1, 10), Random.Range(1,5), Random.Range(1, 10));
        }
    }
}
