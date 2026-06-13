using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : EnitityStata
{
    // Start is called before the first frame update
    public AirState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

    public override void UpDate()
    {
        base.UpDate();
        if (_player.move.x != 0)
        {
            _player.filp();
            _player.updateSpeed(_player.move);

        }

        if (_player.isWall)
        {
            _player.statemachine.ChangeState(_player._WallHua);
        }
       
        
    }
}
