using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cController;
    public float speed = 10.5f;
    public float jumpForce = 3.5f;
    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(verticalInput, 0f, horizontalInput).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);


            cController.Move(direction * speed * Time.deltaTime);
        }

        // perform a jump
        if (Input.GetButtonDown("Jump")) {
            // rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate() {
        
    }
}
