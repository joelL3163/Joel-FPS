using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class target : MonoBehaviour, IDamageable
{
    public float maxHealth;
    private float health;

    public Image healthbar;
    

    void Start()
    {
        health = maxHealth;
    }
    public void Hit(float damage)
    {

        health -= damage;
        if(health <= 0)
        {
            Die();
        }

        healthbar.transform.localScale = new Vector3(health / maxHealth,1,1);
    }

    public void Die() 
    {
        playerMovement.instance.points += 1;
        WaveSpawner.instance.enemiesAlive--;
        Destroy(gameObject);

    } 
}

