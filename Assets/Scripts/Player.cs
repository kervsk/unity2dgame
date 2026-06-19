
using System;
using UnityEngine;


public class Player : Entity
{
    public PlayerInputSystem playerInputSystem;
    public float DashCd = 3f;
    
    public IdleState _idleState { get; private set; }
    public MoveState _moveState{ get; private set; }
    public JumpState _jumpState{ get; private set; }
    public JumpFall _jumpFall{ get; private set; }
    public WallHua _WallHua{ get; private set; }
    public DashState _DashState{ get; private set; }
    public AttackState _AttackState{ get; private set;}

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
    }
    private void Start()
    {
        statemachine.Init(_idleState);
    }

    protected override void Update()
    {
        base.Update();
        DashCdFun();
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
    
    public void  SetAttack()
    {
        statemachine.CurrentState.SetAttack();
    }
}

