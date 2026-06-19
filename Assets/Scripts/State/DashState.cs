using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : EnitityPlayerStata
{
    // Start is called before the first frame update
    public DashState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

     float dashDuring = 1f;

    public override void Enter()
    {
        
        base.Enter();
        dashDuring = 0.5f;
        _player.DashCd = 1.5f;
        float x = _player.ChaoXiang;
        _player.rb.AddForce(new Vector2(x, 0).normalized * 10f, ForceMode2D.Impulse);
    }


    public override void UpDate()
    {
        base.UpDate();
        dashDuring -= Time.deltaTime;
        if (dashDuring < 0)
        {
            if (_player.isGround)
            {
                _player.statemachine.ChangeState(_player._idleState);
            }

            if (_player.isWall && _player.isGround == false)
            {
                _player.statemachine.ChangeState(_player._WallHua);
                
            }

            if (_player.isWall == false && _player.isGround == false)
            {
                _player.statemachine.ChangeState(_player._jumpFall);
            }
                
        }
    }

    public override void Exit()
    {
        base.Exit();
        if (_player.isGround)
        {
            _player.rb.velocity = new Vector2(0, 0);
        }
        
    }
}
