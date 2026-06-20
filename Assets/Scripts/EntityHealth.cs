using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float health ;
    
    public void TakeDamage(float damage)
    {
        Debug.Log("damage taken");
        health -= damage;
        if(health <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        
    }
}
