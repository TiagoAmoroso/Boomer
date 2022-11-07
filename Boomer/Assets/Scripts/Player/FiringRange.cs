using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringRange : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;

    private Weapon currentWeapon;

    private void OnMouseDown()
    {
        currentWeapon = weaponManager.getCurrentWeapon();

        if(currentWeapon.isFireable())
        {
            currentWeapon.fire();
        }
    }
}
