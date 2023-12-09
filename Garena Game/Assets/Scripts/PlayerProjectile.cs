using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] AudioClip[] sounds;

    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;
    private AudioSource source;

    public int damage = 1;

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
            if (Random.Range(1, 3) == 2)
            {
                source.clip = sounds[Random.Range(0, sounds.Length)];
                source.Play();
            }
            collision.gameObject.GetComponent<EnemyManager>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
