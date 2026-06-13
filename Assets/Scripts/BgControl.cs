using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera mainCamera;
  [SerializeField] private BgControlItem[] bgControls;
  private float currentLong;
  private float lastLong;
    
   void Update()
  {
      currentLong = mainCamera.transform.position.x;
      float movelong = currentLong - lastLong;
      lastLong = currentLong;

      foreach (var VARIABLE in bgControls)
      {
            VARIABLE.SetTransform(movelong);         
      }
  }
  
   
  
}
