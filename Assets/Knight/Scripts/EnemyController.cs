using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy controller, contains logic
public class EnemyController
{
    public EnemyModel model;

    public EnemyController(EnemyModel newMod)
    {
        model = newMod;
    }

    //control player sprite facing left/right
    public void scaleControl()
    {
        if (model.attackState == model.atkStateDefault)
        {
            if (model.horizontalMovement < 0)
                model.isLeft = true;
            else if (model.horizontalMovement > 0)
                model.isLeft = false;
        }
    }

    //apply the velocity according to the conditions
    public void hMovement()
    {
        model.characterRB.velocity = new Vector2(model.horizontalMovement, model.characterRB.velocity.y);
    }

    //detect if player is within the attacking range of the enemy, if so, make an attack
    public bool isInSight(EnemyCore em)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(em.transform.position.x, em.transform.position.y - 0.1f - model.attacRayHeightModifier, em.transform.position.z), new Vector2(em.transform.localScale.x, 0), model.attackRange, LayerMask.GetMask("Player"));
        Debug.DrawRay(new Vector3(em.transform.position.x, em.transform.position.y - 0.1f - model.attacRayHeightModifier, em.transform.position.z), new Vector2(em.transform.localScale.x, 0), Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                model.direction = (int) em.transform.localScale.x;
                if(hit.collider.transform.position.x - em.transform.position.x < model.attackRange)
                    return true;
            }
        }
        return false;
    }
}
