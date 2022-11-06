using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtDeterioration : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int firstStateHealth;
    [SerializeField] private int secondStateHealth;

    [Header("Images")]
    [SerializeField] private Sprite firstStateSprite;
    [SerializeField] private Sprite secondStateSprite;

    
    new private SpriteRenderer renderer;

    private Health health;
    private int currentHealth;


    private void Start()
    {
        health = GetComponent<Health>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentHealth = health.getHealth();

        if(currentHealth <= secondStateHealth)
        {
            changeSprite(secondStateSprite);
        }
        else if(currentHealth <= firstStateHealth)
        {
            changeSprite(firstStateSprite);
        }
    }

    private void changeSprite(Sprite newSprite)
    {
        renderer.sprite = newSprite;
    }
}
