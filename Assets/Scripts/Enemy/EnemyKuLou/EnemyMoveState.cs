using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState :EnemyGroundState
{
    // Start is called before the first frame update

    public EnemyMoveState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void UpDate()
    {
        base.UpDate();
        rb.velocity = new Vector2(_enemy.moveSpeed*_enemy.ChaoXiang , rb.velocity.y);
        if (_enemy.emeryIsGround==false&&_enemy.isBattle==false)
        {
            _enemy.filp();
            _enemy.statemachine.ChangeState(_enemy._idleState);
            
        }

        if (_enemy.isWall)
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
