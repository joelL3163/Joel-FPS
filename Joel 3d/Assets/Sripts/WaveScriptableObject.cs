using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "Wave System/Wave")]
public class WaveScriptableObject : ScriptableObject
{
    public List<EnemyScriptableObject> enemies;
}


