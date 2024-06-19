using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public BaseEnemy BaseEnemy;
    public MovingEnemy MovingEnemy;
    public FastMovingEnemy FastMovingEnemy;
    public ShootingEnemy ShootingEnemy;
    public DashingEnemy DashingEnemy;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
