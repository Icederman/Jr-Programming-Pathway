using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the enemy movement
    private float bottomBound = -17.0f; // Z-axis bottom boundary

    Rigidbody rb; // Reference to the Rigidbody component
    GameObject player; // Reference to the player GameObject
    public GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        player = GameObject.Find("Player"); // Find the player GameObject by name
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized; // Calculate direction to the player

        rb.AddForce(direction * speed); // Move the enemy towards the player

        PlayerBoundary(); // Check and enforce player boundaries

    }

    void PlayerBoundary()
    {
        // Z-axis bottom boundary 
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Destroy the enemy on collision with a bullet
        }
    }

}
