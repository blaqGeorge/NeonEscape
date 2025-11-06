using UnityEngine;

public class HeallthRestore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            other.GetComponent<healthProb>()?.RestoreHealth(); // Apply damage
                                                               //  Restore(gameObject);
        }

    }
}
