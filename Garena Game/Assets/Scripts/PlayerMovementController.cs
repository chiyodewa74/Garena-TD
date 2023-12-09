using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController Instance;
    public GameObject CorpesLeft;
    public GameObject CorpesRight;
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

        if(Instance == null)
        {
            Instance = this;
        }
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

    public void Die()
    {
        //anim.SetTrigger("Die");

        if (transform.position.x < 0)
        {
            Instantiate(CorpesLeft, transform.position, Quaternion.identity);
        }else
        {
            Instantiate(CorpesRight, transform.position, Quaternion.identity);
        }

        transform.position = new Vector2(-0.64f, 3.45f);
    }
}
