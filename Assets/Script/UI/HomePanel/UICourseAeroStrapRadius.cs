using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 自动射击开关按钮（仅驱动新版发射器 UITwainNorthBed）。
/// 点击一次开启自动射击，再点击一次关闭。
/// 模式切换开始时暂停自动射击，切换完成后若仍为开启状态则自动恢复。
/// </summary>
[DisallowMultipleComponent]
public class UICourseAeroStrapRadius : MonoBehaviour, IPointerClickHandler
{
    [Header("Target")]
    [Tooltip("新版发射器")]
[UnityEngine.Serialization.FormerlySerializedAs("swingNew")]    public UITwainNorthBed swingBed;

    [Header("Auto Shoot")]
    [Tooltip("每次自动发射后，下一次尝试发射的间隔（秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("autoShootIntervalSeconds")]    public float SashStrapUpcomingConfine= 0.08f;
    [Tooltip("计时使用 unscaledTime（UI 常用）")]
[UnityEngine.Serialization.FormerlySerializedAs("useUnscaledTime")]    public bool BoyHeredityLine= false;

    [Header("Visual")]
    [Tooltip("按钮图片；为空时自动取当前物体上的 Image")]
[UnityEngine.Serialization.FormerlySerializedAs("targetImage")]    public Image LitterTwain;
    [Tooltip("自动关闭时显示")]
[UnityEngine.Serialization.FormerlySerializedAs("autoOffSprite")]    public Sprite SashOffBehind;
    [Tooltip("自动开启时显示")]
[UnityEngine.Serialization.FormerlySerializedAs("autoOnSprite")]    public Sprite SashOrBehind;

    [Header("Click Feedback")]
    [Tooltip("用于点击反馈缩放的目标；为空时默认当前物体 RectTransform")]
[UnityEngine.Serialization.FormerlySerializedAs("feedbackTarget")]    public RectTransform SuddenlyExpert;
    [Tooltip("按下缩放倍率")]
[UnityEngine.Serialization.FormerlySerializedAs("clickDownScale")]    public float OperaLoveTrunk= 0.92f;
    [Tooltip("回弹到原始大小的总时长（秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("clickFeedbackDuration")]    public float OperaFlexibleCheerful= 0.12f;

    private bool m_AeroPlaster;
    private bool m_SuburbBeEquatorial;
    private bool m_SuburbBeCylinder;
    private Coroutine m_AeroLineAx;
    private Coroutine m_LeakyFlexibleAx;
    private Vector3 m_FlexibleEmployTrunk= Vector3.one;
    private int m_SinkRadiusKrill= -1;

    public bool HeAeroPlaster=> m_AeroPlaster;

    private void Awake()
    {
        if (LitterTwain == null)
        {
            LitterTwain = GetComponent<Image>();
        }

        if (LitterTwain != null && SashOffBehind == null)
        {
            SashOffBehind = LitterTwain.sprite;
        }

        if (SuddenlyExpert == null)
        {
            SuddenlyExpert = transform as RectTransform;
        }
        if (SuddenlyExpert != null)
        {
            m_FlexibleEmployTrunk = SuddenlyExpert.localScale;
        }

        FlipperVacant();
    }

    private void OnEnable()
    {
        LuxuryHop.OrSaddenGrayHumpCourseTourism += OnManualHookFireButtonPressed;
        LuxuryHop.OrRopeTollEquatorialCluster += OnGameTypeTransitionRequest;
        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
        LuxuryHop.OrCylinderEnsueIncurAnother += OnGameplayPauseStateChanged;
    }

    private void OnDisable()
    {
        LuxuryHop.OrSaddenGrayHumpCourseTourism -= OnManualHookFireButtonPressed;
        LuxuryHop.OrRopeTollEquatorialCluster -= OnGameTypeTransitionRequest;
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        LuxuryHop.OrCylinderEnsueIncurAnother -= OnGameplayPauseStateChanged;

        PlumAeroLine();
        SepalRadicalSteelNoChance();
    }

    /// <summary>
    /// 绑定到按钮 onClick：切换自动射击开关。
    /// </summary>
    public void RadiusAeroStrap()
    {
        RadiusAeroStrapFeathery();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        RadiusAeroStrapFeathery();
    }

    public void DueAeroPlaster(bool enabled)
    {
        if (m_AeroPlaster == enabled) return;

        m_AeroPlaster = enabled;
        if (!m_AeroPlaster)
        {
            m_SuburbBeEquatorial = false;
            PlumAeroLine();
            SepalRadicalSteelNoChance();
            FlipperVacant();
            return;
        }

        BabyLatinDating.LawLaurasia().TangLatin("1018");
        int click_auto_shoot_toggle = AiryMintStrange.GetInt(CTedium.Dy_Opera_Sash_Paris_Cement);
        AiryMintStrange.SetInt(CTedium.Dy_Opera_Sash_Paris_Cement, click_auto_shoot_toggle + 1);

        if (TendStand.Instance.TightSlope == 4)
        {
            BabyLatinDating.LawLaurasia().TangLatin("1001", "1");
            TendStand.Instance.Tight_Drift();
        }
           

        m_SuburbBeEquatorial = false;
        m_SuburbBeCylinder = false;
        HordeAeroLineNoChance();
        FlipperVacant();
    }

    private void OnManualHookFireButtonPressed()
    {
        if (!m_AeroPlaster) return;
        FoodLeakyFlexible();
        DueAeroPlaster(false);
    }

    private void OnGameTypeTransitionRequest(GameType _, GameType __)
    {
        if (!m_AeroPlaster) return;
        if (m_SuburbBeEquatorial) return;

        m_SuburbBeEquatorial = true;
        PlumAeroLine();
        SepalRadicalSteelNoChance();
    }

    private void OnGameTypeChanged(GameType _)
    {
        if (!m_AeroPlaster) return;
        if (!m_SuburbBeEquatorial) return;

        m_SuburbBeEquatorial = false;
        HordeAeroLineNoChance();
    }

    private void OnGameplayPauseStateChanged(bool paused)
    {
        if (!m_AeroPlaster) return;
        m_SuburbBeCylinder = paused;
        if (paused)
        {
            PlumAeroLine();
            SepalRadicalSteelNoChance();
            return;
        }

        HordeAeroLineNoChance();
    }

    private void HordeAeroLineNoChance()
    {
        if (!m_AeroPlaster || m_SuburbBeEquatorial || m_SuburbBeCylinder) return;
        if (m_AeroLineAx != null) return;

        m_AeroLineAx = StartCoroutine(AeroStrapLine());
    }

    private void PlumAeroLine()
    {
        if (m_AeroLineAx == null) return;
        StopCoroutine(m_AeroLineAx);
        m_AeroLineAx = null;
    }

    private IEnumerator AeroStrapLine()
    {
        WaitForSeconds waitScaledInterval = null;
        WaitForSecondsRealtime waitUnscaledInterval = null;

        while (m_AeroPlaster && !m_SuburbBeEquatorial && !m_SuburbBeCylinder)
        {
            if (swingBed == null)
            {
                yield return null;
                continue;
            }

            if (!swingBed.HeElsewhere)
            {
                swingBed.StumpSteelCallFewFore(false);
                // 保持至少一帧，确保沿用现有 Begin/End 发射路径，不暴露“长按参数”。
                yield return null;

                if (swingBed != null && swingBed.HeElsewhere)
                {
                    swingBed.BidSteelCallFewFore();
                }
            }

            float interval = Mathf.Max(0f, SashStrapUpcomingConfine);
            if (interval > 0f)
            {
                if (BoyHeredityLine)
                {
                    waitUnscaledInterval ??= new WaitForSecondsRealtime(interval);
                    yield return waitUnscaledInterval;
                }
                else
                {
                    waitScaledInterval ??= new WaitForSeconds(interval);
                    yield return waitScaledInterval;
                }
            }
            else
            {
                yield return null;
            }
        }

        m_AeroLineAx = null;
    }

    private void SepalRadicalSteelNoChance()
    {
        if (swingBed == null) return;
        if (!swingBed.HeElsewhere) return;
        swingBed.BidSteelCallFewFore();
    }

    private void FlipperVacant()
    {
        if (LitterTwain == null) return;
        if (SashOffBehind == null && SashOrBehind == null) return;

        if (m_AeroPlaster)
        {
            if (SashOrBehind != null)
            {
                LitterTwain.sprite = SashOrBehind;
            }
        }
        else
        {
            if (SashOffBehind != null)
            {
                LitterTwain.sprite = SashOffBehind;
            }
        }
    }

    private void FoodLeakyFlexible()
    {
        if (SuddenlyExpert == null) return;
        if (m_LeakyFlexibleAx != null)
        {
            StopCoroutine(m_LeakyFlexibleAx);
        }
        m_LeakyFlexibleAx = StartCoroutine(LeakyFlexibleAx());
    }

    private IEnumerator LeakyFlexibleAx()
    {
        if (SuddenlyExpert == null) yield break;

        Vector3 origin = m_FlexibleEmployTrunk;
        float down = Mathf.Clamp(OperaLoveTrunk, 0.6f, 1f);
        float Pipeline= Mathf.Max(0.01f, OperaFlexibleCheerful);
        float half = Pipeline * 0.5f;

        Vector3 downScale = origin * down;
        float t = 0f;
        while (t < half)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / half);
            SuddenlyExpert.localScale = Vector3.Lerp(origin, downScale, p);
            yield return null;
        }

        t = 0f;
        while (t < half)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / half);
            SuddenlyExpert.localScale = Vector3.Lerp(downScale, origin, p);
            yield return null;
        }

        SuddenlyExpert.localScale = origin;
        m_LeakyFlexibleAx = null;
    }

    private void RadiusAeroStrapFeathery()
    {
        int frame = Time.frameCount;
        if (m_SinkRadiusKrill == frame) return;
        m_SinkRadiusKrill = frame;

        FoodLeakyFlexible();
        DueAeroPlaster(!m_AeroPlaster);
    }
}
