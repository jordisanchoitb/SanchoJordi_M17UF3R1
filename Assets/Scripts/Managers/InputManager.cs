using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerControlers.IPlayerActions
{
    [Header("Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float groundCheckDistance = 0.5f;
    [SerializeField] private LayerMask groundLayer;
    private float initialSpeed;
    private PlayerControlers pControlers;
    private Rigidbody rigidBody;
    [NonSerialized] public Vector3 inputMovement;
    [NonSerialized] public bool isRun;
    [NonSerialized] public bool isDance;
    [NonSerialized] public bool isAiming;
    [NonSerialized] public bool isJumping;
    [NonSerialized] public bool isCrouching;

    private void Awake()
    {
        pControlers = new PlayerControlers();
        rigidBody = GetComponent<Rigidbody>();
        pControlers.Player.SetCallbacks(this);
        isRun = false;
        isDance = false;
        initialSpeed = speed;
    }
    private void FixedUpdate()
    {
        if (!isDance)
        {    
            Movement();
            Iaming();
            Jump();
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
    public void Movement()
    {
        if (!isCrouching)
            ChangeSpeedRun();
        rigidBody.MovePosition(rigidBody.position + speed * Time.deltaTime * inputMovement.normalized);
    }
    public void Jump()
    {
        if (isJumping && IsGrounded())
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void ChangeSpeedRun()
    {
        if (isRun)
            speed = initialSpeed * speedMultiplier;
        else
            speed = initialSpeed;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void Iaming()
    {
        if (isAiming)
        {
            GetComponent<CameraManager>().SwitchCamera("FirstPerson");
        }
        else
        {
            GetComponent<CameraManager>().SwitchCamera("ThirdPerson");
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector3>();
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

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed)
            isAiming = true;
        else if (context.canceled)
            isAiming = false;
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isCrouching)
            {
                isCrouching = true;
                speed /= 3f;
            }
            else
            {
                isCrouching = false;
                speed = initialSpeed;
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        } 
        else if (context.canceled)
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
