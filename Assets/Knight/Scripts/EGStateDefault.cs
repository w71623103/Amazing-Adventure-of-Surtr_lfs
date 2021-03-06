using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if hp less than 0, the enemy is dead, make sure it ends the attacking action
public class EGStateDefault : EnemyGeneralStateBase
{
    public override void EnterState(EnemyCore em) 
    {
        
    }
    public override void Update(EnemyCore em) 
    {
        if (em.model.hp <= 0) em.ChangeGeneralState(em.model.gStateDead);
    }

    public override void LeaveState(EnemyCore em) 
    {
        em.ChangeAttackState(em.model.atkStateDefault);
    }
}
