using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DashingEnemy : BaseEnemy
{
    //variables for the time it takes for the enemy to find or dash (used in the coroutine)
    private float findingTime = 1f;
    private float dashingTime = 2f;

    private bool coroutineRunning = true;

    //variables for the dash
    private bool dashing = false;
    private float dashSpeed = 8f;
   
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(DashCoroutine());
    }

    // Coroutine that keeps looping changing the dashing variable from true to false
    IEnumerator DashCoroutine()
    {
        while (coroutineRunning)
        {
            yield return new WaitForSeconds(dashing ? dashingTime : findingTime);
            dashing = !dashing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindOrDash();
    }

    //function that calls base.RotateTowardsTarget() if the enemy is not dashing, otherwise it calls Dash()
    private void FindOrDash()
    {
        if (dashing == false)
        {
            base.RotateTowardsTarget();
        }
        else
        {
            Dash();
        }
    }

    //Dash function that moves the enemy forward while it is active
    private void Dash()
    {
        transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
    }
}
