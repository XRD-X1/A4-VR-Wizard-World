using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public void SpawnEnemies()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 3.0f);
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(630f, 650f);
        float randomZ = Random.Range(380f, 383f);

        GameObject enemy =Instantiate(enemyPrefab, new Vector3(randomX, 158, randomZ), Quaternion.identity);
        enemy.GetComponent<DieScript>().target = Camera.main.gameObject;
    }
}
