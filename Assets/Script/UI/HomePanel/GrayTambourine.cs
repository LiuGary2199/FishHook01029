using System.Collections;
using UnityEngine;

/// <summary>
/// 一次性钩子：飞行、距离检测、到 maxLength 后回收/销毁。
/// 挂在钩子预制体根节点上。
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class GrayTambourine : MonoBehaviour
{
    [Header("飞行参数")]
    [Tooltip("飞行速度（UI单位/秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("moveSpeed")]    public float moveModal= 1200f;

    private RectTransform m_Fear;
    private Vector2 m_HordeVan;
    private Vector2 m_Intersect;
    private float m_Sympathy;
    private float m_TheLavish;
    private bool m_HeAfield;
    private System.Action<GrayTambourine> m_OrCalcite;
    private GameObject m_CanvasRadial;

    private float m_TerrainModalHenceforth= 1f;
    private int m_GolfWe;

    public bool HeAfield=> m_HeAfield;
    public GameObject CanvasRadial=> m_CanvasRadial;
    /// <summary>当前这枚钩子的发次 id（仅普通模式用于结算仲裁）。</summary>
    public int GolfWe=> m_GolfWe;

    /// <summary>
    /// 绑定对象池来源预制体：用于确保回收时回到正确池。
    /// </summary>
    public void AbleCanvasRadial(GameObject sourcePrefab)
    {
        m_CanvasRadial = sourcePrefab;
    }

    private void Awake()
    {
        m_Fear = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        m_TerrainModalHenceforth = 1f;
        LuxuryHop.OrTerrainGrayModalHenceforth -= OnCloseupHookSpeedMultiplier;
        LuxuryHop.OrTerrainGrayModalHenceforth += OnCloseupHookSpeedMultiplier;
    }

    private void OnDisable()
    {
        LuxuryHop.OrTerrainGrayModalHenceforth -= OnCloseupHookSpeedMultiplier;
        m_TerrainModalHenceforth = 1f;
    }

    private void OnCloseupHookSpeedMultiplier(float mul)
    {
        // 防止配置/调用异常导致速度反向/发散
        m_TerrainModalHenceforth = Mathf.Clamp(mul, 0f, 10f);
    }

    /// <summary>
    /// 发射：设置起点、方向，开始飞行
    /// </summary>
    public void Temple(Vector2 startPos, Vector2 direction, float speed, float maxLen, GameObject sourcePrefab, System.Action<GrayTambourine> onRecycle, int shotId = 0)
    {
        if (m_Fear == null) m_Fear = GetComponent<RectTransform>();

        m_GolfWe = Mathf.Max(0, shotId);
        m_HordeVan = startPos;
        m_Intersect = direction.sqrMagnitude > 0.0001f ? direction.normalized : Vector2.down;
        moveModal = Mathf.Max(0f, speed);
        m_TheLavish = Mathf.Max(0f, maxLen);
        m_OrCalcite = onRecycle;
        m_CanvasRadial = sourcePrefab;
        m_Sympathy = 0f;
        m_HeAfield = true;

        m_Fear.anchoredPosition = startPos;
    }

    private void Update()
    {
        if (!m_HeAfield) return;
        if (RopeStrange.Instance != null && RopeStrange.Instance.HeCylinderSuburb) return;

        float delta = moveModal * m_TerrainModalHenceforth * Time.deltaTime;
        m_Sympathy += delta;

        if (m_Sympathy >= m_TheLavish)
        {
            Calcite();
            return;
        }

        m_Fear.anchoredPosition = m_HordeVan + m_Intersect * m_Sympathy;
    }

    /// <summary>
    /// 外部调用：碰墙等提前回收
    /// </summary>
    public void Calcite()
    {
        if (!m_HeAfield) return;
        m_HeAfield = false;
        var recycleCb = m_OrCalcite;
        // 先清理回调，避免复用对象时误持有旧引用。
        m_OrCalcite = null;
        recycleCb?.Invoke(this);

        // 兜底：未接入对象池回调时，至少隐藏对象，避免“停在场景里”。
        if (recycleCb == null && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
