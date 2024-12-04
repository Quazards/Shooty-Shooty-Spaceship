using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int health = 3;

    private void Update()
    {
        if(health <= 0)
        {
            OnDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int bulletDamage = collision.GetComponent<Bullet>().damage;
            TakeDamage(bulletDamage);
        }
        else if (collision.CompareTag("Player"))
        {
            TakeDamage(2);
        }
    }

    public void OnDeath()
    {
        return;
    }
}
