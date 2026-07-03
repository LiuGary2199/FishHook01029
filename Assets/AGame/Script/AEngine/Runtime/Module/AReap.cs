using UnityEngine;

public class AReap
{
    #region 框架模块

    /// <summary>
    /// 获取游戏基础模块。
    /// </summary>
    public static AAtomFamous Coal=> AAtomFamous.Slowness;

    /// <summary>
    /// 获取音频模块。
    /// </summary>
    public static A_HavenEarning Haven=> A_HavenEarning.Slowness;
    
    /// <summary>
    /// 获取UI模块。
    /// </summary>
    public static AUIFamous UI=> AUIFamous.Slowness;

    /// <summary>
    /// 获取计时器模块。
    /// </summary>
    public static AClumpFamous Clump=> AClumpFamous.Slowness;
    
    #endregion
    
    public static void Figurine()
    {
        Debug.Log("GameModule Shutdown");
        
    }
}