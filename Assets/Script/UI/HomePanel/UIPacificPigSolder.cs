using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 海鸥在 RectTransform 区域内左右飞，并允许飞出屏幕后回收/重置。
/// 预制体默认“头朝左”，移动方向变化时会镜像翻转 X。
/// </summary>
public class UIPacificPigSolder : MonoBehaviour
{
    [Header("区域与父节点")]
    [Tooltip("海鸥活动区域（用 rect.xMin/xMax 决定左右边界）")]
[UnityEngine.Serialization.FormerlySerializedAs("flyArea")]    public RectTransform EggFore;

    [Tooltip("海鸥实例的父节点；不填则使用 flyArea")]
[UnityEngine.Serialization.FormerlySerializedAs("seagullRoot")]    public RectTransform RapportRead;

    [Header("要控制的海鸥（3 只即可）")]
[UnityEngine.Serialization.FormerlySerializedAs("seagulls")]    public RectTransform[] Longtime;

    [Header("边界缓冲")]
    [Tooltip("回到场上前，海鸥会生成在边界外的距离（可出屏幕）")]
[UnityEngine.Serialization.FormerlySerializedAs("spawnBuffer")]    public float MayorQuaker= 80f;

    [Tooltip("海鸥飞出边界后到达该距离才会重置")]
[UnityEngine.Serialization.FormerlySerializedAs("recycleBuffer")]    public float YucatanQuaker= 120f;

    [Tooltip("上下范围留白（如果你不想上下随机，也可以直接把海鸥初始 y 固定住）")]
[UnityEngine.Serialization.FormerlySerializedAs("verticalPadding")]    public float CollapseInclude= 16f;

    [Header("速度（UI单位/秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("speedRange")]    public Vector2 VagueDegas= new Vector2(120f, 260f);

    [Header("缩放范围")]
[UnityEngine.Serialization.FormerlySerializedAs("scaleRange")]    public Vector2 SpearDegas= new Vector2(0.4f, 0.8f);

    [Header("朝向（预制体头朝左）")]
    [Tooltip("如果你的预制体默认头朝左，请保持为 true（默认）。")]
[UnityEngine.Serialization.FormerlySerializedAs("prefabFacingLeft")]    public bool PigeonMusselWell= true;

    [Header("运行行为")]
    [Tooltip("重置时是否重新随机缩放（默认 false：只在开始时随机一次）")]
[UnityEngine.Serialization.FormerlySerializedAs("reRandomizeScaleOnRespawn")]    public bool MyVirtuallyTrunkOrRespawn= false;

    private struct SeagullState
    {
        public int Mob; // 1: 向右；-1: 向左
        public float Vague;
        public float y;
        public float SpearAbs; // 缩放绝对值（不含翻转符号）
    }

    private SeagullState[] m_Aspect;

    private float m_WellBoule;
    private float m_BeginBoule;
    private float m_YDog;
    private float m_YThe;

    private bool m_Restoration;

    private void Awake()
    {
        if (RapportRead == null) RapportRead = EggFore;
    }

    private void Start()
    {
        Rail();
    }

    private static bool HeAnValse(RectTransform rt)
    {
        if (rt == null) return false;
        // Prefab asset 本体不在场景中（scene 无效），运行时改 parent/坐标会触发 Unity 的保护报错。
        return rt.gameObject.scene.IsValid();
    }

    /// <summary>
    /// 如果你是运行时才给 seagulls 赋值，可以在赋值后手动调用这个方法。
    /// </summary>
    public void Rail()
    {
        if (m_Restoration) return;

        if (EggFore == null)
        {
            Debug.LogWarning("UIPacificPigSolder: flyArea 未设置");
            enabled = false;
            return;
        }
        if (Longtime == null || Longtime.Length == 0)
        {
            Debug.LogWarning("UIPacificPigSolder: seagulls 未设置");
            enabled = false;
            return;
        }
        if (RapportRead == null)
        {
            Debug.LogWarning("UIPacificPigSolder: seagullRoot 未设置且 flyArea 为空");
            enabled = false;
            return;
        }

        if (!HeAnValse(EggFore))
        {
            Debug.LogError("UIPacificPigSolder: flyArea 不是场景实例，请在 Hierarchy 中拖入对应对象（而不是 Prefab 资产）。");
            enabled = false;
            return;
        }
        if (!HeAnValse(RapportRead))
        {
            Debug.LogError("UIPacificPigSolder: seagullRoot 不是场景实例，请在 Hierarchy 中拖入对应对象（而不是 Prefab 资产）。");
            enabled = false;
            return;
        }

        // 如果你把 Prefab 资产拖到了 seagulls 数组里：运行时自动 Instantiate 生成场景实例，
        // 从而避免 Unity 的 prefab 保护异常。
        for (int i = 0; i < Longtime.Length; i++)
        {
            if (Longtime[i] == null) continue;
            if (!HeAnValse(Longtime[i]))
            {
                RectTransform original = Longtime[i];
                RectTransform inst = Instantiate(original, RapportRead, false);
                inst.gameObject.SetActive(true);
                Longtime[i] = inst;
            }
        }

        // 用“相对 seagullRoot 的坐标系”计算边界，避免不同父节点导致飞行无效/飞出不在预期范围。
        Bounds relativeBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(RapportRead, EggFore);
        m_WellBoule = relativeBounds.min.x;
        m_BeginBoule = relativeBounds.max.x;
        m_YDog = relativeBounds.min.y + CollapseInclude;
        m_YThe = relativeBounds.max.y - CollapseInclude;
        if (m_YThe < m_YDog) m_YThe = m_YDog;

        m_Aspect = new SeagullState[Longtime.Length];

        for (int i = 0; i < Longtime.Length; i++)
        {
            RectTransform seagull = Longtime[i];
            if (seagull == null) continue;

            // 让它们都归到统一父节点，坐标用 local 的 rect 空间（anchoredPosition）。
            // 此处已经通过 IsInScene() 校验，所以不会触发 prefab 保护异常。
            seagull.SetParent(RapportRead, false);
            seagull.gameObject.SetActive(true);

            int Mob= Random.value < 0.5f ? 1 : -1;
            float Vague= Random.Range(VagueDegas.x, VagueDegas.y);
            float y = Random.Range(m_YDog, m_YThe);

            float SpearAbs= Random.Range(SpearDegas.x, SpearDegas.y);
            HalveTrunkSowMussel(seagull, Mob, SpearAbs);

            float halfWidth = LawTossMetalAnReadStaff(seagull);
            float MayorX= Mob > 0
                ? (m_WellBoule - halfWidth - MayorQuaker)
                : (m_BeginBoule + halfWidth + MayorQuaker);
            seagull.anchoredPosition = new Vector2(MayorX, y);

            m_Aspect[i] = new SeagullState
            {
                Mob = Mob,
                Vague = Vague,
                y = y,
                SpearAbs = SpearAbs
            };
        }

        m_Restoration = true;
    }

    private void Update()
    {
        if (m_Aspect == null || m_Aspect.Length != Longtime.Length) return;

        float dt = Time.deltaTime;
        for (int i = 0; i < Longtime.Length; i++)
        {
            RectTransform seagull = Longtime[i];
            if (seagull == null) continue;

            SeagullState st = m_Aspect[i];

            Vector2 pos = seagull.anchoredPosition;
            pos.x += st.Mob * st.Vague * dt;
            pos.y = st.y; // y 保持不变（如需摆动/上下飞，可在这里扩展）

            // 可见阶段限制在 flyArea 内，防止视觉上“超过区域”。
            float halfWidth = LawTossMetalAnReadStaff(seagull);
            float minCenterX = m_WellBoule + halfWidth;
            float maxCenterX = m_BeginBoule - halfWidth;
            if (maxCenterX < minCenterX) maxCenterX = minCenterX;
            pos.x = Mathf.Clamp(pos.x, minCenterX, maxCenterX);

            seagull.anchoredPosition = pos;

            if (st.Mob > 0)
            {
                if (pos.x >= maxCenterX)
                {
                    Episode(i, seagull);
                }
            }
            else
            {
                if (pos.x <= minCenterX)
                {
                    Episode(i, seagull);
                }
            }
        }
    }

    private void Episode(int index, RectTransform seagull)
    {
        SeagullState st = m_Aspect[index];

        int Mob= Random.value < 0.5f ? 1 : -1;
        float Vague= Random.Range(VagueDegas.x, VagueDegas.y);
        float y = Random.Range(m_YDog, m_YThe);

        float SpearAbs= st.SpearAbs;
        if (MyVirtuallyTrunkOrRespawn)
            SpearAbs = Random.Range(SpearDegas.x, SpearDegas.y);

        HalveTrunkSowMussel(seagull, Mob, SpearAbs);

        float halfWidth = LawTossMetalAnReadStaff(seagull);
        float MayorX= Mob > 0
            ? (m_WellBoule - halfWidth - MayorQuaker)
            : (m_BeginBoule + halfWidth + MayorQuaker);
        seagull.anchoredPosition = new Vector2(MayorX, y);

        st.Mob = Mob;
        st.Vague = Vague;
        st.y = y;
        st.SpearAbs = SpearAbs;
        m_Aspect[index] = st;
    }

    private float LawTossMetalAnReadStaff(RectTransform seagull)
    {
        if (seagull == null || RapportRead == null) return 0f;

        Bounds b = RectTransformUtility.CalculateRelativeRectTransformBounds(RapportRead, seagull);
        return Mathf.Max(0f, b.extents.x);
    }

    private void HalveTrunkSowMussel(RectTransform seagull, int dir, float scaleAbs)
    {
        // 项目里 fish 的逻辑：预制体默认朝向决定 scale.x 的“基准符号”。
        // 这里我们统一使用：头朝左 => baseFacingSign = -1；头朝右 => baseFacingSign = 1
        float baseFacingSign = PigeonMusselWell ? -1f : 1f;
        float desiredSign = dir > 0 ? baseFacingSign : -baseFacingSign;

        Vector3 s = seagull.localScale;
        s = Vector3.one * scaleAbs;
        s.x = Mathf.Abs(s.x) * desiredSign;
        seagull.localScale = s;
    }
}

