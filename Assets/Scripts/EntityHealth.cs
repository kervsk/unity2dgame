using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    // Start is called before the first frame update
    [SerializeField] public float health ;
    [SerializeField] private List<GameObject> damageSource;
    
    
    private IEntity _entity;
    private bool _isDead;
    void Awake()
    {
        maxHealth = health;
        // 只查找一次接口，避免每次受伤GetComponent
        _entity = GetComponent<IEntity>();
    }
  
    public void TakeDamage(float damage,GameObject source)
    {
        // 死亡直接返回，解决多次扣血重复死亡
        if (_isDead) return;

        GetComponent<DamageMet>()?.ChangeColor();

        // 去重，防止列表无限膨胀
        if (!damageSource.Contains(source))
        {
            damageSource.Add(source);
        }

        health -= damage;

        // 调用接口受伤，代替你原来layer硬编码
        _entity?.OnTakeDamage(source);
        
        EnemyDead();
    }

    public virtual void EnemyDead()
    {
        if (health <= 0 && !_isDead)
        {
            _isDead = true;
            _entity?.OnEntityDead();
        }
    }
}
