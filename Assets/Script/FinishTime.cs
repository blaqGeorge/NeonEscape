using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // UI text to show the time
    public GameObject targetPoint; // Assign the goal object (checkpoint)
    private float elapsedTime = 0f;
    private bool hasReachedTarget = false;

    void Update()
    {
        if (!hasReachedTarget) // Keep counting until the player reaches the target
        {
            elapsedTime += Time.deltaTime;
            timerText.text = "Time: " + elapsedTime.ToString("F2") + " seconds";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetPoint && !hasReachedTarget)
        {
            hasReachedTarget = true; // Stop the timer
            PlayerPrefs.SetFloat("BestTime", elapsedTime); // Save time
            Debug.Log("Reached Target in " + elapsedTime.ToString("F2") + " seconds!");
        }
    }
}