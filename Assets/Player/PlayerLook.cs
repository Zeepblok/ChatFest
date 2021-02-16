using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerLook : NetworkBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerHead;
    public bool mayLook;

    private float xRotation = 0;
    // Start is called before the first frame update
    private void Start()
    {
        mayLook = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mayLook)
        {
            HandleLook();
        }

    }

    void HandleLook()
    {
        if (mayLook && isLocalPlayer)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerHead.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
