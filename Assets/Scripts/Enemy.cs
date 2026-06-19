using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    public IdleState _idleState;
    public MoveState _moveState;
}
