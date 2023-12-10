using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] SuperTextMesh WaveText;
    [SerializeField] GameObject upgradePanel;
    [SerializeField] Transform canvas;

    public List<Transform> SpawnPoints;
    public List<Wave> waves;
    public int CurrentWave = 1;
    float NextSpawn;
    float NextWave;

    private void Start()
    {
        NextSpawn = Time.time + Random.Range(waves[CurrentWave - 1].MinSpawnTime, waves[CurrentWave - 1].MaxSpawnTime);
        NextWave = Time.time + waves[CurrentWave - 1].WaveTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(!gm.winGame)
        {
            if (Time.time >= NextWave)
            {
                TriggerUpgradePanel();

                CurrentWave++;
                WaveText.text = "<b>Wave</b>: " + CurrentWave;
                NextWave = Time.time + waves[CurrentWave - 1].WaveTime;

                if(CurrentWave - 1 > waves.Count)
                {
                    CurrentWave = waves.Count;
                }
            }

            if (!gm.loseGame && !gm.isStunned)
            {
                if (Time.time >= NextSpawn)
                {
                    Instantiate(waves[CurrentWave - 1].Enemies[Random.Range(0, waves[CurrentWave - 1].Enemies.Count)], SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
                    NextSpawn = Time.time + Random.Range(waves[CurrentWave - 1].MinSpawnTime, waves[CurrentWave - 1].MaxSpawnTime);
                }
            }
        }
    }

    private void TriggerUpgradePanel()
    {
        Time.timeScale = 0;
        upgradePanel.SetActive(true);
        /*
        GameObject upgrade = Instantiate(upgradePanel, Vector2.zero, Quaternion.identity);
        upgrade.transform.SetParent(canvas);
        */
    }
}

[System.Serializable]
public class Wave
{
    public float WaveTime;
    public float MinSpawnTime;
    public float MaxSpawnTime;
    public List<GameObject> Enemies;
}
