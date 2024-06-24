using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BaseEnemy
{
    //variables for controlling how often the enemy can fire
    private bool canFire = false;
    private float timer;
    private float timeBetweenFiring = 0.3f;

    //variables for referencing the bullet prefab and bullet spawn point
    public GameObject enemyBulletPrefab;
    public Transform bulletSpawnPoint;

    private float moveSpeed = 3f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Shoot();    
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        Shoot();
        MoveTowardsPlayer();
    }

    //shoot function that instanciates the bullet prefab at the bullet spawn point when canfire is true
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

       //function that moves the enemy towards the player
    protected virtual void MoveTowardsPlayer()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
