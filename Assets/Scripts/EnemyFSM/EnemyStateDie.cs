using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateDie : EnemyStateBase
{
    public override void EnterState(EnemyController enemy)
    {
        enemy.agent.ResetPath();                            // Clear navmesh destination
        enemy.character.Move(Vector3.zero);                 // Stop moving
        enemy.agent.enabled = false;                        // Disable navmesh agent
        enemy.character.enabled = false;                    // Disable character controller
        enemy.animator.SetBool("DeathTrigger", true);       // Play death animation
    }

    public override void Update(EnemyController enemy)
    {
        // Remove corpse after a delay

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
