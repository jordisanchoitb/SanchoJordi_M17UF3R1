using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out WeaponManager weaponManagerPlayer))
        {
            if (weaponManagerPlayer.weaponIsObtained)
            {
                GetComponent<Animator>().SetBool("OpenDoor", true);
            }
        }
    }
}
