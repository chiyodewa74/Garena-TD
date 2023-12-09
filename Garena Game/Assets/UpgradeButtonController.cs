using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] PlayerProjectile playerProjectile;
    [SerializeField] PlayerMovementController playerCont;
    [SerializeField] PlayerWall playerWallLeft;
    [SerializeField] PlayerWall playerWallRight;
    [SerializeField] PlayerAttack playerAttack;

    public void DamageUpgradeButtonPressed()
    {
        playerProjectile.damage += 1;

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void HealthUpgradeButtonPressed()
    {
        playerCont.initialPlayerHealth += 2;

        playerWallLeft.Health += 2;
        playerWallRight.Health += 2;

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void SpeedUpgradeButtonPressed()
    {
        playerAttack.timeBetweenFiring -= 1;

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
