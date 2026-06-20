using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : EntityEnemyState
{
    // Start is called before the first frame update
    public EnemyDead(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }
    

    public override void Enter()
    {
        base.Enter();
        anim.enabled = false;
        rb.gravityScale = 12;
        rb.velocity = new Vector2(rb.velocity.x, 12);
        rb.GetComponent<Collider2D>().enabled = false;

    }
}
