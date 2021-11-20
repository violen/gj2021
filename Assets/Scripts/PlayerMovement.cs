using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cController;
    public Transform camera;
    public float speed = 10f;
    public float smoothTimeForTurn = 0.15f;
    float velocityForTurn;
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
        Vector3 direction = new Vector3(verticalInput, 0f, -horizontalInput).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocityForTurn, smoothTimeForTurn);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // perform a jump
        if (Input.GetButtonDown("Jump")) {
            // rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate() {
        
    }
}
