using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateRun : PlayerStateBase
{
    public override void EnterState(PlayerController player)
    {
        // Unfreeze
        player.animator.speed = 1;
    }

    public override void Update(PlayerController player)
    {
        // Face in direction of movement
        if (player.agent.desiredVelocity.magnitude > float.Epsilon)
        {
            player.transform.rotation = Quaternion.LookRotation(player.agent.desiredVelocity);
            player.animator.SetFloat("Forward", player.agent.desiredVelocity.magnitude);
        }

        // If not there yet, keep going, otherwise change to stop state
        if (player.agent.remainingDistance > player.agent.stoppingDistance)
        {
            // Move along path
            player.character.Move(player.agent.desiredVelocity * Time.deltaTime);
        }
        else
        {
            player.ChangeState(player.stateStop);
        }
    }

    public override void LeaveState(PlayerController player)
    {
        // Freeze
        player.animator.speed = 0;
    }
}
