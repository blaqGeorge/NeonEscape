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
    private CharacterController controller;
    public float speed = 5f;
    private Rigidbody rb;
    public float dashSpeed;
    public float dashTime;
    private bool isDashing;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
    
        float moveX = Input.GetAxis("Vertical") * speed;
        float moveZ = Input.GetAxis("Horizontal") * speed;
        Vector3 MoveDir = rb.linearVelocity;
        rb.linearVelocity = new Vector3(-moveX, rb.linearVelocity.y, moveZ);

        if (MoveDir != Vector3.zero)

        {
            transform.rotation = Quaternion.LookRotation(MoveDir);
        }

        //float moveX = Input.GetAxis("Vertical") * speed;
        //float moveZ = Input.GetAxis("Horizontal") * speed;

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(-moveX, rb.linearVelocity.y, moveZ);
       

        // Apply movement
        //rb.linearVelocity = moveDirection;

        // Rotate the player towards movement direction (if moving)
        //if (moveDirection != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(moveDirection);
        //}

        //if (Input.GetKey(KeyCode.E) && !isDashing)
        //{
        //    //StartCoroutine(Dash());
        //    tp();
        //   ;
        //}
    }

    //void tp()
    //{
    //    //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E))
    //    //{
    //    //    transform.position += new Vector3(-1.5f, 0, 0.2f);
    //    //}
    //    //else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.E))
    //    //{
    //    //    transform.position -= new Vector3(+1.5f, 0, 0);
    //    //}
    //    Vector3 forwardDirection = transform.forward;

    //    // Adjust teleport distance
    //    float tpDistance = 1.5f;

    //    // Move the player forward based on their current facing direction
    //    transform.position += forwardDirection * tpDistance;

    //}


    //IEnumerator Dash()
    //{
    //    float startTime = Time.time;

    //    //Vector3 dashDirection = rb.linearVelocity.normalized;
    //    //while (Time.time < startTime + dashTime)
    //    //{
    //    //    rb.linearVelocity = dashDirection * dashSpeed;
    //    //    yield return null;
    //    //}

       
        
        
        

    //    isDashing = false;

    //}
}