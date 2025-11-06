using UnityEngine;
using System.Collections;

public class SafeZoneTrigger : MonoBehaviour
{
    public GameObject cubeToMove; // Assign cube in Inspector
    public GameObject safeZone; // Assign safe zone in Inspector
    public float pushForce = 5f;
    public float cubeMoveHeight = 2f;
    public float delayBeforeLift = 3f; // Delay before lifting cube
    public float safeZoneDelay = 120f; // 2-minute delay
    private bool triggered = false;

   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            PushPlayer(other.gameObject);
            StartCoroutine(LiftCubeAfterDelay());
            Invoke(nameof(ShowSafeZone), safeZoneDelay); // Delay before showing safe zone
        }
    }

    void PushPlayer(GameObject player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
        }
    }

    IEnumerator LiftCubeAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLift);
        cubeToMove.transform.position += Vector3.up * cubeMoveHeight;
    }

    void ShowSafeZone()
    {
        safeZone.SetActive(true);
    }
}
