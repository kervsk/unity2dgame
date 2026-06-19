using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState :EntityEnemyState
{
    // Start is called before the first frame update

    public EnemyMoveState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void UpDate()
    {
        base.UpDate();
        rb.velocity = new Vector2(_enemy.moveSpeed*_enemy.ChaoXiang , 0);
        if (_enemy.emeryIsGround==false)
        {
            _enemy.filp();
            _enemy.statemachine.ChangeState(_enemy._idleState);
            
        }
    }

    public override void Exit()
    {
        base.Exit();
        rb.velocity = Vector2.zero;
    }
}
