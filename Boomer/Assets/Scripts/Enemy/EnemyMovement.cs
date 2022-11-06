using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    new private Transform transform;

    [SerializeField] private int speed;

    private bool moving = true;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(moving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void stopMoving()
    {
        moving = false;
    }

    public void startMoving()
    {
        moving = true;
    }

    public void changeSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
