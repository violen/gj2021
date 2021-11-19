using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.5f;
    private float horizontalInput;
    private float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // forwardInput = Input.GetAxis("Vertical");

        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * forwardInput);
        transform.Translate(Vector3.right * speed * horizontalInput);
    }
}
