using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attack State A for enemies, attack state A is the state that attack fx and effects will apply to the scene
[System.Serializable]
public class EAStateA : EnemyAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    [SerializeField] private GameObject attackA;
    [SerializeField] private GameObject pos;
    private GameObject newAttack;

    public override void EnterState(EnemyCore em) 
    {
        frameCounter = maxFrameNum;
        em.model.attackAanim = true;
        em.model.enemyAnim.SetBool(em.model.isAttackAHash, em.model.attackAanim);
        //attackA.SetActive(true);
        newAttack = GameObject.Instantiate(attackA, pos.transform.position, Quaternion.identity);
        newAttack.transform.localScale = new Vector3(-em.transform.localScale.x * newAttack.transform.localScale.x, newAttack.transform.localScale.y, newAttack.transform.localScale.z);
    }
    public override void Update(EnemyCore em) 
    {
        if (frameCounter <= 0f)
        {
            em.ChangeAttackState(em.model.atkStateCD);
        }
        //=======================================

        frameCounter -= Time.deltaTime;
    }
    public override void LeaveState(EnemyCore em) 
    {
        MonoBehaviour.Destroy(newAttack);
        em.model.attackAanim = false;
        em.model.enemyAnim.SetBool(em.model.isAttackAHash, em.model.attackAanim);
    }
}
