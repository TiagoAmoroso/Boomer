using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private int damage;
    [SerializeField] private float shotInterval;
    [SerializeField] private float inactiveTransparency;

    new private SpriteRenderer renderer;
    private Vector2 mousePos;


    private float timeSinceLastShot;
    private bool active = false;
    private bool fireable = true;

    [Header("Particles")]
    [SerializeField] private GameObject particleEmitter;
    private GameObject newEmitter;

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

        if(timeSinceLastShot >= shotInterval)
        {
            fireable = true;
        }
        else
        {
            fireable = false;
        }

        timeSinceLastShot += Time.deltaTime;
    }

    public void resetTimeSinceLastShot()
    {
        timeSinceLastShot = 0;
    }

    private void OnMouseDown()
    {
        weaponManager.deactivateAllWeapons();

        activate();

        Debug.Log(gameObject.name + " is in use");
    }

    public void fire()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(gameObject.name + " fired!");

        //particles
        newEmitter = Instantiate(particleEmitter);
        newEmitter.transform.position = mousePos;

        //sound
        SoundManager.instance.PlaySound(attackSound);

        resetTimeSinceLastShot();
    }


    public bool isFireable()
    {
        return fireable;
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
