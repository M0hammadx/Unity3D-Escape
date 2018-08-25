using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerMov : MonoBehaviour
{
    Hand hand = null;
    public Rigidbody rb;

    public float movespeed = 3;
    void Start()
    {
        hand = GetComponent<Hand>();
       // rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) || ((hand != null) && (hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
        {
            rb.velocity = transform.forward * movespeed;
            // transform.Translate(Vector3.forward * movespeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }




    }
}
