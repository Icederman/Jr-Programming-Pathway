using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bullet;
    GameObject player;
    PlayerMovement playerMovementScript;

    public float bulletSpeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.IsAlive)
        {
            BulletMovement();
            BoundaryCheck();
        }

        else
        {
            Destroy(gameObject);
        }
    }


    private void BulletMovement()
    {
        bullet.AddForce(Vector3.right * bulletSpeed, ForceMode.Acceleration);
    }

    private void BoundaryCheck()
    {
        if (transform.position.x > player.transform.position.x + 50f)
        {
            Destroy(gameObject);
        }

    }

}
