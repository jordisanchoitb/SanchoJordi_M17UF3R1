using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour, PlayerControlers.IWeaponActions
{
    private PlayerControlers pControlers;

    private void Awake()
    {
        pControlers = new PlayerControlers();
        pControlers.Weapon.SetCallbacks(this);
    }

    private void OnEnable()
    {
        pControlers.Enable();
    }

    private void OnDisable()
    {
        pControlers.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject enemy = GameObject.Find("Enemy");
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().Hurt(10);
            }
        }
        
    }
}
