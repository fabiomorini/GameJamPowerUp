﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController controller = null;
    //Look Around Parameters
    public float mouseSensitivity = 100f;
    //Movement Prameters
    public bool activeMovement = true;
    public bool isMoving { get; private set; } = false;
    private bool move = true;
    private bool obstacleLooking = false;
    private bool touchingCollision = false;
    [SerializeField] private float speed = 12f;
    private float currentSpeed = 0f;
    [SerializeField] private float stopParameter = 0.2f;
    [SerializeField] private float returnMoveTime = 1.0f;
    private float moveTimer = 0.0f;
    private Vector3 velocity = Vector3.one;

    private HeadBobber bobbing = null;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        bobbing = GetComponentInChildren<HeadBobber>();
        moveTimer = returnMoveTime;
        currentSpeed = speed;
    }


    private void Update()
    {
        //LOOK AROUND
        //Get Mouse input
        float mouseInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //Update Body Rotation
        transform.GetComponent<Transform>().Rotate(Vector3.up * mouseInput);

        //Set Movement vector
        Vector3 movementVec = transform.forward * currentSpeed * Time.deltaTime;

        //OBSTACLE SLOW DOWN
        if (touchingCollision)
        {
            if (obstacleLooking)
            {
                move = false;
            }
            else
            {
                move = true;
                touchingCollision = false;
            }
        }

        //MOVEMENT
        if (activeMovement)
        {
            Movement(mouseInput, movementVec);
        }


    }

    private void Movement(float mouse, Vector3 movementVec)
    {
        if (Mathf.Abs(mouse) < stopParameter && move)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0)
            {
                controller.Move(movementVec);
                isMoving = true;
            }
        }
        else
        {
            moveTimer = returnMoveTime;
            isMoving = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            if (Physics.Raycast(transform.position, transform.forward, LayerMask.NameToLayer("Obstacle")))
            {
                Debug.DrawLine(transform.position, other.transform.position, Color.red);
                obstacleLooking = true;
                currentSpeed = speed / 2;
                bobbing.currentWalkingBobbingSpeed = bobbing.walkingBobbingSpeed / 2;
            }
            else
            {
                obstacleLooking = false;
                currentSpeed = speed;
                bobbing.currentWalkingBobbingSpeed = bobbing.walkingBobbingSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            obstacleLooking = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            touchingCollision = true;
        }
        else
        {
            touchingCollision = false;
        }
    }
}
