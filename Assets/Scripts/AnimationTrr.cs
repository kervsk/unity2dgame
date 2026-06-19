using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrr : MonoBehaviour
{
    public Entity Entity;
    public void Awake()
    {
        Entity = GetComponentInParent<Entity>();
    }
    // Start is called before the first frame update
  public virtual void AttackTr()
  {
      Entity.SetAttack();
  }
}
