using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    private float maxHealth;

    private void Start()
    {
        maxHealth = health.getHealth();
        totalHealthBar.fillAmount = (float)(health.getHealth()) / maxHealth;
    }

    private void Update()
    {
        Debug.Log((float)(health.getHealth()) / 10);
        currentHealthBar.fillAmount = (float)(health.getHealth()) / maxHealth;

        if(health.getHealth() == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
