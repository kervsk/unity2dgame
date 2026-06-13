using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallHua :AirState
{
    // Start is called before the first frame update
    public WallHua(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

    public override void UpDate()
    {
        base.UpDate();
        if (_player.isGround)
        {
            _player.statemachine.ChangeState(_player._idleState);
            _player.filp();
        }

        if (_player.rb.velocity.x != 0)
        {

           
            if (_player.isWall == false)
            {
                _player.statemachine.ChangeState(_player._jumpFall);
            }
        }
        if (_player.playerInputSystem.Player.Jump.WasPerformedThisFrame())
        {
            
            _player.statemachine.ChangeState(_player._jumpState);
        }
    }
       
    
}
