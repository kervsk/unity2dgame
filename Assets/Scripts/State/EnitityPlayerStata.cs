
using UnityEngine;

public  class EnitityPlayerStata:EntityState
{
    // Start is called before the first frame update
    protected Player _player;
    
   
    
    public EnitityPlayerStata (StataMachine stataMachine,Player player,string animationName) : base(stataMachine, animationName)
    {
        
        _player = player;
        anim = player.animator;
        rb = player.rb;

    }
    
    public override void Enter()
    {
        base.Enter();
        isattackover = false;
    }
    
    public override void UpDate()
    {
        base.UpDate();
        anim.SetFloat("yVecolity",rb.velocity.y);
      
        if (_player.playerInputSystem.Player.Sprint.WasPerformedThisFrame()&&_player.DashCd<0)
        {
            _player.statemachine.ChangeState(_player._DashState);
        }
    }
    
 
    
}
