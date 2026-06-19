

public class EntityGround : EnitityPlayerStata
{
    // Start is called before the first frame update
    public EntityGround(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }

  

    // Update is called once per frame
    public override void UpDate()
    {
        base.UpDate();
        if (_player.playerInputSystem.Player.Jump.WasPerformedThisFrame())
        {
            _player.statemachine.ChangeState(_player._jumpState);
        }

        if (_player.playerInputSystem.Player.Attack.WasPerformedThisFrame())
        {
            _player.statemachine.ChangeState(_player._AttackState);
        }
            
    }
}
