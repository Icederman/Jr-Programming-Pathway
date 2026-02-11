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
    public bool isGrounded = true;

    public bool pressedE = false;
    public bool pressedSpace = false;

    private Animator playerAnim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        // Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        DeathCheck();

        PlayerBoundary();

        if (Input.GetKeyDown(KeyCode.E))
        {
            pressedE = true;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            pressedSpace = true;
        }

        MovementAnimation();
    }


    private void FixedUpdate()
    {
        Movement();

        Shoot();


        if(isGrounded && pressedSpace)
        {
            Jump();
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
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            playerHealth -= 10f;
            Debug.Log("Player has collided with a knife holder! Health= " + playerHealth);


        }

        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            playerHealth -= 15f;
            Debug.Log("Player has collided with a chapati holder! Health= " + playerHealth);

        }



        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            playerHealth -= 25f;
            Debug.Log("Player has collided with a rocket! Health= " + playerHealth);

        }
    }

    public void MovementAnimation()
    {
        if (Input.GetKeyDown(KeyCode.D) && isAlive)
        {
            playerAnim.SetFloat("Speed_f", 0.4f);
        }

        else if (Input.GetKeyUp(KeyCode.D) && isAlive)
        {
            playerAnim.SetFloat("Speed_f", 0f);
        }


    }

    public void Movement()
    {
        // Movement
        rb.AddForce(Vector3.right * speed * horizontalInput);
        rb.AddForce(Vector3.forward * speed * verticalInput);
    }

    public void Shoot()
    {
        if (pressedE)
        {
            Vector3 shotPos = new Vector3(transform.position.x, 2f, transform.position.z);
            Instantiate(bulletPrefab, shotPos, bulletPrefab.transform.rotation);

            pressedE = false;
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig");
        isGrounded = false;
        pressedSpace = false;
    }

    public void DeathCheck()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player has died! Game Over!");
            Destroy(gameObject);
            isAlive = false;
        }
    }




}
