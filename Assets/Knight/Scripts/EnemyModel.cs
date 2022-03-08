using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contains variables of enemy
[System.Serializable]
public class EnemyModel
{
    public enum EnemyMode { patrol, boss};
    public EnemyMode enemyMode = EnemyMode.patrol;
    public float hp;
    public float maxhp;

    public Rigidbody2D characterRB;
    public float horizontalMovement = 0f;
    public float moveSpeed = 2f;
    public bool isLeft = false;
    
    public int direction = 1;

    public bool attackCondition;
    public EnemyAttackStateBase attackState;
    public EAStateA atkStateA = new EAStateA();
    public EAStateCD atkStateCD = new EAStateCD();
    public EAStateStart atkStateStart = new EAStateStart();
    public EAStateDefault atkStateDefault = new EAStateDefault();

    public Animator enemyAnim;
    public bool attackAanim = false;
    public int isMovingHash;
    public int isAttackAHash;
    public int isAttackStartHash;
    public int isDeadHash;

    public EnemyGeneralStateBase generalState;
    public EGStateDefault gStateDefault = new EGStateDefault();
    public EGStateDamage1 gStateDamage1 = new EGStateDamage1();
    public EGStateDamage2 gStateDamage2 = new EGStateDamage2();
    public EGStateDead gStateDead = new EGStateDead();

    public float hitForce;
    public float attackRange = 0.3f;
    public float attacRayHeightModifier = 0f;
}
