using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveIndicator : MonoBehaviour
{
    private TMP_Text text;
    [SerializeField] private WaveManager waveManager;

    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int currentWave = waveManager.getCurrentWave();

        text.text = "Wave " + currentWave;
    }
        
    

}
