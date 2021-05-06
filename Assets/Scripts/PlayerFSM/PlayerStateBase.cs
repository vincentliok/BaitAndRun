using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase
{
    public abstract void EnterState(PlayerController player);
    public abstract void Update(PlayerController player);
    public abstract void LeaveState(PlayerController player);
}
