using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour
{
    [SerializeField] int minHealth = 1;
    [SerializeField] int maxHealth = 5;

    public int Health = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }

    void TakeDamage(int Points)
    {
        Health -= Points;

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
