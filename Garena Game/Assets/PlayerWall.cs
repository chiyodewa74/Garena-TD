using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour
{
    public int Health = 3;

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
