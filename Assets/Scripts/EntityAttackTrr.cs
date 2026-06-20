using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackTrr : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float CheckRange = 1f;
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private float Damage;

    public void AttackDamage()
    {
        foreach (var VARIABLE in CheckAttack())
        {
          VARIABLE.GetComponent<EntityHealth>().TakeDamage(Damage,gameObject);
        }
    }
    public Collider2D[] CheckAttack()
    {

        return Physics2D.OverlapCircleAll(target.position, CheckRange, _LayerMask);
    }
    
    
}
