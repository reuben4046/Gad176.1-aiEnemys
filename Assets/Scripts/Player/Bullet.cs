using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with an enemy
        BaseEnemy enemy = other.gameObject.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.TakeDamage(damage);
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}