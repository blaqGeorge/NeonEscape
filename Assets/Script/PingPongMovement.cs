using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingPongMovement : MonoBehaviour
{
    private bool movingRight = true;
    //const bool Mtrigger = true;
    public float speed = 10.0f;
    //float positionMovementX = 18f;

    void FixedUpdate()
    {

        //transform.position = transform.position + new Vector3(3f, 0, 0) * Time.deltaTime * speed;

        /* if ((transform.position.x != positionMovementX) )
          {

              transform.position = transform.position + new Vector3(3f, 0, 0) * Time.deltaTime * speed;
            //  if (transform.position= transform.position(18f,0,0))
                  positionMovementX = -18f;
          }
          else 
          {

              transform.position = transform.position - new Vector3(3f, 0, 0) * Time.deltaTime * speed;
              positionMovementX = -18f;
          }*/

        if (movingRight)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;

            // Check if we've reached the right limit
            if (transform.position.z >= 30f)
            {
                movingRight = false; // Change direction
            }
        }
        else
        {
            transform.position += Vector3.back * speed * Time.deltaTime;

            // Check if we've reached the left limit
            if (transform.position.y <= 35f)
            {
                movingRight = true; // Change direction
            }
        }

    }

}