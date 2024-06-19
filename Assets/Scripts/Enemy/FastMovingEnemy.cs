using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMovingEnemy : MovingEnemy
{

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        MoveTowardsPlayer();
    }

    private float speedMultiplier = 4f;

    protected override void MoveTowardsPlayer()
    {
        var step = moveSpeed * speedMultiplier * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    
}
