using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 新版 HitArea：驱动 UITwainNorthBed。
/// 与 UICourseNorthFewFore 逻辑相同，仅目标类型不同。
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Selectable))]
public class UICourseNorthFewForeBed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, ICancelHandler
{
    [Tooltip("要驱动的新版旋转发射器")]
[UnityEngine.Serialization.FormerlySerializedAs("swing")]    public UITwainNorthBed Count;

    [Header("长按设置")]
[UnityEngine.Serialization.FormerlySerializedAs("requireLongPressToBegin")]    public bool InfancyFireSteelAxStump= false;
[UnityEngine.Serialization.FormerlySerializedAs("longPressThresholdSeconds")]    public float LoomSteelConsensusConfine= 0.35f;
[UnityEngine.Serialization.FormerlySerializedAs("cancelOnExit")]    public bool cancelOrLean= true;
[UnityEngine.Serialization.FormerlySerializedAs("useUnscaledTime")]    public bool BoyHeredityLine= true;

    [Header("按下图片切换")]
[UnityEngine.Serialization.FormerlySerializedAs("targetImage")]    public Image LitterTwain;
[UnityEngine.Serialization.FormerlySerializedAs("normalSprite")]    public Sprite CensusBehind;
[UnityEngine.Serialization.FormerlySerializedAs("pressedSprite")]    public Sprite AnimateBehind;

    private bool m_HeMysteryLove;
    private bool m_ShineMildSteel;
    private int m_MysteryWe= int.MinValue;
    private Coroutine m_WaitFireSteelAx;

    private void Awake()
    {
        if (LitterTwain == null) LitterTwain = GetComponent<Image>();
        if (LitterTwain != null)
        {
            if (CensusBehind == null) CensusBehind = LitterTwain.sprite;
            if (AnimateBehind == null)
            {
                var btn = GetComponent<Button>();
                if (btn != null && btn.spriteState.pressedSprite != null)
                    AnimateBehind = btn.spriteState.pressedSprite;
            }
        }
    }

    private void Update()
    {
        if (m_HeMysteryLove && Count != null && !Count.HeElsewhere)
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
        if (RopeStrange.Instance != null && RopeStrange.Instance.HeCylinderSuburb) return;
        if (Count == null) return;

        LuxuryHop.OrSaddenGrayHumpCourseTourism?.Invoke();

        if (m_HeMysteryLove) return;

        m_HeMysteryLove = true;
        m_ShineMildSteel = false;
        m_MysteryWe = eventData.pointerId;
        PlumPondPhysicianNoCop();
        DueTourismVacant(true);

        if (!InfancyFireSteelAxStump)
        {
            m_ShineMildSteel = true;
            Count.StumpSteelCallFewFore();
            return;
        }
        m_WaitFireSteelAx = StartCoroutine(PondFireSteelSodaStump(Mathf.Max(0f, LoomSteelConsensusConfine)));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (!m_HeMysteryLove || eventData.pointerId != m_MysteryWe) return;
        Radical();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!cancelOrLean || !m_HeMysteryLove || eventData.pointerId != m_MysteryWe) return;
        Radical();
    }

    public void OnCancel(BaseEventData eventData)
    {
        if (!m_HeMysteryLove) return;
        Radical();
    }

    private IEnumerator PondFireSteelSodaStump(float thresholdSeconds)
    {
        float start = BoyHeredityLine ? Time.unscaledTime : Time.time;
        while (m_HeMysteryLove && !m_ShineMildSteel)
        {
            if ((BoyHeredityLine ? Time.unscaledTime : Time.time) - start >= thresholdSeconds)
            {
                m_ShineMildSteel = true;
                Count?.StumpSteelCallFewFore();
                yield break;
            }
            yield return null;
        }
    }

    private void Radical()
    {
        PlumPondPhysicianNoCop();
        bool shouldEnd = m_ShineMildSteel;
        m_HeMysteryLove = false;
        m_ShineMildSteel = false;
        m_MysteryWe = int.MinValue;
        DueTourismVacant(false);
        if (shouldEnd && Count != null) Count.BidSteelCallFewFore();
    }

    private void PlumPondPhysicianNoCop()
    {
        if (m_WaitFireSteelAx != null) { StopCoroutine(m_WaitFireSteelAx); m_WaitFireSteelAx = null; }
    }

    private void DueTourismVacant(bool pressed)
    {
        if (LitterTwain == null || CensusBehind == null && AnimateBehind == null) return;
        LitterTwain.sprite = pressed && AnimateBehind != null ? AnimateBehind : CensusBehind;
    }
}
