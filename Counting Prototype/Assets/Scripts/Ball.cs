using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;// Reference to the StartTheGame script

    private Rigidbody ball; // Reference to the Rigidbody component
    private float ballHorizontalSpeed = 12f; // Horizontal speed of the ball
    private float ballVerticalSpeed = 6f; // Vertical speed of the ball

    private bool jumpPressed = false; // Flag to check if jump is pressed
    private bool ballHitBar = false; // Flag to check if ball hit the goalpost
    private bool isOnPlay = false; // Flag to check if the ball is in play
    
    private float ballBoundaryX = 15f; // Boundary limit on the X-axis
    private float ballBoundaryZ = 12f; // Boundary limit on the Z-axis

    public AudioClip shotSound; // Audio clip for ball shot sound effect
    public AudioClip barhit; // Audio clip for bar hit sound effect
    public AudioClip missSound; // Audio clip for miss sound effect

    public ParticleSystem ballHitTheBar; // Particle system for ball hitting the bar effect
    public ParticleSystem goalMiss; // Particle system for goal miss effect

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody component attached to the ball
        ball = GetComponent<Rigidbody>();

       // Find the GameManager script in the scene
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        BallBoundaries(); // Ball Boundaries 

        // Check for jump input if the ball is not already in play and the game has started after pressing the start button
        if (Input.GetKeyDown(KeyCode.Space) && !isOnPlay && gameManager.gameStarted)
        {
            jumpPressed = true;  // Set jumpPressed to true when space key is pressed
            isOnPlay = true; // Once pressed, the ball is considered in play and no further input is accepted
        }
    }

    private void FixedUpdate()
    {
        // Launch the ball if jump is pressed and it hasn't hit the goalpost

        if (jumpPressed && !ballHitBar)
        {
            AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position); // Play shot sound effect
            BallLaunch(); // Call the BallLaunch method to launch the ball
            jumpPressed = false; // Reset jumpPressed after launching the ball

        }   
    }


    void BallLaunch()
    {
        // Ball Launch Mechanics
        ball.AddForce(Vector3.up * ballVerticalSpeed , ForceMode.Impulse);
        ball.AddForce(Vector3.left * ballHorizontalSpeed , ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball collides with the goalpost and stop its movement if it hits the goalpost
        if (collision.gameObject.CompareTag("Goalpost"))
        {
            AudioSource.PlayClipAtPoint(barhit, Camera.main.transform.position); // Play bar hit sound effect
            ballHitBar = true; // Set ballHitBar to true when the ball hits the goalpost
            ball.linearVelocity = Vector3.zero; // Stop the ball's movement
            Debug.Log("Ball hit the goalpost!"); 
            Instantiate(ballHitTheBar, transform.position, transform.rotation); // Play particle effect at the ball's position
            Destroy(gameObject, 2f); // Destroy the ball after 2 seconds
        }
    }


    void BallBoundaries()

    {
        // Check if the ball is out of defined boundaries and destroy it if so
        if (Mathf.Abs(transform.position.x ) > ballBoundaryX || Mathf.Abs(transform.position.z) > ballBoundaryZ)
        {
            Instantiate(goalMiss, transform.position, transform.rotation); // Play miss particle effect at the ball's position
            Destroy(gameObject); // Destroy the ball if it goes out of bounds
            Debug.Log("You missed!");
            AudioSource.PlayClipAtPoint(missSound, Camera.main.transform.position); // Play miss sound effect
            gameManager.UpdateLives(); // Call UpdateLives method in GameManager to decrease lives
        }


    }
}
