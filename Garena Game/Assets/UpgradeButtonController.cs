using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerMovementController playerCont;

    public void DamageUpgradeButtonPressed()
    {
        playerAttack.ProjectileDamage += 1;

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void HealthUpgradeButtonPressed()
    {
        playerCont.initialPlayerHealth += 2;

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
