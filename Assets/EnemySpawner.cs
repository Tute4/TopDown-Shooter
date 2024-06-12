using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int EnemigosPorRonda = 5; 
    public float spawnInterval = 2f; 
    public float PausaDeRonda = 10f;
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f); 

    private int enemigosSpawneados = 0; 
    private int EnemigosDestruidos = 0; 
    private int rondasCompletadas = 0; 
    private bool rondaEnProgreso = false; 

    void Start()
    {
       
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        
        while (enemigosSpawneados < EnemigosPorRonda)
        {
            
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2), 0f, Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));
            SpawnEnemy(randomPosition);

            
            enemigosSpawneados++;

            
            yield return new WaitForSeconds(spawnInterval);
        }

        
        rondaEnProgreso = true;

        
        while (EnemigosDestruidos < EnemigosPorRonda)
        {
            yield return null; 
        }

        
        rondaEnProgreso = false;

        
        rondasCompletadas++;

        
        EnemigosPorRonda *= 2;

        
        yield return new WaitForSeconds(PausaDeRonda);

       
        enemigosSpawneados = 0;

        
        EnemigosDestruidos = 0;

        
        StartCoroutine(SpawnEnemies());
    }

    void SpawnEnemy(Vector3 position)
    {
        
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    
    public void EnemyDestroyed()
    {
       
        EnemigosDestruidos++;

        
        if (EnemigosDestruidos >= EnemigosPorRonda)
        {
            
            GameManager.instance.RondaCompletada();
        }
    }


    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
