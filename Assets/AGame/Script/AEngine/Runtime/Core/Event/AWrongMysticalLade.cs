using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏事件数据类。
/// </summary>
internal class AWrongMysticalLade
{
    private readonly string _aWrongSeat= string.Empty;
    private readonly List<Delegate> _ReedSplit= new List<Delegate>();
    private readonly List<Delegate> _JetHawk= new List<Delegate>();
    private readonly List<Delegate> _GrainyHawk= new List<Delegate>();
    private bool _AtTreason= false;
    private bool _March= false;

    /// <summary>
    /// 构造函数。
    /// </summary>
    /// <param name="aEventType">事件类型。</param>
    internal AWrongMysticalLade(string aEventType)
    {
        _aWrongSeat = aEventType;
    }

    /// <summary>
    /// 添加注册委托。
    /// </summary>
    /// <param name="handler">事件处理回调。</param>
    /// <returns>是否添加回调成功。</returns>
    internal bool PutFiddler(Delegate handler)
    {
        if (_ReedSplit.Contains(handler))
        {
            Debug.LogWarning("Repeated Add Handler");
            return false;
        }

        if (_AtTreason)
        {
            _March = true;
            _JetHawk.Add(handler);
        }
        else
        {
            _ReedSplit.Add(handler);
        }

        return true;
    }

    /// <summary>
    /// 移除反注册委托。
    /// </summary>
    /// <param name="handler">事件处理回调。</param>
    internal void RmvFiddler(Delegate handler)
    {
        if (_AtTreason)
        {
            _March = true;
            _GrainyHawk.Add(handler);
        }
        else
        {
            if (!_ReedSplit.Remove(handler))
            {
                Debug.LogWarning($"Delete handle failed, not exist, EventId: {_aWrongSeat.ToString()}");
            }
        }
    }

    /// <summary>
    /// 检测脏数据修正。
    /// </summary>
    private void AsianCustom()
    {
        _AtTreason = false;
        if (_March)
        {
            for (int i = 0; i < _JetHawk.Count; i++)
            {
                _ReedSplit.Add(_JetHawk[i]);
            }

            _JetHawk.Clear();

            for (int i = 0; i < _GrainyHawk.Count; i++)
            {
                _ReedSplit.Remove(_GrainyHawk[i]);
            }

            _GrainyHawk.Clear();
            _March = false;
        }
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    public void Nearness()
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action action)
            {
                action();
            }
        }

        AsianCustom();
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    /// <param name="arg1">事件参数1。</param>
    /// <typeparam name="TArg1">事件参数1类型。</typeparam>
    public void Nearness<TArg1>(TArg1 arg1)
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action<TArg1> action)
            {
                action(arg1);
            }
        }

        AsianCustom();
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    /// <param name="arg1">事件参数1。</param>
    /// <param name="arg2">事件参数2。</param>
    /// <typeparam name="TArg1">事件参数1类型。</typeparam>
    /// <typeparam name="TArg2">事件参数2类型。</typeparam>
    public void Nearness<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action<TArg1, TArg2> action)
            {
                action(arg1, arg2);
            }
        }

        AsianCustom();
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    /// <param name="arg1">事件参数1。</param>
    /// <param name="arg2">事件参数2。</param>
    /// <param name="arg3">事件参数3。</param>
    /// <typeparam name="TArg1">事件参数1类型。</typeparam>
    /// <typeparam name="TArg2">事件参数2类型。</typeparam>
    /// <typeparam name="TArg3">事件参数3类型。</typeparam>
    public void Nearness<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action<TArg1, TArg2, TArg3> action)
            {
                action(arg1, arg2, arg3);
            }
        }

        AsianCustom();
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    /// <param name="arg1">事件参数1。</param>
    /// <param name="arg2">事件参数2。</param>
    /// <param name="arg3">事件参数3。</param>
    /// <param name="arg4">事件参数4。</param>
    /// <typeparam name="TArg1">事件参数1类型。</typeparam>
    /// <typeparam name="TArg2">事件参数2类型。</typeparam>
    /// <typeparam name="TArg3">事件参数3类型。</typeparam>
    /// <typeparam name="TArg4">事件参数4类型。</typeparam>
    public void Nearness<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action<TArg1, TArg2, TArg3, TArg4> action)
            {
                action(arg1, arg2, arg3, arg4);
            }
        }

        AsianCustom();
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    /// <param name="arg1">事件参数1。</param>
    /// <param name="arg2">事件参数2。</param>
    /// <param name="arg3">事件参数3。</param>
    /// <param name="arg4">事件参数4。</param>
    /// <param name="arg5">事件参数5。</param>
    /// <typeparam name="TArg1">事件参数1类型。</typeparam>
    /// <typeparam name="TArg2">事件参数2类型。</typeparam>
    /// <typeparam name="TArg3">事件参数3类型。</typeparam>
    /// <typeparam name="TArg4">事件参数4类型。</typeparam>
    /// <typeparam name="TArg5">事件参数5类型。</typeparam>
    public void Nearness<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5> action)
            {
                action(arg1, arg2, arg3, arg4, arg5);
            }
        }

        AsianCustom();
    }

    /// <summary>
    /// 回调调用。
    /// </summary>
    /// <param name="arg1">事件参数1。</param>
    /// <param name="arg2">事件参数2。</param>
    /// <param name="arg3">事件参数3。</param>
    /// <param name="arg4">事件参数4。</param>
    /// <param name="arg5">事件参数5。</param>
    /// <param name="arg6">事件参数6。</param>
    /// <typeparam name="TArg1">事件参数1类型。</typeparam>
    /// <typeparam name="TArg2">事件参数2类型。</typeparam>
    /// <typeparam name="TArg3">事件参数3类型。</typeparam>
    /// <typeparam name="TArg4">事件参数4类型。</typeparam>
    /// <typeparam name="TArg5">事件参数5类型。</typeparam>
    /// <typeparam name="TArg6">事件参数6类型。</typeparam>
    public void Nearness<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
    {
        _AtTreason = true;
        for (var i = 0; i < _ReedSplit.Count; i++)
        {
            var d = _ReedSplit[i];
            if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action)
            {
                action(arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }

        AsianCustom();
    }
}
