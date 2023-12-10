using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;

    public int Health;
    public bool loseGame;
    public bool winGame;
    public bool isStunned;
    public float stunTime;
    public float waveOver;
    bool CanRestart;

    private void Awake()
    {
        loseGame = false;
        winGame = false;
    }

    private void Update()
    {
        if(CanRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (enemySpawner.CurrentWave >= enemySpawner.waves.Count)
        {
            winGame = true;
            Time.timeScale = 0;
            winPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            loseGame = false;
            Time.timeScale = 0;
            losePanel.SetActive(true);
            CanRestart = true;
        }

        FindObjectOfType<ObjectiveManager>().TakeDamage();
    }
}
