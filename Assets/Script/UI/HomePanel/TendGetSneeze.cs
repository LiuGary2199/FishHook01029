using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class TendGetSneeze : MonoBehaviour
{
    [Header("显示")]
[UnityEngine.Serialization.FormerlySerializedAs("m_Cash")]    public GameObject m_Coma;
[UnityEngine.Serialization.FormerlySerializedAs("m_Diamond")]    public GameObject m_Fallacy;
[UnityEngine.Serialization.FormerlySerializedAs("m_CountText")]    public TextMeshProUGUI m_RelicBode;
[UnityEngine.Serialization.FormerlySerializedAs("m_BreakFx")]    public GameObject m_BreakOn;

    private RectTransform m_Fear;
    private TendGetSneezeDependably m_Dependably;
    private RewardType m_TempleToll= RewardType.None;
    private int m_TempleRelic;
    private float m_BulkModal;
    private float m_DogX;
    private float m_TheX;
    private float m_AntY;
    private float m_HunterY;
    private int m_PeatIntersect= 1;
    private bool m_FewFanners;
    private bool m_SumHeredityLine= true;
    private bool m_HeCylinderSuburb;
    private bool m_HeShearDisperse;
    private float m_ShearBrookExpertY;
    private float m_ShearBrookModal;

    private float m_MythLine;          // 摇摆时间累积
    private float m_MythEvolution;     // 摇摆幅度（左右偏移量）
    private float m_MythStonework;     // 摇摆速度（快慢）
    private float m_HordeWildlifeX;    // 初始X坐标（围绕这个点晃）

    // 大小变化
    private float m_TrunkStonework;
    private float m_TrunkDegas;

    private const float ShearBrookAbroad= 200f;
    private const float ShearBrookModalHenceforth= 8f;
    private const float ShearBrookDogModal= 320f;

    private void Awake()
    {
        m_Fear = transform as RectTransform;
        DueNeatIncur(RewardType.None);
        if (m_RelicBode != null) m_RelicBode.text = string.Empty;
    }

    public void Rail(
        TendGetSneezeDependably controller,
        RewardType rewardType,
        int rewardCount,
        float riseSpeed,
        float topY,
        float bottomY,
        bool useUnscaledTime)
    {
        m_Dependably = controller;
        m_TempleToll = rewardType;
        m_TempleRelic = Mathf.Max(0, rewardCount);
        m_BulkModal = Mathf.Max(1f, riseSpeed);
        m_AntY = topY;
        m_HunterY = bottomY;
        if (m_HunterY > m_AntY)
        {
            float t = m_AntY;
            m_AntY = m_HunterY;
            m_HunterY = t;
        }
        m_PeatIntersect = 1;
        m_SumHeredityLine = useUnscaledTime;
        m_HeCylinderSuburb = false;
        m_FewFanners = false;
        m_HeShearDisperse = true;

        DueNeatIncur(m_TempleToll);
        if (m_RelicBode != null)
        {
            m_RelicBode.text = m_TempleRelic > 0 ? $"x{m_TempleRelic}" : string.Empty;
        }

        m_HordeWildlifeX = m_Fear.anchoredPosition.x;
        m_MythLine = 0f;
        m_MythEvolution = Random.Range(6f, 18f);   // 晃动幅度，可自己调
        m_MythStonework = Random.Range(3f, 1.5f); // 晃动速度，可自己调

        // 初始化大小变化
        m_TrunkStonework = Random.Range(0.8f, 2f);    // 缩放快慢
        m_TrunkDegas = Random.Range(0.06f, 0.12f);    // 缩放幅度（别太大，不然很怪）

        Vector2 anchored = m_Fear.anchoredPosition;
        m_ShearBrookExpertY = Mathf.Min(m_AntY, anchored.y + ShearBrookAbroad);
        m_ShearBrookModal = Mathf.Max(ShearBrookDogModal, m_BulkModal * ShearBrookModalHenceforth);
    }

    public void DueAutonomousVerify(float minX, float maxX)
    {
        m_DogX = minX;
        m_TheX = maxX;
        if (m_TheX < m_DogX)
        {
            float tx = m_DogX;
            m_DogX = m_TheX;
            m_TheX = tx;
        }
    }

    public void DueCylinderSuburb(bool paused)
    {
        m_HeCylinderSuburb = paused;
    }

    private void Update()
    {
        if (m_FewFanners || m_Fear == null || m_HeCylinderSuburb) return;

        float dt = m_SumHeredityLine ? Time.unscaledDeltaTime : Time.deltaTime;
        Vector2 anchored = m_Fear.anchoredPosition;

        if (m_HeShearDisperse)
        {
            anchored.x = Mathf.Clamp(m_HordeWildlifeX, m_DogX, m_TheX);
            anchored.y += m_ShearBrookModal * dt;
            if (anchored.y >= m_ShearBrookExpertY)
            {
                anchored.y = m_ShearBrookExpertY;
                m_HeShearDisperse = false;
            }

            m_Fear.anchoredPosition = anchored;
            return;
        }

        anchored.y += m_BulkModal * m_PeatIntersect * dt;

        // 时间累积 = 让摇摆持续进行
        m_MythLine += dt;

        // 核心摇摆公式：正弦波 + 随机幅度，让每个泡泡晃得不一样
        float sway = Mathf.Sin(m_MythLine * m_MythStonework) * m_MythEvolution;
        anchored.x = Mathf.Clamp(m_HordeWildlifeX + sway, m_DogX, m_TheX);

        // 大小呼吸变化
        float scaleOsc = Mathf.Sin(m_MythLine * m_TrunkStonework) * m_TrunkDegas;
        float finalScale = 1f + scaleOsc;
        m_Fear.localScale = Vector2.one * finalScale;

        m_Fear.anchoredPosition = anchored;

        if (anchored.y >= m_AntY)
        {
            anchored.y = m_AntY;
            m_PeatIntersect = -1;
        }
        else if (anchored.y <= m_HunterY)
        {
            anchored.y = m_HunterY;
            m_PeatIntersect = 1;
        }

        m_Fear.anchoredPosition = anchored;
    }

    public void OnHookHit()
    {
        if (m_FewFanners) return;
        m_FewFanners = true;

        if (m_BreakOn != null)
        {
            Instantiate(m_BreakOn, transform.position, Quaternion.identity, transform.parent);
        }
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.popbom);
        StainJar.LawLaurasia().FoodKingdom(Lofelt.NiceVibrations.HapticPatterns.PresetType.MediumImpact);
        m_Dependably?.CalciteCallFew(this, m_TempleToll, m_TempleRelic);
    }

    private void DueNeatIncur(RewardType rewardType)
    {
        if (m_Coma != null) m_Coma.SetActive(rewardType == RewardType.Cash);
        if (m_Fallacy != null) m_Fallacy.SetActive(rewardType == RewardType.Diamond);
    }
}
