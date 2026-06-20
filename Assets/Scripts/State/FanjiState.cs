using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanjiState :EnitityPlayerStata
{
    // Start is called before the first frame update

    public FanjiState(StataMachine stataMachine, Player player, string animationName) : base(stataMachine, player, animationName)
    {
        
    }
    public override void UpDate()
    {
        base.UpDate();

        AnimatorStateInfo animInfo = _player.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0);
        // 攻击动画播放完毕，退出回到地面
        if (animInfo.normalizedTime >= 1f)
        {
            _player.statemachine.ChangeState(_player._idleState);
            
        }

        // 攻击状态内不再响应跳跃、攻击等输入
    }
}
