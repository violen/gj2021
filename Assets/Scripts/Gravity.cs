using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public CharacterController cController;
    public float gravity = -9f;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    Vector3 gravityVelocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2;
        }

        // apply gravity
        gravityVelocity.y += gravity * Time.deltaTime;
        cController.Move(gravityVelocity * Time.deltaTime);
    }
}
