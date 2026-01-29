using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(20, 0, 0);

    private float startDelay;
    private float repeatRate;
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startDelay = Random.Range(2f, 4f);
        repeatRate = Random.Range(1.5f, 3f);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();


        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }


}
