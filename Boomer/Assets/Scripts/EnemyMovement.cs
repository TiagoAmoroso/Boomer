using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    new private Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void changeSpeed(int newSpeed)
    {
        speed = newSpeed;
    }
}
