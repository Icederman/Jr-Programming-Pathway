using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody ball;
    private float ballHorizontalSpeed;
    private bool ballHitBar = false;

    private float ballBoundaryX = 35f;
    private float ballBoundaryZ = 21f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ballHorizontalSpeed = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (ballHitBar == false)
        {
            BallLaunch(); // Ball Launching
            
        }

        BallBoundaries(); // Ball Boundaries 
    }


    void BallLaunch()
    {
        ball.AddForce(Vector3.left * ballHorizontalSpeed * Time.deltaTime, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goalpost"))
        {
            ballHitBar = true;
            ball.linearVelocity = Vector3.zero;
        }
    }


    void BallBoundaries()

    {
        if(Mathf.Abs(transform.position.x ) > ballBoundaryX || Mathf.Abs(transform.position.z) > ballBoundaryZ)
        {
            Destroy(gameObject);
            Debug.Log("The ball got destroyed!");
        }


    }
}
