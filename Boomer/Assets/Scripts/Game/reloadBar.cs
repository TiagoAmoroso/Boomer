using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reloadBar : MonoBehaviour
{
    [SerializeField] private Image fullBar;
    [SerializeField] private Image currentBar;
    [SerializeField] private WeaponManager weaponManager;

    private Weapon currentWeapon;

    private void Start()
    {
        currentWeapon = weaponManager.fallbackWeapon;
        fullBar.fillAmount = currentWeapon.getShotInterval() / currentWeapon.getShotInterval();
    }

    private void Update()
    {
        currentWeapon = weaponManager.getCurrentWeapon();

        if(currentWeapon.getTimeSinceLastShot() > 0)
        {
            currentBar.fillAmount = currentWeapon.getTimeSinceLastShot() / currentWeapon.getShotInterval();
        }
        
    }
}
