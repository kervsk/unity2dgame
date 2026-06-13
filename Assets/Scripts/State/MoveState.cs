
using UnityEngine;

public class MoveState :EntityGround
{
    public MoveState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

   
    
  

    public override void UpDate()
    {
        base.UpDate();
        _player.filp();
        if (_player.move.x == 0)
        {
            _player.statemachine.ChangeState(_player._idleState);
        }
        
        _player.updateSpeed(_player.move);
    }

  

}
