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
          if (VARIABLE.GetComponent<Player>().canfanji)
          {
              Debug.Log("damage");
              Debug.Log(GetComponent<Rigidbody2D>().velocity.x);
              this.GetComponent<Rigidbody2D>().velocity =
                  new Vector2(-100f, GetComponent<Rigidbody2D>().velocity.y);
          }
        }
    }
    public Collider2D[] CheckAttack()
    {

        return Physics2D.OverlapCircleAll(target.position, CheckRange, _LayerMask);
    }
    
    
}
