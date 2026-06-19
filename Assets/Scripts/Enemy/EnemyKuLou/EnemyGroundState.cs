using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundState : EntityEnemyState
{
    // Start is called before the first frame update
    public EnemyGroundState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }

    public override void UpDate()
    {
        base.UpDate();
        if (_enemy.isBattle&&_enemy.PlayerCanAttack())
        {
            _enemy.statemachine.ChangeState(_enemy._attackState);
        }
    }
    
    
}
