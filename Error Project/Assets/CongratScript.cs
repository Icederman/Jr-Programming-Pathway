using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh text;
    public ParticleSystem sparksParticles;

    private List<string> textToDisplay;

    private float rotatingSpeed;
    private float timeToNextText;

    private int currentText;

    // Start is called before the first frame update
    void Start()
    {
        textToDisplay = new List<string>();

        timeToNextText = 0.0f;
        currentText = 0;

        textToDisplay.Add("Congratulation");
        textToDisplay.Add("All Errors Fixed");

        rotatingSpeed = 10.0f;

        text.text = textToDisplay[0];

        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * rotatingSpeed * Time.deltaTime);

        timeToNextText += Time.deltaTime;

        if (timeToNextText > 1.5f)
        {
            timeToNextText = 0.0f;
            text.text = textToDisplay[1];
            currentText++;

            if (currentText >= textToDisplay.Count)
            {
                currentText = 0;


                text.text = textToDisplay[currentText];
            }
        }
    }

}