using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHp : MonoBehaviour
{
  [SerializeField] private Entity entity;
  private EntityHealth entityHealth;
  private Slider slider;
  private bool isFlipped;

  private void Awake()
  {
    slider = GetComponent<Slider>();
    entityHealth= entity.GetComponent<EntityHealth>();
  }

  private void Start()
  {
    
    slider.maxValue = entityHealth.maxHealth;
  }

  private void Update()
  {
    
    slider.value = entityHealth.health;
    if (entity.ChaoXiang!=1&&isFlipped==false)
    {
      
      transform.Rotate(0, 180, 0);
      isFlipped = true;

    }
    else if (entity.ChaoXiang == 1&&isFlipped==true)
    {
      transform.Rotate(0, 180, 0);
       isFlipped = false;
    }
  }
}
