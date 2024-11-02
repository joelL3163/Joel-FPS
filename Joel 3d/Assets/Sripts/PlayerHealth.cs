using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHealth { get; private set; } = 100;
public float currentHealth { get; private set; }
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
    }
    public void Heal(float healthGained)
    {
        currentHealth = Mathf.Clamp((currentHealth + healthGained),0,maxHealth);
        
    }
    public void Hit(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log(currentHealth);
    }

    public void Die()
    {
        Debug.Log("You died");
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        EnemyProjectile bulletCollision = collision.gameObject.GetComponent<EnemyProjectile>();
        if (bulletCollision != null)
        {
            Hit(bulletCollision.damage);
            Destroy(bulletCollision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyProjectile bulletCollision = other.gameObject.GetComponent<EnemyProjectile>();
        if (bulletCollision != null)
        {
            Hit(bulletCollision.damage);
            Destroy(bulletCollision.gameObject);
        }
    }
    */

}
