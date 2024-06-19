using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DashingEnemy : BaseEnemy
{
    private float findingTime = 1f;

    private bool dashing = false;
    private float dashSpeed = 8f;

    private bool coroutineRunning = true;
    private float dashingTime = 2f;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        base.Start();
        StartCoroutine(DashCoroutine());
    }


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

    private void FindOrDash()
    {
        if (dashing == false)
        {
            //Debug.Log("finding");
            base.RotateTowardsTarget();
        }
        else
        {
            //Debug.Log("dashing");
            Dash();
        }
    }


    private void Dash()
    {
        transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
    }
}
