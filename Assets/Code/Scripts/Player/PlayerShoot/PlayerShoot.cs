using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour, IShootable
{
    public ObjectPooler bulletPool;
    public int bulletSpeed;
    public Transform shootPoint;

    public void ShootProjectile()
    {
        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = shootPoint.position;
        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
