

using UnityEngine;

public class JumpFall : AirState
{
    // Start is called before the first frame update
    public JumpFall(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

    public override void UpDate()
    {
        base.UpDate();
        if (_player.isGround)
        {
            _player.statemachine.ChangeState(_player._idleState);
        }
            
    }

    public override void Exit()
    {
        base.Exit();
        _player.rb.velocity = new Vector2(0, 0);
    }
}
