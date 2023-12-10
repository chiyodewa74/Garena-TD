using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    // [SerializeField] private LayerMask groundMask;
    [SerializeField] float timer;
    public GameObject playerProjectile;

    private Camera mainCamera;
    [SerializeField] bool canFire;
    [SerializeField] float minTimeBetweenFiring = 1f;
    [SerializeField] float maxTimeBetweenFiring = 5f;
    Animator anim;
    public bool Throwing;
    public float timeBetweenFiring;
    public Transform ThrowPoint;
    PlayerMovementController playerMovement;
    public Slider Reload;

    private void Start()
    {
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            Reload.value += Time.deltaTime;
            Reload.maxValue = Mathf.Clamp(timeBetweenFiring, minTimeBetweenFiring, maxTimeBetweenFiring);

            if (timer >= Mathf.Clamp(timeBetweenFiring, minTimeBetweenFiring, maxTimeBetweenFiring))
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            anim.SetTrigger("Throw");
            Reload.value = 0;

            if (playerMovement.horizontalInput != 0)
            {
                anim.SetInteger("X", (int)playerMovement.horizontalInput);
            }else
            {
                anim.SetInteger("X", 1);
            }

            canFire = false;
            Throwing = true;
        }
    }

    public void ThrowProjectile()
    {
        Throwing = false;
        Instantiate(playerProjectile, ThrowPoint.position, Quaternion.identity);
    }
}
