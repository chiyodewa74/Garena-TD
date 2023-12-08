using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> SpawnPoints;
    public List<Wave> waves;
    [SerializeField] int CurrentWave = 1;
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
        if(Time.time >= NextSpawn)
        {
            Instantiate(waves[CurrentWave - 1].Enemies[Random.Range(0, waves[CurrentWave - 1].Enemies.Count)], SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
            NextSpawn = Time.time + Random.Range(waves[CurrentWave - 1].MinSpawnTime, waves[CurrentWave - 1].MaxSpawnTime);
        }

        if(Time.time >= NextWave)
        {
            CurrentWave++;
            NextWave = Time.time + waves[CurrentWave - 1].WaveTime;
        }
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
