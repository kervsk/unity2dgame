using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEnemyState : EntityState
{
    protected Enemy _enemy;
    // Start is called before the first frame update
    public EntityEnemyState(StataMachine stataMachine,Enemy enemy, string animationName) : base(stataMachine, animationName)
    {
        _enemy = enemy;
        anim = enemy.animator;
        rb = enemy.rb;
    }


}
