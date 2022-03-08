using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//general state contains default, damage1, damage2, dead
[System.Serializable]
public abstract class EnemyGeneralStateBase
{
    public abstract void EnterState(EnemyCore em);
    public abstract void Update(EnemyCore em);
    public abstract void LeaveState(EnemyCore em);
}
