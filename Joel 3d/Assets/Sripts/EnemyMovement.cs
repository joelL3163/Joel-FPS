using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 speed;
    public float rotationSpeed;
    public float acceleration;
    public float maxSpeed;

    public Rigidbody rb;
    private playerMovement player;

    void Start()
    {
        player = playerMovement.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        speed += acceleration * direction; 
        if(speed.magnitude >= maxSpeed)
        {
            speed = maxSpeed*direction;
        }
        
        
        rb.velocity = speed;


        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
        //Debug.Log("Enemy" + direction);
        transform.eulerAngles = new Vector3(0,angle,0);
        
    }
}
