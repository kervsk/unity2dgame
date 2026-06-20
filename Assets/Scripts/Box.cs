using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour,IEntity
{
    private Animator animator;
    private void Awake()
    {
         animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage()
    {
        animator.SetBool("Open",true);
    }

    public void OnTakeDamage(GameObject source)
    {
      
    }

    public void OnEntityDead()
    {
        TakeDamage();
    }
}
