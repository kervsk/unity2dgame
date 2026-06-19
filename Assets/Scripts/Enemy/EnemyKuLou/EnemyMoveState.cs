using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState :EntityEnemyState
{
    // Start is called before the first frame update

    public EnemyMoveState(StataMachine stataMachine, Enemy enemy, string animationName) : base(stataMachine, enemy, animationName)
    {
    }
}
