using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private Health houseHealth;

    private void Update()
    {
        if(houseHealth.getHealth() <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}