
public abstract class EnitityStata
{
    // Start is called before the first frame update
    protected StataMachine stataMachine;
    protected Player _player;
    protected string animationName;
    public bool isattackover = false;
    
    public EnitityStata (StataMachine stataMachine,Player player,string animationName)
    {
        this.stataMachine = stataMachine;
        this._player = player;
        this.animationName = animationName;
    }
    
    public virtual void Enter()
    {
        _player.animator.SetBool(animationName,true);
        isattackover = false;
    }
    
    public virtual void UpDate()
    {
        _player.animator.SetFloat("yVecolity",_player.rb.velocity.y);
        if (_player.playerInputSystem.Player.Sprint.WasPerformedThisFrame()&&_player.DashCd<0)
        {
            _player.statemachine.ChangeState(_player._DashState);
        }
    }
    
    public virtual void Exit()
    {
        _player.animator.SetBool(animationName,false);
    }

    public void SetAttack()
    {
        isattackover = true;
    }
}
