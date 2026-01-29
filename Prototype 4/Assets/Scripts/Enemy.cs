using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed; // Speed of the enemy

    Rigidbody enemyRb; // Reference to the enemy's Rigidbody    
    GameObject player; // Reference to the player GameObject
    Vector3 lookDirection; // Direction vector towards the player

    float bottomBound = -10; // Boundary limit for the enemy


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (player.transform.position - transform.position).normalized;
        
        if(transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        enemyRb.AddForce(lookDirection * speed);
    }


}
