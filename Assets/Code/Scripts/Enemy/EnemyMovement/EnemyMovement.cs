using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMoveable
{
    public float speed;

    private void Update()
    {
        Move(Vector2.down, speed);
    }

    public void Move(Vector2 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
