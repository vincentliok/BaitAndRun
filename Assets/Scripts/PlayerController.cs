using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Components
    public Camera cam { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public CharacterController character { get; private set; }
    public Animator animator { get; private set; }

    // States
    public PlayerStateBase currentState { get; private set; }
    public PlayerStateRun stateRun { get; private set; }
    public PlayerStateStop stateStop { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Setup components
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        // Setup states
        stateRun = new PlayerStateRun();
        stateStop = new PlayerStateStop();

        ChangeState(stateStop);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    public void ChangeState(PlayerStateBase newState)
    {
        if (currentState != null)
        {
            currentState.LeaveState(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.EnterState(this);
        }
    }
}
