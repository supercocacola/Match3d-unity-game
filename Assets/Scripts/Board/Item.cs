﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Replicator;

[Serializable]
public class Item
{
    public Cell Cell { get; private set; }

    public Transform View { get; private set; }

    private SpriteRenderer m_spriteRenderer;

    public virtual void SetView()
    {
        string prefabname = GetPrefabName();

        if (!string.IsNullOrEmpty(prefabname))
        {
            ObjectPool pool = Resources.Load<ObjectPool>(prefabname);
            if (pool)
            {
                View = pool.Spawn().transform;
                m_spriteRenderer = View.GetComponent<SpriteRenderer>();
            }
        }
    }

    protected virtual string GetPrefabName() { return string.Empty; }

    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.DOMove(Cell.transform.position, 0.2f).SetRecyclable(true);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View)
        {
            View.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;
        
        if (m_spriteRenderer)
        {
            m_spriteRenderer.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;
        
        if (m_spriteRenderer)
        {
            m_spriteRenderer.sortingOrder = 0;
        }

    }

    public void SetSprite(Sprite sprite)
    {
        if (sprite)
            m_spriteRenderer.sprite = sprite;
    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.localScale;
        View.localScale = Vector3.one * 0.1f;
        View.DOScale(scale, 0.1f).SetRecyclable(true);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (View)
        {
            View.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    Recycle();
                    View = null;
                }
                ).SetRecyclable(true);
        }
    }



    internal void AnimateForHint()
    {
        if (View)
        {
            View.DOPunchScale(View.localScale * 0.1f, 0.1f).SetLoops(-1).SetRecyclable(true);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View)
        {
            View.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View)
        {
            Recycle();
            View = null;
        }
    }

    internal void Reset()
    {
        View.localScale = Vector3.one;
    }

    internal void Recycle()
    {
        Reset();
        View.gameObject.Recycle();
    }
}
