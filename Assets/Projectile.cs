using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int daño = 10; 
    public float speed = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            
            if (enemyHealth != null)
            {
                
                enemyHealth.RecibirDaño(daño);
            }
        }

        
        Destroy(gameObject);
    }
}
