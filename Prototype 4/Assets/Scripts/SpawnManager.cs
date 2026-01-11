using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    float spawnRange = 9.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(randomX, 0, randomZ);

        return spawnPos;

    }


}
