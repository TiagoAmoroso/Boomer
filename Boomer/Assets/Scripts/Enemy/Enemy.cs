using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;
    private int damage;

    [SerializeField] private WeaponManager weaponManager;
    private Weapon currentWeapon;

    private void Start()
    {
        health = GetComponent<Health>();
        damage = 10;
    }

    private void OnMouseDown()
    {
        currentWeapon = weaponManager.getCurrentWeapon();

        if(currentWeapon.isFireable())
        {
            damage = currentWeapon.getDamage();
            health.removeHealth(damage);
           
            currentWeapon.resetTimeSinceLastShot();
        }
    }
}
