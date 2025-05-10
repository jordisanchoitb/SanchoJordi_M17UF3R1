using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowObjectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WeaponManager player))
        {
            player.weaponIsObtained = true;
            Destroy(gameObject);
        }
    }
}
