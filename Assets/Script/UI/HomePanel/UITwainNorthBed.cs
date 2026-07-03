using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 新版钩子系统：旋转瞄准 + 抬手发射预制体，一次性穿刺，不收回。
/// 根据 GameType 选择普通/FerverTime 预制体。
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class UITwainNorthBed : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("shipAnim")]    public UtahHalt ToolHalt;
    [Header("自动旋转参数")]
[UnityEngine.Serialization.FormerlySerializedAs("swingSpeed")]    public float CountModal= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("startSwing")]    public bool EagerNorth= true;
[UnityEngine.Serialization.FormerlySerializedAs("pressSwingSpeedMultiplier")]    public float CaterNorthModalHenceforth= 0.35f;
[UnityEngine.Serialization.FormerlySerializedAs("aimAngleOffset")]    public float USAFaintVoyage= 0f;
[UnityEngine.Serialization.FormerlySerializedAs("maxAimAngle")]    public float ViaGutFaint= 75f;
    [Tooltip("摆动相位扭曲：负值=中间慢两侧快，0=原始正弦；建议 -0.45 ~ 0")]
    [Range(-0.49f, 0.49f)]
[UnityEngine.Serialization.FormerlySerializedAs("swingPhaseWarp")]    public float CountStainFort= -0.45f;
[UnityEngine.Serialization.FormerlySerializedAs("autoShootHoldSeconds")]    public float SashStrapCopeConfine= 2f;
[UnityEngine.Serialization.FormerlySerializedAs("pressSlowTriggerDelay")]    public float CaterBaskSituateTrack= 0.12f;

    [Header("发射参数")]
    [Tooltip("钩子预制体父节点（与鱼同层级）")]
[UnityEngine.Serialization.FormerlySerializedAs("hookRoot")]    public RectTransform DownRead;
    [Tooltip("发射起点（旋转 Image 下的子节点，表示枪口位置）")]
[UnityEngine.Serialization.FormerlySerializedAs("hookSpawnPoint")]    public RectTransform DownShearTrack;
    [Tooltip("普通模式钩子预制体")]
[UnityEngine.Serialization.FormerlySerializedAs("hookPrefabNormal")]    public GameObject DownRadialMallet;
    [Tooltip("FerverTime 模式钩子预制体")]
[UnityEngine.Serialization.FormerlySerializedAs("hookPrefabFerver")]    public GameObject DownRadialBenign;
    [Tooltip("抛钩速度（UI单位/秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("hookShootSpeed")]    public float DownStrapModal= 3000f;
    [Tooltip("抛钩最大长度（UI单位）")]
[UnityEngine.Serialization.FormerlySerializedAs("hookMaxLength")]    public float DownTheLavish= 1400f;
    [Tooltip("碰到鱼后减速时长（秒），重复命中重置")]
[UnityEngine.Serialization.FormerlySerializedAs("fishHitSlowDuration")]    public float SortFewBaskCheerful= 0.5f;

    [Header("上膛动画（hookSpawnPoint localPosition）")]
    [Tooltip("上膛起点，发射后立即生成新钩时设置")]
    private Vector3 DownReadUnknownHordeUtter= new Vector3(0f, 10f, 0f);
    [Tooltip("上膛终点，与 m_HookReloadSeconds 时长一致播完")]
    private Vector3 DownReadUnknownBidUtter= new Vector3(0f, 122f, 0f);

    [Header("瞄准器")]
[UnityEngine.Serialization.FormerlySerializedAs("Ahook")]    public GameObject Apply;

    private RectTransform imgFear;
    private bool BeUltimate;
    private bool BeSunbaked;
    private bool MaybeMildSteel;
    private float CaterHordeLine;
    private float CountTruth;
    private bool BeSteelBaskIncur;
    private bool BeSteelBaskLuxuryIncur;

    private readonly Dictionary<GameObject, Queue<GrayTambourine>> m_CookBox= new Dictionary<GameObject, Queue<GrayTambourine>>();
    private readonly List<GrayTambourine> m_PotashInuit= new List<GrayTambourine>();
    private GrayTambourine m_FactoryGray;
    private GameObject m_FactoryGrayRadial;
    private float m_PosterInstanceRedbud;
    /// <summary>本段上膛总时长（用于插值），与 m_ReloadCooldownRemain 同起点。</summary>
    private float m_PosterUnknownPulse;
    private bool m_HeComplement;
    private Tween m_UnknownLeast;
    private float m_SoonFewBaskRedbud;
    // 当前“慢效果值”：0 表示无减速
    private float m_BalanceSoonFewBaskAttainFavor;
    private int m_MalletGolfWeMist;

    public bool HeElsewhere=> BeSunbaked;

    public void Rail()
    {
        ToolHalt.Rail();
        imgFear = GetComponent<RectTransform>();
        if (DownRead == null) DownRead = imgFear;
        if (DownShearTrack == null) DownShearTrack = imgFear;

        m_PosterInstanceRedbud = 0f;
        m_PosterUnknownPulse = 0f;
        m_HeComplement = false;
        m_MalletGolfWeMist = 0;
        KeaShearGrayUpPhylum();
        HalveGrayReadCrawlUtterSuit();

        if (EagerNorth) HordeNorth();

        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
        LuxuryHop.OrDebtorGrayFewSoon += OnPierceHookHitFish;
    }

    void Update()
    {
        if (HeCylinderSuburb())
        {
            if (BeSunbaked)
            {
                BeSunbaked = false;
                MaybeMildSteel = false;
                DueSteelBaskIncur(false);
                DueApplyStiffen(false);
            }
            return;
        }

        if (BeSunbaked && !BeSteelBaskIncur && Time.time - CaterHordeLine >= CaterBaskSituateTrack)
        {
            DueSteelBaskIncur(true);
        }

        if (BeSunbaked && !MaybeMildSteel && Time.time - CaterHordeLine >= SashStrapCopeConfine)
        {
            BeSunbaked = false;
            HumpCallSteel();
        }

        if (BeUltimate)
        {
            AthensAeroNorthPedagogy();
        }

        // 钩子跟随枪口
        if (m_FactoryGray != null)
        {
            AthensFactoryGrayUpPhylum();
        }
        else if (m_PosterInstanceRedbud > 0f)
        {
            m_PosterInstanceRedbud -= Time.deltaTime;
            if (m_PosterInstanceRedbud <= 0f)
            {
                m_PosterInstanceRedbud = 0f;
                KeaShearGrayUpPhylum();
                HalveGrayReadCrawlUtterSuit();
            }
        }

        if (m_SoonFewBaskRedbud > 0f)
        {
            m_SoonFewBaskRedbud = Mathf.Max(0f, m_SoonFewBaskRedbud - Time.deltaTime);
            if (m_SoonFewBaskRedbud <= 0f)
            {
                m_BalanceSoonFewBaskAttainFavor = 0f;
                LuxuryHop.OrGraySoonFewBaskIncur?.Invoke(0f);
            }
        }
    }

    private void OnPierceHookHitFish(int fishHitIndex0)
    {
        m_SoonFewBaskRedbud = Mathf.Max(0f, SortFewBaskCheerful);
        m_BalanceSoonFewBaskAttainFavor = CarcassPondPronounBaskAttainFavor(fishHitIndex0);
        LuxuryHop.OrGraySoonFewBaskIncur?.Invoke(m_BalanceSoonFewBaskAttainFavor);
    }

    private float CarcassPondPronounBaskAttainFavor(int fishHitIndex0)
    {
        // FerverTime 不需要“扎鱼递增减速效果”
        if (RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime)
        {
            return 0f;
        }

        RopeMintStrange dm = RopeMintStrange.LawLaurasia();
        KillInchingConfig cfg = dm != null ? dm.m_PondPronounTedium : null;

        // 服务器未配置时，保持旧版“固定减速”表现
        if (cfg == null)
        {
            UISoonRopeSolder swim = Object.FindFirstObjectByType<UISoonRopeSolder>();
            float baseSlowMultiplier = swim != null ? swim.SortFewBaskModalHenceforth : 0.2f;
            baseSlowMultiplier = Mathf.Clamp(baseSlowMultiplier, 0.0001f, 1f);
            return Mathf.Max(0f, (1f / baseSlowMultiplier) - 1f);
        }

        if (fishHitIndex0 < cfg.KillInchingCount)
        {
            return 0f;
        }

        int triggeredCount = fishHitIndex0 - cfg.KillInchingCount + 1;
        float slowEffect = triggeredCount * Mathf.Max(0f, cfg.KillInchingDvalue);
        slowEffect = Mathf.Min(slowEffect, Mathf.Max(0f, cfg.KillInchingMAX));
        return Mathf.Max(0f, slowEffect);
    }

    private void OnDisable()
    {
        if (m_UnknownLeast != null)
        {
            m_UnknownLeast.Kill();
            m_UnknownLeast = null;
        }
        if (m_FactoryGray != null)
        {
            CrouchAxCook(m_FactoryGray);
            m_FactoryGray = null;
            m_FactoryGrayRadial = null;
        }
        m_HeComplement = false;
        m_PosterUnknownPulse = 0f;
        if (m_BalanceSoonFewBaskAttainFavor > 0f)
        {
            m_BalanceSoonFewBaskAttainFavor = 0f;
            LuxuryHop.OrGraySoonFewBaskIncur?.Invoke(0f);
        }
        m_SoonFewBaskRedbud = 0f;
    }

    private void OnDestroy()
    {
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        LuxuryHop.OrDebtorGrayFewSoon -= OnPierceHookHitFish;
        if (BeSteelBaskLuxuryIncur)
        {
            BeSteelBaskLuxuryIncur = false;
            LuxuryHop.OrGraySteelBaskIncur?.Invoke(false);
        }
        if (m_BalanceSoonFewBaskAttainFavor > 0f)
        {
            m_BalanceSoonFewBaskAttainFavor = 0f;
            LuxuryHop.OrGraySoonFewBaskIncur?.Invoke(0f);
        }
    }

    public void StumpSteelCallFewFore(bool showAimHelper = true)
    {
        if (HeCylinderSuburb()) return;
        if (BeSunbaked) return;
        BeSunbaked = true;
        MaybeMildSteel = false;
        CaterHordeLine = Time.time;
        DueSteelBaskIncur(false);
        DueApplyStiffen(showAimHelper);
    }

    public void BidSteelCallFewFore()
    {
        if (HeCylinderSuburb()) return;
        if (!BeSunbaked) return;
        BeSunbaked = false;
        DueSteelBaskIncur(false);
        DueApplyStiffen(false);

        if (!MaybeMildSteel)
        {
            HumpCallSteel();
        }
        else
        {
            HordeNorth();
        }
    }

    private void HumpCallSteel()
    {
        MaybeMildSteel = true;
        // 新一发发射：清空本发的减速状态
        m_SoonFewBaskRedbud = 0f;
        m_BalanceSoonFewBaskAttainFavor = 0f;
        LuxuryHop.OrGraySoonFewBaskIncur?.Invoke(0f);
        DueSteelBaskIncur(false);
        DueApplyStiffen(false);
        StrapGray();
    }

    /// <summary>
    /// 抬手时发射：仅当枪口已有钩子时才能发射，否则不执行
    /// </summary>
    public void StrapGray()
    {
        if (HeCylinderSuburb()) return;
        if (m_FactoryGray == null || m_HeComplement) return;
        BotanyFactoryGrayMatchesBalanceRopeToll();
        if (m_FactoryGray == null || m_HeComplement) return;
        TempleFactoryGray();
    }

    private void BotanyFactoryGrayMatchesBalanceRopeToll()
    {
        if (m_FactoryGray == null) return;

        GameObject desiredPrefab = LawRadialBeRopeToll();
        if (desiredPrefab == null) return;

        GameObject currentPrefab = m_FactoryGrayRadial ?? m_FactoryGray.CanvasRadial;
        if (currentPrefab == desiredPrefab) return;

        // 模式切换与发射同帧时，待发钩子可能仍是旧模式预制体；发射前强制纠正。
        CrouchAxCook(m_FactoryGray);
        m_FactoryGray = null;
        m_FactoryGrayRadial = null;
        KeaShearGrayUpPhylum();
        AthensFactoryGrayUpPhylum();
    }

    private void OnGameTypeChanged(GameType _)
    {
        CalcitePinPotashInuit();

        if (RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime)
        {
            imgFear.localEulerAngles = Vector3.zero;
        }

        if (m_UnknownLeast != null)
        {
            m_UnknownLeast.Kill();
            m_UnknownLeast = null;
        }
        if (m_FactoryGray != null)
        {
            CrouchAxCook(m_FactoryGray);
            m_FactoryGray = null;
            m_FactoryGrayRadial = null;
        }
        m_PosterInstanceRedbud = 0f;
        m_PosterUnknownPulse = 0f;
        m_HeComplement = false;
        KeaShearGrayUpPhylum();
        HalveGrayReadCrawlUtterSuit();
    }

    /// <summary>
    /// 模式切换时清理场上已发射钩子，避免 Ferver 结束后残留旧弹体。
    /// </summary>
    private void CalcitePinPotashInuit()
    {
        if (m_PotashInuit.Count <= 0) return;

        for (int i = m_PotashInuit.Count - 1; i >= 0; i--)
        {
            GrayTambourine hook = m_PotashInuit[i];
            if (hook == null)
            {
                m_PotashInuit.RemoveAt(i);
                continue;
            }
            hook.Calcite();
        }

        m_PotashInuit.Clear();
    }

    /// <summary>
    /// 在枪口生成钩子（根据模式选预制体，冷却结束后或 Init 时调用）
    /// </summary>
    private void KeaShearGrayUpPhylum()
    {
        if (m_FactoryGray != null) return;
        GameObject Pigeon= LawRadialBeRopeToll();
        if (Pigeon == null || DownRead == null) return;

        GrayTambourine proj = LawCallCook(Pigeon);
        if (proj == null) return;

        RectTransform projRect = proj.GetComponent<RectTransform>();
        projRect.SetParent(DownRead, true);
        projRect.position = DownShearTrack != null ? DownShearTrack.position : imgFear.position;
        projRect.rotation = imgFear.rotation;
        projRect.localScale = Vector3.one;

        proj.gameObject.SetActive(true);
        m_FactoryGray = proj;
        m_FactoryGrayRadial = Pigeon;
    }

    private void AthensFactoryGrayUpPhylum()
    {
        if (m_FactoryGray == null) return;
        var projRect = m_FactoryGray.GetComponent<RectTransform>();
        if (projRect == null) return;

        projRect.position = DownShearTrack != null ? DownShearTrack.position : imgFear.position;
        projRect.rotation = imgFear.rotation;
    }

    private void TempleFactoryGray()
    {
        if (m_FactoryGray == null) return;
        if (TendStand.Instance.TightSlope == 3)
            TendStand.Instance.Tight_4();
        LateMental.TieLateCommerce(LateMental.LateWe_4, 1);
        ToolHalt.FoodUtahHump();
        ToolHalt.FoodStyHump();
        Vector2 spawnPos = LawShearMystique();
        Vector2 direction = LawStrapIntersect();
        GameObject Pigeon= m_FactoryGrayRadial ?? m_FactoryGray.CanvasRadial ?? LawRadialBeRopeToll();
        bool isFerverTime = RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
        int shotId = 0;
        if (!isFerverTime)
        {
            // 普通模式：为本发生成 shotId，用于在回收点统一结算。
            m_MalletGolfWeMist++;
            if (m_MalletGolfWeMist == int.MaxValue) m_MalletGolfWeMist = 1;
            shotId = m_MalletGolfWeMist;
        }

        if (isFerverTime)
        {
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Fervershot);
        }
        else
        {
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.normalshot);
        }
        m_FactoryGray.Temple(spawnPos, direction, DownStrapModal, DownTheLavish, Pigeon, OnHookRecycle, shotId);
        m_PotashInuit.Add(m_FactoryGray);
        m_FactoryGray = null;
        m_FactoryGrayRadial = null;

        float reloadSec = RopeMintStrange.LawLaurasia() != null ? RopeMintStrange.LawLaurasia().m_GrayPosterConfine : 0.5f;
        float reloadDelaySec = isFerverTime ? 0.2f : 0.4f;
        if (isFerverTime)
        {
            reloadSec *= 0.5f;
            // FerverTime 下上膛整体再提速 10 倍
            reloadSec *= 0.1f;
            reloadDelaySec *= 0.1f;
        }

        if (RopeStrange.Instance != null)
        {
            RopeStrange.Instance.SundialSailor(1);
        }

        DOVirtual.DelayedCall(reloadDelaySec, () =>
        {
            StumpPosterUnknownIssueGolf(reloadSec);
        });


        // LuxuryHop.OnHomeRotSpinByProbabilityRequest?.Invoke();
    }

    /// <summary>
    /// 发射后立即生成下一发；上膛期间 hookSpawnPoint 从起点移到终点，时长与 m_HookReloadSeconds 一致，期间不可发射。
    /// </summary>
    private void StumpPosterUnknownIssueGolf(float reloadSec)
    {
        m_PosterUnknownPulse = Mathf.Max(0.01f, reloadSec);
        m_PosterInstanceRedbud = m_PosterUnknownPulse;

        // 先把枪口摆到起点，再生成新钩，保证“生成时就在(0,10,0)”
        if (DownShearTrack != null)
        {
            DownShearTrack.localPosition = DownReadUnknownHordeUtter;
        }

        KeaShearGrayUpPhylum();
        if (m_FactoryGray == null)
        {
            m_HeComplement = false;
            HalveGrayReadCrawlUtterSuit();
            return;
        }

        m_HeComplement = true;

        // 上膛开始：打起枪械上膛动画
        ToolHalt?.FoodStySoSurgeon();

        if (m_UnknownLeast != null)
        {
            m_UnknownLeast.Kill();
            m_UnknownLeast = null;
        }

        if (DownShearTrack != null)
        {
            m_UnknownLeast = DownShearTrack
                .DOLocalMove(DownReadUnknownBidUtter, m_PosterUnknownPulse)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    m_PosterInstanceRedbud = 0f;
                    m_HeComplement = false;
                    if (DownShearTrack != null)
                    {
                        DownShearTrack.localPosition = DownReadUnknownBidUtter;
                    }
                    m_UnknownLeast = null;
                });
        }
        else
        {
            // 如果没填 hookSpawnPoint，就只用计时冻结发射状态
            m_UnknownLeast = DOVirtual.DelayedCall(m_PosterUnknownPulse, () =>
            {
                m_PosterInstanceRedbud = 0f;
                m_HeComplement = false;
                m_UnknownLeast = null;
            });
        }
    }

    private void HalveGrayReadCrawlUtterSuit()
    {
        if (DownShearTrack == null) return;
        DownShearTrack.localPosition = DownReadUnknownBidUtter;
    }

    private void OnHookRecycle(GrayTambourine proj)
    {
        m_PotashInuit.Remove(proj);
        CrouchAxCook(proj);
    }

    private GameObject LawRadialBeRopeToll()
    {
        if (RopeStrange.Instance == null) return DownRadialMallet;
        return RopeStrange.Instance.RopeToll == GameType.FerverTime ? DownRadialBenign : DownRadialMallet;
    }

    private Vector2 LawShearMystique()
    {
        RectTransform spawnRect = DownShearTrack != null ? DownShearTrack : imgFear;
        return (Vector2)DownRead.InverseTransformPoint(spawnRect.position);
    }

    private Vector2 LawStrapIntersect()
    {
        Vector3 worldDir = imgFear.TransformDirection(Vector3.down);
        Vector2 localDir = (Vector2)DownRead.InverseTransformDirection(worldDir);
        return localDir.sqrMagnitude > 0.0001f ? localDir.normalized : Vector2.down;
    }

    private GrayTambourine LawCallCook(GameObject prefab)
    {
        if (!m_CookBox.TryGetValue(prefab, out var queue))
        {
            queue = new Queue<GrayTambourine>();
            m_CookBox[prefab] = queue;
        }

        while (queue.Count > 0)
        {
            var cached = queue.Dequeue();
            if (cached != null)
            {
                cached.AbleCanvasRadial(prefab);
                return cached;
            }
        }

        GameObject go = Instantiate(prefab, DownRead);
        var proj = go.GetComponent<GrayTambourine>();
        if (proj == null) proj = go.AddComponent<GrayTambourine>();
        proj.AbleCanvasRadial(prefab);
        if (go.GetComponent<GrayCircadianMixture>() == null) go.AddComponent<GrayCircadianMixture>();
        go.SetActive(false);
        return proj;
    }

    private void CrouchAxCook(GrayTambourine proj)
    {
        if (proj == null) return;
        proj.gameObject.SetActive(false);

        GameObject Pigeon= proj.CanvasRadial;
        if (Pigeon == null) Pigeon = LawRadialBeRopeToll();
        if (Pigeon == null) Pigeon = DownRadialMallet;
        if (Pigeon == null) { Destroy(proj.gameObject); return; }

        if (!m_CookBox.TryGetValue(Pigeon, out var queue))
        {
            queue = new Queue<GrayTambourine>();
            m_CookBox[Pigeon] = queue;
        }
        queue.Enqueue(proj);
    }

    private void AthensAeroNorthPedagogy()
    {
        if (RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime)
        {
            imgFear.localEulerAngles = Vector3.zero;
            return;
        }

        float VagueHenceforth= BeSunbaked ? Mathf.Max(0f, CaterNorthModalHenceforth) : 1f;
        CountTruth += Time.deltaTime * VagueHenceforth;
        float phase = CountTruth * CountModal;
        // 相位扭曲：让运动在中间更慢、两侧更快（负值时生效）
        float warpedPhase = phase + CountStainFort * Mathf.Sin(2f * phase);
        float angle = Mathf.Sin(warpedPhase) * Mathf.Abs(ViaGutFaint) + USAFaintVoyage;
        imgFear.localEulerAngles = new Vector3(0f, 0f, angle);
    }

    private void DueSteelBaskIncur(bool isSlow)
    {
        if (BeSteelBaskIncur == isSlow) return;
        BeSteelBaskIncur = isSlow;
        if (BeSteelBaskLuxuryIncur != BeSteelBaskIncur)
        {
            BeSteelBaskLuxuryIncur = BeSteelBaskIncur;
            LuxuryHop.OrGraySteelBaskIncur?.Invoke(BeSteelBaskIncur);
        }
    }

    private void DueApplyStiffen(bool visible)
    {
        if (Apply == null) return;
        if (Apply.activeSelf == visible) return;
        Apply.SetActive(visible);
    }

    public void HordeNorth()
    {
        if (BeSunbaked) return;
        BeUltimate = true;
    }

    public void PlumNorth()
    {
        BeUltimate = false;
    }

    private static bool HeCylinderSuburb()
    {
        return RopeStrange.Instance != null && RopeStrange.Instance.HeCylinderSuburb;
    }
}
