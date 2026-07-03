using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HisRowStand : SeedUIHouse
{
    public class OpenArgs
    {
        public double Scout;
        public bool fromGazeSoonStint;
        public string IfLatinWe;
    }
[UnityEngine.Serialization.FormerlySerializedAs("m_CloseBtn")]
    public Button m_DriftTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_CleamBtn")]    public Button m_GripeTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_ADCleamBtn")]    public Button m_ADGripeTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_SlotGroup")]
    public WaryKenya m_WaryKenya;
    [Tooltip("大奖金额文本（可选）")]
[UnityEngine.Serialization.FormerlySerializedAs("m_RewardText")]    public TextMeshProUGUI m_TempleBode;
    [Tooltip("激励视频埋点ID")]
[UnityEngine.Serialization.FormerlySerializedAs("m_AdEventId")]    public string m_AdLatinWe= "1007";

    private double m_SeedTemple;
    private double m_BalanceTemple;
    private bool m_CallGazeSoonStint;
    private bool m_TraderLuxurySpot;
    private string m_PeddlerSoLatinWe;
[UnityEngine.Serialization.FormerlySerializedAs("m_ShipSkeleton")]    public SkeletonGraphic m_UtahPossible;
[UnityEngine.Serialization.FormerlySerializedAs("m_Light")]    public GameObject m_Party;
[UnityEngine.Serialization.FormerlySerializedAs("m_money")]
    public RectTransform m_Scout;
[UnityEngine.Serialization.FormerlySerializedAs("m_slot")]    public RectTransform m_Beau;
[UnityEngine.Serialization.FormerlySerializedAs("m_adbtn")]    public RectTransform m_Canal;
[UnityEngine.Serialization.FormerlySerializedAs("m_getbtn")]    public RectTransform m_Cheese;

    private const int k_UtahShieldBridgeParty= 70;
    private const int k_BravelyShield= 5;
    private const float k_ImpressYou= 60f;
    private const float k_VarietyWildlifeYVoyage= 200f;
    private const float k_PartySowInnerPriorTrack= 0.35f;
    private const float k_PeatCheerful= 0.22f;
    private const float k_TrunkSoCheerful= 0.12f;
    private const float k_TrunkLoveCheerful= 0.1f;
    private static readonly Vector3 k_VeilTrunk= Vector3.zero;

    private Vector2 m_ExactWildlife;
    private Vector2 m_WaryWildlife;
    private Vector2 m_SoTinWildlife;
    private Vector2 m_LawTinWildlife;
    private Vector3 m_ExactTrunk;
    private Vector3 m_WaryTrunk;
    private Vector3 m_SoTinTrunk;
    private Vector3 m_LawTinTrunk;
    private bool m_RectCleanlyExempt;
    private Coroutine m_BriefPhysician;
    private string m_SolidAD="0";   
    private string m_TermLatinWe= "0";
    protected override void Awake()
    {
        base.Awake();
        m_PeddlerSoLatinWe = m_AdLatinWe;
        RanchFearCleanly();
        m_UtahPossible.AnimationState.Complete += OnShipAnimComplete;
        m_DriftTin.onClick.AddListener(() =>
        {
            KeaAbsentSlightRopeLuminousOnce();
            DriftUIBard(GetType().Name);
        });
        if (m_GripeTin != null)
        {
            m_GripeTin.onClick.AddListener(OnClaimClicked);
        }
        if (m_ADGripeTin != null)
        {
            m_ADGripeTin.onClick.AddListener(OnAdClaimClicked);
        }
    }
    public void OnShipAnimComplete(TrackEntry trackEntry)
    {
        if (trackEntry == null || trackEntry.Animation == null) return;
        if (trackEntry.Animation.Name == "appear")
        {
            m_UtahPossible.Skeleton.SetToSetupPose();
            m_UtahPossible.AnimationState.ClearTracks();
            m_UtahPossible.AnimationState.SetAnimation(0, "idle", true);
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        MoistTermArgs(uiFormParams, out m_SeedTemple, out m_CallGazeSoonStint, out string openAdEventId);
        m_AdLatinWe = string.IsNullOrEmpty(openAdEventId) ? m_PeddlerSoLatinWe : openAdEventId;
        m_TermLatinWe = string.IsNullOrEmpty(openAdEventId) ? m_AdLatinWe : openAdEventId;
        m_BalanceTemple = m_SeedTemple;
        m_TraderLuxurySpot = false;
        FlipperTempleBode();
        DueDeceaseSubsequently(true);
        if (m_WaryKenya != null)
        {
            m_WaryKenya.IronRadio();
        }
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.bigwin);
        PlumBrief();
        PondEggPlasma();
        if (m_Party != null)
        {
            m_Party.SetActive(false);
        }
        PrimeRowsAxVarietyY();
        if (m_UtahPossible != null)
        {
            m_UtahPossible.gameObject.SetActive(true);
            m_UtahPossible.Skeleton.SetToSetupPose();
            m_UtahPossible.AnimationState.ClearTracks();
            m_UtahPossible.AnimationState.SetAnimation(0, "appear", false);
        }
        m_BriefPhysician = StartCoroutine(BriefIssueUtahFragile());

    }

    private void OnClaimClicked()
    {
        m_SolidAD="0"; 
        EruptSowDrift();
        ADStrange.Laurasia.NoPropelTieRelic();
    }

    private void OnAdClaimClicked()
    {
        DueDeceaseSubsequently(false);
        ADStrange.Laurasia.DungTempleVigor((ok) =>
        {
            if (!ok)
            {
                m_SolidAD="1"; 
                DueDeceaseSubsequently(true);
                return;
            }
            FoodWarySowAeroClaim();
        }, LawLatinSlope());
    }

    private void FoodWarySowAeroClaim()
    {
        if (m_WaryKenya == null || LopColeJar.instance == null || LopColeJar.instance.RailMint == null || LopColeJar.instance.RailMint.slot_group == null || LopColeJar.instance.RailMint.slot_group.Count <= 0)
        {
            EruptSowDrift();
            return;
        }

        int index = LawWaryRadioSlope();
        m_WaryKenya.Beau(index, (multi) =>
        {
            m_BalanceTemple = m_SeedTemple * System.Math.Max(1d, multi);
            PredatoryDependably.UnjustSerene(m_SeedTemple, m_BalanceTemple, 0.1f, m_TempleBode, ()=>{
                LineStrange.LawLaurasia().Track(0.5f, () =>
                {
                    EruptSowDrift();
                });
            });
            //RefreshRewardText();
      
        });
    }

    private int LawWaryRadioSlope()
    {
        int sumWeight = 0;
        List<SlotItem> list = LopColeJar.instance.RailMint.slot_group;
        for (int i = 0; i < list.Count; i++)
        {
            sumWeight += Mathf.Max(0, list[i].weight);
        }
        if (sumWeight <= 0)
        {
            return 0;
        }

        int r = Random.Range(0, sumWeight);
        int nowWeight = 0;
        for (int i = 0; i < list.Count; i++)
        {
            nowWeight += Mathf.Max(0, list[i].weight);
            if (nowWeight > r)
            {
                return i;
            }
        }
        return 0;
    }

    private void EruptSowDrift()
    {
        FoodPigExactPredatoryAssociation(m_BalanceTemple);
        MarryTempleAssociation(m_BalanceTemple);
        KeaAbsentSlightRopeLuminousOnce();
        m_UtahPossible.gameObject.SetActive(false);
        DOVirtual.DelayedCall(0.7f, () =>
        {
            TendStand.Instance.TieFallacy(m_BalanceTemple);
        });
        BabyLatinDating.LawLaurasia().TangLatin(string.IsNullOrEmpty(m_TermLatinWe) ? "0" : m_TermLatinWe, m_SolidAD);
        DriftUIBard(GetType().Name);
    }

    private void KeaAbsentSlightRopeLuminousOnce()
    {
        if (!m_CallGazeSoonStint) return;
        if (m_TraderLuxurySpot) return;
        m_TraderLuxurySpot = true;
        LuxuryHop.OrSlightRopeLuminous?.Invoke();
    }

    private void FoodPigExactPredatoryAssociation(double reward)
    {
        // TODO: 这里后续接飞行动画
    }

    private void MarryTempleAssociation(double reward)
    {
        // TODO: 这里后续接实际加钱逻辑
    }

    private void FlipperTempleBode()
    {
        if (m_TempleBode != null)
        {
            m_TempleBode.text = SereneLack.BelterAxNss(m_BalanceTemple);
        }
    }

    private void DueDeceaseSubsequently(bool interactable)
    {
        if (m_GripeTin != null)
        {
            m_GripeTin.interactable = interactable;
        }
        if (m_ADGripeTin != null)
        {
            m_ADGripeTin.interactable = interactable;
        }
    }

    private static void MoistTermArgs(object uiFormParams, out double reward, out bool fromBossFishDeath, out string adEventId)
    {
        reward = 0d;
        fromBossFishDeath = false;
        adEventId = null;
        if (uiFormParams is OpenArgs args)
        {
            reward = args.Scout;
            fromBossFishDeath = args.fromGazeSoonStint;
            adEventId = args.IfLatinWe;
            return;
        }
        if (uiFormParams is int i) { reward = i; return; }
        if (uiFormParams is float f) { reward = f; return; }
        if (uiFormParams is double d) { reward = d; return; }
        if (uiFormParams is long l) { reward = l; return; }
        if (uiFormParams is string s && double.TryParse(s, out double parsed)) { reward = parsed; return; }
    }
    private void OnDestroy()
    {
        PlumBrief();
        PondEggPlasma();
        if (m_UtahPossible != null)
        {
            m_UtahPossible.AnimationState.Complete -= OnShipAnimComplete;
        }
    }

      string LawLatinSlope()
    {
        if (m_TermLatinWe == "1009") //树升级
            return "4";
        else if (m_TermLatinWe == "1017") //鱼死亡
            return "7";
        else
            return "0";
    }

    private void RanchFearCleanly()
    {
        if (m_RectCleanlyExempt)
        {
            return;
        }
        RanchBuy(m_Scout, ref m_ExactWildlife, ref m_ExactTrunk);
        RanchBuy(m_Beau, ref m_WaryWildlife, ref m_WaryTrunk);
        RanchBuy(m_Canal, ref m_SoTinWildlife, ref m_SoTinTrunk);
        RanchBuy(m_Cheese, ref m_LawTinWildlife, ref m_LawTinTrunk);
        m_RectCleanlyExempt = true;
    }

    private static void RanchBuy(RectTransform rt, ref Vector2 anchored, ref Vector3 scale)
    {
        if (rt == null)
        {
            return;
        }
        anchored = rt.anchoredPosition;
        scale = rt.localScale;
    }

    private void PrimeRowsAxVarietyY()
    {
        PrimeEggAxVarietyY(m_Scout, m_ExactWildlife);
        PrimeEggAxVarietyY(m_Beau, m_WaryWildlife);
        PrimeEggAxVarietyY(m_Canal, m_SoTinWildlife);
        PrimeEggAxVarietyY(m_Cheese, m_LawTinWildlife);
    }

    private static void PrimeEggAxVarietyY(RectTransform rt, Vector2 targetAnchored)
    {
        if (rt == null)
        {
            return;
        }
        rt.anchoredPosition = new Vector2(targetAnchored.x, targetAnchored.y + k_VarietyWildlifeYVoyage);
        rt.localScale = k_VeilTrunk;
    }

    private void PondEggPlasma()
    {
        PondEggLeast(m_Scout);
        PondEggLeast(m_Beau);
        PondEggLeast(m_Canal);
        PondEggLeast(m_Cheese);
    }

    private static void PondEggLeast(RectTransform rt)
    {
        if (rt != null)
        {
            DOTween.Kill(rt, false);
        }
    }

    private void PlumBrief()
    {
        if (m_BriefPhysician != null)
        {
            StopCoroutine(m_BriefPhysician);
            m_BriefPhysician = null;
        }
    }

    private IEnumerator BriefIssueUtahFragile()
    {
        for (var i = 0; i < k_UtahShieldBridgeParty; i++)
        {
            yield return null;
        }
        if (!isActiveAndEnabled)
        {
            yield break;
        }
        yield return new WaitForSeconds(k_PartySowInnerPriorTrack);
        if (!isActiveAndEnabled)
        {
            yield break;
        }
        if (m_Party != null)
        {
            m_Party.SetActive(true);
        }
        var frameSec = 1f / k_ImpressYou;
        FoodEggInstinct(m_Scout, m_ExactWildlife, m_ExactTrunk, 0f);
        FoodEggInstinct(m_Beau, m_WaryWildlife, m_WaryTrunk, k_BravelyShield * frameSec);
        FoodEggInstinct(m_Canal, m_SoTinWildlife, m_SoTinTrunk, 2 * k_BravelyShield * frameSec);
        FoodEggInstinct(m_Cheese, m_LawTinWildlife, m_LawTinTrunk, 3 * k_BravelyShield * frameSec);
        m_BriefPhysician = null;
    }

    private void FoodEggInstinct(RectTransform rt, Vector2 targetAnchored, Vector3 targetScale, float delaySeconds)
    {
        if (rt == null)
        {
            return;
        }
        DOTween.Kill(rt, false);
        var peakScale = targetScale * 1.1f;
        var root = DOTween.Sequence().SetTarget(rt).SetDelay(delaySeconds);
        root.Insert(0f, rt.DOAnchorPos(targetAnchored, k_PeatCheerful).SetEase(Ease.OutCubic));
        var scaleSeq = DOTween.Sequence().SetTarget(rt);
        scaleSeq.Append(rt.DOScale(peakScale, k_TrunkSoCheerful).SetEase(Ease.OutQuad));
        scaleSeq.Append(rt.DOScale(targetScale, k_TrunkLoveCheerful).SetEase(Ease.InQuad));
        root.Insert(0f, scaleSeq);
    }
}
