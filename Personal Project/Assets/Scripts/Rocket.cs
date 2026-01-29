using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rocket;
    
    private float rocketSpeed = 30f;
    private float rocketBoundary = -18f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rocket.AddForce(Vector3.left * rocketSpeed, ForceMode.Acceleration);

        

        if ( transform.position.x < rocketBoundary)
        {
            Destroy(gameObject);
        }
    }
}
