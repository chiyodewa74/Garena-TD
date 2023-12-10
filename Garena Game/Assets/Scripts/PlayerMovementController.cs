using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] GameManager gm;

    public static PlayerMovementController Instance;
    public GameObject CorpesLeft;
    public GameObject CorpesRight;
    [SerializeField] float movementSpeed = 1f;
    CharacterRenderer charaRenderer;
    PlayerAttack playerAttack;
    public float horizontalInput;
    public float verticalInput;
    public int initialPlayerHealth;
    public int playerHealth;

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

        playerHealth = initialPlayerHealth;
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

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        GameObject.Find("DamageScreen").GetComponent<Animator>().SetTrigger("Damage");
        Material mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("HITEFFECT_ON");

        Invoke("ResetHighlight", 0.1f);
            AudioManager.Instance.PlaySound("grunt" + Random.Range(0, 6), 1, 1, false);
    }

    void ResetHighlight()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.DisableKeyword("HITEFFECT_ON");
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Get the current cell coordinates based on the object's position
        Vector3 objectPosition = transform.position;
        Vector2Int cellCoordinates = WorldToGridCoordinates(objectPosition);

        // Spawn the object at the current cell
        SpawnObjectAtCell(cellCoordinates);

        //anim.SetTrigger("Die");

        transform.position = new Vector2(-0.28f, 0.48f);
        playerHealth = initialPlayerHealth;

        StartCoroutine(EnemyStunned(gm.stunTime));
    }

    // Convert world coordinates to grid coordinates
    private Vector2Int WorldToGridCoordinates(Vector3 worldPosition)
    {
        // Your logic to convert world coordinates to grid coordinates
        // ...

        // For example, you might round the coordinates to get the nearest grid cell
        int gridX = Mathf.RoundToInt(worldPosition.x);
        int gridY = Mathf.RoundToInt(worldPosition.y);

        return new Vector2Int(gridX, gridY);
    }

    // Spawn the object at the specified grid cell
    private void SpawnObjectAtCell(Vector2Int cellCoordinates)
    {
        GameObject GO;
        if (transform.position.x < 0)
        {
            GO = Instantiate(CorpesLeft, new Vector3(cellCoordinates.x, cellCoordinates.y, 0), Quaternion.identity);
        }
        else
        {
            GO = Instantiate(CorpesRight, new Vector3(cellCoordinates.x, cellCoordinates.y, 0), Quaternion.identity);
        }

        GO.GetComponent<PlayerWall>().Health = initialPlayerHealth;
    }

    private IEnumerator EnemyStunned(float stunTime)
    {
        gm.isStunned = true;
        yield return new WaitForSeconds(stunTime);
        gm.isStunned = false;
    }
}
