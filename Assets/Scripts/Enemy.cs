using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    public EnemyIdleState _idleState;
    public EnemyMoveState _moveState;
    
     public bool emeryIsGround = false;
    

    protected override void GroundCheck()
    {
        base.GroundCheck();
        emeryIsGround = (Physics2D.Raycast(transform.position+Vector3.right*ChaoXiang, Vector2.down, GroundXia, Ground));;
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
}
