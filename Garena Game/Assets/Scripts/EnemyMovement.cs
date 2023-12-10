using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameManager gm;

    public float Speed;
    public Transform target;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Money Pile").transform;                                                             
        rb = GetComponent<Rigidbody2D>();
        gm = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = target.position.x > transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gm.isStunned)
        {
            rb.position = Vector2.MoveTowards(transform.position, target.transform.position, Speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            gm.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
