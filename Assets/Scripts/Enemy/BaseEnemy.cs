using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public PlayerMovement player;

    private float turnSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }

    void RotateTowardsTarget()
    {
        Vector3 targetDirection;

        targetDirection = player.transform.position - transform.position;

        float turnStep = turnSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnStep, 0);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
