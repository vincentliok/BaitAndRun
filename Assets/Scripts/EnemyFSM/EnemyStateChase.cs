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
        if (enemy.target.GetComponent<PlayerController>().currentState == enemy.target.GetComponent<PlayerController>().stateRun)
        {
            enemy.animator.speed = 1;
            enemy.agent.SetDestination(enemy.target.transform.position);

            // Face in direction of movement
            if (enemy.agent.desiredVelocity.magnitude > float.Epsilon)
            {
                enemy.transform.rotation = Quaternion.LookRotation(enemy.agent.desiredVelocity);
                enemy.animator.SetFloat("Forward", enemy.agent.desiredVelocity.magnitude);
            }

            if (enemy.agent.remainingDistance > enemy.agent.stoppingDistance)
            {
                enemy.character.Move(enemy.agent.desiredVelocity * Time.deltaTime);
            }
        }
        else
        {
            enemy.animator.speed = 0;
            enemy.agent.ResetPath();
            enemy.character.Move(Vector3.zero);
        }

        float dist = Vector3.Distance(enemy.target.transform.position, enemy.transform.position);
        if (dist > enemy.aggroRadius)
        {
            enemy.agent.ResetPath();
            enemy.character.Move(Vector3.zero);
            enemy.ChangeState(enemy.stateStop);
        }
    }

    public override void LeaveState(EnemyController enemy)
    {
        enemy.animator.speed = 1;
    }
}
