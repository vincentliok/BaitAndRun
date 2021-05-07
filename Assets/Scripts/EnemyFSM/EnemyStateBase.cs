using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStateBase
{
    public abstract void EnterState(EnemyController enemy);
    public abstract void Update(EnemyController enemy);
    public abstract void LeaveState(EnemyController enemy);
}
