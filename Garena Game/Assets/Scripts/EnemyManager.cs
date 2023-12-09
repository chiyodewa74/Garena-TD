using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health;
    public GameObject Vfx;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Material mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("HITEFFECT_ON");
        Invoke("TurnOffWhite", 0.1f);
    }

    void TurnOffWhite()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.DisableKeyword("HITEFFECT_ON");

        if (health <= 0)
        {
            Instantiate(Vfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
