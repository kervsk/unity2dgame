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

        statemachine.Init(_idleState);
    }
   
}
