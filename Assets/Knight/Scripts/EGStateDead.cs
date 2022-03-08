using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deactivate this object if dead
[System.Serializable]
public class EGStateDead : EnemyGeneralStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.333f;
    public override void EnterState(EnemyCore em) 
    {
        frameCounter = maxFrameNum; ;
        em.model.enemyAnim.SetBool(em.model.isDeadHash, true);
        em.model.horizontalMovement = 0f;
        em.model.characterRB.velocity = Vector2.zero;
        em.model.characterRB.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public override void Update(EnemyCore em) 
    {
        em.model.characterRB.velocity = Vector2.zero;
        if (frameCounter <= 0f)
        {
            em.gameObject.SetActive(false);
        }

        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(EnemyCore em) 
    { 

    }
}
