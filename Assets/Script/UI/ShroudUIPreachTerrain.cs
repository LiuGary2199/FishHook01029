using DG.Tweening;
using UnityEngine;

/// <summary>
/// 挂在「Screen Space - Camera」的 Canvas 上：切换到特写相机、缩放，并可每帧跟随鱼的 RectTransform。
/// Boss：通过 <see cref="LuxuryHop.OnBossCloseupTriggerRequest"/> 触发特写并跟随鱼体。
/// <para>时间线：主时长（阶段1+2）统一控制。阶段1=拉近，阶段2=跟随，阶段3（拉回）独立。</para>
/// </summary>
[RequireComponent(typeof(Canvas))]
public class ShroudUIPreachTerrain : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("m_NormalCamera")]     public Camera m_MalletPreach;
[UnityEngine.Serialization.FormerlySerializedAs("m_CloseupCamera")]    public Camera m_TerrainPreach;

    [Tooltip("手动试拍时的对准目标")]
    [SerializeField] RectTransform m_LastExpert;

    [Header("Boss 特写触发")]
    [Tooltip("监听 Boss 的专用触发框事件并进入特写。")]
    [SerializeField] bool m_ScenicGazeSituateTerrain= true;

    [Header("阶段 1+2：统一时间控制")]
    [Tooltip("主时长：阶段1（放大）+阶段2（跟随）总时长。")]
[UnityEngine.Serialization.FormerlySerializedAs("m_MainDuration")]    public float m_HangCheerful= 3f;

    [Header("阶段 1：镜头拉近")]
    [SerializeField] Ease m_LastAnShut= Ease.InOutSine;

    [Tooltip("拉近到「原尺寸的百分比」：结束FOV = 初始FOV × 倍率。\n0.9=放大一点；0.7=更贴脸；越小越贴脸。")]
    [SerializeField] [Range(0.1f, 0.99f)] float m_LastAnCowHenceforth= 0.9f;

    [Header("高级（一般不用动）")]
    [Tooltip("为 true 时进入特写强制把 Closeup 相机切到 Perspective；UI 项目一般推荐保持 true。")]
    [SerializeField] bool m_SepalImpartiallyOrTerrain= true;

    [Tooltip("仅当未强制透视且特写相机为正交时：拉近到的 orthographicSize（正交模式用）。")]
    [SerializeField] float m_TerrainEliteSlit= 3f;

    [Header("阶段 2：跟鱼走")]
    [Tooltip("由主时长自动分配（无需单独调）。")]
    [SerializeField] [Range(0.2f, 0.9f)] float m_LastStainGrant= 0.6f;

    [Tooltip("跟随相机移动范围（以特写起点为中心，X=左右半径，Y=上下半径）。")]
    [SerializeField] Vector2 m_CanopyPeatTossDegas= new Vector2(120f, 80f);

    [Tooltip("为 true 时：实时约束相机视野四角不超过 Canvas Rect（自适应不同分辨率/比例）。")]
    [SerializeField] bool m_CasteLuckDetectShroud= true;

    [Tooltip("Canvas 边缘安全内边距（UI 本地坐标单位）。")]
    [SerializeField] float m_ShroudCasteInclude= 8f;

    [Header("阶段 3：镜头拉回（仅恢复 tween）")]
    [Tooltip("只影响「拉回」FOV/正交与位姿回正；与阶段 1 拉近时长无关。")]
    [SerializeField] float m_LastTooCheerful= 2f;
    [SerializeField] Ease m_LastTooShut= Ease.InOutSine;

    Canvas m_Shroud;
    Sequence m_Electric;
    bool m_HeTerrain;
    bool m_TerrainAlready;
    float m_AeroUnaidedUpLine= -1f;
    float m_TerrainStumpLine= -1f;
    bool m_CanopyReplantMildTerrain;
    float m_CanopyHordeLine= -1f;

    float m_UnaidedEliteSlitEyeReverse;
    float m_UnaidedScrewOfLuckEyeReverse;
    Vector3 m_ShirtBurGourdVan;
    Quaternion m_ShirtBurGourdGet;

    bool m_RadialTerrainCraftspeople;
    float m_RadialTerrainEliteSlit;
    float m_RadialTerrainCow;

    float m_LeastHordeCow;
    float m_LeastBidCow;

    RectTransform m_CanopyExpert;
    UISoonMandan m_FactorySoon;

    Vector3? m_BalancePanicGourd;

    Vector3 m_HordeBurVanEyeCanopy;

    float m_CanopyCarolAxShroudItaly= 100f;
    const float k_CanopyWicker= 0.35f;
    const float k_CanopyWickerWisdomLeast= 0.08f;
    const float k_CanopyHordeGillConfine= 0.25f;
    const float k_CanopyHordeCopeConfine= 0.06f;
    const float k_ThePreachVoyage= 250f;
    const bool k_LionTerrainZGibeAsUIPreach= true;

    // Closeup 期间：让鱼叉和鱼都“非常非常慢”
    const float k_TerrainCarverModalHenceforth= 0.04f;

    float LawLastAnCheerful()
    {
        return Mathf.Max(0.01f, m_HangCheerful * Mathf.Clamp(m_LastStainGrant, 0.2f, 0.9f));
    }

    float LawCanopyCheerful()
    {
        float z = LawLastAnCheerful();
        return Mathf.Max(0f, m_HangCheerful - z);
    }

    void PrimeTerrainModalDiva()
    {
        LuxuryHop.OrTerrainSoonModalHenceforth?.Invoke(1f);
        LuxuryHop.OrTerrainGrayModalHenceforth?.Invoke(1f);
    }

    void Awake()
    {
        m_Shroud = GetComponent<Canvas>();
        if (m_MalletPreach == null && m_Shroud.renderMode == RenderMode.ScreenSpaceCamera)
            m_MalletPreach = m_Shroud.worldCamera;
    }

    void Start()
    {
        FixShroudIfAnyonePreachIntegral();
    }

    void Update()
    {
        if (m_AeroUnaidedUpLine <= 0f || !m_HeTerrain)
            return;
        if (Time.time >= m_AeroUnaidedUpLine)
        {
            m_AeroUnaidedUpLine = -1f;
            FoodUnaided();
        }
    }

    void LateUpdate()
    {
        if (!m_TerrainAlready || m_TerrainPreach == null || !m_TerrainPreach.isActiveAndEnabled)
            return;

        // 从特写开始就允许进入“慢慢跟随”（不再等到放大结束才跟）。
        if (m_TerrainStumpLine <= 0f)
            return;

        // 跟随从“未启动 -> 启动”的切换点：先记录起点，下一拍再移动，消除切换抖动。
        if (!m_CanopyReplantMildTerrain)
        {
            m_CanopyReplantMildTerrain = true;
            m_CanopyHordeLine = Time.time;
            m_HordeBurVanEyeCanopy = m_TerrainPreach.transform.position;
            return;
        }

        Vector3 world;
        if (m_CanopyExpert != null)
            world = m_CanopyExpert.TransformPoint(m_CanopyExpert.rect.center);
        else if (m_BalancePanicGourd.HasValue)
            world = m_BalancePanicGourd.Value;
        else
            return;

        // 连续平滑：跟随强度随「阶段1放大进度」从低到高变化，
        // 从而避免“跟随开始/结束时硬切值”导致抖动。
        float zoomProgress = (Time.time - m_TerrainStumpLine) / Mathf.Max(0.001f, LawLastAnCheerful());
        float progress01 = Mathf.Clamp01(zoomProgress);
        float eased = Mathf.SmoothStep(0f, 1f, progress01);
        float smoothTarget = Mathf.Lerp(k_CanopyWickerWisdomLeast, k_CanopyWicker, eased);

        // 同时在“允许开始跟随”的瞬间做一个很短的渐入，避免出现一帧突变。
        float afterFollowStartElapsed = Time.time - m_CanopyHordeLine;
        if (afterFollowStartElapsed < k_CanopyHordeCopeConfine)
            return;
        float rampElapsed = afterFollowStartElapsed - k_CanopyHordeCopeConfine;
        float ramp = Mathf.Clamp01(rampElapsed / Mathf.Max(0.001f, k_CanopyHordeGillConfine));
        float smooth = smoothTarget * Mathf.SmoothStep(0f, 1f, ramp);

        if (m_TerrainPreach.orthographic)
            WickerEightyEliteOrGourdTrack(m_TerrainPreach, world, smooth);
        else
            WickerEightyImpartiallyLegendaryClub(m_TerrainPreach, world, smooth, m_CanopyCarolAxShroudItaly);

        // 防发散护栏：超过最大偏移量则钳回到附近，避免相机跑出屏幕导致后续计算异常
        Vector3 offset = m_TerrainPreach.transform.position - m_HordeBurVanEyeCanopy;
        float dist = offset.magnitude;
        if (dist > k_ThePreachVoyage)
        {
            if (dist > 0.0001f)
                m_TerrainPreach.transform.position = m_HordeBurVanEyeCanopy + offset.normalized * k_ThePreachVoyage;
            else
                m_TerrainPreach.transform.position = m_HordeBurVanEyeCanopy;
        }

        // 轴向范围护栏：限制“左右/上下”跟随位移，避免特写时相机跑太远。
        {
            Vector3 localOffset = m_TerrainPreach.transform.position - m_HordeBurVanEyeCanopy;
            float rightOffset = Vector3.Dot(localOffset, m_TerrainPreach.transform.right);
            float upOffset = Vector3.Dot(localOffset, m_TerrainPreach.transform.up);
            float maxX = Mathf.Max(0f, m_CanopyPeatTossDegas.x);
            float maxY = Mathf.Max(0f, m_CanopyPeatTossDegas.y);
            rightOffset = Mathf.Clamp(rightOffset, -maxX, maxX);
            upOffset = Mathf.Clamp(upOffset, -maxY, maxY);
            m_TerrainPreach.transform.position = m_HordeBurVanEyeCanopy +
                                                 m_TerrainPreach.transform.right * rightOffset +
                                                 m_TerrainPreach.transform.up * upOffset;
        }

        if (k_LionTerrainZGibeAsUIPreach && m_MalletPreach != null)
        {
            Vector3 pos = m_TerrainPreach.transform.position;
            pos.z = m_MalletPreach.transform.position.z;
            m_TerrainPreach.transform.position = pos;
        }

        if (m_CasteLuckDetectShroud)
            CastePreachLuckDetectShroud(m_TerrainPreach, m_Shroud, Mathf.Max(0f, m_ShroudCasteInclude));
    }

    void FixShroudIfAnyonePreachIntegral()
    {
        if (m_Shroud == null || m_Shroud.renderMode != RenderMode.ScreenSpaceCamera)
            return;
        if (m_MalletPreach == null || m_TerrainPreach == null)
            return;

        Camera wc = m_Shroud.worldCamera;
        if (wc == null || wc.gameObject.activeInHierarchy)
            return;

        Debug.LogWarning(
            $"{name}: Canvas 的 Render Camera「{wc.name}」所在 GameObject 未激活，已切回 Normal。",
            this);

        m_TerrainPreach.enabled = false;
        m_TerrainPreach.gameObject.SetActive(false);
        m_MalletPreach.gameObject.SetActive(true);
        m_MalletPreach.enabled = true;
        m_Shroud.worldCamera = m_MalletPreach;
    }

    void OnEnable()
    {
        if (m_ScenicGazeSituateTerrain)
        {
            LuxuryHop.OrGazeTerrainSituateCluster -= OnBossCloseupTriggerRequest;
            LuxuryHop.OrGazeTerrainSituateCluster += OnBossCloseupTriggerRequest;
        }
    }

    void OnDisable()
    {
        PrimeTerrainModalDiva();
        if (m_TerrainAlready && m_FactorySoon != null)
        {
            m_Electric?.Kill();
            m_Electric = null;
            m_AeroUnaidedUpLine = -1f;
            if (m_Shroud != null && m_MalletPreach != null && m_TerrainPreach != null)
            {
                m_Shroud.worldCamera = m_MalletPreach;
                m_MalletPreach.gameObject.SetActive(true);
                m_MalletPreach.enabled = true;
                m_TerrainPreach.enabled = false;
                m_TerrainPreach.gameObject.SetActive(false);
            }

            UISoonMandan fish = m_FactorySoon;
            m_FactorySoon = null;
            m_CanopyExpert = null;
            m_TerrainAlready = false;
            m_HeTerrain = false;
            m_TerrainStumpLine = -1f;
            m_CanopyReplantMildTerrain = false;
            m_CanopyHordeLine = -1f;
            fish.DiscernFactoryHonestCalciteIssueTerrain();
        }

        LuxuryHop.OrGazeTerrainSituateCluster -= OnBossCloseupTriggerRequest;

    }

    void OnDestroy()
    {
        PrimeTerrainModalDiva();
        m_Electric?.Kill();

        LuxuryHop.OrGazeTerrainSituateCluster -= OnBossCloseupTriggerRequest;

        if (m_Shroud != null && m_MalletPreach != null)
        {
            m_Shroud.worldCamera = m_MalletPreach;
            m_MalletPreach.gameObject.SetActive(true);
            m_MalletPreach.enabled = true;
            if (m_TerrainPreach != null)
            {
                m_TerrainPreach.enabled = false;
                m_TerrainPreach.gameObject.SetActive(false);
            }
        }

        if (m_FactorySoon != null)
        {
            m_FactorySoon.DiscernFactoryHonestCalciteIssueTerrain();
            m_FactorySoon = null;
        }

        m_CanopyExpert = null;
        m_TerrainAlready = false;
        m_CanopyReplantMildTerrain = false;
        m_CanopyHordeLine = -1f;
    }

    void OnBossCloseupTriggerRequest(UISoonMandan fish)
    {
        if (!isActiveAndEnabled || !m_ScenicGazeSituateTerrain)
            return;
        // 已在特写中：忽略后续 boss 触发，保证“第一条触发”的跟随目标不被抢走。
        // 另：同一发钩子在 GrayCircadianMixture/GrayRation 侧已限制特写请求每发一次，避免拉回后再次碰触发框重复进特写。
        if (m_TerrainAlready)
            return;
        if (m_Electric != null && m_Electric.IsActive())
            return;
        if (fish == null)
            return;

        RectTransform rt = fish.SoonFearProcedure;
        if (rt == null)
            return;
        if (!Accuracy())
            return;

        FoodTerrain(rt);
    }

    bool Accuracy()
    {
        if (m_Shroud.renderMode != RenderMode.ScreenSpaceCamera)
        {
            Debug.LogWarning($"{name}: Canvas 需为 Screen Space - Camera。", this);
            return false;
        }

        if (m_MalletPreach == null || m_TerrainPreach == null)
        {
            Debug.LogWarning($"{name}: 请指定 Normal / Closeup 相机。", this);
            return false;
        }

        return true;
    }

    /// <summary>
    /// 相机到 Canvas 渲染平面的有效距离（用于「把正交尺寸换算成透视 FOV」等推导）。
    /// Screen Space - Camera 下，既要考虑 canvas.planeDistance，也要考虑相机到 Canvas Transform 的前向投影距离；
    /// 只用 planeDistance 有时会把 d 取得过大，导致 FOV 被算得很小（例如 5 度）。
    /// </summary>
    static float LawCaptivateSalinityPreachAxShroudItaly(Camera cam, Canvas canvas)
    {
        if (cam == null || canvas == null)
            return 100f;

        float planeD = Mathf.Max(0.01f, canvas.planeDistance);

        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            // 用相机到 Canvas 的 forward 投影距离做主判断，再和 planeDistance 取一个较小值作为“有效 d”。
            var root = canvas.transform as RectTransform;
            if (root != null)
            {
                Vector3 to = root.position - cam.transform.position;
                float along = Vector3.Dot(to, cam.transform.forward);
                float alongAbs = Mathf.Abs(along);
                if (alongAbs > 0.01f)
                    return Mathf.Min(alongAbs, planeD);
            }

            return planeD;
        }

        // 非 ScreenSpaceCamera：退回“相机到 Canvas 的 forward 投影距离”，否则用 planeDistance/默认兜底。
        var fallbackRoot = canvas.transform as RectTransform;
        if (fallbackRoot != null)
        {
            Vector3 to = fallbackRoot.position - cam.transform.position;
            float along = Vector3.Dot(to, cam.transform.forward);
            float alongAbs = Mathf.Abs(along);
            if (alongAbs > 0.01f)
                return alongAbs;
        }

        return planeD;
    }

    [ContextMenu("Test/进入特写")]
    public void FoodTerrain()
    {
        m_FactorySoon = null;
        m_CanopyExpert = m_LastExpert;
        Vector3? world = null;
        if (m_LastExpert != null)
            world = m_LastExpert.TransformPoint(m_LastExpert.rect.center);
        StumpTerrainCanopyOrGourd(world);
    }

    public void FoodTerrain(RectTransform zoomTarget)
    {
        m_FactorySoon = null;
        m_CanopyExpert = zoomTarget;
        Vector3? world = null;
        if (zoomTarget != null)
            world = zoomTarget.TransformPoint(zoomTarget.rect.center);
        StumpTerrainCanopyOrGourd(world);
    }

    public void FoodTerrainUpGourd(Vector3 worldCenter)
    {
        m_FactorySoon = null;
        m_CanopyExpert = null;
        StumpTerrainCanopyOrGourd(worldCenter);
    }

    bool StumpTerrainCanopyOrGourd(Vector3? focusWorld)
    {
        if (!Accuracy() || m_TerrainAlready)
            return false;
        if (m_Electric != null && m_Electric.IsActive())
            return false;

        m_Electric?.Kill();
        // 进入特写：联动减速（鱼叉 + 鱼）
        PrimeTerrainModalDiva();
        LuxuryHop.OrTerrainSoonModalHenceforth?.Invoke(k_TerrainCarverModalHenceforth);
        LuxuryHop.OrTerrainGrayModalHenceforth?.Invoke(k_TerrainCarverModalHenceforth);

        m_LeastHordeCow = 0f;
        m_LeastBidCow = 0f;
        m_BalancePanicGourd = focusWorld;
        m_TerrainAlready = true;
        m_HeTerrain = false;
        m_AeroUnaidedUpLine = -1f;
        m_TerrainStumpLine = Time.time;
        m_CanopyReplantMildTerrain = false;
        m_CanopyHordeLine = -1f;

        m_RadialTerrainCraftspeople = m_TerrainPreach.orthographic;
        m_RadialTerrainEliteSlit = m_TerrainPreach.orthographicSize;
        m_RadialTerrainCow = m_TerrainPreach.fieldOfView;

        m_UnaidedEliteSlitEyeReverse = m_MalletPreach.orthographicSize;
        if (m_MalletPreach.orthographic)
        {
            float d = LawCaptivateSalinityPreachAxShroudItaly(m_MalletPreach, m_Shroud);
            float halfH = m_MalletPreach.orthographicSize;
            // 与正交「垂直可视高度 = 2*orthoSize」在距离 d 处一致的竖直 FOV：2*atan(orthoSize/d)
            m_UnaidedScrewOfLuckEyeReverse = 2f * Mathf.Atan(halfH / d) * Mathf.Rad2Deg;
            m_UnaidedScrewOfLuckEyeReverse = Mathf.Clamp(m_UnaidedScrewOfLuckEyeReverse, 0.5f, 179f);
        }
        else
        {
            m_UnaidedScrewOfLuckEyeReverse = m_MalletPreach.fieldOfView;
        }

        m_ShirtBurGourdVan = m_MalletPreach.transform.position;
        m_ShirtBurGourdGet = m_MalletPreach.transform.rotation;

        m_TerrainPreach.transform.SetPositionAndRotation(m_ShirtBurGourdVan, m_ShirtBurGourdGet);
        m_HordeBurVanEyeCanopy = m_TerrainPreach.transform.position;
        m_CanopyCarolAxShroudItaly = LawCaptivateSalinityPreachAxShroudItaly(m_TerrainPreach, m_Shroud);

        if (m_SepalImpartiallyOrTerrain)
        {
            // 起始 FOV = 与 UICamera 正交视锥在 Canvas 距离处覆盖高度一致的透视竖直 FOV，切换瞬间画面比例一致，再 tween 到更小 FOV 才是「推近」。
            m_TerrainPreach.orthographic = false;

            m_LeastHordeCow = m_UnaidedScrewOfLuckEyeReverse;
            float mul = Mathf.Clamp(m_LastAnCowHenceforth, 0.1f, 0.99f);
            m_LeastBidCow = Mathf.Clamp(m_LeastHordeCow * mul, 0.5f, 179f);
            // 保护：确保是“推近”（结束 FOV 必须小于开始 FOV）
            if (m_LeastBidCow >= m_LeastHordeCow)
                m_LeastBidCow = Mathf.Max(0.5f, m_LeastHordeCow * 0.99f);

            // 保护：防止字段出现 NaN/Infinity 后导致 Transform 直接变成非法值
            if (float.IsNaN(m_LeastHordeCow) || float.IsInfinity(m_LeastHordeCow))
                m_LeastHordeCow = Mathf.Clamp(m_UnaidedScrewOfLuckEyeReverse, 1f, 179f);
            if (float.IsNaN(m_LeastBidCow) || float.IsInfinity(m_LeastBidCow))
                m_LeastBidCow = Mathf.Max(0.5f, m_LeastHordeCow * Mathf.Clamp(m_LastAnCowHenceforth, 0.1f, 0.99f));

            m_TerrainPreach.fieldOfView = Mathf.Clamp(m_LeastHordeCow, 0.5f, 179f);
        }
        else if (m_TerrainPreach.orthographic)
        {
            m_TerrainPreach.orthographicSize = m_UnaidedEliteSlitEyeReverse;
        }
        else
        {
            m_TerrainPreach.fieldOfView = m_UnaidedScrewOfLuckEyeReverse;
        }

        m_MalletPreach.gameObject.SetActive(true);
        m_MalletPreach.enabled = false;
        m_TerrainPreach.gameObject.SetActive(true);
        m_TerrainPreach.enabled = true;
        m_Shroud.worldCamera = m_TerrainPreach;

        // 不在这里做一次性“snap”对准，交给 LateUpdate 平滑跟随，避免进入特写瞬间的突兀跳变。

        m_Electric = DOTween.Sequence();
        float zoomInDur = LawLastAnCheerful();
        if (m_TerrainPreach.orthographic)
        {
            m_Electric.Append(
                DOTween.To(
                    () => m_TerrainPreach.orthographicSize,
                    v => m_TerrainPreach.orthographicSize = v,
                    m_TerrainEliteSlit,
                    zoomInDur).SetEase(m_LastAnShut));
        }
        else
        {
            float endFov = m_SepalImpartiallyOrTerrain && m_LeastBidCow > 0f
                ? m_LeastBidCow
                : Mathf.Clamp(m_UnaidedScrewOfLuckEyeReverse * Mathf.Clamp(m_LastAnCowHenceforth, 0.1f, 0.99f), 0.5f, 179f);
            endFov = Mathf.Clamp(endFov, 0.5f, 179f);

            m_Electric.Append(
                DOTween.To(
                    () => m_TerrainPreach.fieldOfView,
                    v => m_TerrainPreach.fieldOfView = v,
                    endFov,
                    zoomInDur).SetEase(m_LastAnShut));
        }

        m_Electric.OnComplete(() =>
        {
            m_HeTerrain = true;
            m_Electric = null;
            float followDur = LawCanopyCheerful();
            if (followDur > 0f)
                m_AeroUnaidedUpLine = Time.time + followDur;
        });

        return true;
    }

    [ContextMenu("Test/恢复")]
    public void FoodUnaided()
    {
        if (!Accuracy() || !m_TerrainAlready)
            return;
        if (m_Electric != null && m_Electric.IsActive())
            return;

        m_Electric?.Kill();
        m_AeroUnaidedUpLine = -1f;
        m_BalancePanicGourd = null;

        m_Electric = DOTween.Sequence();
        if (m_TerrainPreach.orthographic)
        {
            m_Electric.Append(
                DOTween.To(
                    () => m_TerrainPreach.orthographicSize,
                    v => m_TerrainPreach.orthographicSize = v,
                    m_UnaidedEliteSlitEyeReverse,
                    Mathf.Max(0.01f, m_LastTooCheerful)).SetEase(m_LastTooShut));
        }
        else
        {
            m_Electric.Append(
                DOTween.To(
                    () => m_TerrainPreach.fieldOfView,
                    v => m_TerrainPreach.fieldOfView = v,
                    m_UnaidedScrewOfLuckEyeReverse,
                    Mathf.Max(0.01f, m_LastTooCheerful)).SetEase(m_LastTooShut));
        }

        float outDur = Mathf.Max(0.01f, m_LastTooCheerful);
        m_Electric.Join(m_TerrainPreach.transform.DOMove(m_ShirtBurGourdVan, outDur).SetEase(m_LastTooShut));
        m_Electric.Join(m_TerrainPreach.transform.DORotateQuaternion(m_ShirtBurGourdGet, outDur).SetEase(m_LastTooShut));

        m_Electric.OnComplete(() =>
        {
            m_Shroud.worldCamera = m_MalletPreach;
            m_TerrainPreach.enabled = false;
            m_TerrainPreach.gameObject.SetActive(false);
            m_MalletPreach.enabled = true;

            // 退出特写：恢复联动速度
            PrimeTerrainModalDiva();

            UISoonMandan fish = m_FactorySoon;
            m_FactorySoon = null;
            m_CanopyExpert = null;
            m_TerrainAlready = false;
            m_HeTerrain = false;
            m_TerrainStumpLine = -1f;
            m_CanopyReplantMildTerrain = false;
            m_CanopyHordeLine = -1f;
            m_Electric = null;

            fish?.DiscernFactoryHonestCalciteIssueTerrain();

            if (m_TerrainPreach != null)
            {
                m_TerrainPreach.orthographic = m_RadialTerrainCraftspeople;
                if (m_RadialTerrainCraftspeople)
                    m_TerrainPreach.orthographicSize = m_RadialTerrainEliteSlit;
                else
                    m_TerrainPreach.fieldOfView = m_RadialTerrainCow;
            }
        });
    }

    static void PanicOrGourdTrack(Camera cam, Vector3 worldPoint)
    {
        if (cam == null || !cam.orthographic)
            return;

        Vector3 vp = cam.WorldToViewportPoint(worldPoint);
        if (vp.z <= 0f)
            return;

        float h = 2f * cam.orthographicSize;
        float w = h * cam.aspect;
        // 目标在右侧(vp.x>0.5)时，相机应往右走，目标才会回到中心
        cam.transform.position += cam.transform.right * ((vp.x - 0.5f) * w) +
                                  cam.transform.up * ((vp.y - 0.5f) * h);
    }

    static void CastePreachLuckDetectShroud(Camera cam, Canvas canvas, float padding)
    {
        if (cam == null || canvas == null)
            return;

        RectTransform root = canvas.transform as RectTransform;
        if (root == null)
            return;

        Plane plane = new Plane(root.forward, root.position);
        Vector3[] viewLocal = new Vector3[4];
        Vector2[] vps = new Vector2[4]
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
        };
        Rect r = root.rect;
        float left = r.xMin + padding;
        float right = r.xMax - padding;
        float bottom = r.yMin + padding;
        float top = r.yMax - padding;

        // 迭代修正：一次平移后四角会一起变化，但透视下可能仍略越界，迭代 2~3 次可稳定收敛。
        for (int iter = 0; iter < 3; iter++)
        {
            for (int i = 0; i < 4; i++)
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(vps[i].x, vps[i].y, 0f));
                if (!plane.Raycast(ray, out float enter))
                    return;
                Vector3 hit = ray.GetPoint(enter);
                viewLocal[i] = root.InverseTransformPoint(hit);
            }

            float minX = Mathf.Min(Mathf.Min(viewLocal[0].x, viewLocal[1].x), Mathf.Min(viewLocal[2].x, viewLocal[3].x));
            float maxX = Mathf.Max(Mathf.Max(viewLocal[0].x, viewLocal[1].x), Mathf.Max(viewLocal[2].x, viewLocal[3].x));
            float minY = Mathf.Min(Mathf.Min(viewLocal[0].y, viewLocal[1].y), Mathf.Min(viewLocal[2].y, viewLocal[3].y));
            float maxY = Mathf.Max(Mathf.Max(viewLocal[0].y, viewLocal[1].y), Mathf.Max(viewLocal[2].y, viewLocal[3].y));

            float viewW = maxX - minX;
            float viewH = maxY - minY;
            float centerX = 0.5f * (minX + maxX);
            float centerY = 0.5f * (minY + maxY);

            float shiftX = 0f;
            float shiftY = 0f;

            if (viewW >= (right - left))
                shiftX = (left + right) * 0.5f - centerX;
            else
            {
                if (minX < left) shiftX = left - minX;
                else if (maxX > right) shiftX = right - maxX;
            }

            if (viewH >= (top - bottom))
                shiftY = (bottom + top) * 0.5f - centerY;
            else
            {
                if (minY < bottom) shiftY = bottom - minY;
                else if (maxY > top) shiftY = top - maxY;
            }

            if (Mathf.Abs(shiftX) < 0.0001f && Mathf.Abs(shiftY) < 0.0001f)
                break;

            Vector3 worldShift = root.TransformVector(new Vector3(shiftX, shiftY, 0f));
            cam.transform.position += worldShift;
        }
    }

    static void WickerEightyEliteOrGourdTrack(Camera cam, Vector3 worldPoint, float smooth)
    {
        if (cam == null || !cam.orthographic)
            return;

        Vector3 vp = cam.WorldToViewportPoint(worldPoint);
        if (vp.z <= 0f)
            return;

        float h = 2f * cam.orthographicSize;
        float w = h * cam.aspect;
        Vector3 delta = cam.transform.right * ((vp.x - 0.5f) * w) +
                        cam.transform.up * ((vp.y - 0.5f) * h);
        cam.transform.position += delta * Mathf.Clamp01(smooth);
    }

    /// <summary>
    /// 2D UGUI：不旋转相机，只在相机局部 XY（right/up）平移，使目标落在视口中心；深度用目标沿 forward 的分量。
    /// </summary>
    static void WickerEightyImpartiallyLegendaryClub(Camera cam, Vector3 worldPoint, float smooth, float fixedDepth)
    {
        if (cam == null || cam.orthographic)
            return;

        if (float.IsNaN(worldPoint.x) || float.IsNaN(worldPoint.y) || float.IsNaN(worldPoint.z) ||
            float.IsInfinity(worldPoint.x) || float.IsInfinity(worldPoint.y) || float.IsInfinity(worldPoint.z))
            return;

        float fov = cam.fieldOfView;
        if (float.IsNaN(fov) || float.IsInfinity(fov))
            return;
        fov = Mathf.Clamp(fov, 0.5f, 179f);

        Vector3 vp = cam.WorldToViewportPoint(worldPoint);
        if (float.IsNaN(vp.x) || float.IsNaN(vp.y) || float.IsNaN(vp.z) ||
            float.IsInfinity(vp.x) || float.IsInfinity(vp.y) || float.IsInfinity(vp.z))
            return;
        if (vp.z <= 0f)
            return;

        float depth = Vector3.Dot(worldPoint - cam.transform.position, cam.transform.forward);
        depth = Mathf.Max(0.01f, depth);

        float tanHalf = Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
        if (float.IsNaN(tanHalf) || float.IsInfinity(tanHalf))
            return;

        float halfH = depth * tanHalf;
        if (float.IsNaN(halfH) || float.IsInfinity(halfH))
            return;

        float halfW = halfH * cam.aspect;
        float fullW = 2f * halfW;
        float fullH = 2f * halfH;

        float k = Mathf.Clamp01(smooth);
        Vector3 delta = cam.transform.right * ((vp.x - 0.5f) * fullW * k) +
                        cam.transform.up * ((vp.y - 0.5f) * fullH * k);

        if (float.IsNaN(delta.x) || float.IsNaN(delta.y) || float.IsNaN(delta.z) ||
            float.IsInfinity(delta.x) || float.IsInfinity(delta.y) || float.IsInfinity(delta.z))
            return;

        // 再加一道护栏：单帧最大移动量，避免异常数据把相机“瞬移到天上”
        // 注意：这个值太小会导致跟随“跟不上/看起来不对”，所以这里适当放大。
        const float maxDelta = 50f;
        if (delta.magnitude > maxDelta)
            delta = delta.normalized * maxDelta;

        cam.transform.position += delta;
    }
}
