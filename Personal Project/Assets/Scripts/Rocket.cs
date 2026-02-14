using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rocket;
    
    private float rocketSpeed = 20f;
    private float rocketBoundary = -18f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ABSTRACTION
        BoundaryCheck();
        RocketMovement();
    }

    
      
  


    private void RocketMovement()
    {
        rocket.AddForce(Vector3.left * rocketSpeed, ForceMode.Acceleration);
    }

    private void BoundaryCheck()
    {
        if (transform.position.x < rocketBoundary)
        {
            Destroy(gameObject);
        }
    }
}
