using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Components
    public NavMeshAgent agent { get; private set; }
    public CharacterController character { get; private set; }
    public Animator animator { get; private set; }

    // Camera
    [SerializeField]
    private Vector3 cameraOffset;
    [SerializeField]
    private Vector3 cameraRotation;

    // States
    public PlayerStateBase currentState { get; private set; }
    public PlayerStateRun stateRun { get; private set; }
    public PlayerStateStop stateStop { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Setup components
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        // Setup camera
        Camera.main.transform.rotation = Quaternion.Euler(cameraRotation);

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

    // Always do camera follow code last, after player has moved.
    void LateUpdate()
    {
        Camera.main.transform.position = transform.position + cameraOffset;
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (other.gameObject.tag == "Spikes")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(SceneManager.sceneCountInBuildSettings);
        }
    }
}
