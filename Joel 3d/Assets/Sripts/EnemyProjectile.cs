using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;
    private Transform enemy;

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
    }
}
