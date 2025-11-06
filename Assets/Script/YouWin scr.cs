using UnityEngine;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winScreen; // Assign Win Screen UI in Inspector
    public GameObject safePoint; // Assign the safe point GameObject in Inspector

    void Start()
    {
        winScreen.SetActive(false); // Hide the win screen at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == safePoint) // Check if player reached the safe point
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winScreen.SetActive(true); // Show the win screen
        Time.timeScale = 0f; // Pause game
        Debug.Log("Congratulations! You reached the safe point.");
    }
}