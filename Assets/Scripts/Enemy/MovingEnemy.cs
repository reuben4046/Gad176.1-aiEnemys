using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MovingEnemy : BaseEnemy
{
    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        MoveTowardsPlayer();
    }

    protected float moveSpeed = 1f;

    protected virtual void MoveTowardsPlayer()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
