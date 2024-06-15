using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMovingEnemy : MovingEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        MoveTowardsPlayer();
    }

    protected override void MoveTowardsPlayer()
    {
        var step = moveSpeed * 2f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
