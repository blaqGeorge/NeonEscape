using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidRotation : MonoBehaviour
{
    public float yRotation = 3.0f;

    public float speed = 10.0f;

    void FixedUpdate()
    {

        //  float vertical = Input.GetAxis("Vertical");



        transform.Rotate(0, yRotation, 0);
    }




}
