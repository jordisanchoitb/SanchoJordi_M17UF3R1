using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour, PlayerControlers.IWeaponActions
{
    private PlayerControlers pControlers;
    [SerializeField]
    private GameObject ObjectWeaponEquiped;
    [SerializeField]
    private GameObject weaponNonEquiped;
    private InputManager inputManager;
    public RawImage weaponImage;
    public bool weaponIsObtained = false;
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Transform aimDirection;


    private void Awake()
    {
        pControlers = new PlayerControlers();
        pControlers.Weapon.SetCallbacks(this);
        inputManager = GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        if (weaponIsObtained)
        {
            if (inputManager.isAiming)
            {
                ObjectWeaponEquiped.SetActive(true);
                weaponNonEquiped.SetActive(false);
            }
            else
            {
                ObjectWeaponEquiped.SetActive(false);
                weaponNonEquiped.SetActive(true);
            }
            weaponImage.gameObject.SetActive(true);

        }
    }

    private void OnEnable()
    {
        pControlers.Enable();
        weaponIsObtained = false;
    }

    private void OnDisable()
    {
        pControlers.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && weaponIsObtained && inputManager.isAiming)
        {
            GameObject arrowObj = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.LookRotation(aimDirection.forward));
            ArrowBullet arrow = arrowObj.GetComponent<ArrowBullet>();
            arrow.Launch(aimDirection.forward);
        }
    }
}
