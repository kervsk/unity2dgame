using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    public EnemyIdleState _idleState;
    public EnemyMoveState _moveState;
    public EnemyAttackState _attackState;
    public EnemyDead _deadState;
    public bool isBattle;
    [SerializeField]
    private Transform player;
    public  float InBattle=10f;
    [SerializeField]
    private LayerMask playerMask;

    [SerializeField] private float juli;
    [SerializeField] protected float playerjuli;
    
    
    
     public bool emeryIsGround = false;

     protected override void Update()
     {
         base.Update();
         Battle();
         BattleFlip();
     }

     protected override void GroundCheck()
    {
        base.GroundCheck();
        emeryIsGround = (Physics2D.Raycast(transform.position+Vector3.right*ChaoXiang, Vector2.down, GroundXia, Ground));
        PlayerCanAttack();
        PlayerDetection();
        
    }

    public RaycastHit2D PlayerDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * ChaoXiang, juli, playerMask);
        return hit;
    }

    public RaycastHit2D PlayerCanAttack()
    {
        return Physics2D.Raycast(transform.position, Vector2.right * ChaoXiang, playerjuli, playerMask);
    }
    public override void filp()
    {
        if (isFilp==false)
        {

            PlayerFlip();

        }
        else if ( isFilp)
        {

            PlayerFlip();
        }
    }

    public void Battle()
    {
        if (PlayerDetection())
        {
            isBattle = true;
           
        }

        if (InBattle > 0)
        {
            InBattle-=Time.deltaTime;
        }

        if (InBattle <= 0)
        {
            isBattle = false;
            InBattle = 10f;
        }
    }

    public void BattleFlip()
    {
        if (isBattle)
        {
            
            if(transform.position.x-player.transform.position.x>0&&ChaoXiang>0)
            {
                filp();
            }

            if (transform.position.x - player.transform.position.x < 0 && ChaoXiang < 0)
            {
                filp();
            }
        }
     
    }

    public void EnemyDead()
    {
        statemachine.ChangeState(_deadState);
        Destroy(gameObject, 2f);
    }
}
