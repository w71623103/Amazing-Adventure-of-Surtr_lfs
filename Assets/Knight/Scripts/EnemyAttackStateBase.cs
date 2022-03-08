using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attack states contains attackStart, attackA, attackCD
[System.Serializable]
public abstract class EnemyAttackStateBase
{
    public abstract void EnterState(EnemyCore em);
    public abstract void Update(EnemyCore em);
    public abstract void LeaveState(EnemyCore em);
}
