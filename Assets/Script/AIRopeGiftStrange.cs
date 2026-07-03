using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AIRopeGiftStrange : MonoSnowstorm<AIRopeGiftStrange>
{
    //获取IOS函数声明
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void onGameEvent(string eventToken);

    [DllImport("__Internal")]
    internal extern static void onGameLevelChanged(int level);
#endif

    public void TangLatin(string eventToken)
    {
#if UNITY_IOS 
        onGameEvent(eventToken);
        print("AIGamePlus 尝试调用原生方法打点 事件：" + eventToken);
#endif
    }

    public void TangMagmaAnother(int level)
    {
#if UNITY_IOS
        onGameLevelChanged(level);
        print($"AIGamePlus 尝试调用原生方法：等级： {level}");
#endif
    }
}

