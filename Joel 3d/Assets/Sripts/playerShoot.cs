using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform camera;
    public LayerMask targetLayer;
    public float damage = 1;
    public ParticleSystem particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            Debug.Log(Physics.Raycast(camera.position, camera.forward, targetLayer));
            if(Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, 1000f, targetLayer))
            {
                hit.transform?.GetComponent<IDamageable>().Hit(damage);
               
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            particles.Play();

        }
        if(Input.GetMouseButtonUp(0))
        {
            particles.Stop();
        }

    }
}
