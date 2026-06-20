
using System;
using UnityEngine;


public class Player : Entity, IEntity
{
    public PlayerInputSystem playerInputSystem;
    public float DashCd = 3f;
    public bool fanji ;
    public bool canfanji;
    private AnimationTrr animTrr;
    
    
    public IdleState _idleState { get; private set; }
    public MoveState _moveState{ get; private set; }
    public JumpState _jumpState{ get; private set; }
    public JumpFall _jumpFall{ get; private set; }
    public WallHua _WallHua{ get; private set; }
    public DashState _DashState{ get; private set; }
    public AttackState _AttackState{ get; private set;}
    
    public DeadState _deadState{ get; private set;}
    public FanjiState _FanjiState{ get; private set;}
    

    protected override void Awake()
    {
        base.Awake();
        playerInputSystem = new PlayerInputSystem();
        _idleState = new IdleState(statemachine,this,"Idle");
        _moveState = new MoveState(statemachine,this,"Move");
        _jumpFall = new JumpFall(statemachine,this,"Jump");
        _jumpState = new JumpState(statemachine,this,"Jump");
        _WallHua = new WallHua(statemachine,this,"Wall");
        _DashState = new DashState(statemachine,this,"Dash");
        _AttackState = new AttackState(statemachine, this, "Attack");
        _deadState = new DeadState(statemachine,this,"Dead");
        _FanjiState = new FanjiState(statemachine,this,"fanji");
        statemachine.Init(_idleState);
        animTrr = GetComponentInChildren<AnimationTrr>();
        
        
    }

    protected  void CounterEffect()
    {
       
     
        

    }


    private void Start()
    {
       
    }

    protected override void Update()
    {
        base.Update();
        DashCdFun();
        CounterEffect();
    }

    private void OnEnable()
    {
        playerInputSystem.Enable();
        playerInputSystem.Player.Move.performed+= ctx =>move=ctx.ReadValue<Vector2>();
        playerInputSystem.Player.Move.canceled += ctx =>move=Vector2.zero;
    }
    
    private void OnDisable()
    {
        playerInputSystem.Disable();
    }
    
    void DashCdFun()
    {
        DashCd -= Time.deltaTime;
    }

    public void PlayerDead()
    {
        
        statemachine.ChangeState(_deadState);
        playerInputSystem.Disable();
    }


    public void OnTakeDamage(GameObject source)
    {
       
    }

    public void OnEntityDead()
    {
        PlayerDead();
    }
}

