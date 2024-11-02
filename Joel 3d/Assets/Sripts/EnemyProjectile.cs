using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;
    private Transform enemy;
    private float timeAlive;
    public float lifetime = 10;
    public float damage = 1;
    public Rigidbody rb;
    // Start is called before the first frame update



    void Start()
    {
        enemy = transform.parent;
        transform.forward = enemy.right;
        transform.parent = null;
     
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        timeAlive += Time.deltaTime;
        if (timeAlive > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.Hit(damage);
            Destroy(gameObject);
        }
    }
}
