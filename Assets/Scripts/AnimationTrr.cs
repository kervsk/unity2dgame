using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrr : MonoBehaviour
{
    public Player player;
    public void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    // Start is called before the first frame update
  public void AttackTr()
  {
      player.SetAttack();
  }
}
