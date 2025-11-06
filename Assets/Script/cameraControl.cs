using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 OriPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, OriPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
