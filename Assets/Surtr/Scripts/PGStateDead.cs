using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PGStateDead : PlayerGeneralStateBase
{
    public override void EnterState(PlayerCore pl) 
    {
        //reset player to the start of the scene if dead
        pl.transform.position = pl.GetComponent<PlayerCore>().model.respawnPos;
        pl.model.hp = pl.model.maxhp;
        pl.model.healNum = 3;
        for(int i = 0; i < pl.model.healUI.Length; i++)
        {
            pl.model.healUI[i].SetActive(true);
        }
        pl.ChangeGeneralState(pl.model.gStateDefault);
    }

    public override void Update(PlayerCore pl) 
    {

    }

    public override void LeaveState(PlayerCore pl) 
    { 

    }
}
