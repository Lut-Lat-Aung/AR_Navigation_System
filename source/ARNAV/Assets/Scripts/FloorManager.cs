using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class FloorManager : MonoBehaviour
{
    public ImageTargetBehaviour floor5QR; // Drag and drop the Floor 5 Image Target
    public ImageTargetBehaviour floor6QR; // Drag and drop the Floor 6 Image Target
    public ImageTargetBehaviour floor1QR;  // Drag and drop the FLoor 1 Image Target

    private void Update()
    {
        // Check if Floor 5 QR is being tracked
        if (floor5QR.TargetStatus.Status == Status.TRACKED)
        {
            Debug.Log("Floor 5 QR Detected!");
            LoadFloorScene("5thFloor");
        }
        // Check if Floor 6 QR is being tracked
        else if (floor6QR.TargetStatus.Status == Status.TRACKED)
        {
            Debug.Log("Floor 6 QR Detected!");
            LoadFloorScene("6thFloor");
        }

        else if (floor1QR.TargetStatus.Status == Status.TRACKED)
        {
            Debug.Log("Floor 1 QR Detected!");
            LoadFloorScene("1stFloor");
        }
    }

    private void LoadFloorScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName); // Load the correct floor scene
        }
    }
}
