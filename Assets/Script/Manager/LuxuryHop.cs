using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class LuxuryHop 
{
    public static Action OrFolkTune{ get; set; }
    public static Action OrFolkSoon{ get; set; }
    /// <summary>新版穿刺钩子碰鱼时触发，用于碰鱼减速效果</summary>
    public static Action<int> OrDebtorGrayFewSoon{ get; set; }

    public static Action<bool> OrGraySteelBaskIncur{ get; set; }
    /// <summary>
    /// 碰鱼减速：传入当前“慢效果值”，0 表示无减速。
    /// 注意：慢效果值的具体换算（例如换算为速度倍率）由订阅方决定。
    /// </summary>
    public static Action<float> OrGraySoonFewBaskIncur{ get; set; }

    // 鱼受击动画播放完毕后，请求回收（由 UISoonRopeSolder 执行回收/入池）
    public static Action<UISoonMandan> OrSoonClusterCalcite{ get; set; }

    /// <summary>
    /// 鱼被致命击杀、即将回收前发出；参数为鱼身在屏幕/UI 下的世界坐标中心 + 鱼类别（用于按类别播放特效）。
    /// </summary>
    public static Action<Vector3, UIFishCategory> OrSoonHonestPondGourdMystique;

    public delegate bool FishDeathCloseupDelayHandler(UISoonMandan fish);

    /// <summary>
    /// 致命击杀时由 Canvas 特写等系统注册；返回 true 表示延迟回收，之后由特写方调用 <see cref="UISoonMandan.ExecutePendingLethalRecycleAfterCloseup"/>。
    /// 同时只能有一个实现（后注册的覆盖前者）。
    /// </summary>
    public static FishDeathCloseupDelayHandler KeaTrackSoonStintEyePreachTerrain;
    /// <summary>非鱼来源：任务/奖励等「界面加金币」表现入口（与击杀鱼飞金币区分）。</summary>
    public static Action<Transform, int> OrTieExact{ get; set; }

    /// <summary>击杀鱼掉落金币：TendStand 使用 cash 对象池 + FishGoldMove。</summary>
    public static Action<Transform, int> OrSoonTieExact{ get; set; }

    /// <summary>击杀钻石鱼：TendStand 使用 diamond 对象池 + FishDiamondMove。</summary>
    public static Action<Transform, int> OrSoonTieFallacy{ get; set; }

    // ===== 新增体力相关事件（核心）=====
    // 体力变化事件：参数（当前体力，剩余恢复时间，最大体力）
    public static Action<int, float, int> OrSailorAnother;

    // 船升级经验变化：参数（当前等级，当前等级经验，升级所需经验）
    public static Action<int, int, int> OrUtahLayAnother;

    // 船升级完成：参数（旧等级，新等级，本次提升等级数）
    public static Action<int, int, int> OrUtahMagmaAnother;

    // 船可升级状态变化：参数（是否可升级，待升级次数）
    public static Action<bool, int> OrUtahDeceiveIncurAnother;

    // 请求弹出船升级界面（如满经验首次触发）
    public static Action OrUtahDeceiveLiterCluster;

    // 游戏模式切换：用于鱼池刷新、UI过渡动画等
    public static Action<GameType> OrRopeTollAnother;


    // 模式切换前后事件：可用于播放切换动画
    public static Action<GameType, GameType> OrRopeTollEquatorialCluster;

    // 手动点击发射按钮（用于关闭自动射击等联动）
    public static Action OrSaddenGrayHumpCourseTourism;

    // 全局玩法暂停状态变化（true=暂停，false=恢复）
    public static Action<bool> OrCylinderEnsueIncurAnother;


    // Ferver 进度变化（普通模式下累计）：参数（当前击杀进度，触发所需击杀数）
    public static Action<int, int> OrBenignCommerceAnother;

    // Ferver 倒计时变化：参数（剩余秒数，总秒数）
    public static Action<float, float> OrBenignRelicLoveAnother;

    // 请求进入 FerverTime（用于先播放过渡动画）
    public static Action OrBenignPriorEquatorialCluster;
    // 进入 FerverTime 过渡中段预清场请求（由动画关键帧触发）
    public static Action OrBenignTowStudyCluster;

    // ===== 主页转盘事件 =====
    // 按子项索引请求旋转（索引从 0 开始）
    public static Action<int> OrTendGetMustAxSlopeCluster;

    // 按角度请求旋转（单位：度，0~360 会自动归一化）
    public static Action<float> OrTendGetMustAxFaintCluster;

    // 按可控概率请求旋转（由 TendGetGiant 内部概率配置抽取目标奖励并落点）
    public static Action OrTendGetMustByCelebrationCluster;

    // 主页转盘旋转结束：返回命中索引
    public static Action<int> OrTendGetMustLuminous;
    // 主页转盘旋转奖励结果：奖励类型 + 数量
    public static Action<RewardType, int> OrTendGetTempleMonoxide;

    // 请求生成一条 Boss 鱼（由 UISoonMandan 监听并转发给 UISoonRopeSolder 生成）
    public static Action OrShearGazeSoonCluster;
    // Boss 生成准备完成（dir, spawnX, spawnY, warnSpineDuration, warnPostDelay），可用于预告 UI。
    public static Action<int, float, float, float, float> OrGazeShearBacteria;
    // Boss 预警流程全部结束（Spine 与箭头都关闭），可用于正式出鱼。
    public static Action OrGazeFearLuminous;
    // Boss 即将最后一次折返：可用于弹出“即将消失”提示。
    public static Action OrGazeAdultYellowClarify;

    /// <summary>RopeStrange 在 SetHookFired(true) 时发出；用于复位「本发 Boss 特写已请求」等按发次计的状态（旧版钩子等）。</summary>
    public static Action OrGrayGolfReplant;

    /// <summary>
    /// 新版穿刺钩子：普通模式下钩子回收时先做本发经济/Ferver 等结算（由 TendStand 处理）。
    /// </summary>
    public static Action<int> OrMalletDebtorGrayGolfDemobilize;

    /// <summary>
    /// 本发结算结束后：是否允许低优先级触发（小游戏、定时 Boss 预触发等）。
    /// 同一发内优先级：Boss（在结算内已抑制）&gt; 升级 &gt; Fever 过渡 &gt; 低优先级；allow=false 时后者丢弃。
    /// </summary>
    public static Action<int, bool> OrMalletGolfUnifyTanEfficacyLocation;

    /// <summary>
    /// 普通模式下鱼死亡（回收前）事件：用于把 Ferver 进度/shot 优先级也并入“回收点统一结算”。
    /// 参数：死亡鱼实体（可读取 isBossFish / LastNormalHitShotId）。
    /// </summary>
    public static Action<UISoonMandan> OrMalletSoonStintEyeGolfDemobilize;

    // ===== 随机小游戏调度相关 =====
    // 随机小游戏结束时触发；用于通知调度器继续计时
    public static Action OrSlightRopeLuminous;

    // Boss 专用特写触发框命中（由钩子碰撞按「每发一次」发出，ShroudUIPreachTerrain 监听）
    public static Action<UISoonMandan> OrGazeTerrainSituateCluster;
    
    // Boss 鱼游动到屏幕中心（x=0）时触发引导：主骨骼 Transform + 喵骨骼 Transform（可空）
    public static Action<Transform, Transform> OrGazeSoonGlobeEightyTightCluster;

    // Closeup 期间钩子/鱼叉移动速度倍率（由 ShroudUIPreachTerrain 触发，GrayTambourine 监听）
    public static Action<float> OrTerrainGrayModalHenceforth;

    // Closeup 期间鱼群游动速度倍率（由 ShroudUIPreachTerrain 触发，UISoonRopeSolder 监听）
    public static Action<float> OrTerrainSoonModalHenceforth;

    
    public static Action OrBenignLineHaltTrader;
    public static Action OrPriorRope;

    public static Action OrAthensLateCommerce;
    public static Action OrAthensLateLaw;

}

