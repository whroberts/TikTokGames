using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Movement;
using Projectiles;
using Unity.VisualScripting;

namespace Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private Vector3 playerVelocity;
        [SerializeField] private bool groundedPlayer;
        [SerializeField] private float movementSpeed = 2.0f;
        [SerializeField] private float rotationSpeed = 2.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -9.81f;

        [Header("Projectile")]
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform shootPosition = null;
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private bool canFire = true;

        private InputManager inputManager = null;
        private CharacterController characterController = null;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (inputManager.DirectionVector.normalized.magnitude >= 0.1)
            {
                Move();
            }

            Rotate();

            ShootProjectile();
        }

        private void Move()
        {
            Vector3 move = inputManager.DirectionVector.y * transform.forward;

            characterController.Move(move * movementSpeed * Time.deltaTime);

            if (move != Vector3.zero)
            {
                //gameObject.transform.forward = move;
            }
        }

        private void Rotate()
        {
            Vector3 rotation = new Vector3(0, inputManager.Rotation, 0f) * rotationSpeed * Time.deltaTime;

            //transform.eulerAngles += rotation * rotationSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(rotation);
        }

        private void ShootProjectile()
        {
            if (inputManager.Shoot > 0 && canFire)
            {
                if (projectile != null)
                {
                    var instProjectile = Instantiate(projectile, transform.parent, true);
                    instProjectile.transform.localPosition = shootPosition.transform.position;
                    instProjectile.transform.rotation = shootPosition.transform.rotation;

                    instProjectile.GetComponent<PlayerProjectile>().CallShoot(transform.forward);
                    StartCoroutine(FireRateDelay());
                }
            }
        }

        private IEnumerator FireRateDelay()
        {
            canFire = false;
            yield return new WaitForSeconds(fireRate);
            canFire = true;
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
