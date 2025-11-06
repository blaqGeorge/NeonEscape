using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageHit = 20f;
    public float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // **Destroy bullet on impact**
    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            other.GetComponent<healthProb>()?.takeDamage(damageHit); // Apply damage
            Destroy(gameObject);
        }

        //if (other.CompareTag("Player"))
        //{
        //    Destroy(gameObject);
        //}
    }

    
}