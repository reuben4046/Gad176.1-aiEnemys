using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMovingEnemy : MovingEnemy
{
    //speed multiplier for the fast moving enemy makes it move 4x faster than the normal moving enemy
    private float speedMultiplier = 2f;

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        MoveTowardsPlayer();
    }
    
    // Moves towards the player at a faster pace than the normal moving enemy
    protected override void MoveTowardsPlayer()
    {
        var step = moveSpeed * speedMultiplier * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    
}
