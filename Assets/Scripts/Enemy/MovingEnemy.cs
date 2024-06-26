using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MovingEnemy : BaseEnemy
{

    //variables for moving the enemy towards the player
    protected float moveSpeed = 3f;


    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        MoveTowardsPlayer();
    }

    //function that moves the enemy towards the player
    protected virtual void MoveTowardsPlayer()
    {
        if (player != null)
        { 
            var step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }
}
