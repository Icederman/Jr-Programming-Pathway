using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private Vector3 cubePosition;
    private float startDelay;
    private float timeInterval;

    private float cubeScale;

    private Vector3 cubeRotation;
    private float rotationSpeed;

    private Color cubeColor;
    void Start()
    {
        // Random Spawning and Rotation of the cube at random time intervals
        startDelay = Random.Range(0f, 2f);
        timeInterval = Random.Range(3f, 7f);
        InvokeRepeating("CubeSpawner", startDelay, timeInterval);


        // Random scale for the cube
        cubeScale = Random.Range(1.0f, 5.0f);
        transform.localScale = Vector3.one * cubeScale;


    }

    void Update()
    {
        // Rotate the cube around a random axis at a random speed
        cubeRotation = new Vector3(Random.Range(1f, 100f), Random.Range(1f, 100f), Random.Range(1f, 100f));
        rotationSpeed = Random.Range(2f, 5f);
        transform.Rotate(cubeRotation, rotationSpeed);

        Material material = Renderer.material;

        //Click to change color
        if (Input.GetMouseButtonDown(0))
        {
            cubeColor = new Color(Random.value, Random.value, Random.value, Random.value);
            material.color = cubeColor;
        }




    }

    void CubeSpawner()
    {
        // Random position for the cube
        cubePosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        transform.position = cubePosition;

    }



}
