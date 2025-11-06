using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource; // Assign in Inspector

    void Start()
    {
        musicSource.Play(); // Play the background music
    }
}
