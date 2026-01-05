using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float bottomBound = -10.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Destroy game object if it goes out of bounds 

        if (transform.position.z > topBound)
        {
            Destroy(gameObject);

        }

        else if (transform.position.z < bottomBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
