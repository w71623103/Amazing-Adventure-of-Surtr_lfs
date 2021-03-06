using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//logics of player
public class PlayerController
{
    public PlayerModel model;

    public PlayerController(PlayerModel newMod)
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

    public void hMovement()
    {
        model.characterRB.velocity = new Vector2(model.horizontalMovement, model.characterRB.velocity.y);
    }

    //control jump
    public void Jump()
    {
        //jump action has a CD, makes it only able to jump once per 0.5 second
        if (model.jumpTimer < 0)
        {
            if (Input.GetKey(KeyCode.K) && model.isGrounded && !Input.GetKey(KeyCode.S)) //on the ground and get the input
            {
                model.jumpTimer = model.jumpCD; //reset timer
                
                model.characterRB.AddForce(new Vector2(0, model.jumpSpeed), ForceMode2D.Impulse); //jump
            }
        }

    }

    public void collectItem(PlayerCore pl)
    {
        RaycastHit2D hit = Physics2D.Raycast(pl.transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("collectable"));
        
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("collectable"))
            {
                model.inventory[hit.collider.gameObject.GetComponent<collectable>().type] = true;
                if(hit.collider.gameObject.GetComponent<collectable>().type == "heal")
                {
                    model.healUIP.SetActive(true);
                }
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

    public void heal(PlayerCore pl)
    {
        if (model.inventory["heal"] && model.healTimer <= 0f && model.hp < model.maxhp && model.healNum > 0)
        {
            Object.Instantiate(model.healEffect, pl.transform.position, Quaternion.identity);
            model.healTimer = model.healCD;
            if (model.hp + 35 < model.maxhp)
                model.hp += 35;
            else
                model.hp = model.maxhp;
            model.healUI[model.healNum - 1].SetActive(false);
            model.healNum--;
            
        }
    }

    public void healUIUpdate()
    {
        for (int i = 0; i < model.healNum; i++)
        {
            model.healUI[i].SetActive(true);
        }

        for (int i = model.healUI.Length-1; i > model.healNum-1; --i)
        {
            model.healUI[i].SetActive(false);
        }
    }
}
