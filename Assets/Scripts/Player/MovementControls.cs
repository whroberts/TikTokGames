using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class MovementControls : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private MovementInput movementInput = null;

    private Vector2 directionVector = Vector2.zero;
    public Vector2 DirectionVector => directionVector;

    private float jump = 0;
    public float Jump => jump;

    private Vector2 lookVector = Vector2.zero;
    public Vector2 LookVector => lookVector;

    private float rotation = 0;
    public float Rotation => rotation;

    private PlayerInput playerInput;

    private void Awake()
    {
        movementInput = new MovementInput();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        movementInput.Enable();
    }

    private void OnDisable()
    {
        movementInput.Disable();
    }

    private void Start()
    {
        movementInput.Player.Move.actionMap.actionTriggered += context => ReadDirection(context);
        movementInput.Player.Jump.actionMap.actionTriggered += context => ReadJump(context);
        movementInput.Player.Look.actionMap.actionTriggered += context => ReadLook(context);
        movementInput.Player.Rotate.actionMap.actionTriggered += context => ReadRotation(context);
    }

    private void ReadDirection(InputAction.CallbackContext context)
    {
        directionVector = movementInput.Player.Move.ReadValue<Vector2>();

        //Debug.Log("Direction Vector: " + directionVector);
    }

    private void ReadJump(InputAction.CallbackContext context)
    {
        jump = movementInput.Player.Jump.ReadValue<float>();
    }

    private void ReadLook(InputAction.CallbackContext context)
    {
        lookVector = movementInput.Player.Look.ReadValue<Vector2>();
    }

    private void ReadRotation(InputAction.CallbackContext context)
    {
        rotation = movementInput.Player.Rotate.ReadValue<float>();
    }
}
