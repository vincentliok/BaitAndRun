using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChase : EnemyStateBase
{
    public override void EnterState(EnemyController enemy)
    {

    }

    public override void Update(EnemyController enemy)
    {
        // Only move when player is moving
        if (enemy.target.GetComponent<PlayerController>().currentState == enemy.target.GetComponent<PlayerController>().stateRun)
        {
            // Unfreeze
            enemy.animator.speed = 1;
            // Set a path towards player
            enemy.agent.SetDestination(enemy.target.transform.position);

            // Face in direction of movement
            if (enemy.agent.desiredVelocity.magnitude > float.Epsilon)
            {
                enemy.transform.rotation = Quaternion.LookRotation(enemy.agent.desiredVelocity);
                enemy.animator.SetFloat("Forward", enemy.agent.desiredVelocity.magnitude);
            }

            if (enemy.agent.remainingDistance > enemy.agent.stoppingDistance)
            {
                // Move along path
                enemy.character.Move(enemy.agent.desiredVelocity * Time.deltaTime);
            }
        }
        else
        {
            enemy.animator.speed = 0;               // Freeze
            enemy.agent.ResetPath();                // Clear navmesh destination
            enemy.character.Move(Vector3.zero);     // Stop moving
        }

        // If player is out of range, change to stop state

        float dist = Vector3.Distance(enemy.target.transform.position, enemy.transform.position);
        if (dist > enemy.aggroRadius)
        {
            enemy.agent.ResetPath();                // Clear navmesh destination
            enemy.character.Move(Vector3.zero);     // Stop moving
            enemy.ChangeState(enemy.stateStop);     // Change to stop state
        }
    }

    public override void LeaveState(EnemyController enemy)
    {
        // Unfreeze
        enemy.animator.speed = 1;
    }
}
