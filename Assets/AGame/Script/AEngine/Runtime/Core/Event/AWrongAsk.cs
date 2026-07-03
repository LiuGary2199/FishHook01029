using System;
using System.Collections.Generic;

/// <summary>
/// 游戏事件管理器。
/// </summary>
public class AWrongAsk
{
    private readonly List<string> _ReedWrongSepal;
    private readonly List<Delegate> _ReedPortion;
    private readonly bool _AtCook= false;

    /// <summary>
    /// 游戏事件管理器构造函数。
    /// </summary>
    public AWrongAsk()
    {
        if (_AtCook)
        {
            return;
        }

        _AtCook = true;
        _ReedWrongSepal = new List<string>();
        _ReedPortion = new List<Delegate>();
    }

    /// <summary>
    /// 清理内存对象回收入池。
    /// </summary>
    public void Clear()
    {
        if (!_AtCook)
        {
            return;
        }

        for (int i = 0; i < _ReedWrongSepal.Count; ++i)
        {
            var eventType = _ReedWrongSepal[i];
            var handle = _ReedPortion[i];
            AWrongFamous.DealerWrong(eventType, handle);
        }

        _ReedWrongSepal.Clear();
        _ReedPortion.Clear();
    }

    private void PutWrongImp(string eventType, Delegate handler)
    {
        _ReedWrongSepal.Add(eventType);
        _ReedPortion.Add(handler);
    }

    #region Add

    public void PutWrong(string eventType, Action handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }

    public void PutWrong<T>(string eventType, Action<T> handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }

    public void PutWrong<T1, T2>(string eventType, Action<T1, T2> handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }

    public void PutWrong<T1, T2, T3>(string eventType, Action<T1, T2, T3> handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }

    public void PutWrong<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }

    public void PutWrong<T1, T2, T3, T4, T5>(string eventType, Action<T1, T2, T3, T4, T5> handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }
    
    public void PutWrong<T1, T2, T3, T4, T5, T6>(string eventType, Action<T1, T2, T3, T4, T5, T6> handler)
    {
        if (AWrongFamous.PutWrong(eventType, handler))
        {
            PutWrongImp(eventType, handler);
        }
    }
    
    #endregion
    
    #region Remove
    
    public void DealerWrong(string eventType, Action handler)
    {
        AWrongFamous.DealerWrong(eventType, handler);
        _ReedWrongSepal.Remove(eventType);
        _ReedPortion.Remove(handler);
    }
    
    #endregion
}