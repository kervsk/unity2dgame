using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrrPlayer :AnimationTrr
{
    [SerializeField] private Player _player;
    // Start is called before the first frame update
    public void overfanji()
    {
        _player.canfanji = false;
        _player.fanji = false;
    }
}
