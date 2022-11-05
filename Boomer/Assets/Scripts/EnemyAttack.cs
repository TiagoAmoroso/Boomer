using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    /*
    Movement stops to attack
    Plays attack animation
    Lowers health of recipient
    */


    private void attack(Collision2D attackObject)
    {
        getComponent<enemyMovement>().changeSpeed(0);
        //Play animation
        attackObject.Health.die();
    }



    // Start is called before the first frame update
    private void Start()
    {
        enemyMovement = getComponent<enemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
