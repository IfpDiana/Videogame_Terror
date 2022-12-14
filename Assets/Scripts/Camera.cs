using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public PlayerController player;
    public float mouseSens = 1000f;
    public float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        yRotation -= mouseY;
        if (yRotation >= 120)
        {
            yRotation = 120;
        }
        if (yRotation <= 30)
        {
            yRotation = 30;
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(yRotation, 0, 0), 1);
        player.transform.Rotate(Vector3.up * mouseX);
    }
}
