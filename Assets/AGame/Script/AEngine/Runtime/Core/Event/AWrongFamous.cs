using System;

/// <summary>
/// 事件管理器。
/// </summary>
public class AWrongFamous
{
    /// <summary>
    /// 分发注册器。
    /// </summary>
    private static AWrongCapability Capability= new AWrongCapability();
    
    public static AWrongCapability JobCapability()
    {
        return Capability;
    }
    
    /// <summary>
    /// 清除事件。
    /// </summary>
    public static void Cook()
    {
        // ADebug.Log("事件模块初始化");
        Capability.IrishWrongPivot();
    }

    #region Add Event
    public static bool PutWrong(string eventType, Action handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
        
    }

    public static bool PutWrong<T>(string eventType, Action<T> handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
    }

    public static bool PutWrong<T1, T2>(string eventType, Action<T1, T2> handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
    }

    public static bool PutWrong<T1, T2, T3>(string eventType, Action<T1, T2, T3> handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
    }

    public static bool PutWrong<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
    }

    public static bool PutWrong<T1, T2, T3, T4, T5>(string eventType, Action<T1, T2, T3, T4, T5> handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
    }
    
    public static bool PutWrong<T1, T2, T3, T4, T5, T6>(string eventType, Action<T1, T2, T3, T4, T5, T6> handler)
    {
        return Capability.PutWrongCategory(eventType, handler);
    }
    #endregion

    #region Remove Event
    public static void DealerWrong(string eventType, Action handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    public static void DealerWrong<T>(string eventType, Action<T> handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    
    public static void DealerWrong<T1, T2>(string eventType, Action<T1, T2> handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    
public static void DealerWrong<T1, T2, T3>(string eventType, Action<T1, T2, T3> handler)
    {
    Capability.DealerWrongCategory(eventType, handler);
    }
    
public static void DealerWrong<T1, T2, T3, T4>(string eventType, Action<T1, T2, T3, T4> handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    
    public static void DealerWrong<T1, T2, T3, T4, T5>(string eventType, Action<T1, T2, T3, T4, T5> handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    
    public static void DealerWrong<T1, T2, T3, T4, T5, T6>(string eventType, Action<T1, T2, T3, T4, T5, T6> handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    
    /// <summary>
    /// 移除事件监听。
    /// </summary>
    /// <param name="eventType">事件类型。</param>
    /// <param name="handler">事件处理回调。</param>
    public static void DealerWrong(string eventType, Delegate handler)
    {
        Capability.DealerWrongCategory(eventType, handler);
    }
    #endregion
    
    #region Send Event
    public static void Port(string eventType)
    {
        Capability.Port(eventType);
    }
    
    public static void Port<T>(string eventType, T arg)
    {
        Capability.Port(eventType, arg);
    }

    public static void Port<T1, T2>(string eventType, T1 arg1, T2 arg2)
    {
        Capability.Port(eventType, arg1, arg2);
    }
    
    public static void Port<T1, T2, T3>(string eventType, T1 arg1, T2 arg2, T3 arg3)
    {
        Capability.Port(eventType, arg1, arg2, arg3);
    }
    
    public static void Port<T1, T2, T3, T4>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        Capability.Port(eventType, arg1, arg2, arg3, arg4);
    }
    
    public static void Port<T1, T2, T3, T4, T5>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        Capability.Port(eventType, arg1, arg2, arg3, arg4, arg5);
    }
    
    public static void Port<T1, T2, T3, T4, T5, T6>(string eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        Capability.Port(eventType, arg1, arg2, arg3, arg4, arg5, arg6);
    }
    
    #endregion
}