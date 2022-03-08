using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default state of attacking, detect if attacking condition is meet or not.
[System.Serializable]
public class EAStateDefault : EnemyAttackStateBase
{
    public override void EnterState(EnemyCore em)
    {
        //em.model.comboCount = 0;

    }
    public override void Update(EnemyCore em)
    {
        if (em.model.attackCondition)
        {
            em.ChangeAttackState(em.model.atkStateStart);

        }
    }
    public override void LeaveState(EnemyCore em)
    {

    }
}
