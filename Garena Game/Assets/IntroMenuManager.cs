using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenuManager : MonoBehaviour
{
    Cursor cursor;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        BossRoom GO = FindObjectOfType<BossRoom>();
        GO.enabled = false;
        GO.GetComponent<Animator>().enabled = false;
        FindObjectOfType<EnemySpawner>().enabled = false;
        FindObjectOfType<PlayerMovementController>().enabled = false;
        cursor = FindObjectOfType<Cursor>();
        cursor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            anim.SetTrigger("Start");
            BossRoom GO = FindObjectOfType<BossRoom>();
            GO.enabled = true;
            GO.GetComponent<Animator>().enabled = true;
            FindObjectOfType<EnemySpawner>().enabled = true;
            FindObjectOfType<PlayerMovementController>().enabled = true;
            GameObject.Find("WaveText").GetComponent<Animator>().SetTrigger("In");
            this.enabled = false;
            cursor.gameObject.SetActive(true);
            Destroy(gameObject, 1);
        }
    }
}
