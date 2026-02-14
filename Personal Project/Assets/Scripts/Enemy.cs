using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 3; // Speed of the enemy movement
    protected float bottomBound = -17.0f; // Z-axis bottom boundary

    protected Rigidbody rb; // Reference to the Rigidbody component
    protected GameObject player; // Reference to the player GameObject
    protected PlayerMovement playerMovement; // Reference to the player script
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected AudioClip bulletHitSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
   protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (playerMovement.IsAlive)
        {
            EnemyMovement(); //ABSTRACTION
        }
    }

    protected virtual void EnemyMovement()
    {

        Vector3 direction = (player.transform.position - transform.position).normalized; // Calculate direction to the player

        rb.AddForce(direction * speed); // Move the enemy towards the player

        EnemyBoundary(); // Check and enforce enemy boundaries

    }


    protected virtual void EnemyBoundary()
    {
        // Z-axis bottom boundary 
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            AudioSource.PlayClipAtPoint(bulletHitSound, Camera.main.transform.position);
            Destroy(gameObject); // Destroy the enemy on collision with a bullet
            Debug.Log("Hit!");
        }
    }

}
