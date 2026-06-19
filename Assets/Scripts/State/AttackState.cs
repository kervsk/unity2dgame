using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnitityPlayerStata
{
    // Start is called before the first frame update
    private int _attackNum=0;
    private bool _isNext = false;
    
    public AttackState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        _player.rb.velocity = new Vector2(0, 0);
        if (_attackNum > 2)
        {
            _attackNum = 0;
        }
        _player.animator.SetInteger("_attackNum",_attackNum);
        
        
        

    }

    public override void UpDate()
    {
        base.UpDate();
        _player.rb.velocity = new Vector2(0, 0);
        if (_player.playerInputSystem.Player.Attack.WasPerformedThisFrame())
        {
            _isNext = true;
        }
        if (isattackover)
        {
            if (_isNext)
            { _attackNum++;}
            else
            {
                _attackNum = 0;
            }
            _player.statemachine.ChangeState(_player._idleState);
            _isNext = false;

        }
    }

    public override void Exit()
    {
        base.Exit();
        
    }
}
