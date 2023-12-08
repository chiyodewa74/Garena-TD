using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;

    public int Health;
    public bool loseGame;

    private void Awake()
    {
        loseGame = false;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Lose!");
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (enemySpawner.CurrentWave > enemySpawner.waves.Count)
        {
            Debug.Log("Win!");
        }
    }
}
