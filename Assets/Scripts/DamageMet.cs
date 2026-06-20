using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageMet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material _material;
    private SpriteRenderer _spriteRenderer;
    private Material _soursSpriteRenderer;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _soursSpriteRenderer = _spriteRenderer.material;
    }


    private IEnumerator OnDamage()
    {
        _spriteRenderer.material = _material;
        
        yield return new WaitForSeconds(0.3f);
        _spriteRenderer.material = _soursSpriteRenderer;
    }
    
    public void ChangeColor()
    {
        if (_coroutine!=null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine= StartCoroutine(OnDamage());
        
    }
}
