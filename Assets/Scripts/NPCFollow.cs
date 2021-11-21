using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform target;
    public CharacterController cController;

    public float moveSpeed = 1f;
    public float turnSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = (target.position - transform.position).normalized;
        // rotate to player
        float targetAngle = Mathf.Atan2(-targetDirection.z, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);


        Vector3 direction = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        transform.position = direction;

        // cController.Move(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
