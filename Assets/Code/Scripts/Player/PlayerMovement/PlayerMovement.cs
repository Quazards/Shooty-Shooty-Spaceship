using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    public float speed;
    private Vector2 movementInput;
    private Vector2 bounds;

    private void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        Move(movementInput, speed);
        ClampMovement();
    }

    public void Move(Vector2 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetMovementInput(Vector2 input)
    {
        movementInput = input;
    }

    private void ClampMovement()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, bounds.x * -1, bounds.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, bounds.y * -1, bounds.y);
        transform.position = playerPosition;
    }
}
