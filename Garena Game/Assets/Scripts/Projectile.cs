using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Force;
    Rigidbody2D rb;
    Vector2 Direction;

    static Object[] spriteArray;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (spriteArray == null)
        {
            spriteArray = Resources.LoadAll("CookiesImages", typeof(Sprite));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform player = FindAnyObjectByType<PlayerMovementController>().transform;
        Direction = player.position - transform.position;
        Vector3 rotation = transform.position - player.position;

        int chosenSprite = Random.Range(0, spriteArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(spriteArray[chosenSprite]) as Sprite;


        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Direction.x, Direction.y).normalized * Force;
        transform.Rotate(new Vector3(0, 0, 3));
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
