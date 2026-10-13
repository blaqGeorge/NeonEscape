using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody rb;
//    public float speed = 5f;
//    private CharacterController controller;
//    private Vector3 moveDirection;

//    void Start()
//    {

//        controller = GetComponent<CharacterController>();
//    }

//    void Update()
//    {
//        rb = GetComponent<Rigidbody>();
//        float horizontal = Input.GetAxis("Horizontal");
//        float vertical = Input.GetAxis("Vertical");

//        rb.linearVelocity = new Vector3(-vertical,0f , horizontal).normalized;

//        controller.Move(rb.linearVelocity * speed * Time.deltaTime);
//       // rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
//        rb.useGravity = true;
//    }
//}



public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;

    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Vertical") * speed;
        float moveZ = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(-moveX, 0f, moveZ);

        if (movement != Vector3.zero)
        {
            // Character is moving
            transform.rotation = Quaternion.LookRotation(movement);
            animator.SetBool("isMoving", true);
        }
        else
        {
            // Character is idle
            animator.SetBool("isMoving", false);
        }

        Vector3 velocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        rb.linearVelocity = velocity;

    }
}