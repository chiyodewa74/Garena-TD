using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;
    Vector2 Direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform player = FindAnyObjectByType<PlayerMovementController>().transform;
        Direction = player.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Direction * Speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovementController>().Die();
            Destroy(gameObject);
        }
    }
}
