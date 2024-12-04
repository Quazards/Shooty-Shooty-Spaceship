using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawnable
{
    public ObjectPooler enemyPool;
    public float spawnInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        GameObject enemy = enemyPool.GetPooledObject();
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }

}
