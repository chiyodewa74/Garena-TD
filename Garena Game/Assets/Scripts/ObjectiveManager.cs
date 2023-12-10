using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public GameObject VFX;
    GameObject bossRoom;

    private void Awake()
    {
        bossRoom = FindAnyObjectByType<BossRoom>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Lose Health!");
        }
    }

    public void TakeDamage()
    {
        AudioManager.Instance.PlaySound("MoneyTaken", 1, 1, false);
        Material mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("HITEFFECT_ON");
        Invoke("TurnOffHit", 0.1f);
        Invoke("TurnOnBossRoom", 1f);
        Instantiate(VFX, transform.position, Quaternion.identity);
        bossRoom.SetActive(false);
        GameObject.Find("Virtual Camera").GetComponent<Animator>().SetTrigger("MoneyTaken");
    }

    void TurnOffHit()
    {
        Material mat = GetComponent<Renderer>().material;
        mat.DisableKeyword("HITEFFECT_ON");
    }

    void TurnOnBossRoom()
    {
        bossRoom.SetActive(true);
    }
}
