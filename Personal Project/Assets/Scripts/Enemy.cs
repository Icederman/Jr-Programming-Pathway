using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of the enemy movement
    private float bottomBound = -17.0f; // Z-axis bottom boundary

    private Rigidbody rb; // Reference to the Rigidbody component
    private GameObject player; // Reference to the player GameObject
    private PlayerMovement playerMovement; // Reference to the player script
    public GameObject bullet;
    public AudioClip bulletHitSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsAlive)
        {
            EnemyMovement();
        }
    }

    void EnemyMovement()
    {

        Vector3 direction = (player.transform.position - transform.position).normalized; // Calculate direction to the player

        rb.AddForce(direction * speed); // Move the enemy towards the player

        EnemyBoundary(); // Check and enforce enemy boundaries

    }


    void EnemyBoundary()
    {
        // Z-axis bottom boundary 
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            AudioSource.PlayClipAtPoint(bulletHitSound, transform.position);
            Destroy(gameObject); // Destroy the enemy on collision with a bullet
            Debug.Log("Hit!");
        }
    }

}
