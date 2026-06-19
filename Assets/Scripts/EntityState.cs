using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState 
{
    protected StataMachine stataMachine;
    protected string animationName;
    public bool isattackover ;
    protected Animator anim;
    protected Rigidbody2D rb;
    
    public EntityState (StataMachine stataMachine,string animationName)
    {
        this.stataMachine = stataMachine;
      
        this.animationName = animationName;
    }
    
    public virtual void Enter()
    {
        
        anim.SetBool(animationName,true);
        isattackover = false;
    }
    
    public virtual void UpDate()
    {
    
    }
    public virtual void Exit()
    {
        
        anim.SetBool(animationName,false);
    }
    
    public void SetAttack()
    {
        isattackover = true;
    }
}
