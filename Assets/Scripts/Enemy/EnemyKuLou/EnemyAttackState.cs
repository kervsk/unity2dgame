using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EntityEnemyState
{
    // Start is called before the first frame update
    public EnemyAttackState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = Vector2.zero;
    }

    public override void UpDate()
    {
        base.UpDate();
        rb.velocity = Vector2.zero;
        if (isattackover)
        {
           _enemy.statemachine.ChangeState(_enemy._moveState);
           
        }
    }

    public override void Exit()
    {
        base.Exit();
        rb.velocity = Vector2.zero;
    }
}
