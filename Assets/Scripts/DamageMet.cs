using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageMet : MonoBehaviour
{
    [SerializeField] private Color hitFlashColor = Color.red;
    private SpriteRenderer _spriteRenderer;
    // 沿用你原来的变量名 _soursSpriteRenderer，存渲染参数块
    private MaterialPropertyBlock _soursSpriteRenderer;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _soursSpriteRenderer = new MaterialPropertyBlock();
    }

    public void ChangeColor()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(OnDamage());
    }

    private IEnumerator OnDamage()
    {
        // 读取当前原有渲染参数
        _spriteRenderer.GetPropertyBlock(_soursSpriteRenderer);
        // 修改颜色，不更换材质
        _soursSpriteRenderer.SetColor("_Color", hitFlashColor);
        _spriteRenderer.SetPropertyBlock(_soursSpriteRenderer);

        yield return new WaitForSeconds(0.3f);

        // 清空参数，自动恢复原图颜色，材质全程没变
        _spriteRenderer.SetPropertyBlock(null);
        _coroutine = null;
    }

    // 物体隐藏强制还原，防止卡死变色
    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _spriteRenderer.SetPropertyBlock(null);
            _coroutine = null;
        }
    }
}
