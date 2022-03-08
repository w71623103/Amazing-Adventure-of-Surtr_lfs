using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerDashStateDash : PlayerDashStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    private Vector3 targetPosVect;

    //set the target dash position, disenable the hitbox, start animation
    public override void EnterState(PlayerCore pl)
    {
        frameCounter = 0f;
        targetPosVect = new Vector3(pl.transform.position.x + pl.transform.localScale.x * pl.model.dashDistance, pl.transform.position.y, pl.transform.position.z);
        pl.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        pl.model.playerAnim.SetBool(pl.model.isDashHash, true);
    }

    //detect if dash position is valid, lerp the player position
    public override void Update(PlayerCore pl)
    {
        frameCounter += Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(pl.transform.position, new Vector2(pl.transform.localScale.x,0), 0.6f, LayerMask.GetMask("noPass"));
        if (hit.collider != null) targetPosVect = hit.point;
        pl.transform.position = Vector3.Lerp(pl.transform.position, targetPosVect, frameCounter / maxFrameNum);
        if (frameCounter > maxFrameNum)
        {
            pl.ChangeDashState(pl.model.dStateDefault);
        }
    }

    //re-enable the hitbox, exit animation
    public override void LeaveState(PlayerCore pl)
    {
        pl.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        pl.model.playerAnim.SetBool(pl.model.isDashHash, false);
    }
}
