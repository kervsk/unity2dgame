
using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    public StataMachine statemachine { get; private set; }
    public Animator animator { get; private set; }
    public PlayerInputSystem playerInputSystem;
    public Rigidbody2D rb { get; private set; }
    public bool isFilp = true;
    public bool isGround = false;
    public bool isWall = false;
    public int ChaoXiang = 1;
    
    [SerializeField] private LayerMask Ground;
    
    
    [Header("moveSpeed")]
    public float moveSpeed = 5f;
    [Header("Jump")]
    public float jumpForce = 5f;
    [Header("GroundXia")]
    public float GroundXia = 1.1f;
    public float GroundRight = 0.4f;
    public float DashCd = 3f;


    public IdleState _idleState { get; private set; }
    public MoveState _moveState{ get; private set; }
    public JumpState _jumpState{ get; private set; }
    public JumpFall _jumpFall{ get; private set; }
    public WallHua _WallHua{ get; private set; }
    public DashState _DashState{ get; private set; }
    public AttackState _AttackState{ get; private set;}
    public Vector2 move;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>(); //初始化碰撞体
        statemachine = new StataMachine();
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
    // Update is called once per frame
    void Update()
    {
        
        statemachine.CurrentState.UpDate();
        GroundCheck();
        DashCdFun();


    }

    private void GroundCheck()
    {
        isGround = (Physics2D.Raycast(transform.position, Vector2.down, GroundXia, Ground));
        isWall = (Physics2D.Raycast(transform.position, Vector2.right * ChaoXiang, GroundRight, Ground));
    }
    
    public void filp()
    {
        if (move.x > 0 && isFilp==false)
        {

            PlayerFlip();

        }
        else if (move.x < 0 && isFilp)
        {

            PlayerFlip();
        }
    }
    
    public void  SetAttack()
    {
        statemachine.CurrentState.SetAttack();
    }
    
    public void PlayerFlip()
    {
        transform.Rotate(0, 180, 0);
        isFilp = !isFilp;
        ChaoXiang = -ChaoXiang;
    }
    
    
    
    public void updateSpeed(Vector2 speed)
    {
        

       
        rb.velocity = new Vector2(speed.x*moveSpeed, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -GroundXia));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(GroundRight*ChaoXiang, 0));
    }

    void DashCdFun()
    {
        DashCd -= Time.deltaTime;
    }
}
