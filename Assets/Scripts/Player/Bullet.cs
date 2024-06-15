using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 10f;

    private float timer;
    
    void Update()
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
            enemy.TakeDamage();
        }
        BaseEnemy[] enemies = GetComponentsInChildren<BaseEnemy>();
        foreach (BaseEnemy childEnemy in enemies)
        {
            childEnemy.TakeDamage();
        }

        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}