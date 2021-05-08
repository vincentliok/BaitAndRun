using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateDie : EnemyStateBase
{
    public override void EnterState(EnemyController enemy)
    {
        enemy.agent.ResetPath();
        enemy.character.Move(Vector3.zero);
        enemy.agent.enabled = false;
        enemy.character.enabled = false;
        enemy.animator.SetBool("DeathTrigger", true);
    }

    public override void Update(EnemyController enemy)
    {
        if (enemy.corpseTimer > enemy.maxCorpseTime)
        {
            enemy.gameObject.SetActive(false);
        }
        enemy.corpseTimer += Time.deltaTime;
    }

    public override void LeaveState(EnemyController enemy)
    {

    }
}
