using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10, 0); // Adjust speed in Inspector

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime); // Rotate smoothly
    }
}
