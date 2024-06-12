using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody body;

    private float horizontal;
    private float vertical;

    private float forward;

    private float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForwards();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackwards();
        }
        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if ( Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

    }

    void MoveForwards()
    {
        transform.position += Vector3.fwd * runSpeed * Time.deltaTime;
    }

    void MoveBackwards()
    {
        transform.position += Vector3.back * runSpeed * Time.deltaTime;
    }

    void MoveLeft()
    {
        transform.position += Vector3.left * runSpeed * Time.deltaTime;
    }

    void MoveRight()
    {
        transform.position += Vector3.right * runSpeed * Time.deltaTime;
    }

}
    