//using UnityEngine;

//public class TurretEnemy : MonoBehaviour
//{
//    public Transform player; // Assign player object in Inspector
//    public GameObject bulletPrefab; // Bullet object
//    public Transform firePoint; // Where bullets are shot from
//    public float attackRange = 15f;
//    public float fireRate = 1f;
//    private float nextFireTime = 0f;
//    public Transform bulletSpawnPoint;

//    public float bulletSpeed = 10;

//    public float rotationSpeed = 5f; // Speed of turret rotation

//    void Update()
//    {

//        // Check if player is in range
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//        if (distanceToPlayer <= attackRange)
//        {
//            // Rotate turret to face player
//            Vector3 direction = player.position - transform.position;
//            Quaternion targetRotation = Quaternion.LookRotation(direction);
//            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

//            // Fire at the player
//            if (Time.time >= nextFireTime)
//            {
//                Shoot();
//                nextFireTime = Time.time + 1f / fireRate;
//            }
//        }
//    }

//    void Shoot()
//    {
//        //var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        //bullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;

//        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//        //Rigidbody rb = bullet.GetComponent<Rigidbody>();
//        //rb.linearVelocity = transform.forward * 25f; // Bullet speed

//        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//        Rigidbody rb = bullet.GetComponent<Rigidbody>();
//        rb.linearVelocity = transform.forward * 25f; // Bullet speed


//    }
//}

using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public GameObject bulletPrefab; // Assign bullet prefab
    public Transform firePoint; // The point where bullets are spawned
    public Transform partToRotate;

    public float attackRange = 15f; // Range within which the turret detects the player
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float bulletSpeed = 15f;

    public float rotationSpeed = 5f; // Turret rotation speed

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {

            // Rotate the turret to face the player
            Vector3 direction = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, targetRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);

            // Fire at the player
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        firePoint.LookAt(player.position); // Ensure the firePoint faces the player before shooting
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }

    // Draw Gizmo to visualize turret range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}