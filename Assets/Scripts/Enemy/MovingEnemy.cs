using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MovingEnemy : BaseEnemy
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

    private float moveSpeed = 1f;


    protected void MoveTowardsPlayer()
    {
        var step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
