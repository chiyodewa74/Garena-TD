using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // [SerializeField] private LayerMask groundMask;
    [SerializeField] float timer;
    public GameObject playerProjectile;

    private Camera mainCamera;
    private Vector3 mousePos;
    [SerializeField] bool canFire;
    Animator anim;
    public bool Throwing;
    public float timeBetweenFiring;
    public Transform ThrowPoint;
    PlayerMovementController playerMovement;

    private void Start()
    {
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovementController>();
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

        if (Input.GetMouseButton(0) && canFire)
        {
            anim.SetTrigger("Throw");

            if (playerMovement.horizontalInput != 0)
            {
                anim.SetInteger("X", (int)playerMovement.horizontalInput);
            }else
            {
                anim.SetInteger("X", 1);
            }

            Throwing = true;
        }
    }

    public void ThrowProjectile()
    {
        Throwing = false;
        Instantiate(playerProjectile, ThrowPoint.position, Quaternion.identity);
    }
}
