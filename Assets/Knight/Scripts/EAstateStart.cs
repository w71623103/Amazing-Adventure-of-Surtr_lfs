using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EAStateStart : EnemyAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.5f;

    public override void EnterState(EnemyCore em) 
    {
        Debug.Log("startAttack");
        frameCounter = 0f;
        em.model.enemyAnim.SetBool(em.model.isAttackStartHash, true);
    }
    public override void Update(EnemyCore em) 
    {
        em.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(em.gameObject.GetComponent<SpriteRenderer>().color, Color.black, frameCounter / maxFrameNum);

        if (frameCounter >= maxFrameNum)
        {
            em.ChangeAttackState(em.model.atkStateA);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackA Behavior");
        //=======================================

        frameCounter += Time.deltaTime;
    }
    public override void LeaveState(EnemyCore em) 
    {
        em.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        em.model.enemyAnim.SetBool(em.model.isAttackStartHash, false);
    }
}
