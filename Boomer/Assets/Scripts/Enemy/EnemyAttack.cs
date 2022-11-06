using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private float timeSinceLastAttack;
    private bool attacking = false;
    private Collision2D attackObject;

    [Header("Settings")]
    [SerializeField] private int damage;
    [SerializeField] private float attackInterval;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        timeSinceLastAttack = attackInterval;
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        if(attacking)
        {
            enemyMovement.stopMoving();
            attack(attackObject);
        }
        else
        {
            enemyMovement.startMoving();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Property")
        {
            attacking = true;
            attackObject = collision;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Property")
        {
            attacking = false;
        }
    }


    private void attack(Collision2D collision)
    {
        if(timeSinceLastAttack >= attackInterval)
        {
            Debug.Log("Attacking");
            //Play animation
            collision.collider.transform.GetComponent<Health>().removeHealth(damage);
            timeSinceLastAttack = 0;
            Debug.Log(collision.collider.transform.GetComponent<Health>().getHealth());
        }
    }

}
