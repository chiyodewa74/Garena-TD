using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health;
    public GameObject Vfx;

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(Vfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
