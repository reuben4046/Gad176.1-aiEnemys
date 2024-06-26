using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public Slider slider;
    float healthSliderValue = 1f;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;


    void Start()
    {
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
    }

    public float SetHealthSliderValue()
    {
        healthSliderValue -= 0.1f;
        slider.value = healthSliderValue;

        return healthSliderValue;
    }

    public void SetWaveText(int currentWave)
    {
        waveText.text = "Wave: " + currentWave;
    }


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void GameWin()
    {
        gameWinPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
