using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Assign enemy prefab in Inspector
    public Transform spawnPoint;    // Assign spawn location
    public float spawnInterval = 3f; // Time between spawns
    public int maxEnemies = 5;       // Max number of enemies allowed
    private int currentEnemies = 0;  // Tracks number of spawned enemies

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); // Repeatedly spawns enemies
    }

    void SpawnEnemy()
    {
        if (currentEnemies < maxEnemies)  // Only spawn if limit not reached
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            currentEnemies++; // Increase enemy count
        }
        else
        {
            CancelInvoke("SpawnEnemy"); // Stop spawning when max is reached
        }
    }
}