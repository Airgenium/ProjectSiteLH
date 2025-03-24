using UnityEngine;
using System.Collections;
using System.Linq.Expressions;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;  
    private int currentWave = 1;
    private int enemiesRemaining;
    public int enemyCount;
    int enemyHealth;
    private bool isWaveInProgress = false;

    void Start()
    {
        StartWave();
    }

    void Update()
    {
        if (isWaveInProgress && enemyCount <= 0)
        {
            isWaveInProgress = false;

            if (currentWave < 3)
            {
                currentWave++;
                StartWave();
            }
            else
            {
                Victory();
            }
        }
    }

    public void StartWave()
    {
        isWaveInProgress = true;
        enemyCount = currentWave;
        enemyHealth = currentWave;
        enemiesRemaining = currentWave;
        
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i=0; i < enemiesRemaining;i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<EnemyStats>().SetHealth(currentWave);
        }

        enemiesRemaining = 0;
    }

    void Victory()
    {
        Debug.Log("Victory! You've defeated all the waves!");
    }
}
