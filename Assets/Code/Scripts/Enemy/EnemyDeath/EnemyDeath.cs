using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour, ISpawnable
{
    private ObjectPooler heartPool;
    private ObjectPooler coinPool;

    private void Awake()
    {
        heartPool = GameObject.FindGameObjectWithTag("HeartPool").GetComponent<ObjectPooler>();
        coinPool = GameObject.FindGameObjectWithTag("CoinPool").GetComponent <ObjectPooler>();
    }

    public void SpawnObject()
    {
        int random = Random.Range(1, 4);

        switch(random)
        {
            case 1:
                GameObject hearts = heartPool.GetPooledObject();
                hearts.transform.position = transform.position;
                hearts.gameObject.SetActive(true);
                break;
            case 2:
                GameObject coin = coinPool.GetPooledObject();
                coin.transform.position = transform.position;
                coin.gameObject.SetActive(true);
                break;
            case 3:
                return;
            case 4:
                return;
        }
    }
}
