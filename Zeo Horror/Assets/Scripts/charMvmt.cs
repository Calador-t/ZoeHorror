﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class charMvmt : MonoBehaviour
{
    private float speed;
    private Vector3 currentVelocity;
    private CharacterController charController;
    public float gravity;
    
    private Vector3 movement() {
        Vector3 moveVector = Vector3.zero;

        moveVector += transform.forward * Input.GetAxis("Vertical");
        moveVector += transform.right * Input.GetAxis("Horizontal");
        moveVector *= speed;

        return moveVector;
    }

    void Start() {
        charController = gameObject.GetComponent<CharacterController>();
        currentVelocity = Vector3.zero;
        if (speed == 0) {
            speed = 3f;
        }
        if (gravity == 0) {
            gravity = 3f;
        }
    }

    void Update() {
        currentVelocity += new Vector3(0, -1, 0) * gravity * Time.deltaTime;
        charController.Move((currentVelocity + movement()) * Time.deltaTime);
        if (charController.isGrounded) {
            currentVelocity = Vector3.zero;
        }
    }
}