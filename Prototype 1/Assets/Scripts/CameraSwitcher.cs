using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;

    [SerializeField] private bool isMainCameraActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {

            CameraSwitch();
        
        }
    }



    private void CameraSwitch()
    {
        isMainCameraActive = !isMainCameraActive;

        mainCamera.enabled = isMainCameraActive;
        secondaryCamera.enabled = !isMainCameraActive;



    }



}
