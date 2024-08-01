using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Player.Movement;
using Projectiles;

namespace Player
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        [Header("Values")]
        [SerializeField] private Vector3 playerVelocity;
        [SerializeField] private bool groundedPlayer;
        [SerializeField] private float movementSpeed = 2.0f;
        [SerializeField] private float rotationSpeed = 2.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -9.81f;

        private InputManager inputManager = null;
        public InputManager InputManager => inputManager;
        private CharacterController characterController = null;

        private float health = 100f;

        public delegate void PlayerMovedEventHandler();
        public event PlayerMovedEventHandler OnPlayerMoved;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (inputManager.DirectionVector.normalized.magnitude >= 0.1)
            {
                Move();
            }

            Rotate();
        }

        private void Move()
        {
            Vector3 move = inputManager.DirectionVector.y * transform.forward;

            characterController.Move(move * movementSpeed * Time.deltaTime);

            if (move != Vector3.zero)
            {
                //gameObject.transform.forward = move;
            }

            if (OnPlayerMoved != null)
                OnPlayerMoved();
        }

        private void Rotate()
        {
            Vector3 rotation = new Vector3(0, inputManager.Rotation, 0f) * rotationSpeed * Time.deltaTime;

            //transform.eulerAngles += rotation * rotationSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(rotation);
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void DealDamage(float damage)
        {

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
}
