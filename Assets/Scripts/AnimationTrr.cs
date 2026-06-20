using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrr : MonoBehaviour
{
    private Entity Entity;
    
    private EntityAttackTrr _attackTrr;
    public bool _canfanji;
   
   
    
    public void Awake()
    {
        Entity = GetComponentInParent<Entity>();
        _attackTrr = Entity.GetComponentInChildren<EntityAttackTrr>();
    }
    // Start is called before the first frame update
  public virtual void AttackTr()
  {
      Entity.SetAttack();
  }

  public void AttackCheckTrr()
  {
      _attackTrr.AttackDamage();
  }
    


}
