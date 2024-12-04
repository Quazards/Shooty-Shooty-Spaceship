using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour, IShootable
{
    public ObjectPooler bulletPool;
    public int bulletSpeed;
    public Transform shootPoint;
    public float shootInterval;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        bulletPool = GameObject.FindGameObjectWithTag("EnemyBulletPool").GetComponent<ObjectPooler>();

        StartCoroutine(ShootPlayer());
    }

    private IEnumerator ShootPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            ShootProjectile();
        }
    }

    public void ShootProjectile()
    {
        if (player == null)
            return;

        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = shootPoint.position;
        bullet.SetActive(true);

        Vector2 direction = (player.position - shootPoint.position).normalized;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }    
}
