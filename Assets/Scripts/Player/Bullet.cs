using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // speed and damage of the bullet
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 10f;

    private float timer;
    
    void Update()
    {
        MoveBullet();
    }

    //function that moves the bullet forward
    protected void MoveBullet()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //function that calls a function in the BaseEnemy class that deals damage to the enemy
    protected virtual void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with an enemy
        BaseEnemy enemy = other.gameObject.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            // Deal damage to the enemy
            enemy.TakeDamage();
            Destroy(gameObject);
        }
        BaseEnemy[] enemies = GetComponentsInChildren<BaseEnemy>();
        foreach (BaseEnemy childEnemy in enemies)
        {
            childEnemy.TakeDamage();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    //function that destroys the bullet after 5 seconds
    protected IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
}