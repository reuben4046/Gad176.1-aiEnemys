using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //run speed of the player (serialized so it can stay private but show up in the inspector)
    [SerializeField] private float runSpeed = 10.0f;

    //gameUi reference
    public GameUi gameUi;

    // Update is called once per frame controls the inputs for player movement
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

    //functions for moving the player
    private void MoveForwards()
    {
        transform.position += Vector3.forward * runSpeed * Time.deltaTime;
    }
    private void MoveBackwards()
    {
        transform.position += Vector3.back * runSpeed * Time.deltaTime;
    }
    private void MoveLeft()
    {
        transform.position += Vector3.left * runSpeed * Time.deltaTime;
    }
    private void MoveRight()
    {
        transform.position += Vector3.right * runSpeed * Time.deltaTime;
    }

    //function that deals damage to the player
    public void TakeDamage()
    {
        gameUi.SetHealthSliderValue();

        if (gameUi.SetHealthSliderValue() <= 0) //if the health is less than or equal to 0 then destroy the player and display game over
        {
            Destroy(gameObject);
            gameUi.GameOver();
        }

        Debug.Log("player took damage");
    }

    




}
    