using UnityEngine;
using System.Collections;

public class Goalpost : MonoBehaviour
{
    public float goalMovementSpeed;// Speed of the goalpost movement


    private Vector3 movementDirection; // Current movement direction of the goalpost
    private float rightBoundary = 7.3f; // Right boundary limit for goalpost movement
    private float leftBoundary = -7.3f; // Left boundary limit for goalpost movement

    private GameManager gameManager;// Reference to the StartTheGame script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the GameManager script in the scene
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Initial movement direction
        movementDirection = Vector3.left;

        // Set the goalpost movement speed
        goalMovementSpeed = 10f;
        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Call the GoalpostMovement method to move the goalpost if the game has started and calling the coroutine to increase speed over time

        if (gameManager.gameStarted)
        {
            GoalpostMovement();
        }



    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // Wait for 10 seconds
            goalMovementSpeed += 2f; // Increase speed by 2 units
        }
    }





    void GoalpostMovement()
    {
        // Move the goalpost in the current direction
        transform.Translate(movementDirection * goalMovementSpeed * Time.fixedDeltaTime);

        // Reverse direction if the goalpost reaches certain boundaries
        if (transform.position.z >= rightBoundary)
        {
            movementDirection = Vector3.right;
        }
        else if (transform.position.z <= leftBoundary)
        {
            movementDirection = Vector3.left;
        }

    }

}
