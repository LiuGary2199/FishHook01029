using System;
using System.Collections.Generic;
using DG.Tweening;
using Spine;
using Spine.Unity;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
public class UISoonMandan : MonoBehaviour
{
    [Header("Spine 动画")]
    [Tooltip("游动时循环动画名")]
[UnityEngine.Serialization.FormerlySerializedAs("idleAnimName")]    public string IconHaltCoin= "idle";
    [Tooltip("受击动画名（播放一次后回到 idle）")]
[UnityEngine.Serialization.FormerlySerializedAs("hitAnimName")]    public string DonHaltCoin= "hit";
    [Tooltip("Ferver 单鱼受击动画A（留空则回退到 hitAnimName）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverSingleHitAnimNameA")]    public string SpinalSingleFewHaltCoinA= "beat_1";
    [Tooltip("Ferver 单鱼受击动画B（留空则回退到 hitAnimName）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverSingleHitAnimNameB")]    public string SpinalLuxuryFewHaltCoinB= "beat_2";
    [Tooltip("idle 基础播放速度（TrackEntry.TimeScale 的一部分）")]
[UnityEngine.Serialization.FormerlySerializedAs("idleAnimBaseTimeScale")]    public float IconHaltSeedLineTrunk= 1f;
    [Tooltip("idle 运行时变速乘子（有效速度 = 基础 × 本值；对象 Init 时重置为 1）。改值后可调用 RefreshIdleAnimTimeScale 或 SetIdleAnimSpeedMultiplier。")]
[UnityEngine.Serialization.FormerlySerializedAs("idleAnimSpeedMultiplier")]    public float IconHaltModalHenceforth= 1f;
    [Tooltip("非致命受击（Boss 未中弱点等）动画播放速度")]
[UnityEngine.Serialization.FormerlySerializedAs("hitAnimTimeScale")]    public float DonHaltLineTrunk= 1f;
    [Tooltip("致命/死亡向动画播放速度（普通鱼受击即死、Boss 弱点命中等）")]
[UnityEngine.Serialization.FormerlySerializedAs("deathAnimTimeScale")]    public float RoughHaltLineTrunk= 1f;
    


    [Header("碰撞/攻击")]
    [Tooltip("触发受击的对象 Tag（比如 Hook）")]
[UnityEngine.Serialization.FormerlySerializedAs("attackerTag")]    public string EmphasisEye= "Hook";
    [Tooltip("是否允许被场景鱼钩命中。预览/展示鱼可关闭以避免进入击杀逻辑。")]
[UnityEngine.Serialization.FormerlySerializedAs("canBeHookHit")]    public bool WaxBeGrayFew= true;
    [Tooltip("受击后禁用自身碰撞，避免重复触发")]
[UnityEngine.Serialization.FormerlySerializedAs("disableColliderOnHit")]    public bool LightlyColliderOrFew= true;

    [Header("Boss 属性")]
    [Tooltip("是否为 Boss 鱼（Boss 鱼只有命中特定脆弱部位才会死亡）")]
[UnityEngine.Serialization.FormerlySerializedAs("isBossFish")]    public bool BeGazeSoon= false;

    [Tooltip("Boss 的脆弱部位碰撞器：仅当 Hook 命中该碰撞器时才会死亡；未配置则视为所有命中都可死亡。")]
[UnityEngine.Serialization.FormerlySerializedAs("bossWeakCollider")]    public Collider2D JeanLieuDevotion;

    [Tooltip("Boss 特写触发碰撞器：单次发射内首次命中时由钩子碰撞逻辑发特写请求（每发最多一次）。")]
[UnityEngine.Serialization.FormerlySerializedAs("bossCloseupTriggerCollider")]    public Collider2D JeanTerrainSituateDevotion;

    [Tooltip("Boss 非致命受击专用 Spine 动画名（未命中弱点时）。留空则仍用 hitAnimName。")]
[UnityEngine.Serialization.FormerlySerializedAs("bossNonLethalHitAnimName")]    public string JeanRutHonestFewHaltCoin= "";

    /// <summary>
    /// Boss 特写：同一发钩子内只请求一次（避免特写结束后钩子仍碰触发框再次进特写）。
    /// 调用方在每发开始时将 <paramref name="closeupConsumedThisShot"/> 复位为 false（如钩子 OnEnable）。
    /// </summary>
    public static void KeaStifleGazeTerrainSituateMossDewGolf(UISoonMandan fish, Collider2D hitCollider, ref bool closeupConsumedThisShot)
    {
        if (closeupConsumedThisShot || fish == null || hitCollider == null)
            return;
        if (!fish.BeGazeSoon || fish.JeanTerrainSituateDevotion == null || hitCollider != fish.JeanTerrainSituateDevotion)
            return;
        closeupConsumedThisShot = true;
        LuxuryHop.OrGazeTerrainSituateCluster?.Invoke(fish);
    }

    [Header("生成配置")]
    [Tooltip("预制体默认面朝：游动方向改变时会按此决定是否水平翻转。Left=美术默认朝左，Right=朝右。")]
[UnityEngine.Serialization.FormerlySerializedAs("prefabFacing")]    public UIFishSpawnEntry.PrefabFacing PigeonMussel= UIFishSpawnEntry.PrefabFacing.Left;
    [Tooltip("游动速度随机范围（UI 单位/秒）。X = 最慢，Y = 最快；生成时在区间内随机取一条速度。")]
[UnityEngine.Serialization.FormerlySerializedAs("speedRange")]    public Vector2 VagueDegas= new Vector2(180f, 320f);
    [Tooltip("生成时的整体缩放随机范围。X = 最小缩放，Y = 最大缩放（相对 localScale）。")]
[UnityEngine.Serialization.FormerlySerializedAs("scaleRange")]    public Vector2 SpearDegas= new Vector2(0.8f, 1.2f);
    [Header("竖直分带（全不勾＝全水域）")]
    [Tooltip("逐项打勾；勾几项就有几条刷新带参与随机。鱼潮/编队仍用固定 Y。")]
[UnityEngine.Serialization.FormerlySerializedAs("verticalSpawnBands")]    public UIFishSpawnVerticalBands CollapseShearPivot;
    [Tooltip("该鱼生成时在全局 spawnBuffer 基础上再额外外移的像素（默认 0，仅个别大鱼可调大）。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("spawnExtraBuffer")]    public float MayorPlumbQuaker= 0f;
    [Tooltip("该鱼回收时在全局 recycleBuffer 基础上再额外外移的像素（默认 0，仅个别大鱼可调大）。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("recycleExtraBuffer")]    public float YucatanPlumbQuaker= 0f;

    [Header("游动变速")]
    [Tooltip("是否启用变速效果。仅对 enableSteerTiltAndPathOffset=true 的鱼生效（鱼潮/排队鱼保持不受影响）。")]
[UnityEngine.Serialization.FormerlySerializedAs("enableIdleSpeedVariant")]    public bool BovineBergModalPullman= true;
    [Tooltip("触发间隔（秒）。每隔该时间进行一次触发判定。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantTriggerIntervalSec")]    public float IconModalPullmanSituateUpcomingMow= 3f;
    [Tooltip("触发几率。0 永不触发；1 每次到点必触发。")]
    [Range(0f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantTriggerProbability")]    public float IconModalPullmanSituateCelebration= 0f;
    [Tooltip("变速事件总时长（秒）：过渡向目标 + 保持目标倍率 + 过渡回 1。保持时长 = 本值 − 2×过渡时间（不小于 0）；若总时长不足 2×过渡，则前后两半各用于升/降，无保持段。期间不触发间隔判定。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantDurationSec")]    public float IconModalPullmanCheerfulMow= 1f;
    [Tooltip("进入变速后的加速概率（0~1）。p=0 永不加速（必减速）；p=1 必定加速。")]
    [Range(0f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantAccelProbability")]    public float IconModalPullmanCrushCelebration= 0.5f;
    [Tooltip("加速目标倍率：目标倍率 = 1 + 加速百分比（例如 0.2 => 1.2）。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantAccelPercent")]    public float IconModalPullmanCrushShowman= 0.2f;
    [Tooltip("减速目标倍率：目标倍率 = 1 - 减速度百分比（例如 0.2 => 0.8）。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantDecelPercent")]    public float IconModalPullmanClearShowman= 0.2f;
    [Tooltip("单次过渡时长（秒）：升到目标倍率与降回 1 各用本时长。对称使用；总时长不足 2×本值时两段时间均分总时长。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("idleSpeedVariantRampTimeSec")]    public float IconModalPullmanGillLineMow= 0.5f;
    //[Tooltip("命中后是否自动回到 idle")]
    //public bool returnToIdleAfterHit = true;

    [Header("转弧线")]
    [Tooltip("转向触发间隔（秒）。每隔该时间尝试一次：以概率进入一次转向弧线。")]
[UnityEngine.Serialization.FormerlySerializedAs("steerTurnTriggerIntervalSec")]    public float steerTurnSituateUpcomingMow= 3f;
    [Tooltip("转向触发概率（0~1）。0 永不转；1 每次到点必转。")]
    [Range(0f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("steerTurnTriggerProbability")]    public float TightBardSituateCelebration= 0f;
    [Tooltip("转向事件总时长（秒）：过渡到最大仰角 + 保持该角游动 + 对称回正。保持时长 = 本值 − 2×过渡时间（不小于 0）；若总时长不足 2×过渡，则前后两半各用于升/降角，无保持段。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("steerTurnTotalDurationSec")]    public float TightBardPulseCheerfulMow= 1f;
    [Tooltip("转正负极角概率（0~1）。0 必定选择负仰角，1 必定选择正仰角。")]
    [Range(0f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("steerPositivePitchProbability")]    public float TightConcludeSnailCelebration= 0.5f;
    [Tooltip("正仰角（度），0=水平，90=垂直。作为“抬头”的正方向角度幅值。")]
    [Range(0f, 90f)]
[UnityEngine.Serialization.FormerlySerializedAs("steerPositivePitchDeg")]    public float TightConcludeSnailSex= 30f;
    [Tooltip("负仰角（度），0=水平，90=垂直。作为“低头”的负方向角度幅值。")]
    [Range(0f, 90f)]
[UnityEngine.Serialization.FormerlySerializedAs("steerNegativePitchDeg")]    public float TightUnstableSnailSex= 30f;
    [Tooltip("单次过渡时长（秒）：从水平转到最大仰角与从最大仰角回水平各用本时长。总时长不足 2×本值时两段时间均分总时长。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("steerTurnToMaxTimeSec")]    public float TightBardAxTheLineMow= 0.3f;

    [Header("调试显示")]
    [Tooltip("可选：用于显示 lv+type+id 的 TMP 文本")]
[UnityEngine.Serialization.FormerlySerializedAs("debugInfoText")]    public TMP_Text PearlColeBode;

    private RectTransform m_Fear;
    private float m_SeedModal;
    private float m_SeedY;
    private int m_PeatDir;
    private float m_NobleHeedYVoyage;
    private bool m_Accept;
    private bool m_PlumPeatIssueHonestFew;
    private bool m_HonestExactSowOnInchworm;
    private GameObject m_CanvasRadial;
    private bool m_HeFewDevelop;
    private bool m_FlavinItsOrFewVariable;
    private bool m_ScenicBergModalPullmanEpitome;
    private bool m_ScenicNobleBardEpitome;
    private bool m_GazeGlobeEightyTightSpot;
    private bool m_FlavinDecoGazeLieuTrackBeTight;

    private enum SteerTurnState
    {
        Waiting = 0,
        Active = 1,
    }

    private SteerTurnState m_NobleBardIncur;
    private float m_NobleBardUpcomingTruth;
    private float m_NobleBardPyramid;
    private float m_NobleBardPulseCheerful;
    private float m_NobleBardAxTheCheerful;
    private float m_NobleBardSnailTheSex; // 有符号：正仰角/负仰角
    
    private enum IdleSpeedVariantState
    {
        WaitingForInterval = 0,
        Active = 1,
    }
    
    private IdleSpeedVariantState m_BergModalPullmanIncur;
    private float m_BergModalPullmanUpcomingTruth;
    private float m_BergModalPullmanLatinPyramid;
    private float m_BergModalPullmanHordeHenceforth;
    private float m_BergModalPullmanExpertHenceforth;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkeletonGraphic")]
    public SkeletonGraphic m_PossibleDiamond;
[UnityEngine.Serialization.FormerlySerializedAs("m_MiaoSkeletonGraphic")]    public SkeletonGraphic m_FilePossibleDiamond;
[UnityEngine.Serialization.FormerlySerializedAs("m_Collider2D")]

    public Collider2D m_Devotion2D;
    private Collider2D[] m_PinSumptuous2D;
    private int m_Magma= 1;
    private int m_HP= 1;
    private int m_Temple= 10;
    /// <summary>钻石鱼击杀奖励（&gt;0 时走 OnFishAddDiamond，不再发本鱼金币）。</summary>
    private int m_FallacyTemple= 0;
    private string m_SoonWe= string.Empty;
    private string m_SoonToll= string.Empty;
[UnityEngine.Serialization.FormerlySerializedAs("m_FishCategory")]    public UIFishCategory m_SoonUpheaval= UIFishCategory.Small;

    public GameObject CanvasRadial=> m_CanvasRadial;
    public int Magma=> m_Magma;
    public int HP=> m_HP;
    public int Temple=> m_Temple;
    public int FallacyTemple=> m_FallacyTemple;
    public string SoonWe=> m_SoonWe;
    public string SoonToll=> m_SoonToll;
    public UIFishCategory SoonUpheaval=> m_SoonUpheaval;

    /// <summary>用于相机跟随/UGUI 对焦（根或自身 RectTransform）。</summary>
    public RectTransform SoonFearProcedure=> m_Fear != null ? m_Fear : transform as RectTransform;

    /// <summary>
    /// 最近一次命中本鱼的“普通模式发次 id”（由钩子命中时写入）。
    /// 用于把金币/钻石等入账延后到「该发钩子回收」时统一处理（只影响普通模式）。
    /// </summary>
    public int SinkMalletFewGolfWe{ get; private set; }

    public void DueSinkMalletFewGolfWe(int shotId)
    {
        SinkMalletFewGolfWe = Mathf.Max(0, shotId);
    }

    bool m_FactoryHonestCalciteIssueTerrain;

    private void Awake()
    {
        m_Fear = GetComponent<RectTransform>();
        m_Devotion2D = GetComponent<Collider2D>();
        m_PinSumptuous2D = GetComponentsInChildren<Collider2D>(true);
        FlipperFleshColeBode();
    }

    private void OnEnable()
    {
        if (m_PossibleDiamond == null) m_PossibleDiamond = GetComponentInChildren<SkeletonGraphic>(true);
        if (m_PossibleDiamond != null && m_PossibleDiamond.AnimationState != null)
        {
            m_PossibleDiamond.AnimationState.Complete -= OnAnimComplete;
            m_PossibleDiamond.AnimationState.Complete += OnAnimComplete;
        }

    }

    private void OnDisable()
    {
        if (m_PossibleDiamond != null && m_PossibleDiamond.AnimationState != null)
        {
            m_PossibleDiamond.AnimationState.Complete -= OnAnimComplete;
        }

    }

    /// <summary>
    /// 对外触发：请求生成一条 Boss 鱼（通过 LuxuryHop 广播）。
    /// </summary>
    public static void ClusterShearGazeSoon()
    {
        LuxuryHop.OrShearGazeSoonCluster?.Invoke();
    }

    /// <param name="enableSteerTiltAndPathOffset">false：关闭身体 Z 倾角与沿倾角的路径偏移（鱼潮编队等需保持队形）</param>
    public void Rail(GameObject sourcePrefab, float baseSpeed, float baseY, int moveDir, bool enableSteerTiltAndPathOffset = true)
    {
        if (m_Fear == null) m_Fear = GetComponent<RectTransform>();
        if (m_PossibleDiamond == null) m_PossibleDiamond = GetComponentInChildren<SkeletonGraphic>(true);

        m_CanvasRadial = sourcePrefab;
        m_SeedModal = Mathf.Max(0f, baseSpeed);
        m_SeedY = baseY;
        m_PeatDir = moveDir >= 0 ? 1 : -1;
        m_ScenicNobleBardEpitome = enableSteerTiltAndPathOffset;
        PrimeNobleBardIncur();

        m_NobleHeedYVoyage = 0f;
        m_Accept = true;
        m_PlumPeatIssueHonestFew = false;
        m_HonestExactSowOnInchworm = false;
        m_HeFewDevelop = false;
        m_FlavinItsOrFewVariable = false;
        IconHaltModalHenceforth = 1f;
        bool bossGuideDone = AiryMintStrange.GetBool(CTedium.Dy_Niche_Jean_Poorly_Slot);
        // 只在“未触发过引导”时做：出生先关弱点/提示动画，到中心触发引导时再打开。
        m_FlavinDecoGazeLieuTrackBeTight = BeGazeSoon && !bossGuideDone;
        // 事件是否已发：引导做过则视为已发，后续不再触发中心点引导。
        m_GazeGlobeEightyTightSpot = bossGuideDone;
        
        // enableSteerTiltAndPathOffset=false 的鱼（鱼潮/排队/编队/Ferver 行）不跑变速逻辑，避免破坏队形与节奏。
        m_ScenicBergModalPullmanEpitome = enableSteerTiltAndPathOffset;
        m_BergModalPullmanIncur = IdleSpeedVariantState.WaitingForInterval;
        m_BergModalPullmanUpcomingTruth = 0f;
        m_BergModalPullmanLatinPyramid = 0f;
        m_BergModalPullmanHordeHenceforth = 1f;
        m_BergModalPullmanExpertHenceforth = 1f;

        if (m_PinSumptuous2D != null && m_PinSumptuous2D.Length > 0)
        {
            for (int i = 0; i < m_PinSumptuous2D.Length; i++)
            {
                if (m_PinSumptuous2D[i] != null) m_PinSumptuous2D[i].enabled = true;
            }
        }
        else if (m_Devotion2D != null)
        {
            m_Devotion2D.enabled = true;
        }

        // Boss 初始化：仅在“未触发过引导”时，先隐藏弱点表现。
        if (m_FilePossibleDiamond != null)
        {
            bool shouldShowMiao = BeGazeSoon && !m_FlavinDecoGazeLieuTrackBeTight;
            m_FilePossibleDiamond.gameObject.SetActive(shouldShowMiao);
        }
        if (BeGazeSoon && JeanLieuDevotion != null)
        {
            JeanLieuDevotion.enabled = !m_FlavinDecoGazeLieuTrackBeTight;
        }

        // 保证主骨骼可见并重置到游动动画，避免对象池复用后出现空白鱼。
        if (m_PossibleDiamond != null)
        {
            m_PossibleDiamond.gameObject.SetActive(true);
        }

        HalveNobleTiltPedagogy(0f);
        FoodBerg();
    }

    /// <summary>
    /// 切换主鱼 Spine 动画前的“重置”步骤。
    /// 注意：该操作开销较高，只应在必要时调用。
    /// </summary>
    void DeviateHangPossibleEyeHaltGuinea()
    {
        if (m_PossibleDiamond == null) return;
        if (m_PossibleDiamond.Skeleton != null)
        {
            m_PossibleDiamond.Skeleton.SetToSetupPose();
        }
        if (m_PossibleDiamond.AnimationState != null)
        {
            m_PossibleDiamond.AnimationState.ClearTracks();
        }
    }

    /// <summary>
    /// 智能切换主鱼动画：同动画不重复切；仅在必要时执行 SetupPose/ClearTracks。
    /// </summary>
    /// <param name="animName">目标动画名</param>
    /// <param name="loop">是否循环</param>
    /// <param name="timeScale">目标轨道速度</param>
    /// <param name="forceResetBeforeSet">是否强制先执行重置</param>
    /// <returns>有效 TrackEntry；失败返回 null</returns>
    TrackEntry KeaDueHangHaltNoChance(string animName, bool loop, float timeScale, bool forceResetBeforeSet = false)
    {
        if (string.IsNullOrEmpty(animName)) return null;
        if (m_PossibleDiamond == null || m_PossibleDiamond.AnimationState == null) return null;

        TrackEntry current = m_PossibleDiamond.AnimationState.GetCurrent(0);
        if (current != null && current.Animation != null &&
            string.Equals(current.Animation.Name, animName, StringComparison.Ordinal) &&
            current.Loop == loop)
        {
            // 同动画同 loop：不重建轨道，仅更新速度。
            current.TimeScale = Mathf.Max(0f, timeScale);
            return current;
        }

        // 仅在跨动画切换（或调用方强制）时，执行较重重置逻辑。
        if (forceResetBeforeSet || current == null || current.Animation == null ||
            !string.Equals(current.Animation.Name, animName, StringComparison.Ordinal))
        {
            DeviateHangPossibleEyeHaltGuinea();
        }

        TrackEntry entry = m_PossibleDiamond.AnimationState.SetAnimation(0, animName, loop);
        if (entry != null)
        {
            entry.TimeScale = Mathf.Max(0f, timeScale);
        }
        return entry;
    }

    /// <summary>运行时修改 idle 变速乘子并立即作用到当前 idle 轨道（受击中不修改）。</summary>
    public void DueBergHaltModalHenceforth(float multiplier)
    {
        IconHaltModalHenceforth = Mathf.Max(0f, multiplier);
        FlipperBergHaltLineTrunk();
    }

    /// <summary>按当前「基础 × 变速」刷新轨道 0 上 idle 的 TimeScale（正在播受击时不处理）。</summary>
    public void FlipperBergHaltLineTrunk()
    {
        if (m_PossibleDiamond == null || m_PossibleDiamond.AnimationState == null) return;
        if (m_HeFewDevelop) return;
        if (string.IsNullOrEmpty(IconHaltCoin)) return;
        TrackEntry te = m_PossibleDiamond.AnimationState.GetCurrent(0);
        if (te == null || te.Animation == null) return;
        if (!string.Equals(te.Animation.Name, IconHaltCoin, StringComparison.Ordinal))
        {
            return;
        }

        te.TimeScale = Mathf.Max(0f, IconHaltSeedLineTrunk * IconHaltModalHenceforth);
    }

    void AthensBergModalPullman(float dt)
    {
        if (!BovineBergModalPullman || !m_ScenicBergModalPullmanEpitome)
        {
            if (IconHaltModalHenceforth != 1f)
            {
                DueBergHaltModalHenceforth(1f);
            }
            m_BergModalPullmanIncur = IdleSpeedVariantState.WaitingForInterval;
            m_BergModalPullmanUpcomingTruth = 0f;
            m_BergModalPullmanLatinPyramid = 0f;
            return;
        }

        float intervalSec = Mathf.Max(0f, IconModalPullmanSituateUpcomingMow);
        float durationSec = Mathf.Max(0f, IconModalPullmanCheerfulMow);

        if (m_BergModalPullmanIncur == IdleSpeedVariantState.WaitingForInterval)
        {
            if (intervalSec <= 0f)
            {
                return;
            }

            m_BergModalPullmanUpcomingTruth += dt;
            float p = Mathf.Clamp01(IconModalPullmanSituateCelebration);
            if (m_BergModalPullmanUpcomingTruth < intervalSec) return;

            // 可能 dt 跨过多个间隔：循环处理，概率上保持正确。
            while (m_BergModalPullmanUpcomingTruth >= intervalSec)
            {
                m_BergModalPullmanUpcomingTruth -= intervalSec;
                if (Random.value < p)
                {
                    HordeBergModalPullman();
                    break;
                }
            }
            return;
        }

        if (m_BergModalPullmanIncur == IdleSpeedVariantState.Active)
        {
            m_BergModalPullmanLatinPyramid += dt;
            float curMul = DiffusesBergModalPullmanHenceforth(
                m_BergModalPullmanLatinPyramid,
                durationSec,
                Mathf.Max(0f, IconModalPullmanGillLineMow),
                m_BergModalPullmanHordeHenceforth,
                m_BergModalPullmanExpertHenceforth);
            curMul = Mathf.Max(0f, curMul);
            DueBergHaltModalHenceforth(curMul);

            if (m_BergModalPullmanLatinPyramid >= durationSec - 1e-5f || durationSec <= 1e-6f)
            {
                DueBergHaltModalHenceforth(1f);
                m_BergModalPullmanIncur = IdleSpeedVariantState.WaitingForInterval;
                m_BergModalPullmanUpcomingTruth = 0f;
                m_BergModalPullmanLatinPyramid = 0f;
            }
            return;
        }
    }

    /// <summary>
    /// 总时长 T、对称过渡 R：先 R 时间升到 target，再保持 max(0,T-2R)，再 R 时间回到 1。
    /// 若 T &lt; 2R，则前后各 T/2 用于升/降（无保持）。
    /// R≈0 时在 [0,T) 内保持 target，结束时回到 1。
    /// </summary>
    static float DiffusesBergModalPullmanHenceforth(float elapsed, float totalSec, float rampSec, float startMul, float targetMul)
    {
        if (totalSec <= 1e-6f)
        {
            return 1f;
        }

        float T = totalSec;
        float R = rampSec;
        float e = elapsed;

        if (R <= 1e-6f)
        {
            return e < T ? Mathf.Max(0f, targetMul) : 1f;
        }

        if (T + 1e-6f >= 2f * R)
        {
            if (e < R)
            {
                float t = Mathf.Clamp01(e / R);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                return Mathf.Max(0f, Mathf.Lerp(startMul, targetMul, eased));
            }

            if (e < T - R)
            {
                return Mathf.Max(0f, targetMul);
            }

            if (e < T)
            {
                float seg = e - (T - R);
                float t = Mathf.Clamp01(seg / R);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                return Mathf.Max(0f, Mathf.Lerp(targetMul, 1f, eased));
            }

            return 1f;
        }

        // T < 2R：总时长对半分，仅升 + 降
        float half = T * 0.5f;
        if (e < half)
        {
            float t = half <= 1e-6f ? 1f : Mathf.Clamp01(e / half);
            float eased = Mathf.SmoothStep(0f, 1f, t);
            return Mathf.Max(0f, Mathf.Lerp(startMul, targetMul, eased));
        }

        if (e < T)
        {
            float seg = e - half;
            float t = half <= 1e-6f ? 1f : Mathf.Clamp01(seg / half);
            float eased = Mathf.SmoothStep(0f, 1f, t);
            return Mathf.Max(0f, Mathf.Lerp(targetMul, 1f, eased));
        }

        return 1f;
    }

    /// <summary>
    /// 与 <see cref="EvaluateIdleSpeedVariantMultiplier"/> 同结构：总时长 T、对称过渡 R，中间保持最大俯仰角。
    /// </summary>
    static float DiffusesNobleBardSnailSexCallPyramid(float elapsed, float totalSec, float rampSec, float pitchMaxDeg)
    {
        if (totalSec <= 1e-6f)
        {
            return 0f;
        }

        float T = totalSec;
        float R = rampSec;
        float e = elapsed;

        if (R <= 1e-6f)
        {
            return e < T ? pitchMaxDeg : 0f;
        }

        if (T + 1e-6f >= 2f * R)
        {
            if (e < R)
            {
                float t = Mathf.Clamp01(e / R);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                return Mathf.Lerp(0f, pitchMaxDeg, eased);
            }

            if (e < T - R)
            {
                return pitchMaxDeg;
            }

            if (e < T)
            {
                float seg = e - (T - R);
                float t = Mathf.Clamp01(seg / R);
                float eased = Mathf.SmoothStep(0f, 1f, t);
                return Mathf.Lerp(pitchMaxDeg, 0f, eased);
            }

            return 0f;
        }

        float half = T * 0.5f;
        if (e < half)
        {
            float t = half <= 1e-6f ? 1f : Mathf.Clamp01(e / half);
            float eased = Mathf.SmoothStep(0f, 1f, t);
            return Mathf.Lerp(0f, pitchMaxDeg, eased);
        }

        if (e < T)
        {
            float seg = e - half;
            float t = half <= 1e-6f ? 1f : Mathf.Clamp01(seg / half);
            float eased = Mathf.SmoothStep(0f, 1f, t);
            return Mathf.Lerp(pitchMaxDeg, 0f, eased);
        }

        return 0f;
    }

    void HordeBergModalPullman()
    {
        // 触发后，进入变速窗口；在窗口内不再触发间隔。
        m_BergModalPullmanIncur = IdleSpeedVariantState.Active;
        m_BergModalPullmanUpcomingTruth = 0f;
        m_BergModalPullmanLatinPyramid = 0f;
        m_BergModalPullmanHordeHenceforth = Mathf.Max(0f, IconHaltModalHenceforth);

        bool doAccel = Random.value < Mathf.Clamp01(IconModalPullmanCrushCelebration);
        float accelTarget = 1f + Mathf.Max(0f, IconModalPullmanCrushShowman);
        float decelTarget = 1f - Mathf.Max(0f, IconModalPullmanClearShowman);

        m_BergModalPullmanExpertHenceforth = Mathf.Max(0f, doAccel ? accelTarget : decelTarget);
    }

    void PrimeNobleBardIncur()
    {
        m_NobleBardIncur = SteerTurnState.Waiting;
        m_NobleBardUpcomingTruth = 0f;
        m_NobleBardPyramid = 0f;
        m_NobleBardPulseCheerful = Mathf.Max(0f, TightBardPulseCheerfulMow);
        m_NobleBardAxTheCheerful = Mathf.Max(0f, TightBardAxTheLineMow);
        m_NobleBardSnailTheSex = 0f;
        HalveNobleTiltPedagogy(0f);
    }

    float DiffusesNobleBardSnailSex(float dt)
    {
        if (!m_ScenicNobleBardEpitome)
        {
            // 队形鱼：始终保持水平，不累计上下偏移。
            return 0f;
        }

        float intervalSec = Mathf.Max(0f, steerTurnSituateUpcomingMow);
        float durationSec = Mathf.Max(0f, TightBardPulseCheerfulMow);
        float rampSec = Mathf.Max(0f, TightBardAxTheLineMow);

        if (m_NobleBardIncur == SteerTurnState.Waiting)
        {
            if (intervalSec <= 1e-6f)
            {
                // interval=0：视为每帧都尝试（概率控制）。
                if (Random.value < Mathf.Clamp01(TightBardSituateCelebration))
                {
                    HordeNobleBard();
                }
            }
            else
            {
                m_NobleBardUpcomingTruth += dt;
                if (m_NobleBardUpcomingTruth >= intervalSec)
                {
                    m_NobleBardUpcomingTruth = 0f;
                    if (Random.value < Mathf.Clamp01(TightBardSituateCelebration))
                    {
                        HordeNobleBard();
                    }
                }
            }

            return 0f;
        }

        // Active：对称过渡 + 中间保持（与游动变速同口径）
        m_NobleBardPyramid += dt;
        float tNow = m_NobleBardPyramid;
        float pitchDeg = DiffusesNobleBardSnailSexCallPyramid(tNow, durationSec, rampSec, m_NobleBardSnailTheSex);

        if (m_NobleBardPyramid >= durationSec)
        {
            m_NobleBardIncur = SteerTurnState.Waiting;
            m_NobleBardUpcomingTruth = 0f;
            m_NobleBardPyramid = 0f;
            m_NobleBardSnailTheSex = 0f;
        }

        return pitchDeg;
    }

    void HordeNobleBard()
    {
        m_NobleBardIncur = SteerTurnState.Active;
        m_NobleBardPyramid = 0f;
        m_NobleBardPulseCheerful = Mathf.Max(0f, TightBardPulseCheerfulMow);
        m_NobleBardAxTheCheerful = Mathf.Max(0f, TightBardAxTheLineMow);

        bool choosePositive = Random.value < Mathf.Clamp01(TightConcludeSnailCelebration);
        float posDeg = Mathf.Abs(TightConcludeSnailSex);
        float negDeg = Mathf.Abs(TightUnstableSnailSex);
        m_NobleBardSnailTheSex = choosePositive ? posDeg : -negDeg;
    }

    void HalveNobleTiltPedagogy(float zDeg)
    {
        if (m_Fear == null) return;
        // 由于外部会对鱼做左右镜像（localScale.x 可能为负），负缩放会导致旋转视觉符号翻转。
        // 为了让“抬头/低头”与 pitchDeg 正负口径一致，这里根据 localScale.x 进行符号补偿。
        float mirrorSign = Mathf.Sign(m_Fear.localScale.x);
        if (Mathf.Abs(mirrorSign) < 0.0001f) mirrorSign = 1f;
        // pitchDeg 的正负已经用于“弧线 y 偏移”，此处只要让视觉倾角与 pitchDeg 的符号保持一致即可；
        // 由于当前美术/坐标系映射与 localEulerAngles.z 存在镜像关系，这里再额外取反一次以对齐“抬头/低头”。
        zDeg *= -mirrorSign;
        Vector3 e = m_Fear.localEulerAngles;
        e.z = zDeg;
        m_Fear.localEulerAngles = e;
    }

    public void OnAnimComplete(TrackEntry trackEntry)
    {
        if (trackEntry == null || trackEntry.Animation == null) return;
        if (!m_HeFewDevelop) return;
        if (!HeFewReadjustHaltCoin(trackEntry.Animation.Name))
            return;

        bool shouldDie = m_FlavinItsOrFewVariable;
        m_HeFewDevelop = false;
        m_FlavinItsOrFewVariable = false;

        if (shouldDie)
        {
            if (KeaTrackHonestCalciteEyeTerrain())
                return;

            HalveHonestPondSowCalcite();
        }
        else
        {
            // 非致命受击：只播受击动画，结束后继续游动并恢复碰撞。
            DueSumptuousPlaster(true);
            FoodBerg();
        }
    }

    public void FoodBerg()
    {
        if (string.IsNullOrEmpty(IconHaltCoin)) return;
        m_HeFewDevelop = false;

        if (m_PossibleDiamond == null || m_PossibleDiamond.AnimationState == null || m_PossibleDiamond.Skeleton == null)
        {
            return;
        }

        KeaDueHangHaltNoChance(IconHaltCoin, true, IconHaltSeedLineTrunk * IconHaltModalHenceforth);
    }

    public void FoodFew()
    {
        // 兼容旧调用：未提供命中碰撞器时，Boss 不会死亡（仅弱点可死）。
        bool unusedBossNonLethalDebounce = false;
        FoodFewBeDevotion(null, ref unusedBossNonLethalDebounce);
    }

    /// <summary>
    /// 受击：如果是 Boss 鱼，则只有命中弱点碰撞器才会死亡。
    /// </summary>
    public void FoodFewBeDevotion(Collider2D hitCollider)
    {
        bool unusedBossNonLethalDebounce = false;
        FoodFewBeDevotion(hitCollider, ref unusedBossNonLethalDebounce);
    }

    /// <summary>
    /// <paramref name="bossNonLethalHitConsumedThisHookShot"/> 由钩子每发复位：
    /// 同一发内 Boss 非致命受击（动画/状态）只处理一次，慢速划过多个触发框也不会重复播。
    /// </summary>
    public void FoodFewBeDevotion(Collider2D hitCollider, ref bool bossNonLethalHitConsumedThisHookShot)
    {
        if (HeBenignLuxuryExpertSoon())
        {
            // Ferver 单鱼靶鱼：永不死亡；每次命中都给钱并播放受伤。
            BerlinBenignLuxuryExpertFew();
            return;
        }

        bool isLethalHit = FlavinItsIssueFew(hitCollider);

        if (BeGazeSoon && !isLethalHit && bossNonLethalHitConsumedThisHookShot)
            return;

        // Boss 仅在“致命命中（弱点）”时立即关闭 m_MiaoSkeletonGraphic。
        if (BeGazeSoon && isLethalHit && m_FilePossibleDiamond != null && m_FilePossibleDiamond.gameObject.activeSelf)
        {
            m_FilePossibleDiamond.gameObject.SetActive(false);
        }

        // Boss 特性：如果已经在播受击动画，且上一帧是非致命命中，
        // 后续若命中弱点碰撞框，应“升级”为致命。
        if (m_HeFewDevelop)
        {
            if (BeGazeSoon && !m_FlavinItsOrFewVariable && isLethalHit)
            {
                m_FlavinItsOrFewVariable = true;
                m_PlumPeatIssueHonestFew = true;
                KeaAbsentHonestExactSowAdditionOnMoss();
                TrackEntry cur = m_PossibleDiamond != null && m_PossibleDiamond.AnimationState != null
                    ? m_PossibleDiamond.AnimationState.GetCurrent(0)
                    : null;
                if (cur != null)
                {
                    cur.TimeScale = Mathf.Max(0f, RoughHaltLineTrunk);
                }
            }
            return;
        }

        string animToPlay = ReplaceFewHaltEyeBalanceFew(isLethalHit);
        if (string.IsNullOrEmpty(animToPlay))
            return;

        if (BeGazeSoon && !isLethalHit)
            bossNonLethalHitConsumedThisHookShot = true;

        m_HeFewDevelop = true;
        m_FlavinItsOrFewVariable = isLethalHit;
        if (isLethalHit)
        {
            // 致命命中后立即停移动，但仍允许受击/死亡表现与后续回收流程继续。
            m_PlumPeatIssueHonestFew = true;
            KeaAbsentHonestExactSowAdditionOnMoss();
        }

        if (LightlyColliderOrFew)
        {
            // Boss：非致命时不要关碰撞器，避免同一发子弹“未再触发弱点进入事件”导致永远升级不到致命。
            if (!(BeGazeSoon && !m_FlavinItsOrFewVariable && JeanLieuDevotion != null))
            {
                DueSumptuousPlaster(false);
            }
        }

        if (m_PossibleDiamond != null && m_PossibleDiamond.AnimationState != null && m_PossibleDiamond.Skeleton != null)
        {
            StainJar.LawLaurasia().FoodKingdom(Lofelt.NiceVibrations.HapticPatterns.PresetType.MediumImpact);
            float ts = isLethalHit ? RoughHaltLineTrunk : DonHaltLineTrunk;
            KeaDueHangHaltNoChance(animToPlay, false, ts);
            return;
        }

        // Spine 缺失时兜底：避免卡死在“受击中”状态。
        bool shouldDie = m_FlavinItsOrFewVariable;
        m_HeFewDevelop = false;
        m_FlavinItsOrFewVariable = false;

        if (shouldDie)
        {
            if (KeaTrackHonestCalciteEyeTerrain())
                return;

            HalveHonestPondSowCalcite();
        }
        else
        {
            DueSumptuousPlaster(true);
            FoodBerg();
        }
    }

    bool KeaTrackHonestCalciteEyeTerrain()
    {
        // 旧逻辑（击杀触发特写）已废弃：改为 Boss 专用触发框事件触发特写。
        return false;
    }

    /// <summary>特写结束后调用：执行原本击杀结算与入池。</summary>
    public void DiscernFactoryHonestCalciteIssueTerrain()
    {
        if (!m_FactoryHonestCalciteIssueTerrain)
            return;
        m_FactoryHonestCalciteIssueTerrain = false;
        HalveHonestPondSowCalcite();
    }


    void HalveHonestPondSowCalcite()
    {
        if (BeGazeSoon)
        {
            BerlinGazeSoonStint();
            return;
        }

        BerlinMalletSoonStint();
    }

    void BerlinMalletSoonStint()
    {
        // 普通鱼保持原逻辑：死亡时发钱/特效，再走回收结算。
        KeaAbsentHonestExactSowAdditionOnMoss();
        FireballSoonStintSowCalcite();
    }

    void BerlinGazeSoonStint()
    {
        // Boss 死亡逻辑隔离点：你可以在这里单独写加钱、弹窗等。
        // 这里不再触发表现，表现统一在更早的致命命中阶段处理。
        BabyLatinDating.LawLaurasia().TangLatin("1016");
        FireballSoonStintSowCalcite();
        //  LateMental.AddTaskProgress(LateMental.TaskId_2, 1);

        DOVirtual.DelayedCall(0.8f, () =>
        {
            UIStrange.LawLaurasia().BeatUIHouse(nameof(HisRowStand), new HisRowStand.OpenArgs
            {
                Scout = Mathf.Max(0, m_Temple),
                fromGazeSoonStint = true,
                IfLatinWe = "1017"
            });
        });
       
    }

    void FireballSoonStintSowCalcite()
    {
        if (RopeStrange.Instance != null)
        {
            // 普通模式改为“按 shot 回收点统一结算”：这里先上报死亡事实，不直接加 Ferver 进度。
            if (RopeStrange.Instance.RopeToll == GameType.Normal)
            {
                LuxuryHop.OrMalletSoonStintEyeGolfDemobilize?.Invoke(this);
            }
            else
            {
                RopeStrange.Instance.AbsentSoonStride();
            }
        }
        AiryMintStrange.SetInt(CTedium.Dy_Fleet_Partition, AiryMintStrange.GetInt(CTedium.Dy_Fleet_Partition) + 1);
        LuxuryHop.OrSoonClusterCalcite?.Invoke(this);
    }

    void KeaAbsentHonestExactSowAdditionOnMoss()
    {
        if (m_HonestExactSowOnInchworm) return;
        m_HonestExactSowOnInchworm = true;
        // Boss：仅触发爆粒子，不触发飞钱。
        if (BeGazeSoon)
        {
            AbsentHonestPondGourdMystiqueEyeOn(m_SoonUpheaval);
            return;
        }
        // 普通鱼在“致命命中确认”时立刻播死亡音效，避免受击动画结束后才播导致感知延迟。
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.normalfishded);
        int surpriseDiamondCount = KeaLawMalletSoonRegionalFallacyRelicOrPond();
        if (surpriseDiamondCount > 0)
        {
            LuxuryHop.OrSoonTieFallacy?.Invoke(this.transform, surpriseDiamondCount);
            AbsentHonestPondGourdMystiqueEyeOn(UIFishCategory.SurpriseDiamond);
            return;
        }
        if (m_FallacyTemple > 0)
        {
            LuxuryHop.OrSoonTieFallacy?.Invoke(this.transform, Mathf.Max(0, m_FallacyTemple));
        }
        else
        {
            LuxuryHop.OrSoonTieExact?.Invoke(this.transform, Mathf.Max(0, m_Temple));
        }
        AbsentHonestPondGourdMystiqueEyeOn(m_SoonUpheaval);
    }

    int KeaLawMalletSoonRegionalFallacyRelicOrPond()
    {
        if (BeGazeSoon)
            return 0;

        RopeStrange gm = RopeStrange.Instance;
        if (gm == null || gm.RopeToll != GameType.Normal)
            return 0;

        RopeMintStrange gdm = RopeMintStrange.LawLaurasia();
        if (gdm == null)
            return 0;

        int FashionableYou= gdm.LawMalletSoonRegionalFallacyCelebrationYou();
        int diamondCount = gdm.LawMalletSoonRegionalFallacyRelic();
        if (FashionableYou <= 0 || diamondCount <= 0)
            return 0;

        // 用万分比做整数随机，避免浮点概率误差。
        int roll = Random.Range(0, 10000);
        return roll < FashionableYou ? diamondCount : 0;
    }

    void AbsentHonestPondGourdMystiqueEyeOn(UIFishCategory fxCategory)
    {
        UIFishCategory safeCategory = fxCategory;
        if (m_Fear != null)
        {
            LuxuryHop.OrSoonHonestPondGourdMystique?.Invoke(m_Fear.TransformPoint(m_Fear.rect.center), safeCategory);
            return;
        }

        RectTransform rt = transform as RectTransform;
        if (rt != null)
        {
            LuxuryHop.OrSoonHonestPondGourdMystique?.Invoke(rt.TransformPoint(rt.rect.center), safeCategory);
            return;
        }

        LuxuryHop.OrSoonHonestPondGourdMystique?.Invoke(transform.position, safeCategory);
    }

    /// <summary>Boss 非致命用 bossNonLethalHitAnimName（若配置），否则与普通鱼一致用 hitAnimName。</summary>
    string ReplaceFewHaltEyeBalanceFew(bool lethal)
    {
        if (BeGazeSoon && !lethal && !string.IsNullOrEmpty(JeanRutHonestFewHaltCoin))
            return JeanRutHonestFewHaltCoin;
        return DonHaltCoin;
    }

    bool HeFewReadjustHaltCoin(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;
        if (!string.IsNullOrEmpty(DonHaltCoin) && name == DonHaltCoin)
            return true;
        if (BeGazeSoon && !string.IsNullOrEmpty(JeanRutHonestFewHaltCoin) && name == JeanRutHonestFewHaltCoin)
            return true;
        return false;
    }

    private bool FlavinItsIssueFew(Collider2D hitCollider)
    {
        if (HeBenignLuxuryExpertSoon())
        {
            return false;
        }

        if (!BeGazeSoon) return true;
        
        // 引导前封锁态：Boss 到中心点触发引导前，一律不可击杀。
        if (m_FlavinDecoGazeLieuTrackBeTight)
        {
            return false;
        }

        // 仅弱点可死：Boss 未配置弱点时不可死亡。
        if (JeanLieuDevotion == null) return false;

        // 未提供命中碰撞器（兼容旧调用）：Boss 不可被击杀。
        if (hitCollider == null) return false;

        // 严格模式：仅命中指定弱点碰撞器才死亡。
        return hitCollider == JeanLieuDevotion;
    }

    private bool HeBenignLuxuryExpertSoon()
    {
        // 后端约定：Ferver 单鱼靶鱼使用 type=y,id=2。
        return string.Equals(m_SoonToll, "y", StringComparison.OrdinalIgnoreCase)
               && string.Equals(m_SoonWe, "2", StringComparison.OrdinalIgnoreCase);
    }

    private void BerlinBenignLuxuryExpertFew()
    {
        // 靶鱼每次命中都爆钱，不进入“致命击杀一次性结算”。
        LuxuryHop.OrSoonTieExact?.Invoke(this.transform, Mathf.Max(0, m_Temple));
        // 复用“击杀爆粒子”总线：Ferver 单鱼每次受击也发一次位置信号。
        // 粒子样式由 SoonStintExactBrookOnCook 按 UIFishCategory（Ferver）映射。
        AbsentHonestPondGourdMystiqueEyeOn(m_SoonUpheaval);

        // 保持可重复命中：不要禁用碰撞器，也不要设置致命状态。
        m_FlavinItsOrFewVariable = false;
        m_PlumPeatIssueHonestFew = false;
        DueSumptuousPlaster(true);

        // fever鱼被打缩放动画
        PredatoryDependably.SpectacleScaleani(this.transform);
        // 命中时重复播放受伤动画，形成连续挨打反馈。
        string ferverHitAnimName = LawCodifyBenignLuxuryFewHaltCoin();
        if (m_PossibleDiamond != null && m_PossibleDiamond.AnimationState != null && m_PossibleDiamond.Skeleton != null && !string.IsNullOrEmpty(ferverHitAnimName))
        {
            StainJar.LawLaurasia().FoodKingdom(Lofelt.NiceVibrations.HapticPatterns.PresetType.MediumImpact);
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.feverhit);
            KeaDueHangHaltNoChance(ferverHitAnimName, false, DonHaltLineTrunk);
            TendStand.Instance.m_UIAural.HordeBenignAural();
            m_HeFewDevelop = true;
            return;
        }

        m_HeFewDevelop = false;
        FoodBerg();
    }

    private string LawCodifyBenignLuxuryFewHaltCoin()
    {
        string a = string.IsNullOrWhiteSpace(SpinalSingleFewHaltCoinA) ? string.Empty : SpinalSingleFewHaltCoinA.Trim();
        string b = string.IsNullOrWhiteSpace(SpinalLuxuryFewHaltCoinB) ? string.Empty : SpinalLuxuryFewHaltCoinB.Trim();

        if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
        {
            // 两个都配置时 50/50 随机。
            return Random.value < 0.5f ? a : b;
        }
        if (!string.IsNullOrEmpty(a)) return a;
        if (!string.IsNullOrEmpty(b)) return b;
        return DonHaltCoin;
    }

    private void DueSumptuousPlaster(bool enabled)
    {
        if (m_PinSumptuous2D != null && m_PinSumptuous2D.Length > 0)
        {
            for (int i = 0; i < m_PinSumptuous2D.Length; i++)
            {
                if (m_PinSumptuous2D[i] != null) m_PinSumptuous2D[i].enabled = enabled;
            }
            return;
        }

        if (m_Devotion2D != null)
        {
            m_Devotion2D.enabled = enabled;
        }
    }

    private void DueSumptuousPlasterStarve(bool exceptEnabled, bool othersEnabled, Collider2D exceptCollider)
    {
        // 以 bossWeakCollider 为保留项：其余全部启用/禁用。
        if (m_PinSumptuous2D != null && m_PinSumptuous2D.Length > 0)
        {
            for (int i = 0; i < m_PinSumptuous2D.Length; i++)
            {
                Collider2D c = m_PinSumptuous2D[i];
                if (c == null) continue;
                if (exceptCollider != null && c == exceptCollider)
                {
                    c.enabled = exceptEnabled;
                }
                else
                {
                    c.enabled = othersEnabled;
                }
            }
            return;
        }

        if (m_Devotion2D != null)
        {
            // 如果只有一个 collider，那么除非它恰好是 exceptCollider，否则就按 enabled=false 处理。
            if (exceptCollider != null && m_Devotion2D == exceptCollider)
            {
                m_Devotion2D.enabled = exceptEnabled;
            }
            else
            {
                m_Devotion2D.enabled = othersEnabled;
            }
        }
    }

    /// <summary>
    /// 应用“等级配置”到鱼实例：皮肤+数值
    /// </summary>
    public void HalveMagmaMint(UIFishLevelSpawnSpec spec)
    {
        if (spec == null) return;

        m_Magma = Mathf.Max(1, spec.Spiky);
        m_HP = Mathf.Max(1, spec.An);
        m_Temple = Mathf.Max(0, spec.Remain);
        m_FallacyTemple = Mathf.Max(0, spec.OutdoorTemple);
        FlipperFleshColeBode();

        HalveEnvy(spec.HeroCoin);
    }

    /// <summary>
    /// 应用后端 fish_config 的基础数据。
    /// </summary>
    public void HalveHamperSoonTedium(string fishId, string fishType, int unlockLevel, int sellPrice, int diamondReward = 0)
    {
        m_SoonWe = fishId ?? string.Empty;
        m_SoonToll = fishType ?? string.Empty;
        if (RopeMintStrange.LawLaurasia() != null)
        {
            m_SoonUpheaval = RopeMintStrange.LawLaurasia().ReplaceSoonUpheaval(m_SoonToll);
        }
        m_Magma = Mathf.Max(1, unlockLevel);
        m_HP = 1;
        m_Temple = Mathf.Max(0, sellPrice);
        m_FallacyTemple = Mathf.Max(0, diamondReward);
        FlipperFleshColeBode();
    }

    public void HalveSoonUpheaval(UIFishCategory fishCategory)
    {
        m_SoonUpheaval = fishCategory;
    }

    private void FlipperFleshColeBode()
    {
        if (PearlColeBode == null) return;
        bool showDebug = RopeStrange.Instance != null && RopeStrange.Instance.BeatSoonFleshColeGlide;
        if (PearlColeBode.gameObject.activeSelf != showDebug)
        {
            PearlColeBode.gameObject.SetActive(showDebug);
        }
        PearlColeBode.text = "lv" + m_Magma + "+" + m_SoonToll + "+" + m_SoonWe;
    }

    public void HalveEnvy(string skinName)
    {
        if (string.IsNullOrEmpty(skinName)) return;
        if (m_PossibleDiamond == null) m_PossibleDiamond = GetComponentInChildren<SkeletonGraphic>();
        if (m_PossibleDiamond == null || m_PossibleDiamond.Skeleton == null) return;

        Skeleton skeleton = m_PossibleDiamond.Skeleton;
        if (skeleton.Data == null) return;

        Skin skin = skeleton.Data.FindSkin(skinName);
        if (skin == null)
        {
            Debug.LogWarning($"UISoonMandan: 未找到皮肤 {skinName}");
            return;
        }

        skeleton.SetSkin(skin);
        skeleton.SetSlotsToSetupPose();
        m_PossibleDiamond.AnimationState?.Apply(skeleton);
        m_PossibleDiamond.Update(0f);
    }

    /// <summary>
    /// 返回 true 表示已游出边界，可回收
    /// </summary>
    public bool Lawn(float dt, float speedMultiplier, float leftBound, float rightBound, float recycleBuffer)
    {
        if (!m_Accept || m_Fear == null) return false;
        if (m_PlumPeatIssueHonestFew)
        {
            m_NobleHeedYVoyage = 0f;
            HalveNobleTiltPedagogy(0f);
            return false;
        }

        // 更新 idle 变速状态（变速同时用于游动速度与 idle 的 Spine TimeScale，同步但不冻结）。
        AthensBergModalPullman(dt);

        float sp = m_SeedModal * Mathf.Max(0f, speedMultiplier) * Mathf.Max(0f, IconHaltModalHenceforth) * dt;
        Vector2 pos = m_Fear.anchoredPosition;
        float prevX = pos.x;

        // 转头/转弧线：pitchDeg=0 水平；pitchDeg=正则上弯（y 变大），pitchDeg=负则下弯（y 变小）。
        // 由于你用 prefabFacing 已保证 Spine 鱼头方向统一（即“正仰/负仰”的视觉含义不随左右镜像翻转），
        // 所以这里不再额外乘 m_MoveDir；pitch 的正负完全由配置决定。
        float pitchDeg = DiffusesNobleBardSnailSex(dt);
        float pitchRad = pitchDeg * Mathf.Deg2Rad;

        pos.x += m_PeatDir * Mathf.Cos(pitchRad) * sp;
        m_NobleHeedYVoyage += Mathf.Sin(pitchRad) * sp; // 不要清零：回正后 y 仍停留在“新 y”
        // 视觉倾角与弧线计算使用同一套 pitchDeg 符号口径，避免因符号翻转导致“看起来抬头却往相反方向游”。
        HalveNobleTiltPedagogy(pitchDeg);

        pos.y = m_SeedY + m_NobleHeedYVoyage;
        m_Fear.anchoredPosition = pos;
        KeaAbsentGazeGlobeEightyTight(prevX, pos.x);

        if (m_PeatDir > 0)
        {
            return pos.x > rightBound + recycleBuffer;
        }

        return pos.x < leftBound - recycleBuffer;
    }

    private void KeaAbsentGazeGlobeEightyTight(float prevX, float currX)
    {
        if (!BeGazeSoon || m_GazeGlobeEightyTightSpot)
        {
            return;
        }

        // Boss 从左右入场时，分别在 x=-600 / x=600 触发引导。
        float guideTriggerX = m_PeatDir > 0 ? -600f : 600f;
        bool crossGuidePoint = (prevX <= guideTriggerX && currX >= guideTriggerX) || (prevX >= guideTriggerX && currX <= guideTriggerX);
        if (!crossGuidePoint)
        {
            return;
        }
        this.transform.SetAsLastSibling();
        if (m_FlavinDecoGazeLieuTrackBeTight)
        {
            if (m_FilePossibleDiamond != null)
            {
                m_FilePossibleDiamond.gameObject.SetActive(true);
            }
            if (JeanLieuDevotion != null)
            {
                JeanLieuDevotion.enabled = true;
            }
            m_FlavinDecoGazeLieuTrackBeTight = false;
        }
        AiryMintStrange.SetBool(CTedium.Dy_Niche_Jean_Poorly_Slot, true);
        m_GazeGlobeEightyTightSpot = true;
        Transform mainTf = m_PossibleDiamond != null ? m_PossibleDiamond.transform : transform;
        Transform miaoTf = m_FilePossibleDiamond != null ? m_FilePossibleDiamond.transform : null;
        LuxuryHop.OrGazeSoonGlobeEightyTightCluster?.Invoke(mainTf, miaoTf);
    }

    /// <summary>
    /// 不重置 HP/动画状态，仅把鱼重定位到边界外并反向继续游，用于 Boss 出界折返。
    /// </summary>
    public void StiffenCallPurchase(int moveDir, float baseY, Vector2 anchoredPos)
    {
        if (m_Fear == null) m_Fear = GetComponent<RectTransform>();
        if (m_Fear == null) return;

        m_PeatDir = moveDir >= 0 ? 1 : -1;
        m_SeedY = baseY;
        m_NobleHeedYVoyage = 0f;
        m_Fear.anchoredPosition = anchoredPos;
        HalveNobleTiltPedagogy(0f);
    }
}
