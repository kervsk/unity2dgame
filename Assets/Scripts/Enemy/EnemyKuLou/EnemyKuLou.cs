using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKuLou : Enemy
{
    protected override void Awake()
    {
        base.Awake();
      
        _idleState = new EnemyIdleState(statemachine,this,"Idle");
        _moveState = new EnemyMoveState(statemachine,this,"Move");
        _attackState = new EnemyAttackState(statemachine, this, "Attack");
        _deadState = new EnemyDead(statemachine, this, "Dead");
        _jifeiState = new EnemyJifeiState(statemachine, this, "Jifei");

        statemachine.Init(_idleState);
    }
   
}
