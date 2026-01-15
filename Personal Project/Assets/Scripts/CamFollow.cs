using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isAlive == true)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
