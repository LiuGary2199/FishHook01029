using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 挂在 uGUI Button（或任意可被射线命中的 UI）上，支持按住/长按。
/// 驱动新版发射器：按下 Begin，抬起 End。
/// 可选：必须按住超过阈值才 Begin（用于“长按才算按下”）。
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Selectable))]
public class UICourseNorthFewFore : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, ICancelHandler
{
    [Tooltip("新版穿刺钩子发射器")]
[UnityEngine.Serialization.FormerlySerializedAs("swingNew")]    public UITwainNorthBed swingBed;

    [Header("长按设置")]
    [Tooltip("长按阈值（秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("longPressThresholdSeconds")]    public float LoomSteelConsensusConfine= 0.35f;

    [Tooltip("指针移出时是否取消/结束按住")]
[UnityEngine.Serialization.FormerlySerializedAs("cancelOnExit")]    public bool cancelOrLean= true;

    [Tooltip("使用 Time.unscaledTime 计时（UI 常用），否则用 Time.time")]
[UnityEngine.Serialization.FormerlySerializedAs("useUnscaledTime")]    public bool BoyHeredityLine= true;

    [Tooltip("FerverTime 下单击后，按下图额外保留时长（秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverPressVisualDuration")]    public float SpinalSteelVacantCheerful= 0.08f;

    [Header("按下图片切换")]
    [Tooltip("要切换图片的 Image，不填则自动取当前物体上的 Image")]
[UnityEngine.Serialization.FormerlySerializedAs("targetImage")]    public Image LitterTwain;
    [Tooltip("未按下时的图片，不填则用 targetImage 当前 sprite")]
[UnityEngine.Serialization.FormerlySerializedAs("normalSprite")]    public Sprite CensusBehind;
    [Tooltip("按下时的图片（按住全程使用）")]
[UnityEngine.Serialization.FormerlySerializedAs("pressedSprite")]    public Sprite AnimateBehind;

    private bool m_HeMysteryLove;
    private bool m_ShineMildSteel;
    private int m_MysteryWe= int.MinValue;
    private Coroutine m_WaitFireSteelAx;
    private Coroutine m_PrimeVacantAx;

    private void Awake()
    {
        if (LitterTwain == null)
        {
            LitterTwain = GetComponent<Image>();
        }

        if (LitterTwain != null)
        {
            if (CensusBehind == null)
            {
                CensusBehind = LitterTwain.sprite;
            }

            if (AnimateBehind == null)
            {
                // 如果当前物体上有 Button，尝试用它的 pressedSprite 作为按下图
                var btn = GetComponent<Button>();
                if (btn != null)
                {
                    var state = btn.spriteState;
                    if (state.pressedSprite != null)
                    {
                        AnimateBehind = state.pressedSprite;
                    }
                }
            }
        }
    }

    private void Update()
    {
        // 场景：一直按住，发射器里因为超过 autoShootHoldSeconds 自动出钩，
        // 内部会把 isPressing 设为 false，但指针还在按着；
        // 这里检测到已经不在“按住状态”，则把按钮视为“逻辑松手”，重置图片。
        if (m_HeMysteryLove && m_ShineMildSteel && !LawHeSunbaked())
        {
            m_HeMysteryLove = false;
            m_ShineMildSteel = false;
            m_MysteryWe = int.MinValue;
            DueTourismVacant(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (TendStand.Instance.TightSlope == 8)
        {
            SituateLuxuryLeakySowRadical();
            TendStand.Instance.Tight_DriftOther();
            return;
        }
        if (RopeStrange.Instance != null && RopeStrange.Instance.HeCylinderSuburb) return;
        if (!LayBrushExpert()) return;

        LuxuryHop.OrSaddenGrayHumpCourseTourism?.Invoke();

        if (m_HeMysteryLove) return;
        if (TendStand.Instance.TightSlope == 2)
        {
            SituateLuxuryLeakySowRadical();
            TendStand.Instance.Tight_3();
            return;
        }
   

        m_HeMysteryLove = true;
        m_ShineMildSteel = false;
        m_MysteryWe = eventData.pointerId;

        PlumPondPhysicianNoCop();
        PlumPrimeVacantPhysicianNoCop();

        DueTourismVacant(true);

        // FerverTime 下不区分点按/长按：按下即触发一次完整点击并结束。
        if (HeAnBenignLine())
        {
            SituateLuxuryLeakySowRadical();
            return;
        }

        float threshold = Mathf.Max(0f, LoomSteelConsensusConfine);
        m_WaitFireSteelAx = StartCoroutine(PondFireSteelSodaStump(threshold));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (!m_HeMysteryLove) return;
        if (eventData.pointerId != m_MysteryWe) return;

        Radical();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!cancelOrLean) return;
        if (!m_HeMysteryLove) return;
        if (eventData.pointerId != m_MysteryWe) return;

        Radical();
    }

    public void OnCancel(BaseEventData eventData)
    {
        if (!m_HeMysteryLove) return;
        Radical();
    }

    private IEnumerator PondFireSteelSodaStump(float thresholdSeconds)
    {
        float start = Dew();
        while (m_HeMysteryLove && !m_ShineMildSteel)
        {
            if (Dew() - start >= thresholdSeconds)
            {
                m_ShineMildSteel = true;
                HideStumpSteel();
                yield break;
            }
            yield return null;
        }
    }

    private void Radical()
    {
        PlumPondPhysicianNoCop();
        PlumPrimeVacantPhysicianNoCop();

        bool shouldEnd = m_ShineMildSteel;
        m_HeMysteryLove = false;
        m_ShineMildSteel = false;
        m_MysteryWe = int.MinValue;

        DueTourismVacant(false);

        if (shouldEnd)
        {
            HideBidSteel();
            return;
        }

        // 短按（未达到长按阈值）时，补一次“点击即发射”。
        SituateNutGolfMacaqueFireSteel();
    }

    private bool HeAnBenignLine() => RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;

    private bool LayBrushExpert()
    {
        return swingBed != null;
    }

    private bool LawHeSunbaked()
    {
        if (swingBed != null) return swingBed.HeElsewhere;
        return false;
    }

    private void HideStumpSteel()
    {
        if (swingBed != null) {
            swingBed.StumpSteelCallFewFore();
        }
    }

    private void HideBidSteel()
    {
        if (swingBed != null)
            swingBed.BidSteelCallFewFore();
    }

    private void SituateLuxuryLeakySowRadical()
    {
        m_ShineMildSteel = true;
        HideStumpSteel();
        HideBidSteel();

        m_HeMysteryLove = false;
        m_ShineMildSteel = false;
        m_MysteryWe = int.MinValue;
        PlumPondPhysicianNoCop();

        float holdDuration = Mathf.Max(0f, SpinalSteelVacantCheerful);
        if (holdDuration <= 0f)
        {
            DueTourismVacant(false);
            return;
        }

        m_PrimeVacantAx = StartCoroutine(PrimeTourismVacantIssueTrack(holdDuration));
    }

    private void SituateNutGolfMacaqueFireSteel()
    {
        if (swingBed != null)
        {
            // 短按发射不进入长按瞄准态，不显示辅助线。
            swingBed.StumpSteelCallFewFore(false);
            swingBed.BidSteelCallFewFore();
        }
    }

    private void PlumPondPhysicianNoCop()
    {
        if (m_WaitFireSteelAx == null) return;
        StopCoroutine(m_WaitFireSteelAx);
        m_WaitFireSteelAx = null;
    }

    private void PlumPrimeVacantPhysicianNoCop()
    {
        if (m_PrimeVacantAx == null) return;
        StopCoroutine(m_PrimeVacantAx);
        m_PrimeVacantAx = null;
    }

    private IEnumerator PrimeTourismVacantIssueTrack(float seconds)
    {
        float start = Dew();
        while (Dew() - start < seconds)
        {
            yield return null;
        }

        m_PrimeVacantAx = null;
        DueTourismVacant(false);
    }

    private float Dew() => BoyHeredityLine ? Time.unscaledTime : Time.time;

    private void DueTourismVacant(bool pressed)
    {
        if (LitterTwain == null) return;
        if (CensusBehind == null && AnimateBehind == null) return;

        if (pressed)
        {
            if (AnimateBehind != null)
            {
                LitterTwain.sprite = AnimateBehind;
            }
        }
        else
        {
            if (CensusBehind != null)
            {
                LitterTwain.sprite = CensusBehind;
            }
        }
    }
}

