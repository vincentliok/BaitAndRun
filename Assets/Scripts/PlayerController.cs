using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private CharacterController character;

    [SerializeField]
    private Animator animator;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        moveDirection = agent.desiredVelocity;

        // Face in direction of movement
        if (moveDirection.magnitude > float.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        animator.SetFloat("Forward", moveDirection.magnitude);

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity * Time.deltaTime);
        }
    }
}
