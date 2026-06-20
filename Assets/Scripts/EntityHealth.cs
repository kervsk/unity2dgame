using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float health ;
    [SerializeField] private List<GameObject> damageSource;
    public void TakeDamage(float damage,GameObject source)
    {
        GetComponent<DamageMet>().ChangeColor();
        damageSource.Add(source);
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
