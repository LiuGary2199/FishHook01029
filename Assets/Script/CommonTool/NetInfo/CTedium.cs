/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTedium
{
    #region 常量字段
    //登录url
    public const string ReuseMaw= "/api/client/user/getId?gameCode=";
    //配置url
    public const string TediumMaw= "/api/client/config?gameCode=";
    //时间戳url
    public const string LineMaw= "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string SqueakMaw= "/api/client/user/setAdjustId?gameCode=";
    #endregion

    #region 本地存储的字符串
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string Dy_UtterSaveWe= "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string Dy_UtterHamperWe= "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string Dy_HeBedWindow= "sv_IsNewPlayer";

    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string Dy_UnityBounsLawRelic= "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string Dy_UnitySlopeMood= "sv_DailyBounsDate";
    /// <summary>
    /// 新手引导完成的步数
    /// </summary>
    public const string Dy_BedSaveTone= "sv_NewUserStep";
    /// <summary>
    /// 金币余额
    /// </summary>
    public const string Dy_ComaSate= "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string Dy_InnovativeSeatSate= "sv_CumulativeGoldCoin";
    /// <summary>
    /// 钻石/现金余额
    /// </summary>
    public const string Dy_Token= "sv_Token";
    /// <summary>
    /// 累计钻石/现金总数
    /// </summary>
    public const string Dy_InnovativeParty= "sv_CumulativeToken";
    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string Dy_Defend= "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string Dy_InnovativeDefend= "sv_CumulativeAmazon";
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string Dy_PulseRopeLine= "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string Dy_InnerLawParty= "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string Dy_HasBeatDuneStand= "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string Dy_InnovativeSubsidy= "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string Dy_ReflectMaskDredge= "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string Dy_BedSaveToneTrader= "sv_NewUserStepFinish";
    public const string Dy_Neon_Spiky_Voice= "sv_task_level_count";
    // 是否第一次使用过slot
    public const string Dy_InnerWary= "sv_FirstSlot";

    // 是否第一次使用过slot
    public const string Dy_InnerMagmaUPWary= "sv_FirstLevelUPSlot";
    /// <summary>
    /// adjust adid
    /// </summary>
    public const string Dy_SqueakRely= "sv_AdjustAdid";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string Dy_If_Midst_Bad= "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string Dy_Fleet_If_Bad= "sv_total_ad_num";
    /// <summary>
    /// 生命值
    /// </summary>
    public const string Dy_Purely_Elk= "sv_energy_key";
    /// <summary>
    /// 生命值
    /// </summary>
    public const string Dy_time_Excel_Elk= "sv_time_stamp_key";
    /// <summary>
    /// 船等级
    /// </summary>
    public const string Dy_Tool_Spiky= "sv_ship_level";
    /// <summary>
    /// 当前等级经验
    /// </summary>
    public const string Dy_Tool_exp= "sv_ship_exp";

    /// <summary>
    ///  总共杀的鱼
    /// </summary>
    public const string Dy_Fleet_Partition= "sv_total_fishcount";

    /// <summary>
    ///  总共小游戏次数
    /// </summary>
    public const string Dy_Fleet_Deterrent= "sv_total_smallgame";
     /// <summary>
    ///  总共Ferver次数
    /// </summary>
    public const string Dy_Fleet_Freshwater= "sv_total_fervertime";
    /// <summary>
    /// Boss 鱼到达中心点引导是否已触发
    /// </summary>
    public const string Dy_Niche_Jean_Poorly_Slot= "sv_guide_boss_center_done";
    /// <summary>
    /// Ferver 过场结束后的首次引导是否已触发
    /// </summary>
    public const string Dy_Niche_Spinal_first_Slot= "sv_guide_ferver_first_done";

/// <summary>
    ///click auto shoot toggle
    /// </summary>
    public const string Dy_Opera_Sash_Paris_Cement= "sv_click_auto_shoot_toggle";
    #endregion

    #region 监听发送的消息

    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string mg_ParlorTerm= "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string Ax_ParlorDrift= "mg_WindowClose";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string Ax_Up_Thermodynamic= "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string Ax_Up_Woodlot= "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string Ax_Up_Obsidian= "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string Ax_Up_Germanium= "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string Ax_RopeExtreme= "mg_GameSuspend";

    /// <summary>
    /// 游戏资源数量变化
    /// </summary>
    public static string Ax_KeepUnjust_= "mg_ItemChange_";

    /// <summary>
    /// 活动状态变更
    /// </summary>
    public static string Ax_MaterialIncurUnjust_= "mg_ActivityStateChange_";

    /// <summary>
    /// 关卡最大等级变更
    /// </summary>
    public static string Ax_MagmaTheMagmaUnjust= "mg_LevelMaxLevelChange";

    #endregion

    #region 动态加载资源的路径

    // 金币图片
    public static string Mess_SeatSate_Behind= "Art/Tex/UI/jiangli1";
    // 钻石图片
    public static string Mess_Party_Behind_Longer= "Art/Tex/UI/jiangli4";
    // 鱼预制体名称前缀（例如 NormalFish）
    public const string SoonRadialCoinRunway= "MalletSoon";

    #endregion
}

