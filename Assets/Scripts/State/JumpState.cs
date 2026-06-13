
using UnityEngine;

public class JumpState : AirState
{
    // Start is called before the first frame update
    public JumpState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (stataMachine.LastCurrstate == _player._WallHua)
        {
            _player.rb.velocity = Vector2.zero;

            // 🔥 最强：45度 瞬时冲击力（绝不会被覆盖）
            float x = -_player.ChaoXiang;
            _player.rb.AddForce(new Vector2(x, 1).normalized * 5f, ForceMode2D.Impulse);
            _player.PlayerFlip();
        }
        else
        {
            _player.rb.velocity = new Vector2(_player.rb.velocity.x,_player.jumpForce);
        }
        
    }

    public override void UpDate()
    {
        base.UpDate();
        if (_player.rb.velocity.y < 0)
        {
            
            _player.statemachine.ChangeState(_player._jumpFall);
        }
    }
}
