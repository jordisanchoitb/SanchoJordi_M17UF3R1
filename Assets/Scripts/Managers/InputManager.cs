using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerControlers.IPlayerActions
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    private PlayerControlers pControlers;
    private Rigidbody rigidBody;
    [NonSerialized] public Vector3 inputMovement;

    private void Awake()
    {
        pControlers = new PlayerControlers();
        rigidBody = GetComponent<Rigidbody>();
        pControlers.Player.SetCallbacks(this);
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void OnEnable()
    {
        pControlers.Enable();
    }

    private void OnDisable()
    {
        pControlers.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector3>();
    }

    public void Movement()
    {
        rigidBody.MovePosition(rigidBody.position + speed * Time.deltaTime * inputMovement.normalized);
    }
}
