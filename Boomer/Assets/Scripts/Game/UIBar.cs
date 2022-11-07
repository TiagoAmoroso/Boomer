using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private Health health;
    private int startHealth;
    private float originalXScale;
    private float originalYScale;
    private float originalZScale;

    private void Start()
    {
        startHealth = health.getHealth();
        originalXScale = gameObject.transform.localScale.x;
        originalYScale = gameObject.transform.localScale.y;
        originalZScale = gameObject.transform.localScale.z;
        gameObject.transform.localScale = new Vector3(((float)(health.getHealth()) / (float)(startHealth)) * originalXScale, originalYScale, originalZScale);
        
        
    }

    private void Update()
    {
        gameObject.transform.localScale = new Vector3(((float)(health.getHealth()) / (float)(startHealth)) * originalXScale, originalYScale, originalZScale);
    }
}
