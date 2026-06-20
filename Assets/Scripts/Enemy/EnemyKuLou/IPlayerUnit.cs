using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerUnit
{
    void OnPlayerHurt(int damage);
    void OnPlayerDead(); // Start is called before the first frame update

}
