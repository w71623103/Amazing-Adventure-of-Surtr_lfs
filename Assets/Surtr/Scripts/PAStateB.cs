using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateB : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.333f;
    [SerializeField] private bool hasCombo = false;
    [SerializeField] private GameObject attackB;
    [SerializeField] private GameObject pos;
    private GameObject newAttack;

    public override void EnterState(PlayerCore pl)
    {
        pl.GetComponent<AudioSource>().PlayOneShot(pl.model.hitSound);
        frameCounter = maxFrameNum;
        hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackBHash, pl.model.attackAanim);
        //attackB.SetActive(true);
        newAttack = GameObject.Instantiate(attackB, pos.transform.position, Quaternion.identity);
        newAttack.transform.localScale = new Vector3(pl.transform.localScale.x * newAttack.transform.localScale.x, newAttack.transform.localScale.y, newAttack.transform.localScale.z);
    }

    public override void Update(PlayerCore pl)
    {
        if (pl.model.attackInput) hasCombo = true;

        if (frameCounter <= 0f)
        {
            if (hasCombo) pl.ChangeAttackState(pl.model.atkStateC);
            else pl.ChangeAttackState(pl.model.atkStateT);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackB Behavior");
        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {
        MonoBehaviour.Destroy(newAttack);
        pl.model.comboCount = 2;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackBHash, pl.model.attackAanim);
        //attackB.SetActive(false);
    }
}
