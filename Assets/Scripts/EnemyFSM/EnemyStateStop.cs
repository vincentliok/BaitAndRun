using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateStop : EnemyStateBase
{
    public override void EnterState(EnemyController enemy)
    {
        enemy.animator.SetFloat("Forward", 0.0f);
    }

    public override void Update(EnemyController enemy)
    {
        float dist = Vector3.Distance(enemy.target.transform.position, enemy.transform.position);
        if (dist < 5)
        {
            enemy.ChangeState(enemy.stateChase);
        }
    }

    public override void LeaveState(EnemyController enemy)
    {

    }
}
