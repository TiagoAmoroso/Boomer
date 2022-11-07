using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int inactiveTransparency;
    [SerializeField] private int damage;
    [SerializeField] private float shotInterval;
    private Color inactiveColor = new Color(1,1,1,0);
    private Color activeColor = new Color(1,1,1,1);

    [Header("Stuff")]
    [SerializeField] private GameObject enemyHolder;
    [SerializeField] private GameObject fallbackEnemy;
    [SerializeField] private AudioClip attackSound;

    private int cost;
    private bool active = false;
    new private SpriteRenderer renderer;
    private float timeSinceLastShot;

    private void Start()
    {
        inactiveColor = new Color(1,1,1,(float)(inactiveTransparency)/100);
        renderer = GetComponent<SpriteRenderer>();
        timeSinceLastShot = shotInterval;
    }

    private void Update()
    {
        if(active)
        {
            renderer.color = activeColor;
        }
        else
        {
            renderer.color = inactiveColor;
        }

        if(active && timeSinceLastShot >= shotInterval)
        {
            fire(findClosestEnemy(enemyHolder));
        }

        timeSinceLastShot += Time.deltaTime;
    }


    private void OnMouseDown()
    {
        if(!active)
        {
            activate();

            Debug.Log(gameObject.name + " purchased");
        }
    }


    public void fire(GameObject enemy)
    {
        
        enemy.GetComponent<Health>().removeHealth(damage);

        Debug.Log(gameObject.name + " fired at " + enemy.gameObject.name);

        /*particles
        newEmitter = Instantiate(particleEmitter);
        newEmitter.transform.position = mousePos;
        */

        //sound

        timeSinceLastShot = 0;
    }


    private GameObject findClosestEnemy(GameObject enemies)
    {
        GameObject closestEnemy = fallbackEnemy;
        float myX;
        float closestX = -100;
        float xDiff;

        myX = gameObject.transform.position.x;

        //check trasforms of each... whichever is closest
        for (int i = 0; i< enemies.transform.childCount; i++)
        {
            if(enemies.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                xDiff = myX + enemies.transform.GetChild(i).transform.position.x;

                if(xDiff > closestX)
                {
                    closestEnemy = enemies.transform.GetChild(i).gameObject;
                    closestX = enemies.transform.GetChild(i).transform.position.x;
                }
            }
        }

        return closestEnemy;
    }


    private void activate()
    {
        active = true;
    }

    private void deactivate()
    {
        active = false;
    }
}
