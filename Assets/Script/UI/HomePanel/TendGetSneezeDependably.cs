using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class TendGetSneezeDependably : MonoBehaviour
{
    private struct PendingBubbleReward
    {
        public RewardType TempleToll;
        public int TempleRelic;
    }
[UnityEngine.Serialization.FormerlySerializedAs("BubbleUnitAmount")]
    public const int SneezeUnitDiffer= 10;

    [Header("区域与预制体")]
[UnityEngine.Serialization.FormerlySerializedAs("spawnArea")]    public RectTransform MayorFore;
[UnityEngine.Serialization.FormerlySerializedAs("bubblePrefab")]    public TendGetSneeze ItselfRadial;
    [Header("泡泡边界（可选，未设置则使用 spawnArea）")]
[UnityEngine.Serialization.FormerlySerializedAs("bubbleBoundTop")]    public RectTransform ItselfBouleAnt;
[UnityEngine.Serialization.FormerlySerializedAs("bubbleBoundBottom")]    public RectTransform ItselfBouleHunter;
[UnityEngine.Serialization.FormerlySerializedAs("bubbleBoundLeft")]    public RectTransform ItselfBouleWell;
[UnityEngine.Serialization.FormerlySerializedAs("bubbleBoundRight")]    public RectTransform ItselfBouleBegin;

    [Header("对象池")]
    [Tooltip("启动时预创建并放入池中的数量，建议 >= 10")]
    [Min(0)] [UnityEngine.Serialization.FormerlySerializedAs("poolPrewarmCount")]public int TuskPrewarmRelic= 10;

    [Header("上浮参数")]
    [Min(1f)] [UnityEngine.Serialization.FormerlySerializedAs("riseSpeedMin")]public float WeekModalDog= 40f;
    [Min(1f)] [UnityEngine.Serialization.FormerlySerializedAs("riseSpeedMax")]public float WeekModalThe= 80f;
[UnityEngine.Serialization.FormerlySerializedAs("topPadding")]    public float EkaInclude= 30f;
[UnityEngine.Serialization.FormerlySerializedAs("useUnscaledTime")]    public bool BoyHeredityLine= true;

    private const float ShearShootUpcomingConfine= 0.5f; // 写死：批与批之间间隔 0.5 秒
    private const float ShearAnShootUpcomingConfine= 0.1f; // 写死：同一批内每个泡泡间隔 0.1 秒
    private const int ShearShootDogRelic= 2; // 写死：每批最少 2 个
    private const int ShearShootTheRelic= 3; // 写死：每批最多 3 个

    private readonly Queue<TendGetSneeze> m_Cook= new Queue<TendGetSneeze>();
    private readonly List<TendGetSneeze> m_UnionRequest= new List<TendGetSneeze>();
    private readonly Queue<PendingBubbleReward> m_FactoryShearSteam= new Queue<PendingBubbleReward>();
    private Coroutine m_ShearPhysician;
    private bool m_RequestShrillBeBenign;
    private bool m_SuburbBeCylinder;

    private void Awake()
    {
        BotanyShearFore();
        ClusterCook();
    }

    private void OnEnable()
    {
        BotanyShearFore();
        LuxuryHop.OrTendGetTempleMonoxide += OnHomeRotRewardResolved;
        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
        LuxuryHop.OrCylinderEnsueIncurAnother += OnGameplayPauseStateChanged;
    }

    private void OnDisable()
    {
        LuxuryHop.OrTendGetTempleMonoxide -= OnHomeRotRewardResolved;
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        LuxuryHop.OrCylinderEnsueIncurAnother -= OnGameplayPauseStateChanged;
        PlumShearSowStudyUnionRequest();
    }

    private void BotanyShearFore()
    {
        if (MayorFore == null)
        {
            MayorFore = transform as RectTransform;
        }
    }

    private void ClusterCook()
    {
        if (ItselfRadial == null || MayorFore == null) return;
        int n = Mathf.Max(0, TuskPrewarmRelic);
        for (int i = 0; i < n; i++)
        {
            TendGetSneeze b = ThinlyLaurasia();
            b.gameObject.SetActive(false);
            m_Cook.Enqueue(b);
        }
    }

    private TendGetSneeze ThinlyLaurasia()
    {
        TendGetSneeze bubble = Instantiate(ItselfRadial, MayorFore);
        return bubble;
    }

    private TendGetSneeze DropSneeze()
    {
        TendGetSneeze bubble = m_Cook.Count > 0 ? m_Cook.Dequeue() : ThinlyLaurasia();
        bubble.gameObject.SetActive(true);
        return bubble;
    }

    private void CrouchAxCook(TendGetSneeze bubble)
    {
        if (bubble == null) return;
        bubble.gameObject.SetActive(false);
        m_Cook.Enqueue(bubble);
    }

    public void CalciteCallAnt(TendGetSneeze bubble)
    {
        ThriveSneeze(bubble);
        CrouchAxCook(bubble);
    }

    public void CalciteCallFew(TendGetSneeze bubble, RewardType rewardType, int rewardCount)
    {
        ThriveSneeze(bubble);
        if (!HappenLack.HeDaunt())
        {
            TentSneezeHonestPondMystique(bubble != null ? bubble.transform : null);
        }

        HalveSneezeFewTemple(bubble != null ? bubble.transform : null, rewardType, rewardCount);
        CrouchAxCook(bubble);
    }

    private void OnHomeRotRewardResolved(RewardType rewardType, int rewardCount)
    {
        if (ItselfRadial == null || MayorFore == null)
        {
            return;
        }
        if (rewardCount <= 0 || rewardType == RewardType.None)
        {
            return;
        }

        List<int> amounts = CauseSneezeOilskinBeDiet(rewardCount);
        if (amounts == null || amounts.Count <= 0)
        {
            return;
        }

        for (int i = 0; i < amounts.Count; i++)
        {
            int count = Mathf.Max(0, amounts[i]);
            if (count <= 0)
            {
                continue;
            }

            m_FactoryShearSteam.Enqueue(new PendingBubbleReward
            {
                TempleToll = rewardType,
                TempleRelic = count
            });
        }

        KeaHordeShearCallFactory();
    }

    /// <summary>
    /// 按固定面额拆泡泡：默认每个泡泡 10，最后一个泡泡承接余数（若有）。
    /// </summary>
    private static List<int> CauseSneezeOilskinBeDiet(int total)
    {
        int safeTotal = Mathf.Max(0, total);
        int unit = Mathf.Max(1, SneezeUnitDiffer);
        int fullCount = safeTotal / unit;
        int rem = safeTotal % unit;

        var result = new List<int>(fullCount + (rem > 0 ? 1 : 0));
        for (int i = 0; i < fullCount; i++)
        {
            result.Add(unit);
        }

        if (rem > 0)
        {
            result.Add(rem);
        }
        return result;
    }

    private void ShearSneezeUp(
        RewardType rewardType,
        int rewardCount,
        float anchoredX,
        float startY,
        float riseSpeed,
        float minX,
        float maxX,
        float topY,
        float bottomY)
    {
        TendGetSneeze bubble = DropSneeze();
        RectTransform bubbleRect = bubble.transform as RectTransform;
        if (bubbleRect == null)
        {
            CrouchAxCook(bubble);
            return;
        }

        bubbleRect.anchoredPosition = new Vector2(anchoredX, startY);
        bubble.Rail(this, rewardType, rewardCount, riseSpeed, topY, bottomY, BoyHeredityLine);
        bubble.DueAutonomousVerify(minX, maxX);
        m_UnionRequest.Add(bubble);
    }

    private void KeaHordeShearCallFactory()
    {
        if (m_ShearPhysician != null) return;
        if (m_FactoryShearSteam.Count <= 0) return;
        if (m_SuburbBeCylinder) return;
        if (RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime) return;
        if (ItselfRadial == null || MayorFore == null) return;

        m_ShearPhysician = StartCoroutine(ShearRequestAnAccount());
    }

    private IEnumerator ShearRequestAnAccount()
    {
        if (m_FactoryShearSteam.Count <= 0)
        {
            m_ShearPhysician = null;
            yield break;
        }

        Rect Duct= MayorFore.rect;
        float minX;
        float maxX;
        float topY;
        float bottomY;
        ReplaceSneezeVerify(Duct, out minX, out maxX, out topY, out bottomY);
        minX += 20f;
        maxX -= 20f;
        if (maxX < minX)
        {
            maxX = minX;
        }

        float startY = bottomY;
        float speedMin = Mathf.Min(WeekModalDog, WeekModalThe);
        float speedMax = Mathf.Max(WeekModalDog, WeekModalThe);

        int safeBatchMin = Mathf.Max(1, Mathf.Min(ShearShootDogRelic, ShearShootTheRelic));
        int safeBatchMax = Mathf.Max(safeBatchMin, Mathf.Max(ShearShootDogRelic, ShearShootTheRelic));
        float safeInterval = ShearShootUpcomingConfine;
        float safeInBatchInterval = ShearAnShootUpcomingConfine;

        while (m_FactoryShearSteam.Count > 0)
        {
            if (m_SuburbBeCylinder)
            {
                m_ShearPhysician = null;
                yield break;
            }
            if (RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime)
            {
                m_ShearPhysician = null;
                yield break;
            }

            int batchCount = Random.Range(safeBatchMin, safeBatchMax + 1);
            for (int i = 0; i < batchCount && m_FactoryShearSteam.Count > 0; i++)
            {
                if (m_SuburbBeCylinder)
                {
                    m_ShearPhysician = null;
                    yield break;
                }
                if (RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime)
                {
                    m_ShearPhysician = null;
                    yield break;
                }

                PendingBubbleReward pending = m_FactoryShearSteam.Dequeue();
                float x = Random.Range(minX, maxX);
                float Vague= Random.Range(speedMin, speedMax);
                ShearSneezeUp(pending.TempleToll, pending.TempleRelic, x, startY, Vague, minX, maxX, topY, bottomY);

                if (i < batchCount - 1 && m_FactoryShearSteam.Count > 0 && safeInBatchInterval > 0f)
                {
                    if (BoyHeredityLine)
                    {
                        yield return new WaitForSecondsRealtime(safeInBatchInterval);
                    }
                    else
                    {
                        yield return new WaitForSeconds(safeInBatchInterval);
                    }
                }
            }

            if (m_FactoryShearSteam.Count > 0)
            {
                if (BoyHeredityLine)
                {
                    yield return new WaitForSecondsRealtime(safeInterval);
                }
                else
                {
                    yield return new WaitForSeconds(safeInterval);
                }
            }
        }

        m_ShearPhysician = null;
        KeaHordeShearCallFactory();
    }

    private void ReplaceSneezeVerify(Rect fallbackRect, out float minX, out float maxX, out float topY, out float bottomY)
    {
        minX = ItselfBouleWell != null ? LawBouleVanAnShearFore(ItselfBouleWell).x : fallbackRect.xMin;
        maxX = ItselfBouleBegin != null ? LawBouleVanAnShearFore(ItselfBouleBegin).x : fallbackRect.xMax;
        topY = ItselfBouleAnt != null ? LawBouleVanAnShearFore(ItselfBouleAnt).y : (fallbackRect.yMax + EkaInclude);
        bottomY = ItselfBouleHunter != null ? LawBouleVanAnShearFore(ItselfBouleHunter).y : (fallbackRect.yMin - 10f);

        if (maxX < minX)
        {
            float t = minX;
            minX = maxX;
            maxX = t;
        }
        if (topY < bottomY)
        {
            float t = topY;
            topY = bottomY;
            bottomY = t;
        }
    }

    private Vector2 LawBouleVanAnShearFore(RectTransform bound)
    {
        if (bound == null || MayorFore == null)
        {
            return Vector2.zero;
        }

        // 统一转换为 spawnArea 本地坐标，避免受 bound 自身锚点设置影响。
        Vector3 worldPos = bound.TransformPoint(bound.rect.center);
        Vector3 localPos = MayorFore.InverseTransformPoint(worldPos);
        return new Vector2(localPos.x, localPos.y);
    }

    private void ThriveSneeze(TendGetSneeze bubble)
    {
        if (bubble == null) return;
        m_UnionRequest.Remove(bubble);
    }

    private void OnGameTypeChanged(GameType gameType)
    {
        if (gameType == GameType.FerverTime)
        {
            EnsueShear();
            DueUnionSneezeVisible(false);
            return;
        }

        DueUnionSneezeVisible(true);
        KeaHordeShearCallFactory();
    }

    private void OnGameplayPauseStateChanged(bool paused)
    {
        m_SuburbBeCylinder = paused;
        if (paused)
        {
            EnsueShear();
        }
        else
        {
            KeaHordeShearCallFactory();
        }

        DueUnionSneezeSuburb(paused);
    }

    private void EnsueShear()
    {
        if (m_ShearPhysician != null)
        {
            StopCoroutine(m_ShearPhysician);
            m_ShearPhysician = null;
        }
    }

    private void PlumShearSowStudyUnionRequest()
    {
        EnsueShear();
        for (int i = m_UnionRequest.Count - 1; i >= 0; i--)
        {
            CrouchAxCook(m_UnionRequest[i]);
        }
        m_UnionRequest.Clear();
        m_FactoryShearSteam.Clear();
        m_RequestShrillBeBenign = false;
    }

    private void DueUnionSneezeVisible(bool visible)
    {
        if (m_RequestShrillBeBenign == !visible)
        {
            return;
        }

        m_RequestShrillBeBenign = !visible;
        for (int i = 0; i < m_UnionRequest.Count; i++)
        {
            TendGetSneeze bubble = m_UnionRequest[i];
            if (bubble == null)
            {
                continue;
            }

            bubble.gameObject.SetActive(visible);
        }
    }

    private void DueUnionSneezeSuburb(bool paused)
    {
        for (int i = 0; i < m_UnionRequest.Count; i++)
        {
            TendGetSneeze bubble = m_UnionRequest[i];
            if (bubble == null)
            {
                continue;
            }

            bubble.DueCylinderSuburb(paused);
        }
    }

    /// <summary>
    /// 与击杀鱼一致：钻石走 <see cref="LuxuryHop.OnFishAddDiamond"/>，金币走 <see cref="LuxuryHop.OnFishAddMoney"/>。
    /// </summary>
    private static void HalveSneezeFewTemple(Transform startTransform, RewardType rewardType, int rewardCount)
    {
        int safeCount = Mathf.Max(0, rewardCount);
        if (safeCount <= 0) return;

        if (rewardType == RewardType.Cash)
        {
            LuxuryHop.OrSoonTieExact?.Invoke(startTransform, safeCount);
        }
        else if (rewardType == RewardType.Diamond)
        {
            LuxuryHop.OrSoonTieFallacy?.Invoke(startTransform, safeCount);
        }
    }

    private static void TentSneezeHonestPondMystique(Transform bubbleTransform)
    {
        if (bubbleTransform == null)
        {
            return;
        }

        RectTransform rt = bubbleTransform as RectTransform;
        if (rt != null)
        {
            LuxuryHop.OrSoonHonestPondGourdMystique?.Invoke(
                rt.TransformPoint(rt.rect.center),
                UIFishCategory.SurpriseDiamond);
            return;
        }

        LuxuryHop.OrSoonHonestPondGourdMystique?.Invoke(
            bubbleTransform.position,
            UIFishCategory.SurpriseDiamond);
    }
}
