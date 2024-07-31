using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Movement
{
    public class InputManager : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private PlayerInputSystem playerInputSystem = null;

        private Vector2 directionVector = Vector2.zero;
        public Vector2 DirectionVector => directionVector;

        private float jump = 0;
        public float Jump => jump;

        private Vector2 lookVector = Vector2.zero;
        public Vector2 LookVector => lookVector;

        private float rotation = 0;
        public float Rotation => rotation;

        private float shoot = 0;
        public float Shoot => shoot;

        private PlayerInput playerInput;

        private void Awake()
        {
            playerInputSystem = new PlayerInputSystem();
            playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            playerInputSystem.Enable();
        }

        private void OnDisable()
        {
            playerInputSystem.Disable();
        }

        private void Start()
        {
            playerInputSystem.Player.Move.actionMap.actionTriggered += ReadDirection;
            playerInputSystem.Player.Jump.actionMap.actionTriggered += ReadJump;
            playerInputSystem.Player.Look.actionMap.actionTriggered += ReadLook;
            playerInputSystem.Player.Rotate.actionMap.actionTriggered += ReadRotation;
            playerInputSystem.Player.Shoot.actionMap.actionTriggered += ReadShoot;
        }

        private void ReadDirection(InputAction.CallbackContext context)
        {
            directionVector = playerInputSystem.Player.Move.ReadValue<Vector2>();

            //Debug.Log("Direction Vector: " + directionVector);
        }

        private void ReadJump(InputAction.CallbackContext context)
        {
            jump = playerInputSystem.Player.Jump.ReadValue<float>();
        }

        private void ReadLook(InputAction.CallbackContext context)
        {
            lookVector = playerInputSystem.Player.Look.ReadValue<Vector2>();
        }

        private void ReadRotation(InputAction.CallbackContext context)
        {
            rotation = playerInputSystem.Player.Rotate.ReadValue<float>();
        }

        private void ReadShoot(InputAction.CallbackContext context)
        {
            shoot = playerInputSystem.Player.Shoot.ReadValue<float>();
        }
    }
}