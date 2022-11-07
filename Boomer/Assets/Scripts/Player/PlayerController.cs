using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody2D body;
    private float horizontalInput;
    private float verticalInput;
    private float horizontalVelocity;
    private float verticalVelocity;
    private Vector2 newVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = speed * 100;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        horizontalVelocity = (horizontalInput * speed * Time.deltaTime);
        verticalVelocity = (verticalInput * speed * Time.fixedDeltaTime);
    }


    private void FixedUpdate()
    {
        newVelocity = new Vector2(horizontalVelocity, verticalVelocity);
        newVelocity.Normalize();
    
        body.velocity = newVelocity;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Boomer colliding with: " + collision.collider.transform.name);
    }
}
