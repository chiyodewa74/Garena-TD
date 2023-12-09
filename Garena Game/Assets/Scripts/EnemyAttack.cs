using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask PlayerMask;
    bool DetectingPlayer;
    public float MinShootTime;
    public float MaxShootTime;
    public GameObject Projectile;
    public GameManager gm;
    float SelectedShootTime;
    EnemyMovement enemyMovement;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        gm = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        SelectedShootTime = Time.time + Random.Range(MinShootTime, MaxShootTime);
    }

    // Update is called once per frame
    void Update()
    {
        DetectingPlayer = Physics2D.OverlapCircle(transform.position, attackRange, PlayerMask);

        if (DetectingPlayer && !gm.isStunned)
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
                enemyMovement.target = PlayerMovementController.Instance.transform;
            }
        } else
        {
            enemyMovement.target = GameObject.Find("Money Pile").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovementController>().playerHealth -= 1;
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
