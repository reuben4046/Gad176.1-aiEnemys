using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //list of possible spawn points
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    private List<BaseEnemy> baseEnemies = new List<BaseEnemy>(); 
    private List<MovingEnemy> movingEnemies = new List<MovingEnemy>();
    private List<FastMovingEnemy> fastMovingEnemies = new List<FastMovingEnemy>();
    private List<ShootingEnemy> shootingEnemies = new List<ShootingEnemy>();
    private List<DashingEnemy> dashingEnemies = new List<DashingEnemy>();

    //public references to all of the enemys
    public BaseEnemy baseEnemy;
    public MovingEnemy movingEnemy;
    public FastMovingEnemy fastMovingEnemy;
    public ShootingEnemy shootingEnemy;
    public DashingEnemy dashingEnemy;

    private int waveNumber = 0;

    // Update is called once per frame
    void Update()
    {
        AreEnemysDead();
    }
    
    private void SpawnEnemys()
    {
        //if (waveNumber == 1)
        //{
        //    foreach (Transform t in spawnPoints)
        //    {
        //        BaseEnemy enemy = Instantiate(baseEnemy, t.position, t.rotation);
        //        enemy.transform.parent = transform;
        //        baseEnemies.Add(enemy);
        //    }
        //}
        if (waveNumber == 2)
        {
            foreach (Transform t in spawnPoints)
            {
                MovingEnemy enemy = Instantiate(movingEnemy, t.position, t.rotation);
                
                movingEnemies.Add(enemy);
            }
        }
        if (waveNumber == 3)
        {
            foreach (Transform t in spawnPoints)
            {
                FastMovingEnemy enemy = Instantiate(fastMovingEnemy, t.position, t.rotation);
                
                fastMovingEnemies.Add(enemy);
            }
        }
        if (waveNumber == 4)
        {
            foreach (Transform t in spawnPoints)
            {
                ShootingEnemy enemy = Instantiate(shootingEnemy, t.position, t.rotation);
                
                shootingEnemies.Add(enemy);
            }
        }
        if (waveNumber == 5)
        {
            foreach (Transform t in spawnPoints)
            {
                DashingEnemy enemy = Instantiate(dashingEnemy, t.position, t.rotation);
                
                dashingEnemies.Add(enemy);
            }
        }
        
    }

    private void AreEnemysDead()
    {
    
            if (baseEnemies.Count == 0 && movingEnemies.Count == 0 && fastMovingEnemies.Count == 0 && shootingEnemies.Count == 0 && dashingEnemies.Count == 0)
        {
            waveNumber++;
            SpawnEnemys();
        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform t in spawnPoints)
        {
            Gizmos.DrawWireSphere(t.position, 1f);
        }
    }
}
