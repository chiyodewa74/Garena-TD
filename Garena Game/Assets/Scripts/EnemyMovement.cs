using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;
    Transform MoneyPile;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        MoneyPile = GameObject.Find("Money Pile").transform;                                                             
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position = Vector2.MoveTowards(transform.position, MoneyPile.transform.position, Speed * Time.fixedDeltaTime);
    }
}
