using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnitityPlayerStata
{
    // Start is called before the first frame update

    public DeadState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
    }
    
}
