using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Vector2 movementInput;
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;
    private PlayerShoot playerShoot;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        playerMovement.SetMovementInput(movementInput);
        playerAnimation.GetMovementInput(movementInput);

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is pressed");
            playerShoot.ShootProjectile();
            
        }
    }
}
