using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public Slider slider;
    float healthSliderValue = 1f;

    public void SetHealthSliderValue()
    {
        healthSliderValue -= 0.1f;
        slider.value = healthSliderValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SetWaveText(int currentWave)
    {
        waveText.text = "Wave: " + currentWave;
    }
}
