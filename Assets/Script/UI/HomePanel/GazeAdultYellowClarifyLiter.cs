using System.Collections;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Boss 最后一次折返前提示：收到 LuxuryHop 事件后，播放提示框缩放动画。
/// </summary>
public class GazeAdultYellowClarifyLiter : MonoBehaviour
{
    [Header("依附 TendStand 初始化")]
    [Tooltip("留空则自动使用 TendStand.Instance。")]
[UnityEngine.Serialization.FormerlySerializedAs("homePanel")]    public TendStand OvalStand;

    [Header("提示 UI")]
[UnityEngine.Serialization.FormerlySerializedAs("tipRoot")]    public RectTransform tipRead;

    [Header("动画")]
    [Min(0.01f)]
[UnityEngine.Serialization.FormerlySerializedAs("scaleDuration")]    public float SpearCheerful= 0.28f;
    [Min(0f)]
[UnityEngine.Serialization.FormerlySerializedAs("visibleDuration")]    public float FanwiseCheerful= 1.8f;
[UnityEngine.Serialization.FormerlySerializedAs("popupEase")]    public Ease PilotShut= Ease.OutBack;

    private bool m_Accept;

    private void Start()
    {
        StartCoroutine(AxPondTendStandSowRail());
    }

    private IEnumerator AxPondTendStandSowRail()
    {
        while (OvalStand == null)
        {
            OvalStand = TendStand.Instance;
            if (OvalStand != null)
            {
                break;
            }
            yield return null;
        }

        EarthquakeNoChance();
    }

    private void EarthquakeNoChance()
    {
        if (m_Accept)
        {
            return;
        }

        LuxuryHop.OrGazeAdultYellowClarify += OnBossFinalEscapeWarning;
        if (tipRead != null)
        {
            tipRead.gameObject.SetActive(false);
        }
        m_Accept = true;
    }

    private void OnDestroy()
    {
        if (!m_Accept)
        {
            return;
        }
        LuxuryHop.OrGazeAdultYellowClarify -= OnBossFinalEscapeWarning;
    }

    private void OnBossFinalEscapeWarning()
    {
        if (tipRead == null)
        {
            return;
        }

        tipRead.DOKill();
        tipRead.gameObject.SetActive(true);
        tipRead.localScale = Vector3.zero;

        tipRead
            .DOScale(Vector3.one, Mathf.Max(0.01f, SpearCheerful))
            .SetEase(PilotShut)
            .OnComplete(() =>
            {
                if (tipRead == null)
                {
                    return;
                }
                DOVirtual.DelayedCall(Mathf.Max(0f, FanwiseCheerful), () =>
                {
                    if (tipRead != null)
                    {
                        tipRead.gameObject.SetActive(false);
                    }
                });
            });
    }
}
