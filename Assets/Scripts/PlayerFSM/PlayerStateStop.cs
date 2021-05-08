using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateStop : PlayerStateBase
{
    public override void EnterState(PlayerController player)
    {

    }

    public override void Update(PlayerController player)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                player.agent.SetDestination(hit.point);
                player.ChangeState(player.stateRun);
            }
        }
    }

    public override void LeaveState(PlayerController player)
    {

    }
}
