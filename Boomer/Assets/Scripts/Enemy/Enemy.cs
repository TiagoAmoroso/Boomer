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
        damage = currentWeapon.getDamage();
        //Play sound
        //Spawn particles

        health.removeHealth(damage);
    }
}
