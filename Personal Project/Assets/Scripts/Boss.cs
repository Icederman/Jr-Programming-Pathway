using UnityEngine;
using System.Collections;


public class Boss : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // Speed of the enemy movement
    private float bottomBound = -17.0f; // Z-axis bottom boundary

    private float health = 100f; // Health of the boss
    public GameObject bullet;
    public GameObject rocket;
    [SerializeField] private AudioClip bossHitSound; // Sound to play when the boss is hit

    private float startDelay;
    private float shotInterval;

    Rigidbody rb; // Reference to the Rigidbody component
    GameObject player; // Reference to the player GameObject
    PlayerMovement playerScript; // Reference to the PlayerMovement script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        player = GameObject.Find("Player"); // Find the player GameObject by name
        playerScript = player.GetComponent<PlayerMovement>(); // Get the PlayerMovement script from the player



        startDelay = Random.Range(2f, 4f);
        shotInterval = Random.Range(1f, 2f);


        InvokeRepeating("BossShoot", startDelay, shotInterval);


    }



    // Update is called once per frame
    void Update()
    {
        if (playerScript.IsAlive)
        {
            DeathCheck();

            BossMovement();
        }

        else
        {
            StopShoot();
        }
    }




    void BossBoundary()
    {
        // Z-axis bottom boundary 
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(bossHitSound, Camera.main.transform.position);
            health -= 10;
            Debug.Log("You hit the boss! Boss Health: " + health);
        }
    }

    void BossShoot()
    {
        Vector3 shotPos = new Vector3(transform.position.x - 1f, 1f, transform.position.z);

        Instantiate(rocket, shotPos, rocket.transform.rotation);
    }

    void BossMovement()
    {

        float zdirection = (player.transform.position.z - transform.position.z); // Calculate z direction of the player
        Vector3 bossDirection = new Vector3(0, 0, zdirection).normalized; // Calculate direction to the player

        rb.AddForce(bossDirection * speed); // Move the enemy towards the player

        BossBoundary(); // Check and enforce boss boundaries

    }


    void DeathCheck()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void StopShoot()
    {

        rb.linearVelocity = Vector3.zero;
        CancelInvoke("BossShoot");

    }


}

