using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRanged : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 speed;
    public float rotationSpeed;
    public float acceleration;
    public float maxSpeed;
    public float playerRadius;
    public float fireRate;
    private float timer;
    public float offset;
    public Rigidbody rb;
    private playerMovement player;
    public GameObject bulletPrefab;

    void Start()
    {
        player = playerMovement.instance;
        timer = 1 / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float distanceFromPlayer = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.z - transform.position.z, 2));


        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
        float verticalAngle = -1*(Mathf.Atan2((transform.position.y - player.transform.position.y - offset), distanceFromPlayer) * Mathf.Rad2Deg);

        //Debug.Log("Enemy" + direction);
        transform.eulerAngles = new Vector3(0, angle, verticalAngle);



        if (distanceFromPlayer <= playerRadius)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1 / fireRate;
                Instantiate(bulletPrefab, transform);
            }


            speed += acceleration * transform.forward;
            if (speed.magnitude >= maxSpeed)
            {
                speed = maxSpeed * transform.forward;
            }



            rb.velocity = speed;
            return;
        }

        timer = 1 / fireRate;
        speed += acceleration * direction;


        if (speed.magnitude >= maxSpeed)
        {
            speed = maxSpeed * direction;
        }


        rb.velocity = speed;




    }
}
