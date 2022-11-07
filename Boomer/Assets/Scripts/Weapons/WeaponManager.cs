using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Weapon fallbackWeapon;
    [SerializeField] private Collider2D firingRange;

    private void Start()
    {
        deactivateAllWeapons();

        fallbackWeapon.activate();
    }

    public Weapon getCurrentWeapon()
    {
        for (int i = 0; i< gameObject.transform.childCount; i++)
        {

            if(gameObject.transform.GetChild(i).GetComponent<Weapon>().getActive())
            {
                return gameObject.transform.GetChild(i).GetComponent<Weapon>();
            }
        }

        return fallbackWeapon;

    }

    public void deactivateAllWeapons()
    {
        for (int i = 0; i< gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<Weapon>().deactivate();
        }
    }
}
