using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This state gives some cool-down between enemy attacks.
[System.Serializable]
public class EAStateCD : EnemyAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 5f;
    [SerializeField] private GameObject attackA;
    [SerializeField] private GameObject pos;
    private GameObject newAttack;

    public override void EnterState(EnemyCore em)
    {
        frameCounter = maxFrameNum;
    }
    public override void Update(EnemyCore em) 
    {
        if (frameCounter <= 0f)
        {
            em.ChangeAttackState(em.model.atkStateDefault);
        }
        //=======================================

        frameCounter -= Time.deltaTime;
    }
    public override void LeaveState(EnemyCore em) 
    {

    }
}
