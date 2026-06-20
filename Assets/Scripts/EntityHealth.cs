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
        EnemyDead();
    }

    public virtual void EnemyDead()
    {
        if (health <= 0)
        {
            if (gameObject.layer == 7)
            {
                GetComponent<Player>().PlayerDead();
            }

            if (gameObject.layer == 8)
            {
                GetComponent<Enemy>().EnemyDead();
            }
        }
    }
}
