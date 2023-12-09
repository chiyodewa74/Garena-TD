using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float force;

    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;

    static Object[] spriteArray;

    private void Awake()
    {
        if (spriteArray == null)
        {
            spriteArray = Resources.LoadAll("CookiesImages", typeof(Sprite));
        }
    }

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        int chosenSprite = Random.Range(0, spriteArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(spriteArray[chosenSprite]) as Sprite;
    }

    private void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }

        transform.Rotate(new Vector3(0, 0, 3));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyManager>().health -= 1;
            Destroy(gameObject);
        }
    }
}
