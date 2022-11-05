using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;

    private void removeHealth(int damage)
    {
        health -= damage;
    }

    public void addHealth(int additionalHealth)
    {
        health += additionalHealth;
    }

    public int getHealth()
    {
        return health;
    }
}
