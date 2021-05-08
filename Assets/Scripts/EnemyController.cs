using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Adjust in editor
    public float aggroRadius;
    public float maxCorpseTime;

    // Components
    public NavMeshAgent agent { get; private set; }
    public CharacterController character { get; private set; }
    public Animator animator { get; private set; }

    // States
    public EnemyStateBase currentState { get; private set; }
    public EnemyStateChase stateChase { get; private set; }
    public EnemyStateStop stateStop { get; private set; }
    public EnemyStateDie stateDie { get; private set; }

    // Reference to player
    public GameObject target { get; private set; }

    // Helper variables
    private bool isDead;
    [System.NonSerialized]
    public float corpseTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Setup components
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        // Setup states
        stateChase = new EnemyStateChase();
        stateStop = new EnemyStateStop();
        stateDie = new EnemyStateDie();

        ChangeState(stateStop);

        // Find player
        target = GameObject.Find("Player");

        // Setup variables
        isDead = false;
        corpseTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    public void ChangeState(EnemyStateBase newState)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spikes" && !isDead)
        {
            ChangeState(stateDie);
            isDead = true;
        }
    }
}
