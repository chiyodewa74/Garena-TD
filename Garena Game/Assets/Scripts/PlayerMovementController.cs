using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    CharacterRenderer charaRenderer;
    PlayerAttack playerAttack;
    public float horizontalInput;
    public float verticalInput;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        charaRenderer = GetComponent<CharacterRenderer>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        rb.MovePosition(newPos);

        if (!playerAttack.Throwing)
        {
            charaRenderer.SetDirection(movement);
        }
    }
}
