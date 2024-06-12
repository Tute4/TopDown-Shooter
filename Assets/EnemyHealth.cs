using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 5; 
    private int currentHp; 

    void Start()
    {
        currentHp = maxHp; 
    }

    public void RecibirDaño(int damage)
    {
        
        currentHp -= damage;

        
        if (currentHp <= 0)
        {
            
            Destroy(gameObject);
            
            FindObjectOfType<EnemySpawner>().EnemyDestroyed();
        }
    }
}
