using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaveScriptableObject
{
    public List<EnemyScriptableObject> enemies;

    public WaveScriptableObject(List<EnemyScriptableObject> _enemies)
    {
        enemies = _enemies;
    }
}


