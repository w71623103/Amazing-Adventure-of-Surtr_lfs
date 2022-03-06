using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateC : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    //[SerializeField] private bool hasCombo = false;
    [SerializeField] private GameObject attackC;
    [SerializeField] private GameObject pos;
    private GameObject newAttack;

    public override void EnterState(PlayerCore pl)
    {
        pl.GetComponent<AudioSource>().PlayOneShot(pl.model.hitSound);
        frameCounter = maxFrameNum;
        //hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackCHash, pl.model.attackAanim);
        //attackC.SetActive(true);
        newAttack = GameObject.Instantiate(attackC, pos.transform.position, Quaternion.identity);
        newAttack.transform.localScale = new Vector3(pl.transform.localScale.x * newAttack.transform.localScale.x, newAttack.transform.localScale.y, newAttack.transform.localScale.z);
    }

    public override void Update(PlayerCore pl)
    {
        //if (pl.model.attackInput) hasCombo = true;

        if (frameCounter <= 0f)
        {
            /*if (hasCombo) pl.ChangeAttackState(pl.model.atkStateA);
            else pl.ChangeAttackState(pl.model.atkStateT);*/
            pl.ChangeAttackState(pl.model./*atkStateDefault*/atkStateT);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackC Behavior");
        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {
        MonoBehaviour.Destroy(newAttack);
        pl.model.comboCount = 3;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackCHash, pl.model.attackAanim);
        //attackC.SetActive(false);
    }
}
