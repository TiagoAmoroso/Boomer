using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    [SerializeField] private int damage;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Property")
        {
            attack(collision);
        }
    }


    private void attack(Collision2D collision)
    {
        GetComponent<EnemyMovement>().changeSpeed(0);
        //Play animation
        collision.collider.transform.GetComponent<Health>().removeHealth(damage);
        Debug.Log(collision.collider.transform.GetComponent<Health>().getHealth());
    }

}
