using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Force;
    Rigidbody2D rb;

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
        Vector3 Direction = player.position - transform.position;
        Vector3 rotation = transform.position - player.position;
        rb.velocity = new Vector2(Direction.x, Direction.y).normalized * Force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        int chosenSprite = Random.Range(0, spriteArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(spriteArray[chosenSprite]) as Sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovementController>().playerHealth -= 1;
            Destroy(gameObject);
        }
    }
}
