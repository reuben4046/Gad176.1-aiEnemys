using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class Shooting : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 mousePosition;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canFire;
    public float timer;
    public float timeBetweenFiring = 0.5f;


    private float aimSpeed = 10f;

    void Start()
    {
        
    }

    private void Update() 
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        RotateTowardsTarget();

        if (canFire == false)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    void RotateTowardsTarget()
    {
        Vector3 targetDirection;
        targetDirection = mousePosition - transform.position;

        targetDirection.y = 0;

        float turnStep = aimSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnStep, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }       

}
