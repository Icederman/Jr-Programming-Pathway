using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;

    private float startDelay = 2;
    private float startInterval = 1.5f;

    void Start()
    {

        InvokeRepeating("SpawnRandomAnimal", startDelay, startInterval);

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void SpawnRandomAnimal()
    {
        int animaLIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        Instantiate(animalPrefabs[animaLIndex], spawnPos, animalPrefabs[animaLIndex].transform.rotation);



    }




}
 