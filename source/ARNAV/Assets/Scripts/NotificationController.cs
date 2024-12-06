using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro; // For TextMeshPro support if using TextMeshPro

public class NotificationController : MonoBehaviour
{
    public GameObject notificationPanel; // The UI Panel for notifications
    public TextMeshProUGUI notificationText; // The Text component for the message
    public float displayDuration = 3f; // Time the notification stays on screen

    private bool isShowing = false;

    void Start()
    {
        // Ensure the notification panel is hidden at the start
        notificationPanel.SetActive(false);
    }

    // Call this function to show a notification
    public void ShowNotification(string message)
    {
        if (!isShowing)
        {
            isShowing = true;
            notificationText.text = message;
            notificationPanel.SetActive(true);
            Invoke(nameof(HideNotification), displayDuration); // Hide after a delay
        }
    }

    // Hides the notification
    private void HideNotification()
    {
        notificationPanel.SetActive(false);
        isShowing = false;
    }
}
