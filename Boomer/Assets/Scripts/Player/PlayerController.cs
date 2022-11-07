using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite idleSprite;
    
    private Rigidbody2D body;
    private Animator animator;
    new private SpriteRenderer renderer;
    private float horizontalInput;
    private float verticalInput;
    private float horizontalVelocity;
    private float verticalVelocity;
    private Vector2 newVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        speed = speed * 100;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = Vector3.one;
        }

        horizontalVelocity = (horizontalInput * speed * Time.deltaTime);
        verticalVelocity = (verticalInput * speed * Time.fixedDeltaTime);

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.enabled = false;
            renderer.sprite = idleSprite;
        }
        else
        {
            animator.enabled = true;
        }
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
