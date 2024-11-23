using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaveDirector : MonoBehaviour
{
    public List<EnemyScriptableObject> possibleEnemies;
    public List<EnemyScriptableObject> boughtList;
    public int credits;
    public int waveNumber;
    public int baseCredits;
    public int creditsPerWave;
    public static WaveDirector instance;

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

    // Start is called before the first frame update
    void Start()
    {
        PurchaseWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PurchaseWave ()
    {
        credits = baseCredits+(waveNumber * creditsPerWave);
        List<EnemyScriptableObject> boughtEnemies = new List<EnemyScriptableObject>();
        List<EnemyScriptableObject> affordable = new List<EnemyScriptableObject>();
        while (true)
        {
            affordable.Clear();
            for(int i = 0; i < possibleEnemies.Count; i++)
            {
                if(credits - possibleEnemies[i].cost >= 0)
                {
                    affordable.Add(possibleEnemies[i]);
                    Debug.Log("Enemies affordable " + affordable);
                }
                
            }
            if(affordable.Count == 0)
            {
                break;
            }
            int randomIndex = Random.Range(0, affordable.Count);
            boughtEnemies.Add(affordable[randomIndex]);
            credits -= affordable[randomIndex].cost;
        }
        boughtList = boughtEnemies;
    }
}
