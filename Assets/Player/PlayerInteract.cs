using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public GameObject gunModel;
    public Camera camera;
    
    public GameObject pauseMenu;
    private bool _inMenu;


    private void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !_inMenu)
        {

        }
    }



    public void ToggleMenu()
    {
        _inMenu = !_inMenu;
        if (_inMenu)
        {
            camera.GetComponent<PlayerLook>().mayLook = false;
            gameObject.GetComponent<PlayerMovement>().mayMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(_inMenu);
        }

        if (!_inMenu)
        {
            camera.GetComponent<PlayerLook>().mayLook = true;
            gameObject.GetComponent<PlayerMovement>().mayMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(_inMenu);
        }
    }
}
