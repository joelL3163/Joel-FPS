using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
