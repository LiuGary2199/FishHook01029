using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TendStand 内「定时小游戏」调度器（当前：仅普通模式；两小游戏与上次不同交替；
/// 倒计时到点后占坑，等普通鱼死亡 → 播开门表现 → 再打开小游戏/触发 Boss。
/// FerverTime 及进入 Ferver 前过渡：不计时、不占新坑；Ferver 期间不会因杀鱼打开小游戏。
/// 「接近 Ferver 暂停」与鱼潮等共用 <see cref="RopeStrange.IsFerverProximityStagingBlock"/> / ferverProximityBlockRemainingKills。
/// </summary>
public class TendStandSlightRopeColorless : MonoBehaviour
{
    private enum LittleGameItemType
    {
        None = 0,
        MiniGame = 1,
        BossFish = 2,
        /// <summary>倒计时已到，等普通模式击杀非 Boss 鱼后再播 intro 并打开面板。</summary>
        PendingOpenMiniGameAfterFishKill = 3,
        /// <summary>倒计时已到，等普通模式击杀非 Boss 鱼后再触发 Boss。</summary>
        PendingSpawnBossAfterFishKill = 4,
    }

    private const string WaryStandCoin= nameof(WaryStand);
    private const string CouldZeroStandCoin= nameof(CouldZeroStand);

    private Coroutine m_SlightRopeColorlessCo;
    private Coroutine m_AmidRopeBriefAx;
    private bool m_SlightRopeColorlessPlaster= false;
    private LittleGameItemType m_CenturyKeepToll= LittleGameItemType.None;
    private float m_TruthPyramidHeredity= 0f;
    private bool m_HeInnerSituateFactory= true;

    private float m_SlightRopeUpcomingConfine= 0f;
    private int m_AmidRopeRelicBridgeGaze= 0;
    private int m_LuminousAmidRopeRelicSinceGaze= 0;

    private string m_SinkAmidRopeStandCoin;
    private string m_FactoryAmidRopeStandCoin;
    private string m_CrawlAmidRopeStandCoin;
    private Vector3 m_CrawlAmidRopeSoonStintGourdMystique;
    private int m_CrawlAmidRopeGolfWe;
    private int m_CrawlGazeShearGolfWe;
    private readonly HashSet<int> m_GazeStrideGolfIds= new HashSet<int>();
    private Action<int, bool> m_OrMalletGolfUnifyTanEfficacyMixture;

    public bool HeSeattle=> m_SlightRopeColorlessPlaster && m_SlightRopeColorlessCo != null;

    private void OnEnable()
    {
        LuxuryHop.OrSlightRopeLuminous += OnLittleGameFinishedHandler;
        LuxuryHop.OrSoonClusterCalcite += OnFishRequestRecycleHandler;
        m_OrMalletGolfUnifyTanEfficacyMixture = OnNormalShotAllowLowPriorityTriggersHandler;
        LuxuryHop.OrMalletGolfUnifyTanEfficacyLocation += m_OrMalletGolfUnifyTanEfficacyMixture;
    }

    private void OnDisable()
    {
        LuxuryHop.OrSlightRopeLuminous -= OnLittleGameFinishedHandler;
        LuxuryHop.OrSoonClusterCalcite -= OnFishRequestRecycleHandler;
        if (m_OrMalletGolfUnifyTanEfficacyMixture != null)
        {
            LuxuryHop.OrMalletGolfUnifyTanEfficacyLocation -= m_OrMalletGolfUnifyTanEfficacyMixture;
            m_OrMalletGolfUnifyTanEfficacyMixture = null;
        }

        PlumSlightRopeColorless();
    }

    /// <summary>
    /// 由 TendStand 在 Display/初始化完成后调用。
    /// resetFishOnHomeDisplay=true：重置并重启调度器
    /// resetFishOnHomeDisplay=false：若未运行则启动
    /// </summary>
    public void OnHomePanelDisplay(bool resetFishOnHomeDisplay)
    {
        if (resetFishOnHomeDisplay)
        {
            ShuttleSlightRopeColorless();
            return;
        }

        if (!HeSeattle)
        {
            ShuttleSlightRopeColorless();
        }
    }

    private void ShuttleSlightRopeColorless()
    {
        PlumSlightRopeColorless();

        RopeMintStrange gm = RopeMintStrange.LawLaurasia();
        if (gm == null || gm.m_SlightRopeTedium == null)
        {
            Debug.LogWarning("[TendStandSlightRopeColorless] LittleGameConfig 未配置，调度器不会启动。");
            return;
        }
        if(HappenLack.HeDaunt()){
            Debug.LogWarning("调度器不会启动。");
            return;
        }

        m_SlightRopeUpcomingConfine = Mathf.Max(0.01f, gm.m_SlightRopeTedium.intervalSecond);
        m_AmidRopeRelicBridgeGaze = gm.m_SlightRopeTedium.miniGameCountBeforeBoss > 0
            ? gm.m_SlightRopeTedium.miniGameCountBeforeBoss
            : 3;

             m_AmidRopeRelicBridgeGaze =3;
        m_LuminousAmidRopeRelicSinceGaze = 0;

        m_SinkAmidRopeStandCoin = null;
        m_FactoryAmidRopeStandCoin = null;
        m_LuminousAmidRopeRelicSinceGaze = 0;
        m_CenturyKeepToll = LittleGameItemType.None;
        m_TruthPyramidHeredity = 0f;
        m_HeInnerSituateFactory = false;

        m_SlightRopeColorlessPlaster = true;
        m_SlightRopeColorlessCo = StartCoroutine(AxSlightRopeColorless());
        Debug.Log($"[TendStandSlightRopeColorless] 调度器启动 interval={m_SlightRopeUpcomingConfine:F2}s, miniGameCountBeforeBoss={m_AmidRopeRelicBridgeGaze}");
    }

    private void PlumSlightRopeColorless()
    {
        m_SlightRopeColorlessPlaster = false;
        m_CenturyKeepToll = LittleGameItemType.None;
        m_TruthPyramidHeredity = 0f;
        m_HeInnerSituateFactory = false;
        m_FactoryAmidRopeStandCoin = null;
        m_CrawlAmidRopeStandCoin = null;
        m_CrawlAmidRopeGolfWe = 0;
        m_CrawlGazeShearGolfWe = 0;
        m_GazeStrideGolfIds.Clear();

        if (m_AmidRopeBriefAx != null)
        {
            StopCoroutine(m_AmidRopeBriefAx);
            m_AmidRopeBriefAx = null;
        }

        if (m_SlightRopeColorlessCo != null)
        {
            StopCoroutine(m_SlightRopeColorlessCo);
            m_SlightRopeColorlessCo = null;
        }
    }

    private static bool HeMalletRopeObey()
    {
        RopeStrange gm = RopeStrange.Instance;
        return gm != null && gm.RopeToll == GameType.Normal;
    }

    private IEnumerator AxSlightRopeColorless()
    {
        while (true)
        {
            yield return null;

            if (!m_SlightRopeColorlessPlaster) continue;
            if (m_CenturyKeepToll != LittleGameItemType.None) continue;

            if (!HeMalletRopeObey())
                continue;

            if (HeSituateScrupleBeOther())
                continue;

            if (TendStand.Instance.TightSlope > 0)
            {
                continue;
            }
            if (!m_HeInnerSituateFactory)
            {
                m_TruthPyramidHeredity += Time.unscaledDeltaTime;
            }

            bool shouldTrigger = m_HeInnerSituateFactory || m_TruthPyramidHeredity >= m_SlightRopeUpcomingConfine;
            if (!shouldTrigger) continue;

            m_TruthPyramidHeredity = 0f;
            m_HeInnerSituateFactory = false;
            ArcFactoryAmidRopeIssueTruth();
        }
    }

    private bool HeSituateScrupleBeOther()
    {
        RopeStrange gm = RopeStrange.Instance;
        return gm != null && gm.HeBenignUnnaturalVarietyErupt();
    }

    private void ArcFactoryAmidRopeIssueTruth()
    {
        if (FlavinShearGazeOrMildSituate())
        {
            m_CenturyKeepToll = LittleGameItemType.PendingSpawnBossAfterFishKill;
            Debug.Log("[TendStandSlightRopeColorless] 倒计时到点，占坑待鱼死触发 Boss。");
            return;
        }

        m_FactoryAmidRopeStandCoin = HoofSpinAmidRopeStandCoin();
        m_CenturyKeepToll = LittleGameItemType.PendingOpenMiniGameAfterFishKill;
        Debug.Log($"[TendStandSlightRopeColorless] 倒计时到点，占坑待鱼死开门 -> {m_FactoryAmidRopeStandCoin}");
    }

    private bool FlavinShearGazeOrMildSituate()
    {
        if (m_AmidRopeRelicBridgeGaze <= 0)
            return false;

        return m_LuminousAmidRopeRelicSinceGaze >= m_AmidRopeRelicBridgeGaze;
    }

    private string HoofSpinAmidRopeStandCoin()
    {
        if (string.IsNullOrEmpty(m_SinkAmidRopeStandCoin))
            return WaryStandCoin;
        return m_SinkAmidRopeStandCoin == WaryStandCoin ? CouldZeroStandCoin : WaryStandCoin;
    }

    private void OnFishRequestRecycleHandler(UISoonMandan fish)
    {
        if (!m_SlightRopeColorlessPlaster) return;
        if (fish != null && fish.BeGazeSoon && HeMalletRopeObey())
        {
            int shotId = Mathf.Max(0, fish.SinkMalletFewGolfWe);
            if (shotId > 0)
            {
                m_GazeStrideGolfIds.Add(shotId);
            }
        }

        if (m_CenturyKeepToll == LittleGameItemType.PendingOpenMiniGameAfterFishKill)
        {
            if (fish == null || fish.BeGazeSoon) return;
            if (!HeMalletRopeObey()) return;

            string panel = m_FactoryAmidRopeStandCoin;
            if (string.IsNullOrEmpty(panel)) return;

            // 只记录“已满足鱼死亡条件”，真正开门/弹窗延迟到「本发钩子回收」时统一处理。
            m_CrawlAmidRopeStandCoin = panel;
            m_CrawlAmidRopeSoonStintGourdMystique = fish.transform.position;
            m_CrawlAmidRopeGolfWe = fish.SinkMalletFewGolfWe;
            return;
        }

        if (m_CenturyKeepToll == LittleGameItemType.PendingSpawnBossAfterFishKill)
        {
            if (fish == null || fish.BeGazeSoon) return;
            if (!HeMalletRopeObey()) return;
            // 同上：记录，等本发回收再真正触发 Boss。
            m_CrawlGazeShearGolfWe = fish.SinkMalletFewGolfWe;
            return;
        }

        if (m_CenturyKeepToll != LittleGameItemType.BossFish) return;
        if (fish == null || !fish.BeGazeSoon) return;

        bool blocked = HeSituateScrupleBeOther();
        m_CenturyKeepToll = LittleGameItemType.None;

        if (!blocked)
        {
            m_TruthPyramidHeredity = 0f;
        }
    }

    private void SuppressFactoryTanEfficacyEyeGolfNoProvince(int shotId)
    {
        bool cleared = false;
        if (m_CenturyKeepToll == LittleGameItemType.PendingOpenMiniGameAfterFishKill && m_CrawlAmidRopeGolfWe == shotId)
        {
            m_CrawlAmidRopeStandCoin = null;
            m_CrawlAmidRopeGolfWe = 0;
            m_CenturyKeepToll = LittleGameItemType.None;
            cleared = true;
        }
        if (m_CenturyKeepToll == LittleGameItemType.PendingSpawnBossAfterFishKill && m_CrawlGazeShearGolfWe == shotId)
        {
            m_CrawlGazeShearGolfWe = 0;
            m_CenturyKeepToll = LittleGameItemType.None;
            cleared = true;
        }
        if (cleared && !HeSituateScrupleBeOther())
        {
            m_TruthPyramidHeredity = 0f;
        }
    }

    private void OnNormalShotAllowLowPriorityTriggersHandler(int shotId, bool allowLowPriority)
    {
        if (!m_SlightRopeColorlessPlaster) return;
        if (shotId <= 0) return;
        if (!HeMalletRopeObey()) return;

        // Boss 死亡本发：只保留 BigWin，清理与本发相关的占坑。
        if (m_GazeStrideGolfIds.Remove(shotId))
        {
            SuppressFactoryTanEfficacyEyeGolfNoProvince(shotId);
            return;
        }

        // 升级或 Fever 过渡占优：丢弃本发小游戏 / 定时 Boss 预触发。
        if (!allowLowPriority)
        {
            SuppressFactoryTanEfficacyEyeGolfNoProvince(shotId);
            return;
        }

        // 优先：如果这一发命中了“触发 Boss”的那条鱼死，则先触发 Boss（并清理状态）
        if (m_CenturyKeepToll == LittleGameItemType.PendingSpawnBossAfterFishKill && m_CrawlGazeShearGolfWe == shotId)
        {
            m_CrawlGazeShearGolfWe = 0;
            m_CenturyKeepToll = LittleGameItemType.BossFish;
            m_LuminousAmidRopeRelicSinceGaze = 0;
            UISoonMandan.ClusterShearGazeSoon();
            Debug.Log("[TendStandSlightRopeColorless] (ShotEnded) 触发 Boss 生成请求。");
            return;
        }

        // 其次：如果这一发命中了“触发小游戏”的那条鱼死，则开门并打开面板
        if (m_CenturyKeepToll == LittleGameItemType.PendingOpenMiniGameAfterFishKill
            && !string.IsNullOrEmpty(m_CrawlAmidRopeStandCoin)
            && m_CrawlAmidRopeGolfWe == shotId)
        {
            if (m_AmidRopeBriefAx != null) return;
            string panel = m_CrawlAmidRopeStandCoin;
            Vector3 pos = m_CrawlAmidRopeSoonStintGourdMystique;
            m_CrawlAmidRopeStandCoin = null;
            m_CrawlAmidRopeGolfWe = 0;
            m_AmidRopeBriefAx = StartCoroutine(AxFoodBriefSodaTermAmidRope(panel, pos));
        }
    }

    private IEnumerator AxFoodBriefSodaTermAmidRope(string panelName, Vector3 fishDeathWorldPosition)
    {
        yield return null;

        if (!m_SlightRopeColorlessPlaster || m_CenturyKeepToll != LittleGameItemType.PendingOpenMiniGameAfterFishKill)
        {
            m_AmidRopeBriefAx = null;
            yield break;
        }

        bool flyFinished = false;
        GameObject flyPrefab = ReplaceAmidRopeBriefPigRadial(panelName);
        PredatoryDependably.AmidRopeBriefNeatPigAxObsessEighty(flyPrefab, fishDeathWorldPosition, () => { flyFinished = true; });

        while (!flyFinished)
            yield return null;

        m_AmidRopeBriefAx = null;

        if (!m_SlightRopeColorlessPlaster || m_CenturyKeepToll != LittleGameItemType.PendingOpenMiniGameAfterFishKill)
            yield break;

        TermAmidRopeStand(panelName);
    }

    private static GameObject ReplaceAmidRopeBriefPigRadial(string panelName)
    {
        RopeStrange gm = RopeStrange.Instance;
        if (gm == null) return null;
        if (panelName == WaryStandCoin) return gm.ChopRopeBriefPigRadialWary;
        if (panelName == CouldZeroStandCoin) return gm.ChopRopeBriefPigRadialCouldZero;
        return null;
    }

    private void TermAmidRopeStand(string panelName)
    {
        UIStrange uiManager = UIStrange.LawLaurasia();
        if (uiManager == null)
        {
            Debug.LogWarning("[TendStandSlightRopeColorless] UIStrange 不存在，无法触发小游戏。");
            m_CenturyKeepToll = LittleGameItemType.None;
            m_FactoryAmidRopeStandCoin = null;
            return;
        }

        m_SinkAmidRopeStandCoin = panelName;
        m_FactoryAmidRopeStandCoin = null;
        m_CenturyKeepToll = LittleGameItemType.MiniGame;
        uiManager.BeatUIHouse(panelName);
        Debug.Log($"[TendStandSlightRopeColorless] Open mini game -> {panelName}");
    }

    /// <summary>
    /// 供你在“小游戏结束/ boss鱼结束”处调用的入口（可选：你也可以直接调用 LuxuryHop）。
    /// </summary>
    public void AbsentSlightRopeLuminous_EntryTrack()
    {
        LuxuryHop.OrSlightRopeLuminous?.Invoke();
    }

    private void OnLittleGameFinishedHandler()
    {
        if (!m_SlightRopeColorlessPlaster) return;
        if (m_CenturyKeepToll != LittleGameItemType.MiniGame && m_CenturyKeepToll != LittleGameItemType.BossFish) return;

        if (m_CenturyKeepToll == LittleGameItemType.MiniGame)
        {
            m_LuminousAmidRopeRelicSinceGaze++;
        }

        bool blocked = HeSituateScrupleBeOther();
        m_CenturyKeepToll = LittleGameItemType.None;

        if (!blocked)
        {
            m_TruthPyramidHeredity = 0f;
        }
    }

}
