using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public float sensitivity = 14f;
    float rotationX = 0f;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX -= mouseY;
        Player.Rotate(Vector3.up*mouseX);
        transform.localRotation = Quaternion.Euler(rotationX,0f,0f);
    }
}
