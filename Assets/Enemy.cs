using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; 
    private Transform player; 

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
       
        if (player == null)
            return;

        
        Vector3 direction = (player.position - transform.position).normalized;

        
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        
        transform.Translate(movement, Space.World);
    }
}
