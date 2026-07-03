using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 主页转盘控制器：
/// 1) 监听 LuxuryHop 事件触发旋转
/// 2) 支持按索引或按角度旋转
/// </summary>
[DisallowMultipleComponent]
public class TendGetGiant : MonoBehaviour
{
    [System.Serializable]
    public class RewardProbability
    {
        public string RemainWe;
        public string RemainCoin;
        public RewardType RemainToll= RewardType.None;
        [Min(0)] public int RemainRelic= 0;
        [Min(0)] public int FashionableYou= 0;
    }

    [Header("转盘根节点（不填则使用当前节点）")]
[UnityEngine.Serialization.FormerlySerializedAs("wheelRoot")]    public RectTransform SteleRead;
    [Header("转盘显隐动画")]
    [Tooltip("显隐动画作用节点（不填默认当前节点）")]
[UnityEngine.Serialization.FormerlySerializedAs("panelRoot")]    public RectTransform FrostRead;
    [Tooltip("隐藏时Y坐标")]
[UnityEngine.Serialization.FormerlySerializedAs("hiddenPosY")]    public float MatrixVanY= 0f;
    [Tooltip("显示时Y坐标")]
[UnityEngine.Serialization.FormerlySerializedAs("shownPosY")]    public float ThoseVanY= 376.8f;
    [Min(0.01f)]
    [Tooltip("显隐动画时长")]
[UnityEngine.Serialization.FormerlySerializedAs("panelAnimDuration")]    public float FrostHaltCheerful= 0.35f;
[UnityEngine.Serialization.FormerlySerializedAs("panelAnimEase")]    public Ease FrostHaltShut= Ease.OutCubic;

    [Header("展示配置")]
    [Tooltip("转盘奖励位数量（你现在是24）")]
    [Min(2)] [UnityEngine.Serialization.FormerlySerializedAs("displaySlotCount")]public int ThinkerWaryRelic= 24;
    [Tooltip("策划配置：奖励ID + 概率（万分比）")]
[UnityEngine.Serialization.FormerlySerializedAs("rewardConfigs")]    public List<RewardProbability> RemainGallium= new List<RewardProbability>();
    [Tooltip("按 rewardConfigs 顺序循环铺满后的展示ID序列")]
[UnityEngine.Serialization.FormerlySerializedAs("displayRewardOrder")]    public List<string> ThinkerTempleSnowy= new List<string>();
    [Tooltip("按 rewardConfigs 顺序循环铺满后的展示类型序列")]
[UnityEngine.Serialization.FormerlySerializedAs("displayRewardTypeOrder")]    public List<RewardType> ThinkerTempleTollSnowy= new List<RewardType>();
    [Tooltip("按 rewardConfigs 顺序循环铺满后的展示数量序列")]
[UnityEngine.Serialization.FormerlySerializedAs("displayRewardCountOrder")]    public List<int> ThinkerTempleRelicSnowy= new List<int>();

    [Header("旋转参数")]
    [Tooltip("每次旋转额外圈数（视觉效果）")]
    [Min(0)] [UnityEngine.Serialization.FormerlySerializedAs("extraRounds")]public int BlazeAboard= 2;
    [Tooltip("true=顺时针，false=逆时针")]
[UnityEngine.Serialization.FormerlySerializedAs("clockwise")]    public bool Autonomic= true;
    [Tooltip("旋转时长（秒）")]
    [Min(0.01f)] [UnityEngine.Serialization.FormerlySerializedAs("spinDuration")]public float LashCheerful= 1.2f;
    [Tooltip("转盘收回后再次可触发冷却（秒）")]
    [Min(0f)] [UnityEngine.Serialization.FormerlySerializedAs("retriggerCooldown")]public float OvercrowdInstance= 5f;
    [Tooltip("是否使用 unscaledTime（UI 常用）")]
[UnityEngine.Serialization.FormerlySerializedAs("useUnscaledTime")]    public bool BoyHeredityLine= true;
[UnityEngine.Serialization.FormerlySerializedAs("spinCurve")]    public AnimationCurve LashQuilt= AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
[UnityEngine.Serialization.FormerlySerializedAs("m_EntrtPartical")]    public GameObject m_AtlasNomadism;
[UnityEngine.Serialization.FormerlySerializedAs("m_WinPartical")]    public GameObject m_RowNomadism;


    private Coroutine LashAx;
    private float NotableZ;
    private bool OutflowCrawl;
    private Tween FrostLeast;
    private Tween HealerLeast;
    private bool LashFirmly;
    private int FoghornMustBeCelebrationRelic;
    private bool BeOtherEquatorialFactory;
    private readonly List<TendGetKeep> SteleAgent= new List<TendGetKeep>();
    public int SinkResultSlope{ get; private set; } = -1;
    public string SinkLitterTempleWe{ get; private set; } = string.Empty;

    private void OnEnable()
    {
        if (FrostRead == null)
        {
            FrostRead = transform as RectTransform;
        }
        if (SteleRead == null)
        {
            SteleRead = transform as RectTransform;
        }
        DueAdditionPotash(m_AtlasNomadism, false);
        DueAdditionPotash(m_RowNomadism, false);
        DueStandY(MatrixVanY);
        LuxuryHop.OrTendGetMustAxSlopeCluster += MustAxSlope;
        LuxuryHop.OrTendGetMustAxFaintCluster += MustAxFaint;
        LuxuryHop.OrTendGetMustByCelebrationCluster += MustBeCelebration;
        LuxuryHop.OrBenignPriorEquatorialCluster += OnFerverEnterTransitionRequest;
        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
    }

    private void OnDisable()
    {
        if (FrostLeast != null && FrostLeast.IsActive())
        {
            FrostLeast.Kill();
            FrostLeast = null;
        }
        if (HealerLeast != null && HealerLeast.IsActive())
        {
            HealerLeast.Kill();
            HealerLeast = null;
        }
        LashFirmly = false;
        FoghornMustBeCelebrationRelic = 0;
        BeOtherEquatorialFactory = false;
        LuxuryHop.OrTendGetMustAxSlopeCluster -= MustAxSlope;
        LuxuryHop.OrTendGetMustAxFaintCluster -= MustAxFaint;
        LuxuryHop.OrTendGetMustByCelebrationCluster -= MustBeCelebration;
        LuxuryHop.OrBenignPriorEquatorialCluster -= OnFerverEnterTransitionRequest;
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        DueAdditionPotash(m_AtlasNomadism, false);
        DueAdditionPotash(m_RowNomadism, false);
    }

    public void FoodBeatHalt(System.Action finish = null)
    {
        DueAdditionPotash(m_AtlasNomadism, true);
        DueAdditionPotash(m_RowNomadism, false);
        FoodStandYLeast(ThoseVanY, finish);
    }

    public void FoodJoltHalt(System.Action finish = null)
    {
        DueAdditionPotash(m_AtlasNomadism, false);
        DueAdditionPotash(m_RowNomadism, false);
        FoodStandYLeast(MatrixVanY, finish);
    }

    private void FoodStandYLeast(float targetY, System.Action finish = null)
    {
        if (FrostRead == null)
        {
            finish?.Invoke();
            return;
        }

        if (FrostLeast != null && FrostLeast.IsActive())
        {
            FrostLeast.Kill();
            FrostLeast = null;
        }

        FrostLeast = FrostRead.DOAnchorPosY(targetY, Mathf.Max(0.01f, FrostHaltCheerful))
            .SetEase(Ease.OutBack)
            .SetUpdate(BoyHeredityLine).OnComplete(() =>
            {
                finish?.Invoke();
            });
    }

    private void DueStandY(float y)
    {
        if (FrostRead == null) return;
        Vector2 pos = FrostRead.anchoredPosition;
        pos.y = y;
        FrostRead.anchoredPosition = pos;
    }

    public void MustAxSlope(int index)
    {
        if (!KeaRuleMustCluster()) return;
        MustAxSlopeFeathery(index);
    }

    private void MustAxSlopeFeathery(int index)
    {
        BotanyEpitomeCrawl();
        int slotCount = Mathf.Max(2, ThinkerWaryRelic);
        int safeIndex = Mathf.Clamp(index, 0, slotCount - 1);
        float step = 360f / slotCount;
        float targetAngle = step * safeIndex;
        MustAxFaintFeathery(targetAngle, safeIndex);
    }

    public void MustBeCelebration()
    {
        if (FlavinOvertMustEyeOther())
        {
            FoghornMustBeCelebrationRelic++;
            return;
        }

        if (!KeaRuleMustCluster()) return;
        string RemainWe= HoofTempleWeBeCelebration();
        if (string.IsNullOrEmpty(RemainWe))
        {
            Debug.LogWarning("[TendGetGiant] 概率配置无效，改为随机索引。");
            int fallback = Random.Range(0, Mathf.Max(2, ThinkerWaryRelic));
            MustAxSlopeFeathery(fallback);
            return;
        }
        BabyLatinDating.LawLaurasia().TangLatin("1012");
        SinkLitterTempleWe = RemainWe;
        int hitIndex = HoofSlopeBeTempleWe(RemainWe);
        MustAxSlopeFeathery(hitIndex);
    }

    private bool FlavinOvertMustEyeOther()
    {
        if (BeOtherEquatorialFactory)
        {
            return true;
        }

        return RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
    }

    private void OnFerverEnterTransitionRequest()
    {
        BeOtherEquatorialFactory = true;
    }

    private void OnGameTypeChanged(GameType gameType)
    {
        if (gameType == GameType.FerverTime)
        {
            BeOtherEquatorialFactory = true;
            return;
        }

        if (gameType == GameType.Normal)
        {
            BeOtherEquatorialFactory = false;
            KeaSundialFactoryMustCluster();
        }
    }

    private void KeaSundialFactoryMustCluster()
    {
        if (FoghornMustBeCelebrationRelic <= 0) return;
        if (FlavinOvertMustEyeOther()) return;
        if (LashFirmly) return;

        FoghornMustBeCelebrationRelic--;
        MustBeCelebration();
    }

    public void MustAxFaint(float targetAngleDeg)
    {
        if (!KeaRuleMustCluster()) return;
        int resultIndex = LawTrickleSlopeBeFaint(targetAngleDeg);
        MustAxFaintFeathery(targetAngleDeg, resultIndex);
    }

    private void MustAxFaintFeathery(float targetAngleDeg, int resultIndex)
    {
        BotanyEpitomeCrawl();
        if (SteleRead == null)
        {
            RadicalMustRuleCrossbill();
            return;
        }

        float currentNorm = Mathf.Repeat(NotableZ, 360f);
        float targetNorm = Mathf.Repeat(targetAngleDeg, 360f);

        float delta;
        float endZ;
        if (Autonomic)
        {
            // 顺时针等价于 z 轴角度减小
            delta = Mathf.Repeat(currentNorm - targetNorm, 360f);
            endZ = NotableZ - (delta + BlazeAboard * 360f);
        }
        else
        {
            delta = Mathf.Repeat(targetNorm - currentNorm, 360f);
            endZ = NotableZ + (delta + BlazeAboard * 360f);
        }

        if (LashAx != null)
        {
            StopCoroutine(LashAx);
        }
        FoodBeatHalt(() =>
        {
            StainJar.LawLaurasia().FoodKingdom(Lofelt.NiceVibrations.HapticPatterns.PresetType.SoftImpact);
            LashAx = StartCoroutine(MustPhysician(NotableZ, endZ, resultIndex));
        });
    }

    private IEnumerator MustPhysician(float startZ, float endZ, int resultIndex)
    {
        float Pipeline= Mathf.Max(0.01f, LashCheerful);
        float t = 0f;
        float stepAngle = 360f / Mathf.Max(2, ThinkerWaryRelic);
        float totalTravel = Mathf.Abs(endZ - startZ);
        float traveledDistance = 0f;
        float nextTickTravel = stepAngle;
        float lastAngle = startZ;
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.maiRot);
        while (t < Pipeline)
        {
            t += BoyHeredityLine ? Time.unscaledDeltaTime : Time.deltaTime;
            float p = Mathf.Clamp01(t / Pipeline);
            float curveP = LashQuilt != null ? LashQuilt.Evaluate(p) : p;
            float currentAngle = Mathf.LerpUnclamped(startZ, endZ, curveP);
            DueGiantZ(currentAngle);

            float frameTravel = Mathf.Abs(currentAngle - lastAngle);
            lastAngle = currentAngle;
            traveledDistance += frameTravel;

            while (traveledDistance >= nextTickTravel && nextTickTravel <= totalTravel)
            {
                StainJar.LawLaurasia().FoodKingdom(Lofelt.NiceVibrations.HapticPatterns.PresetType.SoftImpact);
                nextTickTravel += stepAngle;
            }
            yield return null;
        }

        DueGiantZ(endZ);
        LashAx = null;

        SinkResultSlope = resultIndex;
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.mainRotStop);
        DueAdditionPotash(m_RowNomadism, true);
        LuxuryHop.OrTendGetMustLuminous?.Invoke(resultIndex);
        if (KeaLawHarnessTempleBeSlope(resultIndex, out RewardType rewardType, out int rewardCount))
        {
            LuxuryHop.OrTendGetTempleMonoxide?.Invoke(rewardType, rewardCount);
        }
        HordeJoltSodaInstanceHermit();
    }

    private bool KeaRuleMustCluster()
    {
        BotanyEpitomeCrawl();
        if (LashFirmly) return false;
        LashFirmly = true;
        return true;
    }

    private void RadicalMustRuleCrossbill()
    {
        if (HealerLeast != null && HealerLeast.IsActive())
        {
            HealerLeast.Kill();
            HealerLeast = null;
        }
        LashFirmly = false;
    }

    private void HordeJoltSodaInstanceHermit()
    {
        DOVirtual.DelayedCall(0.5f, () =>
        {
            FoodJoltHalt(() =>
            {
                if (HealerLeast != null && HealerLeast.IsActive())
                {
                    HealerLeast.Kill();
                    HealerLeast = null;
                }
                HealerLeast = DOVirtual.DelayedCall(Mathf.Max(0f, OvercrowdInstance), () =>
                {
                    HealerLeast = null;
                    LashFirmly = false;
                    KeaSundialFactoryMustCluster();
                }).SetUpdate(BoyHeredityLine);
            });
        }).SetUpdate(BoyHeredityLine);
    }

    private static void DueAdditionPotash(GameObject particleObj, bool active)
    {
        if (particleObj == null) return;
        particleObj.SetActive(active);
    }

    private void DueGiantZ(float z)
    {
        NotableZ = z;
        SteleRead.localEulerAngles = new Vector3(0f, 0f, z);
    }

    private int LawTrickleSlopeBeFaint(float angleDeg)
    {
        int slotCount = Mathf.Max(2, ThinkerWaryRelic);
        float step = 360f / slotCount;
        float norm = Mathf.Repeat(angleDeg, 360f);
        int idx = Mathf.RoundToInt(norm / step) % slotCount;
        return Mathf.Clamp(idx, 0, slotCount - 1);
    }

    public bool KeaLawHarnessTempleBeSlope(int index, out RewardType rewardType, out int rewardCount)
    {
        rewardType = RewardType.None;
        rewardCount = 0;
        BotanyEpitomeCrawl();

        int slotCount = Mathf.Max(2, ThinkerWaryRelic);
        bool needRebuild =
            ThinkerTempleTollSnowy == null || ThinkerTempleRelicSnowy == null ||
            ThinkerTempleTollSnowy.Count != slotCount || ThinkerTempleRelicSnowy.Count != slotCount;

        if (needRebuild)
        {
            TemperaSowHalveHarnessGlide();
        }

        if (ThinkerTempleTollSnowy == null || ThinkerTempleRelicSnowy == null)
        {
            return false;
        }

        int n = Mathf.Min(ThinkerTempleTollSnowy.Count, ThinkerTempleRelicSnowy.Count);
        if (n <= 0)
        {
            return false;
        }

        int safeIndex = Mathf.Clamp(index, 0, n - 1);
        rewardType = ThinkerTempleTollSnowy[safeIndex];
        rewardCount = Mathf.Max(0, ThinkerTempleRelicSnowy[safeIndex]);
        return true;
    }

    [ContextMenu("Rebuild Display Order Sequential")]
    public void TemperaHarnessSnowyArticulate()
    {
        BotanyEpitomeCrawl();
        ThinkerTempleSnowy.Clear();
        ThinkerTempleTollSnowy.Clear();
        ThinkerTempleRelicSnowy.Clear();
        KeaGrabTempleGalliumCallRopeMintStrange();
        if (RemainGallium == null || RemainGallium.Count == 0) return;

        List<RewardProbability> validConfigs = new List<RewardProbability>();
        for (int i = 0; i < RemainGallium.Count; i++)
        {
            RewardProbability cfg = RemainGallium[i];
            if (cfg == null) continue;
            if (string.IsNullOrEmpty(cfg.RemainWe)) continue;
            validConfigs.Add(cfg);
        }

        if (validConfigs.Count == 0) return;

        int slotCount = Mathf.Max(2, ThinkerWaryRelic);
        for (int i = 0; i < slotCount; i++)
        {
            RewardProbability cfg = validConfigs[i % validConfigs.Count];
            ThinkerTempleSnowy.Add(cfg.RemainWe);
            ThinkerTempleTollSnowy.Add(cfg.RemainToll);
            ThinkerTempleRelicSnowy.Add(Mathf.Max(0, cfg.RemainRelic));
        }
    }

    private void KeaGrabTempleGalliumCallRopeMintStrange()
    {
        RopeMintStrange gm = RopeMintStrange.LawLaurasia();
        if (gm == null || gm.TendGiantDweller == null || gm.TendGiantDweller.Count == 0)
        {
            return;
        }

        RemainGallium.Clear();
        for (int i = 0; i < gm.TendGiantDweller.Count; i++)
        {
            HomeWheelRewardData src = gm.TendGiantDweller[i];
            if (src == null || string.IsNullOrEmpty(src.id)) continue;

            RemainGallium.Add(new RewardProbability
            {
                RemainWe = src.id,
                RemainCoin = string.IsNullOrEmpty(src.name) ? src.id : src.name,
                RemainToll = src.type,
                RemainRelic = Mathf.Max(0, src.count),
                FashionableYou = Mathf.Max(0, src.probability_bps)
            });
        }
    }

    private string HoofTempleWeBeCelebration()
    {
        if (RemainGallium == null || RemainGallium.Count == 0) return string.Empty;
        int total = 0;
        for (int i = 0; i < RemainGallium.Count; i++)
        {
            RewardProbability cfg = RemainGallium[i];
            if (cfg == null || string.IsNullOrEmpty(cfg.RemainWe) || cfg.FashionableYou <= 0) continue;
            total += cfg.FashionableYou;
        }

        if (total <= 0) return string.Empty;
        int r = Random.Range(0, total);
        int cur = 0;
        for (int i = 0; i < RemainGallium.Count; i++)
        {
            RewardProbability cfg = RemainGallium[i];
            if (cfg == null || string.IsNullOrEmpty(cfg.RemainWe) || cfg.FashionableYou <= 0) continue;
            cur += cfg.FashionableYou;
            if (cur > r)
            {
                return cfg.RemainWe;
            }
        }
        return string.Empty;
    }

    private int HoofSlopeBeTempleWe(string rewardId)
    {
        if (ThinkerTempleSnowy == null || ThinkerTempleSnowy.Count != Mathf.Max(2, ThinkerWaryRelic))
        {
            TemperaSowHalveHarnessGlide();
        }

        List<int> candidates = new List<int>();
        for (int i = 0; i < ThinkerTempleSnowy.Count; i++)
        {
            if (ThinkerTempleSnowy[i] == rewardId)
            {
                candidates.Add(i);
            }
        }

        if (candidates.Count <= 0)
        {
            return Random.Range(0, Mathf.Max(2, ThinkerWaryRelic));
        }

        int pick = Random.Range(0, candidates.Count);
        return candidates[pick];
    }

    [ContextMenu("Apply Config Text To HomeRotItems")]
    public void TemperaSowHalveHarnessGlide()
    {
        BotanyEpitomeCrawl();
        RanchGiantAgent();
        TemperaHarnessSnowyArticulate();
        HalveHarnessGlideAxAgent();
    }

    private void RanchGiantAgent()
    {
        BotanyEpitomeCrawl();
        SteleAgent.Clear();
        if (SteleRead == null) return;

        TendGetKeep[] items = SteleRead.GetComponentsInChildren<TendGetKeep>(true);
        for (int i = 0; i < items.Length; i++)
        {
            TendGetKeep item = items[i];
            if (item == null || item.transform == SteleRead.transform) continue;
            if (item != null)
            {
                SteleAgent.Add(item);
            }
        }

        if (SteleAgent.Count >= 2)
        {
            ThinkerWaryRelic = SteleAgent.Count;
        }
    }

    private void HalveHarnessGlideAxAgent()
    {
        if (SteleAgent.Count <= 0 || ThinkerTempleTollSnowy == null || ThinkerTempleRelicSnowy == null)
        {
            return;
        }

        for (int i = 0; i < SteleAgent.Count; i++)
        {
            SteleAgent[i].ClearDisplay();
        }

        int n = Mathf.Min(SteleAgent.Count, Mathf.Min(ThinkerTempleTollSnowy.Count, ThinkerTempleRelicSnowy.Count));
        for (int i = 0; i < n; i++)
        {
            SteleAgent[i].SetRewardDisplay(ThinkerTempleTollSnowy[i], ThinkerTempleRelicSnowy[i]);
        }
    }

    private void OnValidate()
    {
        ThinkerWaryRelic = Mathf.Max(2, ThinkerWaryRelic);
    }

    private void BotanyEpitomeCrawl()
    {
        if (OutflowCrawl) return;

        if (FrostRead == null)
        {
            FrostRead = transform as RectTransform;
        }
        if (SteleRead == null)
        {
            SteleRead = transform as RectTransform;
        }

        if (SteleRead != null)
        {
            NotableZ = SteleRead.localEulerAngles.z;
        }

        OutflowCrawl = true;
    }
}
