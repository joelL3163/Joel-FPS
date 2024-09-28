using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = .225f;
    public float jumpForce = 5;
    public float floorDistance = 1.5f;
    private bool grounded;

    public int points = 0;
    public TextMeshProUGUI scoreText;

    private Transform camera;
    public Rigidbody rb;
    public Transform capsule;

    public LayerMask groundLayer;

    public static playerMovement instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }


    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        float _speed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed *= 1.5f;
        }

        rb.velocity = camera.right*xInput*_speed + new Vector3(camera.forward.x,0,camera.forward.z).normalized * yInput * _speed + Vector3.up * rb.velocity.y;

        Debug.Log("Player" + rb.velocity);

        GroundedCheck();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            capsule.localScale = new Vector3(1,.5f,1);
            if (grounded)
            {
                rb.AddForce(Vector3.down * 5, ForceMode.Impulse);
            }
            
        } else
        {
            capsule.localScale = Vector3.one;
        }

        scoreText.text = "Points: " + points;

    }

    void GroundedCheck()
    {
        Debug.DrawRay(transform.position, Vector3.down * floorDistance, Color.red);
        grounded = Physics.Raycast(transform.position, Vector3.down, floorDistance, groundLayer);
    }
}
