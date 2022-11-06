using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health health;
    private int damage;

    private void Start()
    {
        health = GetComponent<Health>();
        damage = 10;
    }

    private void OnMouseDown()
    {
        //Get weapon Object
        //Use weapon details to determine damage etc...

        health.removeHealth(damage);
    }
}
