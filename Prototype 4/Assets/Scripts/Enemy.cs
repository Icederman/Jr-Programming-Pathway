using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed; // Speed of the enemy

    Rigidbody enemyRb; // Reference to the enemy's Rigidbody    
    GameObject player; // Reference to the player GameObject
    Vector3 lookDirection; // Direction vector towards the player


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
        

    }

    private void FixedUpdate()
    {
        enemyRb.AddForce(lookDirection * speed);
    }


}
