using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public int damageAmount = 20; // Adjust damage value in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if player touched the collider
        {
            other.GetComponent<healthProb>()?.takeDamage(damageAmount); // Apply damage
            Debug.Log("Player took damage: " + damageAmount);
        }
    }
}