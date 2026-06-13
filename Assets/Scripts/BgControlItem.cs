using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BgControlItem
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;

    public void SetTransform( float speed)
    {

        _transform.position += new Vector3(speed*_speed, _transform.position.y, _transform.position.z);
    }
}
