using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{

    private bool canFire = false;
    private float timer;
    private float timeBetweenFiring = 0.3f;

    public GameObject enemyBulletPrefab;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Shoot();    
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        Shoot();
    }

    void Shoot()
    {
        if(canFire == false)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
                Instantiate(enemyBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                canFire = false;
            }
        }
    }
}
