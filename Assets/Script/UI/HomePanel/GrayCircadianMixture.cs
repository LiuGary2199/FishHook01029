using UnityEngine;

/// <summary>
/// 穿刺钩子碰撞：碰鱼播放受击、继续飞；碰墙回收。
/// 不触发 OnCollFish/OnCollWall，避免影响旧系统。
/// </summary>
[RequireComponent(typeof(GrayTambourine))]
public class GrayCircadianMixture : MonoBehaviour
{
    private const string TuneTag= "Wall";
    private const string SoonEye= "Fish";

    private GrayTambourine m_Tambourine;

    // 本次发射（一次钩子）内连击计数：每撞到一只鱼 +1
    private int m_SoonFewRelic;
    // 本次发射（一次钩子）内用于“减速叠加”的命中计数：每次碰到鱼 +1
    private int m_SoonFewRelicEyeBask;
    private bool m_GolfComposite;

    private SwarmHalt m_SwarmHalt;

    [Header("Test: Fish Zoom (duration)")]
    [Tooltip("特写推进时长（秒）；被 MagnifierCam / UI zoom window 复用")]
[UnityEngine.Serialization.FormerlySerializedAs("m_TestZoomDuration")]    public float m_FillLastCheerful= 0.35f;

    [Header("Debug")]
    [Tooltip("调试：命中鱼时打印日志，确认 OnTriggerEnter2D 分支是否执行")]
[UnityEngine.Serialization.FormerlySerializedAs("m_DebugHitFish")]    public bool m_FleshFewSoon= true;

    private bool m_HeLastHollywoodEyeMildGolf;
    private bool m_GazeTerrainConstantMildGolf;
    private bool m_GazeRutHonestFewConstantMildGrayGolf;

    [Header("Test: Fish UI Zoom Window (RawImage area)")]
    [Tooltip("命中第一条鱼时打开 UGUI 放大窗口（只在 RawImage 区域放大）。")]
[UnityEngine.Serialization.FormerlySerializedAs("m_EnableUIZoomWindowTest")]    public bool m_ScenicUILastParlorFill= false;

    [Tooltip("放大倍数（传给 SoonUILastParlorDependably.zoomScale）。")]
[UnityEngine.Serialization.FormerlySerializedAs("m_UIZoomScale")]    public float m_UILastTrunk= 2f;

    private global::SoonUILastParlorDependably m_UILastParlorDependably;

    [Header("Test: MagnifierCam only")]
    [Tooltip("命中鱼时只推 MagnifierCam（不切 Canvas），并在小 RawImage 显示。")]
[UnityEngine.Serialization.FormerlySerializedAs("m_EnableMagnifierCamOnlyTest")]    public bool m_ScenicEuphratesBurClubFill= true;
    private global::SoonEuphratesBurLastDependably m_EuphratesClubDependably;

    [Tooltip("测试时：钩子 OnDisable 时是否强制停止 MagnifierCam 特写。建议先关掉以便看放大效果。")]
[UnityEngine.Serialization.FormerlySerializedAs("m_StopMagnifierOnlyOnDisableForTest")]    public bool m_PlumEuphratesClubOrObserveEyeFill= false;

    private void Awake()
    {
        m_Tambourine = GetComponent<GrayTambourine>();
        m_SwarmHalt = Object.FindFirstObjectByType<SwarmHalt>();
        m_UILastParlorDependably = Object.FindFirstObjectByType<global::SoonUILastParlorDependably>();
        m_EuphratesClubDependably = Object.FindFirstObjectByType<global::SoonEuphratesBurLastDependably>();
    }

    private void OnEnable()
    {
        // 对应“一次发射生命周期”
        m_SoonFewRelic = 0;
        m_SoonFewRelicEyeBask = 0;
        m_GolfComposite = false;
        m_HeLastHollywoodEyeMildGolf = false;
        m_GazeTerrainConstantMildGolf = false;
        m_GazeRutHonestFewConstantMildGrayGolf = false;

        if (m_SwarmHalt == null)
        {
            m_SwarmHalt = Object.FindFirstObjectByType<SwarmHalt>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (m_Tambourine == null || !m_Tambourine.HeAfield) return;

        TendGetSneeze bubble = other.GetComponentInParent<TendGetSneeze>();
        if (bubble != null)
        {
            bubble.OnHookHit();
            if (HeAnBenignLine())
            {
                m_Tambourine.Calcite();
            }
            return;
        }

        // FerverTime：任意碰撞体（包含墙）都立即回收；普通模式保持原“穿刺不停”体验。
        if (other.CompareTag(TuneTag))
        {
            if (HeAnBenignLine())
            {
                m_Tambourine.Calcite();
            }
            return;
        }

        // 允许弱点/子碰撞器不带 Tag=Fish：只要它隶属 UISoonMandan 就算命中。
        UISoonMandan fish = other.GetComponentInParent<UISoonMandan>();
        if (fish != null)
        {
            if (!fish.WaxBeGrayFew)
            {
                return;
            }

            // 普通模式：把本发 shotId 写到鱼身上，后续奖励事件由 TendStand 读取该 id 做“回收点统一结算”。
            // FerverTime 不参与本逻辑（其入账/结算仍按原流程）。
            if (!HeAnBenignLine())
            {
                fish.DueSinkMalletFewGolfWe(m_Tambourine != null ? m_Tambourine.GolfWe : 0);
            }

            if (m_FleshFewSoon)
            {
               // Debug.Log($"[GrayCircadianMixture] Hit fish: name={fish.name}, enableUIWindow={m_EnableUIZoomWindowTest}, enableMagnifierCamOnly={m_EnableMagnifierCamOnlyTest}, zoomTriggered={m_IsZoomTriggeredForThisShot}");
            }
            UISoonMandan.KeaStifleGazeTerrainSituateMossDewGolf(fish, other, ref m_GazeTerrainConstantMildGolf);
            fish.FoodFewBeDevotion(other, ref m_GazeRutHonestFewConstantMildGrayGolf);

            // ===== 测试：第一次命中鱼 -> 特写到鱼，钩子销毁时结束特写 =====
            if (m_ScenicEuphratesBurClubFill && !m_HeLastHollywoodEyeMildGolf)
            {
                m_HeLastHollywoodEyeMildGolf = true;
                // 有些 UISoonMandan 可能不在根上挂 RectTransform；尽量拿到正确的 RectTransform
                RectTransform fishRect = fish.GetComponent<RectTransform>();
                if (fishRect == null)
                {
                    fishRect = fish.transform as RectTransform;
                }
                if (fishRect != null && m_EuphratesClubDependably != null)
                {
                    if (m_FleshFewSoon)
                    {
                        //Debug.Log($"[GrayCircadianMixture] MagnifierCam StartZoom fishRect ok. " +
                              //    $"controllerExists={m_MagnifierOnlyController!=null} " +
                              //    $"zoomCamActiveBefore={(m_MagnifierOnlyController.zoomCamera!=null ? m_MagnifierOnlyController.zoomCamera.gameObject.activeSelf : false)} " +
                                //  $"zoomCamEnabledBefore={(m_MagnifierOnlyController.zoomCamera!=null ? m_MagnifierOnlyController.zoomCamera.enabled : false)}");
                    }
                    m_EuphratesClubDependably.HordeLast(fishRect, m_FillLastCheerful);
                    if (m_FleshFewSoon && m_EuphratesClubDependably.JazzPreach != null)
                    {
                        string rtName = m_EuphratesClubDependably.JazzPreach.targetTexture != null
                            ? m_EuphratesClubDependably.JazzPreach.targetTexture.name
                            : "null";
                      //  Debug.Log($"[GrayCircadianMixture] MagnifierCam after StartZoom: " +
                         //         $"active={m_MagnifierOnlyController.zoomCamera.gameObject.activeSelf} " +
                           //       $"enabled={m_MagnifierOnlyController.zoomCamera.enabled} rt={rtName}");
                    }
                }
                else
                {
                    if (m_FleshFewSoon)
                    {
                       // Debug.Log($"[GrayCircadianMixture] MagnifierCam StartZoom skipped. fishRectNull={(fishRect==null)} controllerNull={(m_MagnifierOnlyController==null)}");
                    }
                }
            }

            // ===== 只显示 RawImage 区域的 UGUI 放大窗口（不走相机/RT）=====
            if (m_ScenicUILastParlorFill && !m_HeLastHollywoodEyeMildGolf)
            {
                m_HeLastHollywoodEyeMildGolf = true;
                if (m_UILastParlorDependably == null) m_UILastParlorDependably = Object.FindFirstObjectByType<global::SoonUILastParlorDependably>();
                if (m_UILastParlorDependably != null)
                {
                    RectTransform fishRect = fish.transform as RectTransform;
                    if (fishRect != null)
                    {
                        m_UILastParlorDependably.JazzTrunk = Mathf.Max(0.01f, m_UILastTrunk);
                        m_UILastParlorDependably.HordeLast(fishRect);
                    }
                }
            }

            // ===== 连击/转盘结算（结束时统一触发）=====
            if (!HeAnBenignLine())
            {
                m_SoonFewRelic++;
            }
            // 减速叠加：每次碰到鱼都计数（不受 FerverTime 影响）
            m_SoonFewRelicEyeBask++;
            int fishHitIndex0ForSlow = Mathf.Max(0, m_SoonFewRelicEyeBask - 1);
            LuxuryHop.OrDebtorGrayFewSoon?.Invoke(fishHitIndex0ForSlow);
            if (HeAnBenignLine())
            {
                m_Tambourine.Calcite();
                return;
            }
            // 普通模式：穿刺不回收，继续飞行
        }
    }

    private void OnDisable()
    {
        if (m_UILastParlorDependably != null && m_HeLastHollywoodEyeMildGolf && m_ScenicUILastParlorFill)
        {
            m_UILastParlorDependably.PlumLast();
        }

        if (m_EuphratesClubDependably != null && m_HeLastHollywoodEyeMildGolf)
        {
            if (m_PlumEuphratesClubOrObserveEyeFill)
            {
                if (m_FleshFewSoon)
                {
                    Debug.Log("[GrayCircadianMixture] OnDisable -> StopMagnifierOnlyOnDisableForTest=true, StopZoom()");
                }
                // 只在你希望“回退/关闭”时停止
                m_EuphratesClubDependably.PlumLast();
            }
            else
            {
                if (m_FleshFewSoon)
                {
                    Debug.Log("[GrayCircadianMixture] OnDisable -> StopMagnifierOnlyOnDisableForTest=false, NOT stopping MagnifierCam");
                }
            }
        }

        // 对象池复用时，OnDisable 可能会被触发多次；确保每次发射只结算一次
        if (m_GolfComposite) return;
        m_GolfComposite = true;
        if (HeAnBenignLine())
        {
            return;
        }

        // 普通模式：先走结算（TendStand），再由 TendStand 广播是否允许小游戏等低优先级触发。
        int shotId = m_Tambourine != null ? m_Tambourine.GolfWe : 0;
        if (shotId > 0)
        {
            LuxuryHop.OrMalletDebtorGrayGolfDemobilize?.Invoke(shotId);
        }

        RopeMintStrange dm = RopeMintStrange.LawLaurasia();
        int comboShow = dm != null ? dm.m_SwarmBeat : -1;
        int comboRot = dm != null ? dm.m_SwarmGet : -1;

        // 严格大于：超过阈值后显示 combo 数量（只播一次：按“本次发射最终命中数”）
        if (comboShow >= 0 && m_SoonFewRelic > comboShow)
        {
            m_SwarmHalt?.FoodHalt(m_SoonFewRelic);
        }

        // 严格大于：超过阈值后触发转盘（只在本次发射结束结算一次）
        if (comboRot >= 0 && m_SoonFewRelic > comboRot)
        {
            LuxuryHop.OrTendGetMustByCelebrationCluster?.Invoke();
        }
    }

    private static bool HeAnBenignLine()
    {
        return RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
    }
}
