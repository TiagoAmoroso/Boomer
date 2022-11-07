using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int inactiveTransparency;
    private Color inactiveColor = new Color(1,1,1,0);
    private Color activeColor = new Color(1,1,1,1);

    private int cost;
    private bool active = false;
    new private SpriteRenderer renderer;

    private void Start()
    {
        inactiveColor = new Color(1,1,1,(float)(inactiveTransparency)/100);
        renderer = GetComponent<SpriteRenderer>();
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
    }

    private void OnMouseDown()
    {
        if(!active)
        {
            activate();

            Debug.Log(gameObject.name + " purchased");
        }
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
