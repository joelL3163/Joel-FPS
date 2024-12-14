using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class advancedEnemy : MonoBehaviour, IDamageable
{
    public enum states 
    {
        strafe,
        spin
    }

    //references
    private playerMovement player;
    private Rigidbody rb;

    //health
    public float maxHealth;
    private float currentHealth;
    
    //states
    public states initialState;
    private states currentState;
    public float stateUptime;
    
    //strafe state
    public float strafeTime;
    private int strafeDirection = 1;
    public float strafeSpeed;
    private float randomStrafeTime;
    
    //spin state
    public float spinSpeed;
    private float initial;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        changeState(initialState);
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }

    public void Hit(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = playerMovement.instance;
    }

    // Update is called once per frame
    void Update()
    {
        stateUptime += Time.deltaTime;



        switch (currentState)
        {
            case states.strafe:
                strafeUpdate();
                break;
            case states.spin:
                spinUpdate();
                break;
        }
    }

    public void changeState(states state)
    {
        currentState = state;
        stateUptime = 0;

        switch (state)
        {
            case states.strafe:
                strafeEnter();
                break;
            case states.spin:
                spinEnter();
                break;
        }


    }
    

    public void strafeEnter()
    {
        strafeTime = 0;
        randomStrafeTime = Random.Range(0.5f, 3f);
    }
    public void spinEnter()
    {
        initial = 0;
        rb.velocity = Vector3.zero;
    }



    public void strafeUpdate()
    {
        Debug.Log("Strafe");
        strafeTime += Time.deltaTime;

        Vector3 direction = (player.transform.position - transform.position).normalized;


        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
        //Debug.Log("Enemy" + direction);
        transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y,angle,.1f), 0);


        rb.velocity = transform.forward*strafeSpeed * strafeDirection;
        
        

        if (strafeTime > randomStrafeTime)
        {
            strafeDirection *= -1;
            strafeTime = 0;
            randomStrafeTime = Random.Range(0.5f, 3f);
        }



        //end state
        if (stateUptime >= 5)
        {
            changeState(states.spin);
        }
    }

    public void spinUpdate()
    {
        Debug.Log("spin");
        
        float angle = transform.eulerAngles.y + spinSpeed;
        initial += spinSpeed;
        transform.eulerAngles = new Vector3(0, angle, 0);


        //end state
        if (initial > 360)
        {
            changeState(states.strafe);
            
        }
    }
}
