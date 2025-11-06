

using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreen; // Assign Start Screen UI in Inspector
    public GameObject startButton; // Assign Start Button in Inspector
    public GameObject safeZone; // Assign Safe Zone in Inspector
    private AudioSource musicSource;


    void Start()
    {
        musicSource = Camera.main.GetComponent<AudioSource>(); // Get Audio Source from Camera
        musicSource.Play(); // **Start playing background music**
        startScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game at start
        safeZone.SetActive(false); // Ensure Safe Zone is hidden at start
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Resume the game
        startScreen.SetActive(false); // Hide the start screen
        //startButton.SetActive(false); // Hide the start button
    }
}
