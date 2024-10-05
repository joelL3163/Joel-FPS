using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Wave System/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public GameObject prefab;
    public int amount;
    public float timeBetween;



}
