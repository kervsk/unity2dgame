using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyGroundState
{
    float a = 0.5f;
    public EnemyIdleState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       
    }

    public override void UpDate()
    {
        base.UpDate();
        a -=  Time.deltaTime;
        if (a < 0)
        {
           
            _enemy.statemachine.ChangeState(_enemy._moveState);
            a = 3f;
        }
    }
    
}
