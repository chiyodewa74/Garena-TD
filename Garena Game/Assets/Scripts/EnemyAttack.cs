using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;
    public float MinShootTime;
    public float MaxShootTime;
    public GameObject Projectile;
    float SelectedShootTime;

    private void Start()
    {
        SelectedShootTime = Time.time + Random.Range(MinShootTime, MaxShootTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyType == EnemyType.Projectile)
        {
            if(Time.time >= SelectedShootTime)
            {
                SelectedShootTime = Time.time + Random.Range(MinShootTime, MaxShootTime);
                Instantiate(Projectile, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Hit");
            Destroy(gameObject);
        }
    }
}

public enum EnemyType
{
    Melee,
    Projectile
}
