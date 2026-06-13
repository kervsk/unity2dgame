
public class IdleState :EntityGround
{
    // Start is called before the first frame update


    public IdleState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
        
    }

    public override void UpDate()
    {
        base.UpDate();
        if (_player.move.x != 0)
        {
            _player.statemachine.ChangeState(_player._moveState);
        }
    }
}
