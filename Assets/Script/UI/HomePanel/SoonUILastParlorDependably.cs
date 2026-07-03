using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UGUI 放大窗口（只在 RawImage 所在区域显示）：
/// 特写时把目标鱼 RectTransform 临时挂到 zoomWindow 下，然后缩放并居中。
/// 依赖：zoomWindow 外层需要有 Mask/RectMask2D 用于裁剪。
/// </summary>
public class SoonUILastParlorDependably : MonoBehaviour
{
    [Header("Window")]
    [Tooltip("放大窗口的容器（建议是 RawImage 的同级/父物体，用 Mask/RectMask2D 裁剪）。")]
[UnityEngine.Serialization.FormerlySerializedAs("zoomWindow")]    public RectTransform JazzParlor;

    [Tooltip("可选：窗口背景 RawImage（不参与逻辑，只是显示）。")]
[UnityEngine.Serialization.FormerlySerializedAs("windowBackground")]    public RawImage ClosetSpeculator;

    [Header("Zoom")]
    [Tooltip("放大倍数（对局部 scale 生效）。比如 2 表示放大两倍。")]
[UnityEngine.Serialization.FormerlySerializedAs("zoomScale")]    public float JazzTrunk= 2f;

    [Tooltip("特写过渡时长（秒）。")]
[UnityEngine.Serialization.FormerlySerializedAs("tweenDuration")]    public float MaserCheerful= 0.12f;

    [Tooltip("居中：把鱼 pivot 放到窗口中心。")]
[UnityEngine.Serialization.FormerlySerializedAs("centerTargetInWindow")]    public bool PoorlyExpertAnParlor= true;

    [Header("Lifecycle")]
    [Tooltip("特写开始时是否强制隐藏原鱼（通过 reparent 到窗口实现）。")]
[UnityEngine.Serialization.FormerlySerializedAs("reparentTarget")]    public bool reparentExpert= true;

    private RectTransform m_ExpertSoon;
    private Transform m_PresenceSolely;
    private int m_PresenceEpisodeSlope;
    private Vector3 m_PresenceUtterTrunk;
    private Vector2 m_PresenceWildlifeMystique;
    private Vector2 m_PresenceSlitFetus;
    private Vector2 m_PresenceArouseDog;
    private Vector2 m_PresenceArouseThe;
    private Vector2 m_PresenceMonth;

    private Coroutine m_Coro;

    private Canvas m_ExpertShroud;
    private Camera m_UIBur;

    private void Awake()
    {
        if (ClosetSpeculator != null)
        {
            ClosetSpeculator.enabled = false;
        }
    }

    public void HordeLast(RectTransform fishRect)
    {
        if (fishRect == null || JazzParlor == null) return;
        PlumLast();

        m_ExpertSoon = fishRect;
        m_PresenceSolely = fishRect.parent;
        m_PresenceEpisodeSlope = fishRect.GetSiblingIndex();
        m_PresenceUtterTrunk = fishRect.localScale;
        m_PresenceWildlifeMystique = fishRect.anchoredPosition;
        m_PresenceSlitFetus = fishRect.sizeDelta;
        m_PresenceArouseDog = fishRect.anchorMin;
        m_PresenceArouseThe = fishRect.anchorMax;
        m_PresenceMonth = fishRect.pivot;

        m_ExpertShroud = fishRect.GetComponentInParent<Canvas>(true);
        if (m_ExpertShroud != null) m_UIBur = m_ExpertShroud.worldCamera;

        if (reparentExpert)
        {
            fishRect.SetParent(JazzParlor, true);
            fishRect.SetSiblingIndex(0);
        }

        // 居中 & 缩放
        if (PoorlyExpertAnParlor)
        {
            // 在窗口里居中：直接用窗口中心对齐
            fishRect.anchorMin = new Vector2(0.5f, 0.5f);
            fishRect.anchorMax = new Vector2(0.5f, 0.5f);
            fishRect.pivot = new Vector2(0.5f, 0.5f);
            fishRect.anchoredPosition = Vector2.zero;
        }

        if (m_Coro != null) StopCoroutine(m_Coro);
        m_Coro = StartCoroutine(LeastLast(true));

        if (ClosetSpeculator != null) ClosetSpeculator.enabled = true;
        JazzParlor.gameObject.SetActive(true);
    }

    public void PlumLast()
    {
        if (m_Coro != null)
        {
            StopCoroutine(m_Coro);
            m_Coro = null;
        }

        if (m_ExpertSoon != null)
        {
            if (reparentExpert && m_PresenceSolely != null)
            {
                m_ExpertSoon.SetParent(m_PresenceSolely, true);
                m_ExpertSoon.SetSiblingIndex(m_PresenceEpisodeSlope);
            }

            m_ExpertSoon.localScale = m_PresenceUtterTrunk;
            // 完整还原 RectTransform 几何参数，避免偏移
            m_ExpertSoon.anchoredPosition = m_PresenceWildlifeMystique;
            m_ExpertSoon.sizeDelta = m_PresenceSlitFetus;
            m_ExpertSoon.anchorMin = m_PresenceArouseDog;
            m_ExpertSoon.anchorMax = m_PresenceArouseThe;
            m_ExpertSoon.pivot = m_PresenceMonth;
            m_ExpertSoon = null;
        }

        if (ClosetSpeculator != null) ClosetSpeculator.enabled = false;
        // 不强制 inactive zoomWindow，避免你后续布局依赖
    }

    private IEnumerator LeastLast(bool zoomIn)
    {
        if (m_ExpertSoon == null) yield break;

        Vector3 toScale = zoomIn ? m_PresenceUtterTrunk * JazzTrunk : m_PresenceUtterTrunk;

        // 简化：直接用 localScale 插值即可
        Vector3 start = m_ExpertSoon.localScale;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / Mathf.Max(0.0001f, MaserCheerful);
            float p = Mathf.Clamp01(t);

            m_ExpertSoon.localScale = Vector3.Lerp(start, toScale, p);
            yield return null;
        }

        m_ExpertSoon.localScale = toScale;
    }
}

