using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public CharacterController2D controller;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    internal void IncreaseSpeedBy(float speedScaler)
    {
        runSpeed *= speedScaler;
    }

    internal void DecreaseSpeedBy(float speedScaler)
    {
        runSpeed /= speedScaler;
    }
}
