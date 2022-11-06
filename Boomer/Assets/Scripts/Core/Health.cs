using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    private void Update()
    {
        if(health <= 0)
        {
            die();
        }
    }

    public void removeHealth(int damage)
    {
        health -= damage;
    }

    public void addHealth(int additionalHealth)
    {
        health += additionalHealth;
    }

    public void die()
    {
        Debug.Log(gameObject.name + " Killed");
        /*
            plays death animation
        */
        gameObject.SetActive(false);
    }

    public int getHealth()
    {
        return health;
    }
}
