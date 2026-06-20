using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJifeiState :EntityEnemyState
{
    public EnemyJifeiState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(-5f*_enemy.ChaoXiang,rb.velocity.y);
    }

    public override void UpDate()
    {
        base.UpDate();
        AnimatorStateInfo animInfo = _enemy.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0);
        if (animInfo.normalizedTime >= 1f)
        {
            stataMachine.ChangeState(_enemy._moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        rb.velocity = Vector2.zero;
    }
}

// Start is called before the first frame update


