using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // [SerializeField] private LayerMask groundMask;
    [SerializeField] float timer;
    [SerializeField] float timeBetweenFiring;
    public GameObject playerProjectile;

    private Camera mainCamera;
    private Vector3 mousePos;
    private bool canFire;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Instantiate(playerProjectile, transform.position, Quaternion.identity);
        }
    }
}
