using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationtrrEmery : AnimationTrr
{
    // Start is called before the first frame update
    [SerializeField] private Player _player;

    public void Fanji()
    {
        
        if (_player.fanji )
        {
            Debug.Log("fanji");
            _player.canfanji = true;
        }
    }
}
