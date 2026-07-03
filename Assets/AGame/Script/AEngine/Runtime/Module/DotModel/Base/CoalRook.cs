using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoalRook
{
    public readonly int ID;
    public CoalRook CartonRook;
    public List<CoalRook> Amniotic;
    public event Action OnDotNotice; 
    
    protected Func<int> _onBowAsian;

    protected bool _RadiumBow;

    public bool LetterBow    {
        get => _RadiumBow;
        set
        {
            _RadiumBow = value;
            if (_RadiumBow)
            {
                Remodel();
            }
            else
            {
                BowHaste = 0;
            }
        }
    }

    protected int _NssHaste;

    public int BowHaste    {
        get => _NssHaste;

        private set
        {
            if (_NssHaste == value) return;
            
            _NssHaste = Math.Max(value, 0);
            //view层
            OnDotNotice?.Invoke();
            //通知父节点
            CartonRook?.EyeballAmnioticBow();
        }
    }
    
    public bool SoKing=> BowHaste > 0;

    public bool SoNext=> CartonRook != null && (Amniotic == null || Amniotic.Count == 0);
    
    public CoalRook(int id, Func<int> onDotCheck = null)
    {
        ID = id;
        _onBowAsian = onDotCheck;
        OnDotNotice = null;
        _NssHaste = 0;
        LetterBow = false;
    }

    public void Acronym()
    {
        CartonRook = null;
        Amniotic?.Clear();
        Amniotic = null;
        OnDotNotice = null;
        _onBowAsian = null;
        _NssHaste = 0;
    }

    protected virtual void OnRelease()
    {
        
    }

    public void StarlingRookAsian(Func<int> onDotCheck)
    {
        _onBowAsian = onDotCheck;
    }

    public void PutMound(CoalRook child)
    {
        if (Amniotic == null)
        {
            Amniotic = new List<CoalRook>();
        }

        if (Amniotic.Contains(child))
        {
            Debug.Log($"重复添加子节点：{child.ID}");
            return;
        }
        Amniotic.Add(child);
    }
    
    public void DealerMound(CoalRook child)
    {
        Amniotic?.Remove(child);
    }
    
    //叶子节点刷新
    public void Remodel()
    {
        if (!LetterBow || !SoNext || _onBowAsian == null) return;
        
        BowHaste = _onBowAsian.Invoke();
    }

    private void EyeballAmnioticBow()
    {
        if (!LetterBow) return;
        BowHaste = Amniotic.Sum(child => child.BowHaste);
    }
}