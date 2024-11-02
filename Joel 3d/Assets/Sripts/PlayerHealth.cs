using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
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
