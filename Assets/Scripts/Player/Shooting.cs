using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class Shooting : MonoBehaviour
{
    //references to the camera and mouse position. 
    public Camera mainCamera;
    private Vector3 mousePosition;

    //references to the bullet prefab and bullet spawn point
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    //variables for checking if the player can fire and the time between firings
    public bool canFire;
    private float timer;
    public float timeBetweenFiring = 0.5f;
    
    //variables for the player's gun aim speed
    private float aimSpeed = 10f;

    // Update is called once per frame - gets the mouse position and rotates the players gun towards the mouse position. 
    //Also checks if the player can fire, and if true and the player presses the mouse button, it will instanciate the bullet prefab.
    void Update() 
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        RotateTowardsMousePos();

        if (canFire == false)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            BulletInstantiator();
        }
    }

    //function that instanciates the bullet prefab at the bullet spawn point
    private void BulletInstantiator()
    {
        canFire = false;
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    //function that rotates the bullet towards the mouse position
    void RotateTowardsMousePos()
    {
        Vector3 targetDirection;
        targetDirection = mousePosition - transform.position;

        targetDirection.y = 0;

        float turnStep = aimSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnStep, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }       

}
