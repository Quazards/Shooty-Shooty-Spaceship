using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int health = 2;
    private EnemyDeath enemyDeath;

    private void Awake()
    {
        enemyDeath = GetComponent<EnemyDeath>();
    }

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
        if(collision.CompareTag("Bullet"))
        {
            int bulletDamage = collision.GetComponent<Bullet>().damage;
            TakeDamage(bulletDamage);
        }
        else if(collision.CompareTag("Player"))
        {
            TakeDamage(health);
        }
        else if(collision.CompareTag("Coin") || collision.CompareTag("Heart"))
        {
            return;
        }
    }

    public void OnDeath()
    {
        enemyDeath.SpawnObject();
        gameObject.SetActive(false);
    }
}
