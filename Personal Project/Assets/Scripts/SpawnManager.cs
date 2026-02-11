using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;

    private float waveNumber = 1;

    private GameObject player;
    private PlayerMovement playerScript;

    private int enemy1Count;
    private int enemy2Count;
    private int enemy3Count;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        MainSpawner();
    }

    void MainSpawner()
    {
        enemy1Count = GameObject.FindGameObjectsWithTag("Enemy1").Length;
        enemy2Count = GameObject.FindGameObjectsWithTag("Enemy2").Length;
        enemy3Count = GameObject.FindGameObjectsWithTag("Enemy3").Length;


        if (enemy1Count == 0 && playerScript.isAlive == true)
        {
            if (waveNumber == 1 && player.transform.position.x > 10)
            {
                SpawnEnemyWave(3);
                waveNumber++;
            }

            else if (waveNumber == 2 && player.transform.position.x > 30)
            {
                SpawnEnemyWave(5);
                waveNumber++;
            }

            else if (waveNumber == 3 && enemy2Count == 0 && player.transform.position.x > 50)
            {
                SpawnEnemyWave(1);
                waveNumber++;
            }

            else if (waveNumber == 4 && enemy3Count == 0)
            {
                Debug.Log("You Win!");
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            float spawnPosX = player.transform.position.x + 32;
            float spawnPosZ = Random.Range(-17f,7f);

            Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

            if (waveNumber == 1)
            {
               Instantiate(enemies[0], spawnPos, enemies[0].transform.rotation);
                
            }

            else if (waveNumber == 2)
            {
               
                Instantiate(enemies[1], spawnPos, enemies[1].transform.rotation);
                
            }

            else if (waveNumber == 3)
            {
               
                Instantiate(enemies[2], spawnPos, enemies[2].transform.rotation);
                
            }

        }
    }
}
