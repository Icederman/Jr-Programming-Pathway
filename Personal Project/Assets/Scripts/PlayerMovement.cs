using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    private float playerHealth = 100f;
    public float speed = 10f;
    public float jumpForce;

    private float horizontalInput;
    private float verticalInput;

    private float bottomBound = -17f;

    public GameObject bulletPrefab;

    public bool isAlive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        


    }

    // Update is called once per frame
    void Update()
    {   
        // Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        
        PlayerBoundary();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 shotPos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);

            Instantiate(bulletPrefab, shotPos, bulletPrefab.transform.rotation);

        }

        if(playerHealth <= 0)
        {
            
            Debug.Log("Player has died! Game Over!");
            Destroy(gameObject);
            isAlive = false;
        }

    }


private void FixedUpdate()
    {
        // Movement
        rb.AddForce(Vector3.right * speed * horizontalInput);
        rb.AddForce(Vector3.forward * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }
            
        


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
        if(collision.gameObject.CompareTag("Enemy1"))
        {
            Debug.Log("Player has collided with a knife holder!");
            playerHealth -= 10f;

        }

        else if(collision.gameObject.CompareTag("Enemy2"))
        {
            Debug.Log("Player has collided with a chapati holder!");
            playerHealth -= 15f;
        }

        else if(collision.gameObject.CompareTag("Rocket"))
        {
            Debug.Log("Player has collided with a rocket!");
            playerHealth -= 25f;
        }

    }



}
