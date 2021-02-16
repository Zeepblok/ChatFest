using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 12f;
    private float _gravity = 3f;
    public bool mayMove;


    public AudioClip step;
    private AudioSource _audioSource;
    private bool _mayPlayStep;

    private CharacterController _controller;
    private Vector3 _move = Vector3.zero;

    private void Start()
    {
        _mayPlayStep = true;
        mayMove = true;
        _controller = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isLocalPlayer && mayMove)
        {
            if (_controller.isGrounded)
            {
               
                float x = Input.GetAxisRaw("Horizontal");
                float z = Input.GetAxisRaw("Vertical");
                _move = transform.right * x + transform.forward * z;
                _move.Normalize();
                
                
            }
            _move.y -= _gravity;
            _controller.Move(_move * (moveSpeed * Time.deltaTime));

            if (_controller.velocity.magnitude >= 1)
            {
                if (_mayPlayStep)
                {
                    _mayPlayStep = false;
                    //_audioSource.PlayOneShot(step);
                    StartCoroutine(StepTimer(0.3f));
                }
            }
        }
    }

    
    IEnumerator StepTimer(float time)
    {
        yield return new WaitForSeconds(time);
        _mayPlayStep = true;
    }

}
