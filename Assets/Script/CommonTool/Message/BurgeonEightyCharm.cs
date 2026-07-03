using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class BurgeonEightyCharm:MonoSnowstorm<BurgeonEightyCharm>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<BurgeonMint>> EngagementMessage;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private BurgeonEightyCharm()
    {
        RailMint();
    }

    private void RailMint()
    {
        //初始化消息字典
        EngagementMessage = new Dictionary<string, Action<BurgeonMint>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Brightly(string key, Action<BurgeonMint> action)
    {
        if (!EngagementMessage.ContainsKey(key))
        {
            EngagementMessage.Add(key, null);
        }
        EngagementMessage[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Thrive(string key, Action<BurgeonMint> action)
    {
        if (EngagementMessage.ContainsKey(key) && EngagementMessage[key] != null)
        {
            EngagementMessage[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Tang(string key, BurgeonMint data = null)
    {
        if (EngagementMessage.ContainsKey(key) && EngagementMessage[key] != null)
        {
            EngagementMessage[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Study()
    {
        EngagementMessage.Clear();
    }
}
