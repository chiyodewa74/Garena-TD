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

    private void Awake()
    {
        loseGame = false;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (enemySpawner.CurrentWave > enemySpawner.waves.Count)
        {
            winPanel.SetActive(true);
            winGame = true;
            Debug.Log("Win!");
        }
    }
}
