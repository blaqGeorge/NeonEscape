using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public GameObject gameOverScreen;  // Assign Game Over UI in Inspector
    public string[] validTags = { "Ground", "HealingZone" }; // Tags for surfaces player can stand on
    private bool isStanding = false;
    private float timer = 0f;
    public float fallTimeThreshold = 3f; // Time before game over

    void Update()
    {
        if (!isStanding)
        {
            timer += Time.deltaTime;

            if (timer >= fallTimeThreshold)
            {
                GameOver(); // Trigger Game Over if time runs out
            }
        }
        else
        {
            timer = 0f; // Reset timer if player is standing on valid surface
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isStanding = CheckValidTag(collision.gameObject.tag);
    }

    void OnCollisionExit(Collision collision)
    {
        if (CheckValidTag(collision.gameObject.tag))
        {
            isStanding = false; // Player left the surface
        }
    }

    bool CheckValidTag(string tag)
    {
        foreach (string validTag in validTags)
        {
            if (tag == validTag) return true;
        }
        return false;
    }

    void GameOver()
    {
        GetComponent<healthProb>()?.takeDamage(100);
        gameOverScreen.SetActive(true); // Show Game Over screen
        Time.timeScale = 0f; // Pause game
        Debug.Log("Game Over! Player was not standing on a valid surface.");
    }
}