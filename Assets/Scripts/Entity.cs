using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StataMachine statemachine { get; private set; }
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public bool isFilp = true;
    public bool isGround ;
    public bool isWall ;
    
    
    public int ChaoXiang = 1;
    
    [SerializeField] protected LayerMask Ground;
    
    
    [Header("moveSpeed")]
    public float moveSpeed = 5f;
    [Header("Jump")]
    public float jumpForce = 5f;
    [Header("GroundXia")]
    public float GroundXia = 1.1f;
    public float GroundRight = 0.4f;
    


 
    public Vector2 move;
    
    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>(); //初始化碰撞体
        statemachine = new StataMachine();
      
    }
 
    
   
    // Update is called once per frame
    protected virtual void Update()
    {
        
        statemachine.CurrentState.UpDate();
        GroundCheck();
       


    }

    protected virtual void GroundCheck()
    {
        isGround = (Physics2D.Raycast(transform.position, Vector2.down, GroundXia, Ground));
        isWall = (Physics2D.Raycast(transform.position, Vector2.right * ChaoXiang, GroundRight, Ground));
    }
    
    public virtual void filp()
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
    
    public void  SetAttack()
    {
        statemachine.CurrentState.SetAttack();
    }

   
}
