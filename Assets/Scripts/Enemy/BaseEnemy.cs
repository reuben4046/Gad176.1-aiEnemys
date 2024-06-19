using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public PlayerMovement player;
 
    [SerializeField] protected float turnSpeed = 1.5f;

    private float health = 100f;
    private float damage = 25f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }

    protected virtual void RotateTowardsTarget()
    {
        Vector3 targetDirection;

        targetDirection = player.transform.position - transform.position;

        float turnStep = turnSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnStep, 0);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    
    public void TakeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
