using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    //function that calls player TakeDamage() if the bullet collides with the player
    protected override void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        
        //Check if the bullet collides with the player
        if (player != null)
        {
            // Deal damage to the player
            player.TakeDamage();
            Destroy(gameObject);
        }
    }
}
