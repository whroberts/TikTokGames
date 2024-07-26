using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float movementSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private MovementControls movementControls = null;
    private CharacterController characterController = null;

    private void Awake()
    {
        movementControls = GetComponent<MovementControls>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (movementControls.DirectionVector.normalized.magnitude >= 0.1)
        {
            Move();
        }

        Rotate();

        //Jump();
    }

    private void Move()
    {
        Vector3 move = movementControls.DirectionVector.y * transform.forward;

        characterController.Move(move * movementSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
        }
    }

    private void Rotate()
    {
        Vector3 rotation = new Vector3(0,movementControls.Rotation, 0f) * rotationSpeed * Time.deltaTime;

        //transform.eulerAngles += rotation * rotationSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(rotation);
    }

    /*
    private void Jump()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Changes the height position of the player..
        if (movementControls.Jump > 0 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    */
}
