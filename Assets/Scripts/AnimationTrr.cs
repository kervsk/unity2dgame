using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrr : MonoBehaviour
{
    private Entity Entity;
    private EntityAttackTrr _attackTrr;
    
    public void Awake()
    {
        Entity = GetComponentInParent<Entity>();
        _attackTrr = Entity.GetComponent<EntityAttackTrr>();
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
