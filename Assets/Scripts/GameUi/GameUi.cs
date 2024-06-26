using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{   
    //reference to the wave text shown in the ui 
    public TextMeshProUGUI waveText;

    //reference to the slider used for health
    public Slider slider;
    float healthSliderValue = 1f;

    //reference to the gameover and win panels
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    //setting the win and game over panels to inactive when the game starts
    void Start()
    {
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
    }

    //function that reduces the health of the player and returns the players health as a float
    public float SetHealthSliderValue()
    {
        healthSliderValue -= 0.1f;
        slider.value = healthSliderValue;

        return healthSliderValue;
    }

    //function that sets the wave text
    public void SetWaveText(int currentWave)
    {
        waveText.text = "Wave: " + currentWave;
    }

    //game over sets the game over panel to active
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    //game win sets the game win panel to active
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
    }

    //connected to a button that loads the menu scene
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
