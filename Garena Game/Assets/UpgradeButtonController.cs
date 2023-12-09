using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    public void DamageUpgradeButtonPressed()
    {
        PlayerProjectile playerProjectile = FindAnyObjectByType<PlayerProjectile>();
        playerProjectile.damage += 1;
    }

    public void HealthUpgradeButtonPressed()
    {
        PlayerMovementController playerCont = FindAnyObjectByType<PlayerMovementController>();
        playerCont.initialPlayerHealth += 2;

        PlayerWall playerWall = FindAnyObjectByType<PlayerWall>();
        playerWall.Health += 2;
    }

    public void SpeedUpgradeButtonPressed()
    {
        PlayerAttack playerAttack = FindAnyObjectByType<PlayerAttack>();
        playerAttack.timeBetweenFiring -= 1;
    }
}
