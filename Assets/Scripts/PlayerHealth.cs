using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth :EntityHealth
{
    public override void Dead()
    {
        base.Dead();
        Debug.Log("Player Dead");
    }
}
