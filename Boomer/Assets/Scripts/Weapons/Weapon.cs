using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private int damage;
    [SerializeField] private float inactiveTransparency;

    new private SpriteRenderer renderer;

    private bool active = false;

    private void Start()
    {
        //inactiveTransparency = Mathf.Clamp(inactiveTransparency, 0, 255);
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(active)
        {
            renderer.color = new Color (255, 255, 255, 255);
        }
        else
        {
            renderer.color = new Color (255, 255, 255, inactiveTransparency/100);
        }
    }

    private void OnMouseDown()
    {
        weaponManager.deactivateAllWeapons();

        activate();

        Debug.Log(gameObject.name + " is in use");
    }

    public bool getActive()
    {
        return active;
    }

    public void deactivate()
    {
        active = false;
    }

    public void activate()
    {
        active = true;
    }

    public int getDamage()
    {
        return damage;
    }
}
