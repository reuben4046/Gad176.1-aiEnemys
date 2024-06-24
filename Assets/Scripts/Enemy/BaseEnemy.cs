using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    //references
    protected PlayerMovement player;
    protected EnemySpawner enemySpawner;
    
    //turn speed for enemy movement
    [SerializeField] protected float turnSpeed = 1.5f;

    //stats
    private float health = 100f;
    private float damageTaken = 25f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        enemySpawner = player.GetComponentInChildren<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }

    //function that rotates the enemy towards the player
    protected virtual void RotateTowardsTarget()
    {
        Vector3 targetDirection;

        targetDirection = player.transform.position - transform.position;

        float turnStep = turnSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnStep, 0);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    //function that deals damage to the enemy and removes it from the list of spawned enemies
    public void TakeDamage()
    {
        health -= damageTaken;
        if (health <= 0)
        {
            int index = 0;

            enemySpawner.enemyList.RemoveAt(index);
            
            Destroy(gameObject);
        }
    }

}
