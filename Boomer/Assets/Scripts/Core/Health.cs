using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    private void removeHealth(int damage)
    {
        health -= damage;
    }

    private void addHealth(int additionalHealth)
    {
        health += additionalHealth;
    }

    private void die()
    {
        consolde.log("Killed")
        /*
            plays death animation
            Destroys object
        */
    }

    public int getHealth()
    {
        return health;
    }
}
