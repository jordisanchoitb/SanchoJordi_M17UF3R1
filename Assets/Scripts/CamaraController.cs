using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraController : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 1.0f;
    private readonly float MAX_X_ROTATION = 45f;
    private readonly float MIN_X_ROTATION = -45f;
    private Vector3 mousePosition;

    private void Awake()
    {
        mousePosition = Input.mousePosition;
        player = gameObject.transform;

        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (mousePosition.x > MAX_X_ROTATION)
            mousePosition.x = MAX_X_ROTATION;
        else if (mousePosition.x < MIN_X_ROTATION)
            mousePosition.x = MIN_X_ROTATION;

        player.Rotate(Vector3.up * (sensitivity * Input.GetAxis("Mouse X")));
        player.Rotate(Vector3.left * (sensitivity * Input.GetAxis("Mouse Y")));
        player.localEulerAngles = new Vector3(player.localEulerAngles.x, player.localEulerAngles.y, 0);

    }
}
