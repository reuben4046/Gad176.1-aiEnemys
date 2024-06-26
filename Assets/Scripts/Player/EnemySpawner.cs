using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Ui references
    [SerializeField] private GameUi gameUi;
    //list of possible spawn points
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    //public references to all of the enemys
    public BaseEnemy baseEnemy;
    public MovingEnemy movingEnemy;
    public FastMovingEnemy fastMovingEnemy;
    public ShootingEnemy shootingEnemy;
    public DashingEnemy dashingEnemy;

    //list of all enemies
    public List<BaseEnemy> enemyList = new List<BaseEnemy>();

    //how many waves have been spawned
    private int waveNumber = 0;

    //how many enemies to spawn in each wave
    private int spawnAmmount = 3;

    // Update is called once per frame
    void Update()
    {
      WaveIncreaser();
      GameWin();
    }

    //function that sets the wave text to the current wave
    private void SetWaveText()
    {
        gameUi.SetWaveText(waveNumber);
    }

    //function that increases the wave number
    private void WaveIncreaser()
    {
        if (waveNumber < 5)
        {
            if (enemyList.Count == 0)
            {
                waveNumber++;
                SpawnController();
                SetWaveText();
            }
        }
    }

    //function that controlls which enemies to spawn
    private void SpawnController()
    {
        if (waveNumber == 1)
        {
            SpawnMovingEnemy();
        }
        else if (waveNumber == 2)
        {
            SpawnFastMovingEnemy();
            SpawnMovingEnemy();
        }
        else if (waveNumber == 3)
        {
            SpawnShootingEnemy();
            SpawnMovingEnemy();
            SpawnFastMovingEnemy();
        }
        else if (waveNumber == 4)
        {
            SpawnDashingEnemy();
            SpawnMovingEnemy();
            SpawnFastMovingEnemy();
            SpawnShootingEnemy();
        }
    }

    //function that ends the game if the player goes past wave 4
    public void GameWin()
    {
        if (waveNumber > 4)
        {
            gameUi.GameWin();
        }
    }

    //functions that choose a random spawn point and instaciate spawnAmmount of enemies at the chosen points
    private void SpawnMovingEnemy()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            int randNumber = Random.Range(0, spawnPoints.Count);
            Instantiate(movingEnemy, spawnPoints[randNumber].position, spawnPoints[randNumber].rotation);
            enemyList.Add(baseEnemy);
        }
        return;
    }
    private void SpawnFastMovingEnemy()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            int randNumber = Random.Range(0, spawnPoints.Count);
            Instantiate(fastMovingEnemy, spawnPoints[randNumber].position, spawnPoints[randNumber].rotation);
            enemyList.Add(baseEnemy);
        }
        return;
    }
    private void SpawnShootingEnemy()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            int randNumber = Random.Range(0, spawnPoints.Count);
            Instantiate(shootingEnemy, spawnPoints[randNumber].position, spawnPoints[randNumber].rotation);
            enemyList.Add(baseEnemy);
        }
        return;
    }
    private void SpawnDashingEnemy()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            int randNumber = Random.Range(0, spawnPoints.Count);
            Instantiate(dashingEnemy, spawnPoints[randNumber].position, spawnPoints[randNumber].rotation);
            enemyList.Add(baseEnemy);
        }
        return;
    }

    //draws gizmos so that they can be seen in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform t in spawnPoints)
        {
            Gizmos.DrawWireSphere(t.position, 1f);
        }
    }

}
