using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EntityEnemyState
{
    float a = 3f;
    public EnemyIdleState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("dd");
    }

    public override void UpDate()
    {
        base.UpDate();
        a -=  Time.deltaTime;
        if (a < 0)
        {
            Debug.Log("dd");
            _enemy.statemachine.ChangeState(_enemy._moveState);
            a = 3f;
        }
    }
    
}
