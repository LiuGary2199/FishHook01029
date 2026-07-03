using UnityEngine;

/// <summary>
/// A包程序入口
/// </summary>
public static class AReapStake
{
    public static void Cook()
    {
        Debug.Log("A包程序入口");
        AReapInstall.Slowness.Cook();
        AReapEarning.Slowness.Cook();
        //打开主界面
        AReap.UI.KingUI<AReapInner_A>();
    }
}