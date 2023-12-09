using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;
    [SerializeField] float attackRange;
    public float MinShootTime;
    public float MaxShootTime;
    public GameObject Projectile;
    public GameObject player;
    float SelectedShootTime;
    EnemyMovement enemyMovement;

    private void Awake()
    {
        player = GameObject.Find("Player");
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        SelectedShootTime = Time.time + Random.Range(MinShootTime, MaxShootTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
        {
            if (enemyType == EnemyType.Projectile)
            {
                if (Time.time >= SelectedShootTime)
                {
                    SelectedShootTime = Time.time + Random.Range(MinShootTime, MaxShootTime);
                    Instantiate(Projectile, transform.position, Quaternion.identity);
                }
            }
            if (enemyType == EnemyType.Melee)
            {
                enemyMovement.target = player.transform;
            }
        } else
        {
            enemyMovement.target = GameObject.Find("Money Pile").transform;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

public enum EnemyType
{
    Melee,
    Projectile
}
