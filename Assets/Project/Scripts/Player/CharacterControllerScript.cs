using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController controller = null;
    [SerializeField] private Transform cameraTransform = null;
    //Look Around Parameters
    public float mouseSensitivity = 100f;
    //Movement Prameters
    public bool activeMovement = true;
    public bool isMoving { get; private set; } = false;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float stopParameter = 0.2f;
    [SerializeField] private float returnMoveTime = 1.0f;
    private float moveTimer = 0.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveTimer = returnMoveTime;
    }


    private void Update()
    {
        //LOOK AROUND
        //Get Mouse input
        float mouseInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //Update Body Rotation
        transform.GetComponent<Transform>().Rotate(Vector3.up * mouseInput);

        //MOVEMENT
        if (activeMovement)
        {
            if (Mathf.Abs(mouseInput) < stopParameter)
            {
                moveTimer -= Time.deltaTime;
                if (moveTimer <= 0)
                {
                    controller.Move(transform.forward * speed * Time.deltaTime);
                    isMoving = true;
                }
            }
            else
            {
                moveTimer = returnMoveTime;
                isMoving = false;
            }
        }
    }
}
