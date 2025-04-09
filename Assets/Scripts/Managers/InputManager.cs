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
    [NonSerialized] public bool isRun;
    [NonSerialized] public bool isDance;

    private void Awake()
    {
        pControlers = new PlayerControlers();
        rigidBody = GetComponent<Rigidbody>();
        pControlers.Player.SetCallbacks(this);
        isRun = false;
        isDance = false;
    }
    private void FixedUpdate()
    {
        if (!isDance)
        {    
           Movement();
        }
    }

    private void OnEnable()
    {
        pControlers.Enable();
    }

    private void OnDisable()
    {
        pControlers.Disable();
        isRun = false;
        isDance = false;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector3>();
    }

    public void Movement()
    {
        rigidBody.MovePosition(rigidBody.position + speed * Time.deltaTime * inputMovement.normalized);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed) 
            isRun = true;
        else if (context.canceled) 
            isRun = false;
    }

    public void OnDance(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            if (!isDance) 
                isDance = true;
            else 
                isDance = false;
        }
    }
}
