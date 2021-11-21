using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowAI : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 1f;
    public float turnSpeed = 1.5f;

    private bool canMove = false;

    public NavMeshAgent agent;

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

        if (canMove) {
            Vector3 direction = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            // transform.position = direction;
            agent.destination = target.position;
            Debug.Log("Agent on Mesh: " + agent.isOnNavMesh);
            Debug.Log("Agent enabled: "+ agent.isActiveAndEnabled);
        }
        // agent.isStopped = !canMove;
        
        GameObject lightingManager = GameObject.Find("LightingManager");
        if (lightingManager != null) {
            canMove = !lightingManager.GetComponent<LightingManager>().IsDayTime();
        }
        else {
            // move always when there is no Day/Night Cycle
            canMove = true;
        }
    }
}
