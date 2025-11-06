using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // AI Navigation
    public Transform player; // Player reference
    public LayerMask whatIsGround, whatIsPlayer;
    public float health = 100f; // Enemy health

    // Patrol Variables
    private Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange = 10f;

    // Sight & Search
    public float sightRange = 15f;
    public float searchDuration = 5f; // Time spent searching for the player
    private float searchTimer = 0f;
    private Vector3 lastKnownPosition;

    private bool playerInSightRange;
    private bool isSearching = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
        {
            lastKnownPosition = player.position; // Save last known position
            isSearching = true;
            searchTimer = searchDuration;
            ChasePlayer();
        }
        else if (isSearching)
        {
            SearchForPlayer();
        }
        else
        {
            Patroling();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position); // AI chases player
    }

    private void SearchForPlayer()
    {
        if (searchTimer > 0)
        {
            agent.SetDestination(lastKnownPosition); // Moves to the last seen position
            searchTimer -= Time.deltaTime;
        }
        else
        {
            isSearching = false; // Stop searching, return to patrol mode
        }
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange); // Show sight range
    }
}
