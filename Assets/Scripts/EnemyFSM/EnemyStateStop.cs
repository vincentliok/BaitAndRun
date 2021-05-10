using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateStop : EnemyStateBase
{
    public override void EnterState(EnemyController enemy)
    {
        // Stop moving
        enemy.animator.SetFloat("Forward", 0.0f);
    }

    public override void Update(EnemyController enemy)
    {
        // If player comes into range, change to chasing state

        float dist = Vector3.Distance(enemy.target.transform.position, enemy.transform.position);
        if (dist < enemy.aggroRadius)
        {
            enemy.ChangeState(enemy.stateChase);
        }
    }

    public override void LeaveState(EnemyController enemy)
    {

    }
}
