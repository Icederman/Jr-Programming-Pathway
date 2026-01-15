using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bullet;
    GameObject player;

    public float bulletSpeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        bullet.AddForce(Vector3.right * bulletSpeed, ForceMode.Acceleration);

        player = GameObject.Find("Player");

        if (transform.position.x > player.transform.position.x + 50f)
        {
            Destroy(gameObject);
        }
    }
}
