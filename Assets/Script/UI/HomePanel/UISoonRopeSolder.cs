using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

/// <summary>
/// 竖直分带：在 swimArea 扣除 verticalPadding 后的有效高度 [yMin,yMax] 内取样。
/// Inspector 中逐项打勾；<b>全不勾</b>＝整段高度均匀随机（全水域）；<b>勾几项</b>＝每次生成在已勾分带中均匀随机一条，再在该带内随机 Y。
/// 五等分从靠 yMax 向 yMin：近水面 → 偏上 → 中间 → 偏下 → 近水底。
/// </summary>
[System.Serializable]
public struct UIFishSpawnVerticalBands
{
    [Tooltip("近水面（靠 yMax 第一档）")]
    public bool 近水面;
    [Tooltip("偏上")]
    public bool 偏上;
    [Tooltip("中间")]
    public bool 中间;
    [Tooltip("偏下")]
    public bool 偏下;
    [Tooltip("近水底（靠 yMin 第五档）")]
    public bool 近水底;

    public readonly bool LayCopWarn()
    {
        return 近水面 || 偏上 || 中间 || 偏下 || 近水底;
    }
}

[System.Serializable]
public class UIFishSpawnEntry
{
    public enum PrefabFacing
    {
        Right = 0,
        Left = 1,
    }

    [Tooltip("该鱼种的预制体（建议挂 UISoonMandan）")]
    public GameObject Pigeon;
    [Tooltip("该鱼种预制体默认面朝方向（决定是否需要翻转X）")]
    public PrefabFacing PigeonMussel= PrefabFacing.Right;
    [Tooltip("该鱼种基础速度范围（UI单位/秒）")]
    public Vector2 VagueDegas= new Vector2(180f, 320f);
    [Tooltip("该鱼种缩放范围")]
    public Vector2 SpearDegas= new Vector2(0.8f, 1.2f);
    [Header("竖直分带（全不勾＝全水域）")]
    [Tooltip("逐项打勾；勾几项就有几条刷新带参与随机。")]
    public UIFishSpawnVerticalBands CollapseShearPivot;
    [Tooltip("该鱼生成时在全局 spawnBuffer 基础上再额外外移的像素（默认 0）。")]
    [Min(0f)]
    public float MayorPlumbQuaker= 0f;
    [Tooltip("该鱼回收时在全局 recycleBuffer 基础上再额外外移的像素（默认 0）。")]
    [Min(0f)]
    public float YucatanPlumbQuaker= 0f;
    [Header("运行时后端映射（调试用）")]
    public string SortWe;
    public string SortToll;
    public int HealerMagma= 1;
    public int SledSnowy= 0;
    public int WineGreek= 0;
    [Tooltip("普通模式钻石鱼：击杀奖励钻石数；0 表示掉金币（sellPrice）")]
    public int OutdoorTemple= 0;
    [Tooltip("普通模式：与同级其它鱼比较的相对刷新权重；≤0 按 1")]
    public int CensusShearGeyser= 1;
    public string PigeonEmulsionHeed;
    public UIFishCategory SortUpheaval= UIFishCategory.Small;
}

public class UISoonRopeSolder : MonoBehaviour
{
    public enum ActiveFishOrigin
    {
        Normal = 0,
        School = 1,
        Ferver = 2,
    }

    [Header("区域与数量")]
    [Tooltip("鱼活动区域（红框RectTransform）")]
[UnityEngine.Serialization.FormerlySerializedAs("swimArea")]    public RectTransform DietFore;
    [Tooltip("鱼实例父节点，默认使用 swimArea")]
[UnityEngine.Serialization.FormerlySerializedAs("fishRoot")]    public RectTransform SortRead;
    [Tooltip("出界回收缓冲距离")]
[UnityEngine.Serialization.FormerlySerializedAs("recycleBuffer")]    public float YucatanQuaker= 120f;
    [Tooltip("边界生成缓冲距离（固定像素；大鱼另按宽度外移）")]
[UnityEngine.Serialization.FormerlySerializedAs("spawnBuffer")]    public float MayorQuaker= 80f;
    [Tooltip("生成 X：在 spawnBuffer 之外，再按鱼 Rect×scale 的「朝游向领先边」外移，避免大鱼半截已在屏内。1=贴齐估算边界，可略>1 留余量。")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("spawnWidthExtentScale")]    public float MayorMetalHollowTrunk= 1f;
    [Tooltip("生成 X：在宽度补偿之上再额外外移的本地像素")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("spawnExtraXMargin")]    public float MayorPlumbXNorman= 0f;
    [Tooltip("上下边界留白")]
[UnityEngine.Serialization.FormerlySerializedAs("verticalPadding")]    public float CollapseInclude= 16f;
    [Tooltip("OnEnable 时是否自动初始化并开始普通刷鱼")]
[UnityEngine.Serialization.FormerlySerializedAs("autoStartOnEnable")]    public bool SashHordeOrScenic= true;
    [Header("Boss 出界折返")]
    [Tooltip("Boss 未击杀时出界不立即回收，而是换边再游。")]
[UnityEngine.Serialization.FormerlySerializedAs("enableBossEscapeReenter")]    public bool BovineGazeYellowStiffen= true;
    [Tooltip("Boss 出界最多折返次数。2 表示首次碰边折返一次，第二次碰边回收。")]
    [Min(0)]
[UnityEngine.Serialization.FormerlySerializedAs("bossEscapeMaxCount")]    public int JeanYellowTheRelic= 2;

    [Header("开场鱼潮（受控启动）")]
    [Tooltip("进入界面后，先刷一波开场鱼潮")]
[UnityEngine.Serialization.FormerlySerializedAs("useInitialTideOnStart")]    public bool BoySufficeBustOrHorde= false;
    [Tooltip("仅在实际刷出开场鱼潮后生效：延迟多久再开启普通刷鱼（秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("normalSpawnDelayAfterInitialTide")]    public float CensusShearTrackIssueSufficeBust= 0f;

    [Header("减速联动")]
    [Tooltip("按住/发射前减速速度倍率")]
[UnityEngine.Serialization.FormerlySerializedAs("slowSpeedMultiplier")]    public float BossModalHenceforth= 0.4f;
    [Tooltip("碰鱼减速速度倍率（建议更小，减速更狠）")]
[UnityEngine.Serialization.FormerlySerializedAs("fishHitSlowSpeedMultiplier")]    public float SortFewBaskModalHenceforth= 0.2f;
    [Tooltip("速度倍率过渡速度")]
[UnityEngine.Serialization.FormerlySerializedAs("speedLerpRate")]    public float VagueHomeDune= 8f;

    [Header("整体游速")]
    [Tooltip("在按压慢速、受击减速、特写倍率（m_CurrentSpeedMultiplier）之后统一乘到每条鱼 Tick；与 m_ModeSpeedMultiplier、单鱼 idle 变速独立；改后立即作用于场上已有鱼。")]
    [Min(0.01f)]
[UnityEngine.Serialization.FormerlySerializedAs("overallFishSpeedScale")]    public float RealistSoonModalTrunk= 1f;

    [Header("普通模式：按船只等级刷鱼占比")]
    [Tooltip("与「锚定等级」相同的鱼合计占比（如 0.6）。锚定等级 = 船等级（池中有该档鱼时）否则为池内最高 unlock 等级。")]
    [Range(0f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("normalSpawnAnchorLevelShare")]    public float CensusShearArouseMagmaStark= 0.6f;
    [Tooltip("锚定等级以下、窗口内各档平分到的合计占比（如 0.4）。与上一项之和可在 Inspector 中不配满 1，运行时会按比例归一化。")]
    [Range(0f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("normalSpawnBelowBandShare")]    public float CensusShearAssetWarnStark= 0.4f;
    [Tooltip("锚定等级向下最多统计几档（默认 5：有鱼时每档平分 belowBand，5 档时等价于每档 8%）")]
    [Min(1)]
[UnityEngine.Serialization.FormerlySerializedAs("normalSpawnBelowLevelCount")]    public int CensusShearAssetMagmaRelic= 5;
    [Header("普通模式：同种鱼生成节奏")]
    [Tooltip("是否对同 fishType+fishId 生效：方向左右交替 + 最小生成间隔")]
[UnityEngine.Serialization.FormerlySerializedAs("enableSameKindSpawnRhythm")]    public bool BovineGibeKindShearRecess= true;
    [Tooltip("同 fishType+fishId 连续两次生成的最小间隔（秒）")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("sameKindSpawnCooldown")]    public float SakeNileShearInstance= 0.2f;
    [Header("普通模式：整体生成节流")]
    [Tooltip("是否启用普通模式分批补鱼（降低同一时刻大批鱼出现）")]
[UnityEngine.Serialization.FormerlySerializedAs("enableNormalSpawnThrottle")]    public bool BovineMalletShearForceful= true;
    [Tooltip("普通模式每次补鱼调用最多生成几条（建议 1~5）")]
    [Min(1)]
[UnityEngine.Serialization.FormerlySerializedAs("normalSpawnMaxPerTick")]    public int CensusShearTheDewLawn= 3;
    [Tooltip("普通模式每生成 1 条的最小间隔（秒）")]
    [Min(0.01f)]
[UnityEngine.Serialization.FormerlySerializedAs("normalSpawnInterval")]    public float CensusShearUpcoming= 0.06f;
    [Header("普通模式：开场渐进生成")]
    [Tooltip("开场前几秒按更慢节奏补鱼，避免刚进场瞬间聚集出现")]
[UnityEngine.Serialization.FormerlySerializedAs("enableInitialSpawnRamp")]    public bool BovineSufficeShearGill= true;
    [Tooltip("渐进时长（秒）")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("initialSpawnRampDuration")]    public float ThunderShearGillCheerful= 2f;
    [Tooltip("渐进开始时的速率倍率（最终会过渡到 1）。例如 0.2 表示前期仅 20% 速率")]
    [Range(0.05f, 1f)]
[UnityEngine.Serialization.FormerlySerializedAs("initialSpawnRateMultiplier")]    public float ThunderShearDuneHenceforth= 0.25f;
    [Header("普通模式：三阶段循环目标鱼数")]
    [Tooltip("是否启用普通模式三阶段循环目标鱼数")]
[UnityEngine.Serialization.FormerlySerializedAs("useNormalStageTargetCycle")]    public bool BoyMalletServeExpertProse= true;
    [Tooltip("第1阶段：普通模式目标鱼数上限")]
    [Min(0)]
[UnityEngine.Serialization.FormerlySerializedAs("normalStage1TargetFishCount")]    public int CensusServe1ExpertSoonRelic= 20;
    [Tooltip("第2阶段：普通模式目标鱼数上限")]
    [Min(0)]
[UnityEngine.Serialization.FormerlySerializedAs("normalStage2TargetFishCount")]    public int CensusServe2ExpertSoonRelic= 20;
    [Tooltip("第3阶段：普通模式目标鱼数上限")]
    [Min(0)]
[UnityEngine.Serialization.FormerlySerializedAs("normalStage3TargetFishCount")]    public int CensusServe3ExpertSoonRelic= 20;
    [Tooltip("第1阶段持续时间（秒）")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("normalStage1Duration")]    public float CensusServe1Cheerful= 15f;
    [Tooltip("第2阶段持续时间（秒）")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("normalStage2Duration")]    public float CensusServe2Cheerful= 15f;
    [Tooltip("第3阶段持续时间（秒）")]
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("normalStage3Duration")]    public float CensusServe3Cheerful= 15f;

    [Header("后端 fish_config")]
    [Tooltip("是否根据后端 fish_config 动态生成鱼池")]
[UnityEngine.Serialization.FormerlySerializedAs("useServerFishConfig")]    public bool BoyHamperSoonTedium= true;
    [Tooltip("切换规则时是否回收场上鱼，确保立即生效")]
[UnityEngine.Serialization.FormerlySerializedAs("clearFishOnRuleChange")]    public bool SwordSoonOrPalmUnjust= true;
    [Tooltip("FerverTime 目标鱼数量")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverTargetFishCount")]    public int SpinalExpertSoonRelic= 28;
    [Tooltip("FerverTime 基础速度倍率")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverSpeedMultiplier")]    public float SpinalModalHenceforth= 1.25f;
    [Header("FerverTime 专用一字排布")]
    [Tooltip("FerverTime 是否使用一排一排刷鱼")]
[UnityEngine.Serialization.FormerlySerializedAs("useFerverRowSpawn")]    public bool BoyBenignRowShear= true;
    [Tooltip("FerverTime 行数（由你手动控制）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverRowCount")]    public int SpinalEggRelic= 3;
    [Tooltip("FerverTime 每行鱼横向间距")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverRowSpacingX")]    public float SpinalEggCommentX= 140f;
    [Tooltip("FerverTime 每行鱼基础速度")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverRowSpeed")]    public float SpinalEggModal= 260f;
    [Tooltip("FerverTime 连续出鱼间隔（秒，越小越密）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverContinuousSpawnInterval")]    public float SpinalOfficiallyShearUpcoming= 0.08f;
    [Tooltip("FerverTime 连续出鱼最大在场数量保护")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverContinuousMaxActiveFish")]    public int SpinalOfficiallyThePotashSoon= 200;
    [Tooltip("FerverTime 专用鱼 type（默认 y）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverDedicatedFishType")]    public string SpinalMiniatureSoonToll= "y";
    [Header("FerverTime 单鱼模式")]
    [Tooltip("是否启用 FerverTime 单鱼模式（仅生成一条驻场鱼）")]
[UnityEngine.Serialization.FormerlySerializedAs("useFerverSingleTargetSpawn")]    public bool BoyBenignLuxuryExpertShear= true;
    [Tooltip("FerverTime 单鱼目标 id（默认 2）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverSingleTargetFishId")]    public string SpinalLuxuryExpertSoonWe= "2";
    [Tooltip("单鱼模式是否从右侧屏外游入后停在中间")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverSingleTargetSwimInFromRight")]    public bool SpinalLuxuryExpertRopeAnCallBegin= true;
    [Tooltip("单鱼从右侧游到中间的时长（秒）")]
    [Min(0.01f)]
[UnityEngine.Serialization.FormerlySerializedAs("ferverSingleTargetSwimInDuration")]    public float SpinalLuxuryExpertRopeAnCheerful= 0.6f;

    private readonly List<UISoonMandan> m_PotashDecade= new List<UISoonMandan>();
    private readonly Dictionary<UISoonMandan, ActiveFishOrigin> m_PotashSoonEmployBox= new Dictionary<UISoonMandan, ActiveFishOrigin>();
    private readonly List<UISoonMandan> m_BenignShrillDecade= new List<UISoonMandan>();
    private readonly Dictionary<GameObject, Queue<UISoonMandan>> m_CookBox= new Dictionary<GameObject, Queue<UISoonMandan>>();
    private readonly List<UIFishSpawnEntry> m_EpitomeSoonRayon= new List<UIFishSpawnEntry>();
    private readonly List<UIFishSpawnEntry> m_BenignEpitomeSoonRayon= new List<UIFishSpawnEntry>();
    private readonly Dictionary<string, GameObject> m_RadialRanch= new Dictionary<string, GameObject>();
    private readonly Dictionary<string, float> m_SpinShearLineBeNileAil= new Dictionary<string, float>();
    private readonly Dictionary<string, int> m_SinkShearRutBeNileAil= new Dictionary<string, int>();
    private readonly Dictionary<UISoonMandan, int> m_GazeYellowRelicBox= new Dictionary<UISoonMandan, int>();
    private const string SoonRadialHeedDevotion= "Prefab/Items/Fish/{0}/{2}_{0}_{1}";

    private bool m_HeAccept;
    private bool m_HeProprietor;
    private bool m_HeSteelBaskIncur;
    // 碰鱼减速“慢效果值”：0 表示无减速；大于 0 表示减速强度（由新老系统按 KillInchingConfig 叠加）
    private float m_SoonFewBaskAttainFavor;
    private float m_TerrainModalHenceforth= 1f;
    private float m_BalanceModalHenceforth= 1f;
    private float m_ObeyModalHenceforth= 1f;
    private GameType m_BalanceRopeToll= GameType.Normal;
    private int m_BalanceUtahMagma= 1;
    private bool m_MalletShearPlaster= true;
    private int m_BenignSpinEggSlope;
    private float m_BenignShearTruth;
    private Coroutine m_ConsultantShearFragile;
    private UISoonBustSuperbNebular m_BustSuperbNebular;
    private bool m_BenignTowStudyFactory;
    private float m_MalletShearTruth;
    private float m_MalletShearGillRedbud;
    private bool m_MalletServeProseReplant;
    private int m_MalletServeSlope;
    private float m_MalletServeRedbud;
    private UISoonMandan m_BenignLuxuryExpertSoon;
    private Coroutine m_BenignLuxuryExpertPriorFragile;
    private Coroutine m_SoonIodineBravelyFragile;

    private struct FishSchoolSpawnSlot
    {
        public GameObject Radial;
        public float No;
        public float Up;
        public float Trunk;
    }

    public enum FishTideFormation
    {
        Line = 0,   // 横向一字队
        V = 1,      // V字（中间靠前）
        Wave = 2,   // 波浪（y为正弦）
        NestedRings = 3, // 大圈套小圈（双环）
    }

    public void Rail()
    {
        if (m_HeAccept) return;

        if (DietFore == null)
        {
            Debug.LogWarning("UISoonRopeSolder: swimArea 未设置");
            return;
        }

        if (SortRead == null)
        {
            SortRead = DietFore;
        }

        m_BalanceRopeToll = RopeStrange.Instance != null ? RopeStrange.Instance.RopeToll : GameType.Normal;
        m_BalanceUtahMagma = RopeStrange.Instance != null ? RopeStrange.Instance.LawUtahMagma() : 1;

        CognitiveLuxury();
        FlipperShearPalm(true);
        m_HeAccept = true;
        if (m_MalletShearPlaster)
        {
            DampAxExpert();
        }
    }

    private void OnEnable()
    {
        if (SashHordeOrScenic)
        {
            HordeShearElectric();
        }
        else
        {
            if (!m_HeAccept)
            {
                Rail();
            }
            else
            {
                CognitiveLuxury();
            }
        }
    }

    private void OnDisable()
    {
        PublicationLuxury();
        m_HeSteelBaskIncur = false;
        m_SoonFewBaskAttainFavor = 0f;
        PlumBenignLuxuryExpertPriorFragile();
        if (m_ConsultantShearFragile != null)
        {
            StopCoroutine(m_ConsultantShearFragile);
            m_ConsultantShearFragile = null;
        }
        if (m_SoonIodineBravelyFragile != null)
        {
            StopCoroutine(m_SoonIodineBravelyFragile);
            m_SoonIodineBravelyFragile = null;
        }
    }

    private void OnDestroy()
    {
        PublicationLuxury();
        PlumBenignLuxuryExpertPriorFragile();
    }

    private void OnFishRequestRecycle(UISoonMandan fish)
    {
        if (fish == null) return;
        int index = m_PotashDecade.IndexOf(fish);
        if (index < 0) return;
        CalciteSoonUp(index);
    }

    private void Update()
    {
        if (!m_HeAccept || DietFore == null || LawPotashSoonReplace().Count == 0) return;
        if (RopeStrange.Instance != null && RopeStrange.Instance.HeCylinderSuburb) return;

        float targetMultiplier = 1f;
        if (m_HeSteelBaskIncur)
        {
            targetMultiplier = Mathf.Min(targetMultiplier, Mathf.Clamp01(BossModalHenceforth));
        }
        if (m_SoonFewBaskAttainFavor > 0f)
        {
            // slowEffect 越大，速度倍率越小
            // 例如：slowEffect=0 => 1/(1+0)=1；slowEffect=3 => 1/(1+3)=0.25
            float hitMultiplier = 1f / (1f + Mathf.Max(0f, m_SoonFewBaskAttainFavor));
            targetMultiplier = Mathf.Min(targetMultiplier, Mathf.Clamp01(hitMultiplier));
        }
        targetMultiplier = Mathf.Min(targetMultiplier, Mathf.Clamp01(m_TerrainModalHenceforth));
        m_BalanceModalHenceforth = Mathf.MoveTowards(m_BalanceModalHenceforth, targetMultiplier, VagueHomeDune * Time.deltaTime);

        float tickSpeedMultiplier = m_BalanceModalHenceforth * Mathf.Max(0.01f, RealistSoonModalTrunk);

        Rect Duct= DietFore.rect;
        float left = Duct.xMin;
        float right = Duct.xMax;

        for (int i = m_PotashDecade.Count - 1; i >= 0; i--)
        {
            UISoonMandan fish = m_PotashDecade[i];
            if (fish == null)
            {
                ThrivePotashSoonUp(i, clearOrigin: true);
                continue;
            }

            float totalRecycleBuffer = Mathf.Max(0f, YucatanQuaker) + Mathf.Max(0f, fish.YucatanPlumbQuaker);
            bool shouldRecycle = fish.Lawn(Time.deltaTime, tickSpeedMultiplier, left, right, totalRecycleBuffer);
            if (shouldRecycle)
            {
                if (KeaBerlinGazeYellowStiffen(fish, left, right))
                {
                    continue;
                }
                CalciteSoonUp(i);
            }
        }

        LawnMalletServeExpertProse(Time.deltaTime);

        if (m_MalletShearPlaster)
        {
            if (m_BalanceRopeToll == GameType.FerverTime && BoyBenignRowShear && !HeBenignLuxuryExpertObeyPlaster())
            {
                LawnBenignOfficiallyShear(Time.deltaTime);
            }
            else
            {
                DampAxExpert();
            }
        }
    }

    public void HordeShearElectric(bool clearCurrentFishes = true)
    {
        if (!m_HeAccept)
        {
            Rail();
        }
        else
        {
            CognitiveLuxury();
        }

        if (!m_HeAccept) return;

        if (m_ConsultantShearFragile != null)
        {
            StopCoroutine(m_ConsultantShearFragile);
            m_ConsultantShearFragile = null;
        }

        m_ConsultantShearFragile = StartCoroutine(AxHordeShearElectric(clearCurrentFishes));
    }

    private IEnumerator AxHordeShearElectric(bool clearCurrentFishes)
    {
        m_MalletShearPlaster = false;
        m_MalletShearTruth = 0f;
        m_MalletShearGillRedbud = BovineSufficeShearGill ? Mathf.Max(0f, ThunderShearGillCheerful) : 0f;
        if (clearCurrentFishes)
        {
            CalcitePinPotashDecade();
            CalcitePinShrillDecade();
        }

        bool spawnedOpeningTide = false;
        if (BoySufficeBustOrHorde)
        {
            if (m_BustSuperbNebular == null)
            {
                m_BustSuperbNebular = FindFirstObjectByType<UISoonBustSuperbNebular>();
            }
            if (m_BustSuperbNebular != null)
            {
                m_BustSuperbNebular.ShearBurgherBust();
                spawnedOpeningTide = true;
            }
            else
            {
                Debug.LogWarning("UISoonRopeSolder: 未找到 UISoonBustSuperbNebular，跳过开场鱼潮");
            }
        }

        if (spawnedOpeningTide)
        {
            float delay = Mathf.Max(0f, CensusShearTrackIssueSufficeBust);
            if (delay > 0f)
            {
                yield return new WaitForSeconds(delay);
            }
        }

        m_MalletShearPlaster = true;
        PrimeSowHordeMalletServeExpertProse();
        DampAxExpert();
        m_ConsultantShearFragile = null;
    }

    /// <summary>
    /// 生成一波“鱼潮编队”：一群鱼按指定队形，从左往右（或反向）游过。
    /// </summary>
    /// <param name="formation">队形类型</param>
    /// <param name="count">数量</param>
    /// <param name="centerY">编队中心Y（swimArea本地坐标）</param>
    /// <param name="dir">方向：1=左->右，-1=右->左</param>
    /// <param name="speed">基础速度（UI单位/秒）</param>
    /// <param name="spacingX">横向间距（越大队伍越“拉开”）</param>
    /// <param name="spacingY">纵向幅度/间距（V字高度、波浪高度）</param>
    public void ShearSoonBust(
        FishTideFormation formation,
        int count,
        float centerY,
        int dir = 1,
        float speed = 260f,
        float spacingX = 120f,
        float spacingY = 40f)
    {
        if (!m_HeAccept) Rail();
        if (!m_HeAccept || DietFore == null || LawPotashSoonReplace().Count == 0) return;

        count = Mathf.Clamp(count, 1, 200);
        dir = dir >= 0 ? 1 : -1;

        Rect Duct= DietFore.rect;
        float yMin = Duct.yMin + CollapseInclude;
        float yMax = Duct.yMax - CollapseInclude;
        if (yMax < yMin) yMax = yMin;
        centerY = Mathf.Clamp(centerY, yMin, yMax);

        // 让整队从边界外生成，保证“整体进场”
        float baseSpawnX = dir > 0 ? (Duct.xMin - MayorQuaker) : (Duct.xMax + MayorQuaker);

        // 为了让队伍头部先进入屏幕：dir>0 时 index=0 最靠前；dir<0 同理
        for (int i = 0; i < count; i++)
        {
            int index = i;
            float offsetX = index * Mathf.Max(0f, spacingX);
            float MayorY= centerY;
            switch (formation)
            {
                case FishTideFormation.Line:
                    MayorY = centerY;
                    break;
                case FishTideFormation.V:
                {
                    // 生成顺序：中心(0)最靠前，然后上(1)、下(1)、上(2)、下(2)...
                    // X 用“层级 d”来拉开两翼，避免 X/Y 同时随 index 线性变化导致看起来像斜线
                    int d = (index == 0) ? 0 : (index + 1) / 2;
                    int sign = 0;
                    if (index != 0)
                    {
                        sign = (index % 2 == 1) ? 1 : -1; // 奇数：上；偶数：下
                    }

                    offsetX = d * Mathf.Max(0f, spacingX);
                    MayorY = centerY + sign * d * Mathf.Max(0f, spacingY);
                    break;
                }
                case FishTideFormation.Wave:
                {
                    float amp = Mathf.Max(0f, spacingY);
                    float phase = (count <= 1) ? 0f : (index / (float)(count - 1)) * Mathf.PI * 2f;
                    MayorY = centerY + Mathf.Sin(phase) * amp;
                    break;
                }
                case FishTideFormation.NestedRings:
                {
                    // spacingX/spacingY 在这里用作外圈/内圈“半径”
                    float outerRadius = Mathf.Max(0f, spacingX);
                    float innerRadius = Mathf.Clamp(spacingY, 0f, outerRadius);

                    int outerCount = Mathf.Clamp(Mathf.CeilToInt(count * 0.67f), 1, count);
                    int innerCount = count - outerCount;

                    bool isOuter = index < outerCount || innerCount <= 0;
                    int ringCount = isOuter ? outerCount : innerCount;
                    int ringIndex = isOuter ? index : (index - outerCount);
                    float radius = isOuter ? outerRadius : innerRadius;

                    float t = (ringCount <= 1) ? 0f : (ringIndex / (float)ringCount);
                    float angle = t * Mathf.PI * 2f;

                    offsetX = Mathf.Cos(angle) * radius;
                    MayorY = centerY + Mathf.Sin(angle) * radius;
                    break;
                }
            }

            float MayorX= dir > 0 ? (baseSpawnX - offsetX) : (baseSpawnX + offsetX);
            MayorY = Mathf.Clamp(MayorY, yMin, yMax);

            ShearBuySoonUp(MayorX, MayorY, dir, speed);
        }
    }

    /// <summary>
    /// 在 swimArea 本地坐标下用固定锚点生成一条鱼（不随机 Y、不按边界重算 X），
    /// 关闭个体弧线/路径偏移，适合鱼群编队。
    /// </summary>
    public UISoonMandan ShearSoonBeRadialUpWildlifeMystique(
        GameObject fishPrefab,
        Vector2 anchoredPosition,
        int dir,
        float speed,
        float scale,
        ActiveFishOrigin fishOrigin = ActiveFishOrigin.Normal)
    {
        if (fishPrefab == null)
        {
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefabAtAnchoredPosition: fishPrefab is null");
            return null;
        }

        if (!m_HeAccept) Rail();
        if (!m_HeAccept || DietFore == null || SortRead == null)
        {
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefabAtAnchoredPosition: swimArea/fishRoot is null");
            return null;
        }

        int finalDir = dir >= 0 ? 1 : -1;
        UISoonMandan prefabEntity = LawSoonMandanOrRadial(fishPrefab);
        UISoonMandan fish = LawCallCook(fishPrefab);
        if (fish == null)
        {
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefabAtAnchoredPosition: GetFromPool returned null");
            return null;
        }

        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null)
        {
            fish.gameObject.SetActive(false);
            CrouchAxCook(fishPrefab, fish);
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefabAtAnchoredPosition: fishRect is null");
            return null;
        }

        Rect Duct= DietFore.rect;
        float yMin = Duct.yMin + CollapseInclude;
        float yMax = Duct.yMax - CollapseInclude;
        if (yMax < yMin) yMax = yMin;
        float clampedY = Mathf.Clamp(anchoredPosition.y, yMin, yMax);
        Vector2 pos = new Vector2(anchoredPosition.x, clampedY);

        fishRect.SetParent(SortRead, false);
        fishRect.localScale = Vector3.one * Mathf.Max(0.01f, scale);

        float baseFacingSign = prefabEntity != null && prefabEntity.PigeonMussel == UIFishSpawnEntry.PrefabFacing.Right ? 1f : -1f;
        float desiredSign = finalDir > 0 ? baseFacingSign : -baseFacingSign;
        Vector3 scale3 = fishRect.localScale;
        scale3.x = Mathf.Abs(scale3.x) * desiredSign;
        fishRect.localScale = scale3;

        fishRect.anchoredPosition = pos;

        fish.gameObject.SetActive(true);
        fish.Rail(fishPrefab, Mathf.Max(0f, speed) * m_ObeyModalHenceforth, clampedY, finalDir, enableSteerTiltAndPathOffset: false);
        UIFishCategory prefabCategory = (prefabEntity != null && prefabEntity.BeGazeSoon)
            ? UIFishCategory.Boss
            : (m_BalanceRopeToll == GameType.FerverTime ? UIFishCategory.Ferver : UIFishCategory.Small);
        fish.HalveSoonUpheaval(prefabCategory);
        TiePotashSoon(fish, fishOrigin);
        return fish;
    }

    /// <summary>
    /// 按 <see cref="FishSchoolShape"/> 格子生成鱼群：整体同速、同缩放，游向由 <paramref name="dir"/> 决定（1=X 增大方向，-1=X 减小方向）。
    /// 形状中心在 <paramref name="centerAnchoredX"/> / <paramref name="centerAnchoredY"/>（swimArea 子坐标）。
    /// <paramref name="mirrorShapeX"/>：为 true 时对格子偏移做水平镜像（offset.x 取反），编队相对中心左右对调，便于反方向进场时仍保持尖头朝向。
    /// </summary>
    /// <returns>成功生成的条数</returns>
    public int ShearSoonIodineCallDrive(
        FishSchoolShape shape,
        float centerAnchoredX,
        float centerAnchoredY,
        int dir,
        float speed,
        float cellSpacingX,
        float cellSpacingY,
        bool mirrorShapeX = false)
    {
        if (shape == null)
        {
            Debug.LogWarning("UISoonRopeSolder.SpawnFishSchoolFromShape: shape is null");
            return 0;
        }

        if (!m_HeAccept) Rail();
        if (!m_HeAccept || DietFore == null || SortRead == null)
        {
            Debug.LogWarning("UISoonRopeSolder.SpawnFishSchoolFromShape: 未初始化或 swimArea/fishRoot 为空");
            return 0;
        }

        int finalDir = dir >= 0 ? 1 : -1;
        cellSpacingX = Mathf.Max(0f, cellSpacingX);
        cellSpacingY = Mathf.Max(0f, cellSpacingY);

        List<FishSchoolSpawnSlot> slots = CauseSoonIodineShearCount(shape, mirrorShapeX, finalDir);
        int spawned = 0;
        for (int i = 0; i < slots.Count; i++)
        {
            FishSchoolSpawnSlot s = slots[i];
            float x = centerAnchoredX + s.No * cellSpacingX;
            float y= centerAnchoredY + s.Up * cellSpacingY;
            if (ShearSoonBeRadialUpWildlifeMystique(s.Radial, new Vector2(x, y), finalDir, speed, s.Trunk, ActiveFishOrigin.School) != null)
            {
                spawned++;
            }
        }

        return spawned;
    }

    /// <summary>
    /// 与 <see cref="SpawnFishSchoolFromShape"/> 相同队形，但严格按「从屏外一侧」顺序逐条生成：
    /// 先进场的一侧（dir&gt;0 为 X 较小侧）先出鱼，每条晚 <paramref name="spawnIntervalSeconds"/> 秒，
    /// 生成位置按编队已前进距离补偿，保持与一次性生成一致的相对间距。
    /// </summary>
    public void ShearSoonIodineCallDriveGalvanize(
        FishSchoolShape shape,
        float centerAnchoredX,
        float centerAnchoredY,
        int dir,
        float speed,
        float cellSpacingX,
        float cellSpacingY,
        bool mirrorShapeX,
        float spawnIntervalSeconds)
    {
        if (spawnIntervalSeconds <= 0f)
        {
            ShearSoonIodineCallDrive(
                shape,
                centerAnchoredX,
                centerAnchoredY,
                dir,
                speed,
                cellSpacingX,
                cellSpacingY,
                mirrorShapeX);
            return;
        }

        if (shape == null)
        {
            Debug.LogWarning("UISoonRopeSolder.SpawnFishSchoolFromShapeStaggered: shape is null");
            return;
        }

        if (!m_HeAccept) Rail();
        if (!m_HeAccept || DietFore == null || SortRead == null)
        {
            Debug.LogWarning("UISoonRopeSolder.SpawnFishSchoolFromShapeStaggered: 未初始化或 swimArea/fishRoot 为空");
            return;
        }

        int finalDir = dir >= 0 ? 1 : -1;
        cellSpacingX = Mathf.Max(0f, cellSpacingX);
        cellSpacingY = Mathf.Max(0f, cellSpacingY);

        List<FishSchoolSpawnSlot> slots = CauseSoonIodineShearCount(shape, mirrorShapeX, finalDir);
        if (slots.Count == 0)
        {
            return;
        }

        if (m_SoonIodineBravelyFragile != null)
        {
            StopCoroutine(m_SoonIodineBravelyFragile);
            m_SoonIodineBravelyFragile = null;
        }

        m_SoonIodineBravelyFragile = StartCoroutine(AxShearSoonIodineGalvanize(
            centerAnchoredX,
            centerAnchoredY,
            finalDir,
            speed,
            cellSpacingX,
            cellSpacingY,
            spawnIntervalSeconds,
            slots));
    }

    private List<FishSchoolSpawnSlot> CauseSoonIodineShearCount(
        FishSchoolShape shape,
        bool mirrorShapeX,
        int finalDir)
    {
        shape.EnsurePalette();
        shape.EnsureCells();

        List<Vector2> offsets = new List<Vector2>(64);
        List<int> typeIds = new List<int>(64);
        shape.GetFilledOffsetsWithTypes(offsets, typeIds);
        if (offsets.Count != typeIds.Count)
        {
            return new List<FishSchoolSpawnSlot>();
        }

        List<FishSchoolSpawnSlot> slots = new List<FishSchoolSpawnSlot>(offsets.Count);
        for (int i = 0; i < offsets.Count; i++)
        {
            int tid = typeIds[i];
            if (tid < 1 || tid > shape.fishTypes.Count)
            {
                continue;
            }

            GameObject Pigeon= shape.fishTypes[tid - 1].prefab;
            if (Pigeon == null)
            {
                Debug.LogWarning($"UISoonRopeSolder: 鱼群形状中「{shape.fishTypes[tid - 1].label}」未指定 prefab，已跳过");
                continue;
            }

            Vector2 o = offsets[i];
            float ox = mirrorShapeX ? -o.x : o.x;
            float oy = o.y;
            float Spear= Mathf.Max(0.01f, shape.fishTypes[tid - 1].scale);
            slots.Add(new FishSchoolSpawnSlot { Radial = Pigeon, No = ox, Up = oy, Trunk = Spear });
        }

        // 严格从“即将进场的一侧”排队：dir>0 时右侧(ox大)先，dir<0 时左侧(ox小)先。
        slots.Sort((a, b) => finalDir > 0 ? b.No.CompareTo(a.No) : a.No.CompareTo(b.No));
        return slots;
    }

    private IEnumerator AxShearSoonIodineGalvanize(
        float centerAnchoredX,
        float centerAnchoredY,
        int finalDir,
        float speed,
        float cellSpacingX,
        float cellSpacingY,
        float spawnIntervalSeconds,
        List<FishSchoolSpawnSlot> slots)
    {
        float vEff = Mathf.Max(0f, speed) * Mathf.Max(0.01f, m_ObeyModalHenceforth);
        int n = slots.Count;
        if (n <= 0)
        {
            m_SoonIodineBravelyFragile = null;
            yield break;
        }

        // 关键：同一竖列（同 Ox）在同一批次生成，保证“同列齐头并进”。
        const float kColumnEpsilon = 0.0001f;
        float currentColumnOx = slots[0].No;
        int columnIndex = 0;

        for (int i = 0; i < n; i++)
        {
            FishSchoolSpawnSlot s = slots[i];
            if (Mathf.Abs(s.No - currentColumnOx) > kColumnEpsilon)
            {
                currentColumnOx = s.No;
                columnIndex++;
            }

            float elapsed = columnIndex * spawnIntervalSeconds;
            float advance = finalDir * vEff * elapsed;
            float x = centerAnchoredX + advance + s.No * cellSpacingX;
            float y = centerAnchoredY + s.Up * cellSpacingY;
            ShearSoonBeRadialUpWildlifeMystique(s.Radial, new Vector2(x, y), finalDir, speed, s.Trunk, ActiveFishOrigin.School);

            bool hasNext = i + 1 < n;
            if (!hasNext)
            {
                continue;
            }

            // 下一条是新列时，等待一个批次间隔；同列不等待。
            float nextOx = slots[i + 1].No;
            bool nextIsNewColumn = Mathf.Abs(nextOx - currentColumnOx) > kColumnEpsilon;
            if (nextIsNewColumn)
            {
                yield return new WaitForSeconds(spawnIntervalSeconds);
            }
        }

        m_SoonIodineBravelyFragile = null;
    }

    /// <summary>
    /// 根据编队外接格子范围，建议形状中心 X，使整队从一侧屏幕外切入（与 <see cref="SpawnFishTide"/> 的 spawnBuffer 一致）。
    /// <paramref name="mirrorShapeX"/> 须与 <see cref="SpawnFishSchoolFromShape"/> 一致。
    /// </summary>
    public float LawHonorableSoonIodineEightyWildlifeX(
        FishSchoolShape shape,
        int dir,
        float cellSpacingX,
        bool mirrorShapeX = false)
    {
        if (shape == null || DietFore == null)
        {
            return 0f;
        }

        shape.EnsureCells();
        List<Vector2> offsets = new List<Vector2>(64);
        shape.GetFilledOffsets(offsets);
        if (offsets.Count == 0)
        {
            return 0f;
        }

        float minOx = float.MaxValue;
        float maxOx = float.MinValue;
        for (int i = 0; i < offsets.Count; i++)
        {
            float ox = mirrorShapeX ? -offsets[i].x : offsets[i].x;
            minOx = Mathf.Min(minOx, ox);
            maxOx = Mathf.Max(maxOx, ox);
        }

        Rect Duct= DietFore.rect;
        float pad = Mathf.Max(0f, MayorQuaker);
        cellSpacingX = Mathf.Max(0f, cellSpacingX);
        int finalDir = dir >= 0 ? 1 : -1;
        float centerX;
        if (finalDir > 0)
        {
            // 从左侧进场并向右游时，前沿是 maxOx，前沿贴到左边界外。
            centerX = Duct.xMin - pad - maxOx * cellSpacingX;
        }
        else
        {
            // 从右侧进场并向左游时，前沿是 minOx，前沿贴到右边界外。
            centerX = Duct.xMax + pad - minOx * cellSpacingX;
        }

        // 额外把“队首鱼”的可见宽度也推到屏外，避免第一条鱼半截出现在屏内。
        float leadMargin = LawSoonIodineLeafletNormanX(shape, finalDir);
        return finalDir > 0 ? centerX - leadMargin : centerX + leadMargin;
    }

    private float LawSoonIodineLeafletNormanX(FishSchoolShape shape, int swimDir)
    {
        if (shape == null || shape.fishTypes == null || shape.fishTypes.Count == 0)
        {
            return 0f;
        }

        float maxMargin = 0f;
        for (int i = 0; i < shape.fishTypes.Count; i++)
        {
            FishSchoolPaletteEntry entry = shape.fishTypes[i];
            if (entry == null || entry.prefab == null)
            {
                continue;
            }

            RectTransform prefabRect = entry.prefab.transform as RectTransform;
            if (prefabRect == null)
            {
                continue;
            }

            float Spear= Mathf.Max(0.01f, entry.scale);
            float a = prefabRect.rect.xMin * Spear;
            float b = prefabRect.rect.xMax * Spear;
            float ext = swimDir > 0 ? Mathf.Max(a, b) : -Mathf.Min(a, b);
            if (ext < 0f)
            {
                ext = 0f;
            }

            UISoonMandan prefabEntity = LawSoonMandanOrRadial(entry.prefab);
            float perFishExtra = prefabEntity != null ? Mathf.Max(0f, prefabEntity.MayorPlumbQuaker) : 0f;
            float margin = ext * Mathf.Max(0f, MayorMetalHollowTrunk) + Mathf.Max(0f, MayorPlumbXNorman) + perFishExtra;
            if (margin > maxMargin)
            {
                maxMargin = margin;
            }
        }

        return maxMargin;
    }

    /// <summary>
    /// 调试/测试：生成指定鱼预制体（绕开后端 fish_config 与权重逻辑）。
    /// </summary>
    public UISoonMandan ShearSoonBeRadial(
        GameObject fishPrefab,
        int dir = 1,
        float speed = 260f,
        float scale = 1f,
        bool useRandomY = true,
        float spawnY = 0f
    )
    {
        if (fishPrefab == null)
        {
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefab: fishPrefab is null");
            return null;
        }
        if (!m_HeAccept) Rail();
        if (DietFore == null || SortRead == null)
        {
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefab: swimArea/fishRoot is null");
            return null;
        }

        Rect Duct= DietFore.rect;
        float yMin = Duct.yMin + CollapseInclude;
        float yMax = Duct.yMax - CollapseInclude;
        if (yMax < yMin) yMax = yMin;

        UISoonMandan prefabEntity = LawSoonMandanOrRadial(fishPrefab);
        UIFishSpawnVerticalBands bands = prefabEntity != null
            ? prefabEntity.CollapseShearPivot
            : default;
        float finalY = useRandomY ? AccuseShearYEyeMudflatsPivot(bands, yMin, yMax) : Mathf.Clamp(spawnY, yMin, yMax);
        int finalDir = dir >= 0 ? 1 : -1;

        float baseSpawnX = LawSeedShearXBeQuaker(Duct, finalDir, MayorQuaker + (prefabEntity != null ? Mathf.Max(0f, prefabEntity.MayorPlumbQuaker) : 0f));

        UISoonMandan fish = LawCallCook(fishPrefab);
        if (fish == null)
        {
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefab: GetFromPool returned null");
            return null;
        }

        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null)
        {
            fish.gameObject.SetActive(false);
            CrouchAxCook(fishPrefab, fish);
            Debug.LogError("UISoonRopeSolder.SpawnFishByPrefab: fishRect is null");
            return null;
        }

        fishRect.SetParent(SortRead, false);
        fishRect.localScale = Vector3.one * scale;

        // 左右朝向翻转：按预制体 default 朝向决定翻转规则
        float baseFacingSign = prefabEntity != null && prefabEntity.PigeonMussel == UIFishSpawnEntry.PrefabFacing.Right ? 1f : -1f;
        float desiredSign = finalDir > 0 ? baseFacingSign : -baseFacingSign;
        Vector3 scale3 = fishRect.localScale;
        scale3.x = Mathf.Abs(scale3.x) * desiredSign;
        fishRect.localScale = scale3;

        float MayorX= SqueakShearXEyeSoonMetal(baseSpawnX, finalDir, fishRect);
        fishRect.anchoredPosition = new Vector2(MayorX, finalY);

        if (prefabEntity != null && prefabEntity.BeGazeSoon)
        {
            float perFishExtra = Mathf.Max(0f, prefabEntity.MayorPlumbQuaker);
            Debug.Log(
                $"UISoonRopeSolder.SpawnFishByPrefab(Boss): dir={finalDir}, spawnBuffer={MayorQuaker:F2}, perFishExtra={perFishExtra:F2}, finalSpawnX={MayorX:F2}, spawnY={finalY:F2}"
            );
        }

        fish.gameObject.SetActive(true);
        fish.Rail(fishPrefab, speed * m_ObeyModalHenceforth, finalY, finalDir);
        UIFishCategory prefabCategory = (prefabEntity != null && prefabEntity.BeGazeSoon)
            ? UIFishCategory.Boss
            : (m_BalanceRopeToll == GameType.FerverTime ? UIFishCategory.Ferver : UIFishCategory.Small);
        fish.HalveSoonUpheaval(prefabCategory);
        TiePotashSoon(fish, m_BalanceRopeToll == GameType.FerverTime ? ActiveFishOrigin.Ferver : ActiveFishOrigin.Normal);
        return fish;
    }

    private void OnHookPressSlowState(bool isSlow)
    {
        m_HeSteelBaskIncur = isSlow;
    }

    private void OnHookFishHitSlowState(float slowEffectValue)
    {
        m_SoonFewBaskAttainFavor = Mathf.Max(0f, slowEffectValue);
    }

    private void OnCloseupFishSpeedMultiplier(float mul)
    {
        m_TerrainModalHenceforth = Mathf.Clamp01(mul);
    }

    private void OnGameTypeChanged(GameType gameType)
    {
        GameType prevGameType = m_BalanceRopeToll;
        m_BalanceRopeToll = gameType;
        // 过渡中段预清场后，切到 FerverTime 时恢复常规刷鱼流程。
        if (gameType == GameType.FerverTime)
        {
            m_BenignTowStudyFactory = false;
            m_MalletShearPlaster = true;
        }

        bool shouldRestoreHiddenFishes = prevGameType == GameType.FerverTime
            && gameType != GameType.FerverTime
            && m_BenignShrillDecade.Count > 0;
        if (shouldRestoreHiddenFishes)
        {
            // 回到普通模式时，先切规则但不立即补鱼，优先恢复 Ferver 前隐藏的鱼。
            CalcitePinPotashDecade();
            FlipperShearPalm(false, false);
            UnaidedShrillDecadeCallBenign();
            DampAxExpert();
            return;
        }

        FlipperShearPalm(true);
    }

    private void OnFerverPreClearRequest()
    {
        // 仅在 Normal 阶段响应一次，避免重复清场抖动。
        if (!m_HeAccept || m_BalanceRopeToll != GameType.Normal || m_BenignTowStudyFactory)
        {
            return;
        }

        m_BenignTowStudyFactory = true;
        m_MalletShearPlaster = false;
        JoltPinPotashDecadeEyeBenign();
    }

    private void OnShipLevelChanged(int oldLevel, int newLevel, int levelUpCount)
    {
        m_BalanceUtahMagma = Mathf.Max(1, newLevel);
        if (m_BalanceRopeToll == GameType.Normal)
        {
            // 升级后仅更新后续生成规则，不强制回收场上鱼。
            FlipperShearPalm(false);
        }
    }

    private void CognitiveLuxury()
    {
        if (m_HeProprietor) return;
        LuxuryHop.OrGraySteelBaskIncur += OnHookPressSlowState;
        LuxuryHop.OrGraySoonFewBaskIncur += OnHookFishHitSlowState;
        LuxuryHop.OrTerrainSoonModalHenceforth += OnCloseupFishSpeedMultiplier;
        LuxuryHop.OrSoonClusterCalcite += OnFishRequestRecycle;
        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
        LuxuryHop.OrUtahMagmaAnother += OnShipLevelChanged;
        LuxuryHop.OrBenignTowStudyCluster += OnFerverPreClearRequest;
        m_HeProprietor = true;
    }

    private void PublicationLuxury()
    {
        if (!m_HeProprietor) return;
        LuxuryHop.OrGraySteelBaskIncur -= OnHookPressSlowState;
        LuxuryHop.OrGraySoonFewBaskIncur -= OnHookFishHitSlowState;
        LuxuryHop.OrTerrainSoonModalHenceforth -= OnCloseupFishSpeedMultiplier;
        LuxuryHop.OrSoonClusterCalcite -= OnFishRequestRecycle;
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        LuxuryHop.OrUtahMagmaAnother -= OnShipLevelChanged;
        LuxuryHop.OrBenignTowStudyCluster -= OnFerverPreClearRequest;
        m_HeProprietor = false;
    }

    private void DampAxExpert()
    {
        if (m_BalanceRopeToll == GameType.FerverTime && HeBenignLuxuryExpertObeyPlaster())
        {
            // Ferver 单鱼模式：仅保证驻场鱼存在，不走鱼群/补鱼逻辑。
            BotanyBenignLuxuryExpertSoon();
            return;
        }

        int safeCount = m_BalanceRopeToll == GameType.Normal
            ? LawBalanceMalletServeExpertSoonRelic()
            : Mathf.Max(0, SpinalExpertSoonRelic);
        if (m_BalanceRopeToll == GameType.FerverTime && BoyBenignRowShear)
        {
            // Ferver 行模式：这里只做初始铺场，后续由 TickFerverContinuousSpawn 持续出鱼。
            DampBenignBeatAxExpert(Mathf.Max(safeCount, Mathf.Max(1, SpinalEggRelic) * 2));
            return;
        }

        int spawnBudget = Mathf.Max(1, CensusShearTheDewLawn);
        if (BovineMalletShearForceful)
        {
            float interval = Mathf.Max(0.01f, CensusShearUpcoming);
            if (BovineSufficeShearGill && m_MalletShearGillRedbud > 0f)
            {
                float rampDuration = Mathf.Max(0.01f, ThunderShearGillCheerful);
                float progress = Mathf.Clamp01(1f - (m_MalletShearGillRedbud / rampDuration));
                float rateMul = Mathf.Lerp(
                    Mathf.Clamp(ThunderShearDuneHenceforth, 0.05f, 1f),
                    1f,
                    progress
                );
                interval /= Mathf.Max(0.05f, rateMul);
                m_MalletShearGillRedbud = Mathf.Max(0f, m_MalletShearGillRedbud - Time.deltaTime);
            }
            m_MalletShearTruth += Mathf.Max(0f, Time.deltaTime);
            int intervalBudget = Mathf.FloorToInt(m_MalletShearTruth / interval);
            if (intervalBudget <= 0)
            {
                return;
            }
            spawnBudget = Mathf.Min(spawnBudget, intervalBudget);
            m_MalletShearTruth -= spawnBudget * interval;
        }

        int guard = 1000; // 防止异常配置时死循环
        int spawned = 0;
        while (LawPotashMalletSoonRelic() < safeCount && guard-- > 0 && spawned < spawnBudget)
        {
            int before = LawPotashMalletSoonRelic();
            bool success = ShearBuySoon();
            if (!success || LawPotashMalletSoonRelic() <= before)
            {
                // 当前条件下无法继续生成时，避免同帧空转。
                break;
            }
            spawned++;
        }
    }

    private void LawnMalletServeExpertProse(float deltaTime)
    {
        if (!BoyMalletServeExpertProse) return;
        if (!m_MalletServeProseReplant) return;
        if (m_BalanceRopeToll != GameType.Normal) return;
        if (!m_MalletShearPlaster) return;
        if (!LayCopConcludeMalletServeCheerful()) return;

        m_MalletServeRedbud -= Mathf.Max(0f, deltaTime);
        int guard = 0;
        while (m_MalletServeRedbud <= 0f && guard++ < 3)
        {
            float overflow = -m_MalletServeRedbud;
            AviatorAxSpinMalletServe();
            m_MalletServeRedbud -= overflow;
        }
    }

    private void PrimeSowHordeMalletServeExpertProse()
    {
        m_MalletServeProseReplant = BoyMalletServeExpertProse;
        m_MalletServeSlope = 0;
        m_MalletServeRedbud = LawMalletServeCheerfulBeSlope(m_MalletServeSlope);

        if (!m_MalletServeProseReplant)
        {
            return;
        }

        if (!LayCopConcludeMalletServeCheerful())
        {
            return;
        }

        int guard = 0;
        while (m_MalletServeRedbud <= 0f && guard++ < 3)
        {
            AviatorAxSpinMalletServe();
        }
    }

    private void AviatorAxSpinMalletServe()
    {
        m_MalletServeSlope = (m_MalletServeSlope + 1) % 3;
        m_MalletServeRedbud = LawMalletServeCheerfulBeSlope(m_MalletServeSlope);
    }

    private int LawBalanceMalletServeExpertSoonRelic()
    {
        if (!BoyMalletServeExpertProse || !m_MalletServeProseReplant)
        {
            return Mathf.Max(0, CensusServe1ExpertSoonRelic);
        }

        switch (m_MalletServeSlope)
        {
            case 0:
                return Mathf.Max(0, CensusServe1ExpertSoonRelic);
            case 1:
                return Mathf.Max(0, CensusServe2ExpertSoonRelic);
            default:
                return Mathf.Max(0, CensusServe3ExpertSoonRelic);
        }
    }

    private float LawMalletServeCheerfulBeSlope(int index)
    {
        switch (index)
        {
            case 0:
                return Mathf.Max(0f, CensusServe1Cheerful);
            case 1:
                return Mathf.Max(0f, CensusServe2Cheerful);
            default:
                return Mathf.Max(0f, CensusServe3Cheerful);
        }
    }

    private bool LayCopConcludeMalletServeCheerful()
    {
        return CensusServe1Cheerful > 0f || CensusServe2Cheerful > 0f || CensusServe3Cheerful > 0f;
    }

    private bool ShearBuySoon()
    {
        UIFishSpawnEntry entry = HoofCodifySlushBeGeyser();
        if (entry == null || entry.Pigeon == null) return false;

        UISoonMandan fish = LawCallCook(entry.Pigeon);
        if (fish == null) return false;

        Rect Duct= DietFore.rect;
        float yMin = Duct.yMin + CollapseInclude;
        float yMax = Duct.yMax - CollapseInclude;
        if (yMax < yMin)
        {
            yMax = yMin;
        }

        int Mob= LawSpinShearIntersectEyeSlush(entry);
        float baseSpawnX = LawSeedShearXBeQuaker(Duct, Mob, MayorQuaker + Mathf.Max(0f, entry.MayorPlumbQuaker));
        float MayorY= AccuseShearYEyeMudflatsPivot(entry.CollapseShearPivot, yMin, yMax);
        float Vague= Random.Range(entry.VagueDegas.x, entry.VagueDegas.y);
        float Spear= Random.Range(entry.SpearDegas.x, entry.SpearDegas.y);
        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null)
        {
            fish.gameObject.SetActive(false);
            CrouchAxCook(entry.Pigeon, fish);
            return false;
        }

        fishRect.SetParent(SortRead, false);
        fishRect.localScale = Vector3.one * Spear;

        // 左右朝向翻转：按预制体默认朝向决定翻转规则
        Vector3 scale3 = fishRect.localScale;
        float baseFacingSign = entry.PigeonMussel == UIFishSpawnEntry.PrefabFacing.Right ? 1f : -1f;
        float desiredSign = Mob > 0 ? baseFacingSign : -baseFacingSign;
        scale3.x = Mathf.Abs(scale3.x) * desiredSign;
        fishRect.localScale = scale3;

        float MayorX= SqueakShearXEyeSoonMetal(baseSpawnX, Mob, fishRect);
        fishRect.anchoredPosition = new Vector2(MayorX, MayorY);

        fish.gameObject.SetActive(true);
        fish.Rail(entry.Pigeon, Vague * m_ObeyModalHenceforth, MayorY, Mob);
        fish.HalveSoonUpheaval(entry.SortUpheaval);
        if (!string.IsNullOrWhiteSpace(entry.SortWe) || !string.IsNullOrWhiteSpace(entry.SortToll))
        {
            fish.HalveHamperSoonTedium(entry.SortWe, entry.SortToll, entry.HealerMagma, entry.WineGreek, entry.OutdoorTemple);
        }
        TiePotashSoon(fish, ActiveFishOrigin.Normal);
        CapeSlushSlipper(entry, Mob);
        return true;
    }

    private void ShearBuySoonUp(float spawnX, float spawnY, int dir, float speed)
    {
        UIFishSpawnEntry entry = HoofCodifySlushBeGeyser();
        if (entry == null || entry.Pigeon == null) return;

        UISoonMandan fish = LawCallCook(entry.Pigeon);
        if (fish == null) return;

        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null)
        {
            fish.gameObject.SetActive(false);
            CrouchAxCook(entry.Pigeon, fish);
            return;
        }

        float Spear= Random.Range(entry.SpearDegas.x, entry.SpearDegas.y);
        fishRect.SetParent(SortRead, false);
        fishRect.localScale = Vector3.one * Spear;

        // 左右朝向翻转：按预制体默认朝向决定翻转规则
        Vector3 scale3 = fishRect.localScale;
        float baseFacingSign = entry.PigeonMussel == UIFishSpawnEntry.PrefabFacing.Right ? 1f : -1f;
        float desiredSign = dir > 0 ? baseFacingSign : -baseFacingSign;
        scale3.x = Mathf.Abs(scale3.x) * desiredSign;
        fishRect.localScale = scale3;

        float spawnXWithPerFishBuffer = HalveDewSoonShearQuaker(spawnX, dir, entry.MayorPlumbQuaker);
        float finalSpawnX = SqueakShearXEyeSoonMetal(spawnXWithPerFishBuffer, dir, fishRect);
        fishRect.anchoredPosition = new Vector2(finalSpawnX, spawnY);

        fish.gameObject.SetActive(true);
        fish.Rail(entry.Pigeon, Mathf.Max(0f, speed) * m_ObeyModalHenceforth, spawnY, dir, enableSteerTiltAndPathOffset: false);
        fish.HalveSoonUpheaval(entry.SortUpheaval);
        if (!string.IsNullOrWhiteSpace(entry.SortWe) || !string.IsNullOrWhiteSpace(entry.SortToll))
        {
            fish.HalveHamperSoonTedium(entry.SortWe, entry.SortToll, entry.HealerMagma, entry.WineGreek, entry.OutdoorTemple);
        }
        TiePotashSoon(fish, ActiveFishOrigin.School);
    }

    private void DampBenignBeatAxExpert(int safeCount)
    {
        int rowCount = Mathf.Max(1, SpinalEggRelic);
        int guard = 1000;
        while (m_PotashDecade.Count < safeCount && guard-- > 0)
        {
            int before = m_PotashDecade.Count;
            ShearLuxuryBenignSoonAnEgg(m_BenignSpinEggSlope, rowCount);
            m_BenignSpinEggSlope = (m_BenignSpinEggSlope + 1) % rowCount;
            if (m_PotashDecade.Count <= before)
            {
                break;
            }
        }
    }

    private void LawnBenignOfficiallyShear(float dt)
    {
        if (m_BenignEpitomeSoonRayon.Count == 0) return;

        int maxActive = Mathf.Max(1, SpinalOfficiallyThePotashSoon);
        if (m_PotashDecade.Count >= maxActive) return;

        float interval = Mathf.Max(0.01f, SpinalOfficiallyShearUpcoming);
        m_BenignShearTruth += Mathf.Max(0f, dt);

        int rowCount = Mathf.Max(1, SpinalEggRelic);
        while (m_BenignShearTruth >= interval)
        {
            if (m_PotashDecade.Count >= maxActive) break;

            int before = m_PotashDecade.Count;
            ShearLuxuryBenignSoonAnEgg(m_BenignSpinEggSlope, rowCount);
            m_BenignSpinEggSlope = (m_BenignSpinEggSlope + 1) % rowCount;
            m_BenignShearTruth -= interval;

            if (m_PotashDecade.Count <= before)
            {
                // 当前帧无法生成时避免死循环。
                m_BenignShearTruth = 0f;
                break;
            }
        }
    }

    private void ShearLuxuryBenignSoonAnEgg(int rowIndex, int rowCount)
    {
        if (DietFore == null) return;
        if (m_BenignEpitomeSoonRayon.Count == 0) return;

        Rect Duct= DietFore.rect;
        float yMin = Duct.yMin + CollapseInclude;
        float yMax = Duct.yMax - CollapseInclude;
        if (yMax < yMin) yMax = yMin;

        int safeRowCount = Mathf.Max(1, rowCount);
        float t = safeRowCount <= 1 ? 0.5f : (rowIndex / (float)(safeRowCount - 1));
        float rowY = Mathf.Lerp(yMax, yMin, t);

        // 第 1 行向左（右->左），第 2 行向右（左->右），依次交替。
        int Mob= (rowIndex % 2 == 0) ? -1 : 1;
        float MayorX= Mob > 0
            ? (Duct.xMin - MayorQuaker)
            : (Duct.xMax + MayorQuaker);

        ShearBuyBenignSoonUp(
            MayorX,
            rowY,
            Mob,
            Mathf.Max(0f, SpinalEggModal)
        );
    }

    private void ShearBuyBenignSoonUp(float spawnX, float spawnY, int dir, float speed)
    {
        UIFishSpawnEntry entry = HoofCodifySlushBeGeyser();
        if (entry == null || entry.Pigeon == null) return;

        UISoonMandan fish = LawCallCook(entry.Pigeon);
        if (fish == null) return;

        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null)
        {
            fish.gameObject.SetActive(false);
            CrouchAxCook(entry.Pigeon, fish);
            return;
        }

        // Ferver 队列模式使用固定缩放，避免随机体积造成“视觉间距不一致”。
        const float fixedScale = 1f;

        fishRect.SetParent(SortRead, false);
        fishRect.localScale = Vector3.one * fixedScale;

        Vector3 scale3 = fishRect.localScale;
        float baseFacingSign = entry.PigeonMussel == UIFishSpawnEntry.PrefabFacing.Right ? 1f : -1f;
        float desiredSign = dir > 0 ? baseFacingSign : -baseFacingSign;
        scale3.x = Mathf.Abs(scale3.x) * desiredSign;
        fishRect.localScale = scale3;

        float spawnXWithPerFishBuffer = HalveDewSoonShearQuaker(spawnX, dir, entry.MayorPlumbQuaker);
        float finalSpawnX = SqueakShearXEyeSoonMetal(spawnXWithPerFishBuffer, dir, fishRect);
        fishRect.anchoredPosition = new Vector2(finalSpawnX, spawnY);

        fish.gameObject.SetActive(true);
        // FerverTime 统一排队直线移动：关闭预制体 steer 倾角/路径偏移，避免受个体参数影响。
        fish.Rail(
            entry.Pigeon,
            Mathf.Max(0f, speed) * m_ObeyModalHenceforth,
            spawnY,
            dir,
            enableSteerTiltAndPathOffset: false
        );
        fish.HalveSoonUpheaval(entry.SortUpheaval);
        if (!string.IsNullOrWhiteSpace(entry.SortWe) || !string.IsNullOrWhiteSpace(entry.SortToll))
        {
            fish.HalveHamperSoonTedium(entry.SortWe, entry.SortToll, entry.HealerMagma, entry.WineGreek, entry.OutdoorTemple);
        }
        TiePotashSoon(fish, ActiveFishOrigin.Ferver);
    }

    private UIFishSpawnEntry HoofCodifySlushBeGeyser()
    {
        List<UIFishSpawnEntry> entries = LawPotashSoonReplace();
        if (entries == null || entries.Count == 0)
        {
            return null;
        }

        if (m_BalanceRopeToll == GameType.FerverTime)
        {
            return HoofCodifySlushHoliday(entries);
        }

        List<UIFishSpawnEntry> readyEntries = EncaseCrawlMalletEntries(entries);
        if (readyEntries.Count == 0)
        {
            return null;
        }
        return HoofCodifyMalletSlushBeUtahMagma(readyEntries);
    }

    private List<UIFishSpawnEntry> EncaseCrawlMalletEntries(List<UIFishSpawnEntry> entries)
    {
        List<UIFishSpawnEntry> Plank= new List<UIFishSpawnEntry>();
        float now = Time.unscaledTime;
        for (int i = 0; i < entries.Count; i++)
        {
            UIFishSpawnEntry entry = entries[i];
            if (entry == null || entry.Pigeon == null)
            {
                continue;
            }

            if (!HeSlushCrawlAxShear(entry, now))
            {
                continue;
            }

            Plank.Add(entry);
        }
        return Plank;
    }

    private bool HeSlushCrawlAxShear(UIFishSpawnEntry entry, float now)
    {
        if (!BovineGibeKindShearRecess)
        {
            return true;
        }

        float cooldown = Mathf.Max(0f, SakeNileShearInstance);
        if (cooldown <= 0f)
        {
            return true;
        }

        string key = LawShearNileAil(entry);
        if (string.IsNullOrEmpty(key))
        {
            return true;
        }

        if (!m_SpinShearLineBeNileAil.TryGetValue(key, out float readyTime))
        {
            return true;
        }

        return now >= readyTime;
    }

    private int LawSpinShearIntersectEyeSlush(UIFishSpawnEntry entry)
    {
        if (!BovineGibeKindShearRecess)
        {
            return Random.value < 0.5f ? 1 : -1;
        }

        string key = LawShearNileAil(entry);
        if (string.IsNullOrEmpty(key))
        {
            return Random.value < 0.5f ? 1 : -1;
        }

        if (m_SinkShearRutBeNileAil.TryGetValue(key, out int lastDir))
        {
            return lastDir >= 0 ? -1 : 1;
        }

        return Random.value < 0.5f ? 1 : -1;
    }

    private void CapeSlushSlipper(UIFishSpawnEntry entry, int dir)
    {
        if (!BovineGibeKindShearRecess)
        {
            return;
        }

        string key = LawShearNileAil(entry);
        if (string.IsNullOrEmpty(key))
        {
            return;
        }

        m_SinkShearRutBeNileAil[key] = dir >= 0 ? 1 : -1;
        float cooldown = Mathf.Max(0f, SakeNileShearInstance);
        m_SpinShearLineBeNileAil[key] = Time.unscaledTime + cooldown;
    }

    private static string LawShearNileAil(UIFishSpawnEntry entry)
    {
        if (entry == null)
        {
            return string.Empty;
        }

        string type = entry.SortToll == null ? string.Empty : entry.SortToll.Trim();
        string id = entry.SortWe == null ? string.Empty : entry.SortWe.Trim();
        if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(id))
        {
            return type + "|" + id;
        }

        if (!string.IsNullOrEmpty(id))
        {
            return "id|" + id;
        }

        if (!string.IsNullOrEmpty(type))
        {
            return "type|" + type;
        }

        return entry.Pigeon != null ? ("prefab|" + entry.Pigeon.name) : string.Empty;
    }

    /// <summary>普通模式：在同一 unlockLevel 列表内按 <see cref="UIFishSpawnEntry.normalSpawnWeight"/> 加权随机。</summary>
    private static UIFishSpawnEntry HoofMalletShearLandsman(List<UIFishSpawnEntry> list)
    {
        if (list == null || list.Count == 0)
        {
            return null;
        }

        if (list.Count == 1)
        {
            return list[0];
        }

        float sum = 0f;
        for (int i = 0; i < list.Count; i++)
        {
            UIFishSpawnEntry e = list[i];
            if (e == null || e.Pigeon == null)
            {
                continue;
            }

            int w = e.CensusShearGeyser;
            sum += w > 0 ? w : 1f;
        }

        if (sum <= 1e-6f)
        {
            return list[Random.Range(0, list.Count)];
        }

        float roll = Random.value * sum;
        float acc = 0f;
        for (int i = 0; i < list.Count; i++)
        {
            UIFishSpawnEntry e = list[i];
            if (e == null || e.Pigeon == null)
            {
                continue;
            }

            int w = e.CensusShearGeyser;
            acc += w > 0 ? w : 1f;
            if (roll < acc)
            {
                return e;
            }
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] != null && list[i].Pigeon != null)
            {
                return list[i];
            }
        }

        return null;
    }

    /// <summary>Ferver 等：在列表内均匀随机（不含等级分档）。</summary>
    private static UIFishSpawnEntry HoofCodifySlushHoliday(List<UIFishSpawnEntry> entries)
    {
        List<UIFishSpawnEntry> valid = new List<UIFishSpawnEntry>();
        for (int i = 0; i < entries.Count; i++)
        {
            UIFishSpawnEntry entry = entries[i];
            if (entry == null || entry.Pigeon == null) continue;
            valid.Add(entry);
        }

        if (valid.Count <= 0) return null;
        return valid[Random.Range(0, valid.Count)];
    }

    /// <summary>
    /// 普通鱼池：排除 Ferver/Boss 后的列表。高等级鱼已在组池时剔除。
    /// 锚定等级 = 船等级（该档有鱼）否则池内最高 unlock；below 窗口内各档平分 belowBand。
    /// </summary>
    private UIFishSpawnEntry HoofCodifyMalletSlushBeUtahMagma(List<UIFishSpawnEntry> entries)
    {
        Dictionary<int, List<UIFishSpawnEntry>> byLevel = new Dictionary<int, List<UIFishSpawnEntry>>();
        for (int i = 0; i < entries.Count; i++)
        {
            UIFishSpawnEntry entry = entries[i];
            if (entry == null || entry.Pigeon == null) continue;
            int lv = Mathf.Max(1, entry.HealerMagma);
            if (!byLevel.TryGetValue(lv, out List<UIFishSpawnEntry> list))
            {
                list = new List<UIFishSpawnEntry>();
                byLevel[lv] = list;
            }
            list.Add(entry);
        }

        if (byLevel.Count == 0) return null;

        int ship = Mathf.Max(1, m_BalanceUtahMagma);
        int anchor;
        if (byLevel.TryGetValue(ship, out List<UIFishSpawnEntry> atShip) && atShip != null && atShip.Count > 0)
        {
            anchor = ship;
        }
        else
        {
            int maxLv = 1;
            foreach (int k in byLevel.Keys)
            {
                if (k > maxLv) maxLv = k;
            }
            anchor = maxLv;
        }

        if (!byLevel.TryGetValue(anchor, out List<UIFishSpawnEntry> anchorList) || anchorList == null || anchorList.Count == 0)
        {
            return HoofCodifySlushHoliday(entries);
        }

        int belowSteps = Mathf.Max(1, CensusShearAssetMagmaRelic);
        List<int> belowLevels = new List<int>();
        for (int k = 1; k <= belowSteps; k++)
        {
            int L = anchor - k;
            if (L < 1) break;
            if (byLevel.TryGetValue(L, out List<UIFishSpawnEntry> bl) && bl != null && bl.Count > 0)
            {
                belowLevels.Add(L);
            }
        }

        float anchorShare = Mathf.Clamp01(CensusShearArouseMagmaStark);
        float belowBand = Mathf.Clamp01(CensusShearAssetWarnStark);
        float sumParts = anchorShare + belowBand;
        if (sumParts > 1e-5f)
        {
            anchorShare /= sumParts;
            belowBand /= sumParts;
        }

        float massAnchor = anchorShare;
        float massEachBelow = belowLevels.Count > 0 ? belowBand / belowLevels.Count : 0f;
        float sumMass = massAnchor + massEachBelow * belowLevels.Count;
        if (sumMass <= 1e-6f)
        {
            return HoofMalletShearLandsman(anchorList);
        }

        massAnchor /= sumMass;
        massEachBelow /= sumMass;

        float roll = Random.value;
        float acc = 0f;
        acc += massAnchor;
        if (roll < acc)
        {
            return HoofMalletShearLandsman(anchorList);
        }

        for (int i = 0; i < belowLevels.Count; i++)
        {
            acc += massEachBelow;
            if (roll < acc)
            {
                List<UIFishSpawnEntry> list = byLevel[belowLevels[i]];
                return HoofMalletShearLandsman(list);
            }
        }

        return HoofMalletShearLandsman(anchorList);
    }

    private List<UIFishSpawnEntry> LawPotashSoonReplace()
    {
        if (m_BalanceRopeToll == GameType.FerverTime && m_BenignEpitomeSoonRayon.Count > 0)
        {
            return m_BenignEpitomeSoonRayon;
        }
        return m_EpitomeSoonRayon;
    }

    private void FlipperShearPalm(bool recycleCurrentFishes, bool refillToTarget = true)
    {
        if (RopeStrange.Instance != null)
        {
            m_BalanceUtahMagma = Mathf.Max(1, RopeStrange.Instance.LawUtahMagma());
            m_BalanceRopeToll = RopeStrange.Instance.RopeToll;
        }

        HalveObeyEpitomeIrritate();
        CauseEpitomeSoonReplaceCallHamper();

        if (recycleCurrentFishes && SwordSoonOrPalmUnjust)
        {
            CalcitePinPotashDecade();
        }

        if (refillToTarget)
        {
            DampAxExpert();
        }
    }

    private void HalveObeyEpitomeIrritate()
    {
        if (m_BalanceRopeToll == GameType.FerverTime)
        {
            m_ObeyModalHenceforth = Mathf.Max(0.01f, SpinalModalHenceforth);
            return;
        }

        m_ObeyModalHenceforth = 1f;
    }

    private void CauseEpitomeSoonReplaceCallHamper()
    {
        m_EpitomeSoonRayon.Clear();
        m_BenignEpitomeSoonRayon.Clear();
        if (!BoyHamperSoonTedium) return;
        if (LopColeJar.instance == null || LopColeJar.instance.TediumMint == null) return;
        List<FishConfigData> serverConfigs = RopeMintStrange.LawLaurasia().SoonGallium;
        if (serverConfigs == null || serverConfigs.Count == 0) return;
        List<FishConfigData> ordered = new List<FishConfigData>(serverConfigs);
        ordered.Sort((a, b) =>
        {
            if (a == null && b == null) return 0;
            if (a == null) return 1;
            if (b == null) return -1;
            return a.sortOrder.CompareTo(b.sortOrder);
        });

        FervorEnormousReplace(ordered);
    }

    private int FervorEnormousReplace(List<FishConfigData> ordered)
    {
        int appendCount = 0;
        for (int i = 0; i < ordered.Count; i++)
        {
            FishConfigData cfg = ordered[i];
            if (cfg == null) continue;
            if (string.IsNullOrWhiteSpace(cfg.id) || string.IsNullOrWhiteSpace(cfg.type)) continue;

            int HealerMagma= Mathf.Max(1, cfg.unlockLevel);
            if (HealerMagma > m_BalanceUtahMagma) continue;

            string usedPath;
            GameObject Pigeon= GrabSoonRadialBeTedium(cfg.type, cfg.id, out usedPath);
            if (Pigeon == null)
            {
                continue;
            }
            UISoonMandan fishPrefabEntity = LawSoonMandanOrRadial(Pigeon);
            if (fishPrefabEntity == null)
            {
                Debug.LogWarning("UISoonRopeSolder: prefab missing UISoonMandan -> " + usedPath);
                continue;
            }

            UIFishSpawnEntry entry = new UIFishSpawnEntry
            {
                Pigeon = Pigeon,
                PigeonMussel = fishPrefabEntity.PigeonMussel,
                VagueDegas = LoathsomeDegas(fishPrefabEntity.VagueDegas, 0f),
                SpearDegas = LoathsomeDegas(fishPrefabEntity.SpearDegas, 0.01f),
                CollapseShearPivot = fishPrefabEntity.CollapseShearPivot,
                MayorPlumbQuaker = Mathf.Max(0f, fishPrefabEntity.MayorPlumbQuaker),
                YucatanPlumbQuaker = Mathf.Max(0f, fishPrefabEntity.YucatanPlumbQuaker),
                SortWe = cfg.id,
                SortToll = cfg.type,
                HealerMagma = HealerMagma,
                SledSnowy = cfg.sortOrder,
                WineGreek = Mathf.Max(0, cfg.sellPrice),
                OutdoorTemple = Mathf.Max(0, cfg.diamondReward),
                CensusShearGeyser = cfg.normalSpawnWeight > 0 ? cfg.normalSpawnWeight : 1,
                PigeonEmulsionHeed = usedPath,
                SortUpheaval = RopeMintStrange.LawLaurasia() != null
                    ? RopeMintStrange.LawLaurasia().ReplaceSoonUpheaval(cfg.type)
                    : UIFishCategory.Small
            };

            // 普通模式池：排除 Ferver 专用(type y) 与 Boss 专用(type z)。
            if (HeBenignMiniatureToll(cfg.type))
            {
                m_BenignEpitomeSoonRayon.Add(entry);
                appendCount++;
                continue;
            }
            if (HeGazeMiniatureToll(cfg.type))
            {
                continue;
            }

            m_EpitomeSoonRayon.Add(entry);
            appendCount++;
        }

        return appendCount;
    }

    private bool HeBenignMiniatureToll(string fishType)
    {
        string type = fishType == null ? string.Empty : fishType.Trim();
        string ferverType = SpinalMiniatureSoonToll == null ? string.Empty : SpinalMiniatureSoonToll.Trim();
        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(ferverType))
        {
            return false;
        }
        return string.Equals(type, ferverType, StringComparison.OrdinalIgnoreCase);
    }

    private bool HeBenignLuxuryExpertObeyPlaster()
    {
        if (m_BalanceRopeToll != GameType.FerverTime) return false;
        if (!BoyBenignLuxuryExpertShear) return false;
        return !string.IsNullOrWhiteSpace(SpinalLuxuryExpertSoonWe);
    }

    private UIFishSpawnEntry EditBenignLuxuryExpertSlush()
    {
        if (m_BenignEpitomeSoonRayon == null || m_BenignEpitomeSoonRayon.Count == 0) return null;
        string targetId = SpinalLuxuryExpertSoonWe == null ? string.Empty : SpinalLuxuryExpertSoonWe.Trim();
        if (string.IsNullOrEmpty(targetId)) return null;

        for (int i = 0; i < m_BenignEpitomeSoonRayon.Count; i++)
        {
            UIFishSpawnEntry entry = m_BenignEpitomeSoonRayon[i];
            if (entry == null || entry.Pigeon == null) continue;
            string entryId = entry.SortWe == null ? string.Empty : entry.SortWe.Trim();
            if (string.Equals(entryId, targetId, StringComparison.OrdinalIgnoreCase))
            {
                return entry;
            }
        }
        return null;
    }

    private void BotanyBenignLuxuryExpertSoon()
    {
        if (m_BenignLuxuryExpertSoon != null && m_BenignLuxuryExpertSoon.gameObject.activeSelf)
        {
            return;
        }

        UIFishSpawnEntry entry = EditBenignLuxuryExpertSlush();
        if (entry == null || entry.Pigeon == null || DietFore == null || SortRead == null)
        {
            return;
        }

        UISoonMandan fish = LawCallCook(entry.Pigeon);
        if (fish == null) return;

        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null)
        {
            fish.gameObject.SetActive(false);
            CrouchAxCook(entry.Pigeon, fish);
            return;
        }

        Rect Duct= DietFore.rect;
        float yMin = Duct.yMin + CollapseInclude;
        float yMax = Duct.yMax - CollapseInclude;
        if (yMax < yMin) yMax = yMin;
        float centerY = Mathf.Clamp(Duct.center.y, yMin, yMax);
        float centerX = Duct.center.x;
        float enterXBase = LawSeedShearXBeQuaker(
            Duct,
            -1,
            MayorQuaker + Mathf.Max(0f, entry.MayorPlumbQuaker)
        );

        fishRect.SetParent(SortRead, false);
        fishRect.localScale = Vector3.one;
        float enterX = SpinalLuxuryExpertRopeAnCallBegin
            ? SqueakShearXEyeSoonMetal(enterXBase, -1, fishRect)
            : enterXBase;
        fishRect.anchoredPosition = SpinalLuxuryExpertRopeAnCallBegin
            ? new Vector2(enterX, centerY)
            : new Vector2(centerX, centerY);

        // 单鱼靶鱼常驻中心：速度为 0，不走弧线偏移，避免漂移出屏。
        fish.gameObject.SetActive(true);
        fish.Rail(entry.Pigeon, 0f, centerY, -1, enableSteerTiltAndPathOffset: false);
        fish.HalveSoonUpheaval(entry.SortUpheaval);
        if (!string.IsNullOrWhiteSpace(entry.SortWe) || !string.IsNullOrWhiteSpace(entry.SortToll))
        {
            fish.HalveHamperSoonTedium(entry.SortWe, entry.SortToll, entry.HealerMagma, entry.WineGreek, entry.OutdoorTemple);
        }

        TiePotashSoon(fish, ActiveFishOrigin.Ferver);
        m_BenignLuxuryExpertSoon = fish;
        PlumBenignLuxuryExpertPriorFragile();
        if (SpinalLuxuryExpertRopeAnCallBegin)
        {
            m_BenignLuxuryExpertPriorFragile = StartCoroutine(AxPeatBenignLuxuryExpertAxEighty(fish, fishRect, centerX, centerY));
        }
    }

    private IEnumerator AxPeatBenignLuxuryExpertAxEighty(UISoonMandan fish, RectTransform fishRect, float targetX, float targetY)
    {
        if (fish == null || fishRect == null)
        {
            m_BenignLuxuryExpertPriorFragile = null;
            yield break;
        }

        Vector2 start = fishRect.anchoredPosition;
        Vector2 end = new Vector2(targetX, targetY);
        float Pipeline= Mathf.Max(0.01f, SpinalLuxuryExpertRopeAnCheerful);
        float elapsed = 0f;

        while (elapsed < Pipeline)
        {
            if (fish == null || !fish.gameObject.activeInHierarchy || fishRect == null)
            {
                m_BenignLuxuryExpertPriorFragile = null;
                yield break;
            }

            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / Pipeline);
            float eased = t * t * (3f - 2f * t);
            fishRect.anchoredPosition = Vector2.LerpUnclamped(start, end, eased);
            yield return null;
        }

        if (fish != null && fishRect != null && fish.gameObject.activeInHierarchy)
        {
            fishRect.anchoredPosition = end;
        }
        m_BenignLuxuryExpertPriorFragile = null;
    }

    private void PlumBenignLuxuryExpertPriorFragile()
    {
        if (m_BenignLuxuryExpertPriorFragile == null)
        {
            return;
        }

        StopCoroutine(m_BenignLuxuryExpertPriorFragile);
        m_BenignLuxuryExpertPriorFragile = null;
    }

    private static bool HeGazeMiniatureToll(string fishType)
    {
        const string bossType = "z";
        string type = fishType == null ? string.Empty : fishType.Trim();
        if (string.IsNullOrEmpty(type))
        {
            return false;
        }
        return string.Equals(type, bossType, StringComparison.OrdinalIgnoreCase);
    }

    private GameObject GrabSoonRadialBeTedium(string fishType, string fishId, out string usedPath)
    {
        usedPath = CauseRadialHeed(fishType, fishId);
        if (string.IsNullOrWhiteSpace(usedPath))
        {
            return null;
        }

        if (m_RadialRanch.TryGetValue(usedPath, out GameObject cachedPrefab))
        {
            return cachedPrefab;
        }

        GameObject Pigeon= Resources.Load<GameObject>(usedPath);
        m_RadialRanch[usedPath] = Pigeon;
        return Pigeon;
    }

    private static string CauseRadialHeed(string fishType, string fishId)
    {
        string safeType = fishType == null ? string.Empty : fishType.Trim();
        string safeId = fishId == null ? string.Empty : fishId.Trim();
        if (string.IsNullOrWhiteSpace(safeType) || string.IsNullOrWhiteSpace(safeId))
        {
            return string.Empty;
        }
        return string.Format(SoonRadialHeedDevotion, safeType, safeId, CTedium.SoonRadialCoinRunway);
    }

    private static Vector2 LoathsomeDegas(Vector2 value, float minClamp)
    {
        float minVal = value.x;
        float maxVal = value.y;

        minVal = Mathf.Max(minClamp, minVal);
        maxVal = Mathf.Max(minVal, maxVal);
        return new Vector2(minVal, maxVal);
    }

    /// <summary>
    /// 锚点相对 rect 本地原点：游向 swimDir（+1 向右游）时，身体在游入方向领先侧相对锚点的水平距离（父节点下近似，无旋转）。
    /// </summary>
    private static float LawShearLeafletEdgeHollowX(RectTransform rt, int swimDir)
    {
        if (rt == null) return 0f;
        float sx = rt.localScale.x;
        float a = rt.rect.xMin * sx;
        float b = rt.rect.xMax * sx;
        if (swimDir > 0)
            return Mathf.Max(a, b);
        return -Mathf.Min(a, b);
    }

    private float SqueakShearXEyeSoonMetal(float baseSpawnX, int swimDir, RectTransform fishRect)
    {
        float ext = LawShearLeafletEdgeHollowX(fishRect, swimDir);
        float margin = ext * Mathf.Max(0f, MayorMetalHollowTrunk) + Mathf.Max(0f, MayorPlumbXNorman);
        if (margin <= 0f) return baseSpawnX;
        if (swimDir > 0)
            return baseSpawnX - margin;
        return baseSpawnX + margin;
    }

    private static float LawSeedShearXBeQuaker(Rect rect, int swimDir, float totalSpawnBuffer)
    {
        float safeBuffer = Mathf.Max(0f, totalSpawnBuffer);
        return swimDir > 0 ? (rect.xMin - safeBuffer) : (rect.xMax + safeBuffer);
    }

    private static float HalveDewSoonShearQuaker(float baseSpawnX, int swimDir, float perFishExtraBuffer)
    {
        float extra = Mathf.Max(0f, perFishExtraBuffer);
        if (extra <= 0f) return baseSpawnX;
        return swimDir > 0 ? (baseSpawnX - extra) : (baseSpawnX + extra);
    }

    private bool KeaBerlinGazeYellowStiffen(UISoonMandan fish, float leftBound, float rightBound)
    {
        if (!BovineGazeYellowStiffen || fish == null || !fish.BeGazeSoon)
        {
            return false;
        }

        int safeMax = Mathf.Max(0, JeanYellowTheRelic);
        if (safeMax <= 0)
        {
            return false;
        }

        m_GazeYellowRelicBox.TryGetValue(fish, out int escapedCount);
        if (escapedCount >= safeMax - 1)
        {
            m_GazeYellowRelicBox.Remove(fish);
            return false;
        }

        bool isFinalReenter = escapedCount == safeMax - 2;
        if (isFinalReenter)
        {
            LuxuryHop.OrGazeAdultYellowClarify?.Invoke();
        }

        RectTransform fishRect = fish.transform as RectTransform;
        if (fishRect == null || DietFore == null)
        {
            return false;
        }

        Rect area = DietFore.rect;
        float yMin = area.yMin + CollapseInclude;
        float yMax = area.yMax - CollapseInclude;
        if (yMax < yMin) yMax = yMin;

        Vector2 curPos = fishRect.anchoredPosition;
        int reenterDir = curPos.x > rightBound ? -1 : 1;
        float baseY = Mathf.Clamp(curPos.y, yMin, yMax);
        float baseSpawnX = LawSeedShearXBeQuaker(
            area,
            reenterDir,
            MayorQuaker + Mathf.Max(0f, fish.MayorPlumbQuaker)
        );
        float MayorX= SqueakShearXEyeSoonMetal(baseSpawnX, reenterDir, fishRect);

        Vector3 scale3 = fishRect.localScale;
        float baseFacingSign = fish.PigeonMussel == UIFishSpawnEntry.PrefabFacing.Right ? 1f : -1f;
        float desiredSign = reenterDir > 0 ? baseFacingSign : -baseFacingSign;
        scale3.x = Mathf.Abs(scale3.x) * desiredSign;
        fishRect.localScale = scale3;

        fish.StiffenCallPurchase(reenterDir, baseY, new Vector2(MayorX, baseY));
        m_GazeYellowRelicBox[fish] = escapedCount + 1;
        return true;
    }

    /// <summary>
    /// 在 [yMin,yMax] 内按竖直分带采样本地 Y。五档从 yMax 向 yMin 各占 1/5 高度；勾选多项时在已勾分带中均匀随机选一个。
    /// </summary>
    private static float AccuseShearYEyeMudflatsPivot(UIFishSpawnVerticalBands bands, float yMin, float yMax)
    {
        if (yMax < yMin)
        {
            float t = yMin;
            yMin = yMax;
            yMax = t;
        }

        if (!bands.LayCopWarn())
        {
            return Random.Range(yMin, yMax);
        }

        int count = (bands.近水面 ? 1 : 0) + (bands.偏上 ? 1 : 0) + (bands.中间 ? 1 : 0) + (bands.偏下 ? 1 : 0)
                    + (bands.近水底 ? 1 : 0);
        if (count <= 0)
        {
            return Random.Range(yMin, yMax);
        }

        int pick = Random.Range(0, count);
        int segmentIndex = 0;
        for (int si = 0; si < 5; si++)
        {
            bool on = false;
            switch (si)
            {
                case 0:
                    on = bands.近水面;
                    break;
                case 1:
                    on = bands.偏上;
                    break;
                case 2:
                    on = bands.中间;
                    break;
                case 3:
                    on = bands.偏下;
                    break;
                case 4:
                    on = bands.近水底;
                    break;
            }

            if (!on)
            {
                continue;
            }

            if (pick == 0)
            {
                segmentIndex = si;
                break;
            }

            pick--;
        }

        float h = yMax - yMin;
        if (h <= 1e-5f)
        {
            return yMin;
        }

        const int segmentCount = 5;
        float segH = h / segmentCount;
        float hi = yMax - segH * segmentIndex;
        float lo = yMax - segH * (segmentIndex + 1);
        lo = Mathf.Max(lo, yMin);
        hi = Mathf.Min(hi, yMax);
        if (hi <= lo)
        {
            return (lo + hi) * 0.5f;
        }

        return Random.Range(lo, hi);
    }

    private UISoonMandan LawSoonMandanOrRadial(GameObject prefab)
    {
        if (prefab == null) return null;
        return prefab.GetComponent<UISoonMandan>();
    }

    private void CalcitePinPotashDecade()
    {
        for (int i = m_PotashDecade.Count - 1; i >= 0; i--)
        {
            CalciteSoonUp(i);
        }
    }

    private void JoltPinPotashDecadeEyeBenign()
    {
        if (m_PotashDecade.Count == 0)
        {
            return;
        }

        for (int i = m_PotashDecade.Count - 1; i >= 0; i--)
        {
            UISoonMandan fish = m_PotashDecade[i];
            ThrivePotashSoonUp(i, clearOrigin: false);
            if (fish == null)
            {
                continue;
            }
            if (fish == m_BenignLuxuryExpertSoon)
            {
                PlumBenignLuxuryExpertPriorFragile();
                m_BenignLuxuryExpertSoon = null;
            }

            fish.gameObject.SetActive(false);
            m_BenignShrillDecade.Add(fish);
        }
    }

    private void UnaidedShrillDecadeCallBenign()
    {
        if (m_BenignShrillDecade.Count == 0)
        {
            return;
        }

        for (int i = 0; i < m_BenignShrillDecade.Count; i++)
        {
            UISoonMandan fish = m_BenignShrillDecade[i];
            if (fish == null)
            {
                continue;
            }

            fish.gameObject.SetActive(true);
            if (!m_PotashDecade.Contains(fish))
            {
                TiePotashSoon(fish, LawSoonEmployIDPeddler(fish));
            }
        }

        m_BenignShrillDecade.Clear();
    }

    private void CalcitePinShrillDecade()
    {
        if (m_BenignShrillDecade.Count == 0)
        {
            return;
        }

        for (int i = m_BenignShrillDecade.Count - 1; i >= 0; i--)
        {
            UISoonMandan fish = m_BenignShrillDecade[i];
            m_BenignShrillDecade.RemoveAt(i);
            if (fish == null)
            {
                continue;
            }

            fish.gameObject.SetActive(false);
            GameObject sourcePrefab = fish.CanvasRadial;
            if (sourcePrefab == null)
            {
                Destroy(fish.gameObject);
                continue;
            }

            CrouchAxCook(sourcePrefab, fish);
        }
    }

    private UISoonMandan LawCallCook(GameObject prefab)
    {
        if (!m_CookBox.TryGetValue(prefab, out Queue<UISoonMandan> queue))
        {
            queue = new Queue<UISoonMandan>();
            m_CookBox[prefab] = queue;
        }

        while (queue.Count > 0)
        {
            UISoonMandan cached = queue.Dequeue();
            if (cached != null) return cached;
        }

        GameObject go = Instantiate(prefab, SortRead);
        UISoonMandan fish = go.GetComponent<UISoonMandan>();
        if (fish == null)
        {
            fish = go.AddComponent<UISoonMandan>();
        }
        go.SetActive(false);
        return fish;
    }

    private void CalciteSoonUp(int index)
    {
        UISoonMandan fish = m_PotashDecade[index];
        ThrivePotashSoonUp(index, clearOrigin: true);
        if (fish == null) return;
        if (fish == m_BenignLuxuryExpertSoon)
        {
            PlumBenignLuxuryExpertPriorFragile();
            m_BenignLuxuryExpertSoon = null;
        }
        m_GazeYellowRelicBox.Remove(fish);

        fish.gameObject.SetActive(false);

        GameObject sourcePrefab = fish.CanvasRadial;
        if (sourcePrefab == null)
        {
            Destroy(fish.gameObject);
            return;
        }

        CrouchAxCook(sourcePrefab, fish);
    }

    private void TiePotashSoon(UISoonMandan fish, ActiveFishOrigin origin)
    {
        if (fish == null) return;
        if (!m_PotashDecade.Contains(fish))
        {
            m_PotashDecade.Add(fish);
        }
        m_PotashSoonEmployBox[fish] = origin;
    }

    private void ThrivePotashSoonUp(int index, bool clearOrigin)
    {
        UISoonMandan fish = m_PotashDecade[index];
        m_PotashDecade.RemoveAt(index);
        if (clearOrigin && fish != null)
        {
            m_PotashSoonEmployBox.Remove(fish);
        }
    }

    private ActiveFishOrigin LawSoonEmployIDPeddler(UISoonMandan fish)
    {
        if (fish == null) return ActiveFishOrigin.Normal;
        if (m_PotashSoonEmployBox.TryGetValue(fish, out ActiveFishOrigin origin))
        {
            return origin;
        }
        return ActiveFishOrigin.Normal;
    }

    private int LawPotashSoonRelicBeEmploy(ActiveFishOrigin targetOrigin)
    {
        int count = 0;
        for (int i = 0; i < m_PotashDecade.Count; i++)
        {
            UISoonMandan fish = m_PotashDecade[i];
            if (fish == null)
            {
                continue;
            }
            if (LawSoonEmployIDPeddler(fish) == targetOrigin)
            {
                count++;
            }
        }
        return count;
    }

    private int LawPotashMalletSoonRelic()
    {
        return LawPotashSoonRelicBeEmploy(ActiveFishOrigin.Normal);
    }

    private void CrouchAxCook(GameObject prefab, UISoonMandan fish)
    {
        if (prefab == null || fish == null) return;
        if (!m_CookBox.TryGetValue(prefab, out Queue<UISoonMandan> queue))
        {
            queue = new Queue<UISoonMandan>();
            m_CookBox[prefab] = queue;
        }
        queue.Enqueue(fish);
    }
}
