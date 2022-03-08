using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the first attacking action in the combo
[System.Serializable]
public class PAStateA : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    [SerializeField] private bool hasCombo = false;
    [SerializeField] private GameObject attackA;
    [SerializeField] private GameObject pos;
    private GameObject newAttack;

    //play audio and animation, instantiate the attack effect object
    public override void EnterState(PlayerCore pl)
    {
        pl.GetComponent<AudioSource>().PlayOneShot(pl.model.hitSound);
        frameCounter = maxFrameNum;
        hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackAHash, pl.model.attackAanim);
        newAttack = GameObject.Instantiate(attackA,pos.transform.position,Quaternion.identity);
        newAttack.transform.localScale = new Vector3(pl.transform.localScale.x * newAttack.transform.localScale.x, newAttack.transform.localScale.y, newAttack.transform.localScale.z);
    }

    //if key is pressed during the attack A, change state to the second combo (attackB), otherwise change to a transition state that allows a short time to continue the combo
    public override void Update(PlayerCore pl)
    {
        if(pl.model.attackInput && pl.model.inventory["combo"]) hasCombo = true;

        if (frameCounter <= 0f)
        {
            if (hasCombo) pl.ChangeAttackState(pl.model.atkStateB);
            else pl.ChangeAttackState(pl.model.atkStateT);
        }
        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {
        //this timer is make sure when you press the attack button quickly, the audio player don't get crazy
        if (pl.model.attackSoundCounter <= 0)
        {
            pl.model.attackSoundCounter = pl.model.attackSoundCD;
            //random choice of audio to play next
            var dice = Random.Range(0, 3);
            while (pl.model.attackSoundExclude[dice])
            {
                dice = Random.Range(0, 3);
            }
            pl.model.attackSoundExclude[dice] = true;
            pl.model.soundPlayer.PlayOneShot(pl.model.atkSounds[dice]);
        }
        MonoBehaviour.Destroy(newAttack);
        pl.model.comboCount = 1;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackAHash, pl.model.attackAanim);
    }
}
