using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when damaged, this state will change the color of the enemy to red quickly, and in the next damage state will change it back
[System.Serializable]
public class EGStateDamage1 : EnemyGeneralStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.5f;
    public override void EnterState(EnemyCore em)
    {
        frameCounter = 0f;
    }

    public override void Update(EnemyCore em)
    {
        em.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(em.gameObject.GetComponent<SpriteRenderer>().color, Color.red, frameCounter / maxFrameNum);

        if (frameCounter > 0.5f)
        {
            em.ChangeGeneralState(em.model.gStateDamage2);
        }
        //=======================================

        frameCounter += Time.deltaTime;
    }

    public override void LeaveState(EnemyCore em)
    {

    }
}
