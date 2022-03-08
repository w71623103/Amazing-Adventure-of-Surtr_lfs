using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//in damage1 the color is changed to red, now change it back to normal
[System.Serializable]
public class EGStateDamage2 : EnemyGeneralStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.5f;
    public override void EnterState(EnemyCore em)
    {
        frameCounter = 0f;
    }

    public override void Update(EnemyCore em)
    {
        em.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(em.gameObject.GetComponent<SpriteRenderer>().color, Color.white, frameCounter / maxFrameNum);

        if (frameCounter > 0.5f)
        {
            em.ChangeGeneralState(em.model.gStateDefault);
        }
        //=======================================

        frameCounter += Time.deltaTime;
    }

    public override void LeaveState(EnemyCore em)
    {

    }
}
