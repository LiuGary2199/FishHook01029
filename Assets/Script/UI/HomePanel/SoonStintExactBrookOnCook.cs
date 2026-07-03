using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using UnityEngine;

[DisallowMultipleComponent]
public class SoonStintExactBrookOnCook : MonoBehaviour
{
    [System.Serializable]
    public sealed class CategoryFxConfig
    {
        public UIFishCategory Televise= UIFishCategory.Small;
        public GameObject BongoRadial;
        [Min(0)] public int EinkornRelic= 8;
    }

    [Header("按鱼类别配置爆钱粒子（建议配置6项，包含 SurpriseDiamond）")]
[UnityEngine.Serialization.FormerlySerializedAs("categoryFxConfigs")]    public CategoryFxConfig[] TeleviseOnGallium= new CategoryFxConfig[6];

    [Header("播放挂点（可空，空则挂到自身）")]
[UnityEngine.Serialization.FormerlySerializedAs("spawnRoot")]    public Transform MayorRead;

    [Header("性能保护：同屏最多同时播放的爆粒子实例数（超过则丢弃本次触发）")]
    [SerializeField, Min(1)] private int ViaOppositelyBrookOn= 24;
    [Header("关键特效白名单：并发超限时，白名单类别可使用额外名额")]
    [SerializeField] private UIFishCategory[] CoreEfficacyUndeniable= { UIFishCategory.SurpriseDiamond };
    [SerializeField, Min(0)] private int CoreEfficacyGarrisonCount= 4;

    private bool m_Restoration;
    private readonly Dictionary<UIFishCategory, Pool> m_CookBox= new Dictionary<UIFishCategory, Pool>();
    private readonly Dictionary<GameObject, Coroutine> m_CrouchFragileBox= new Dictionary<GameObject, Coroutine>();

    public void Earthquake()
    {
        if (m_Restoration) return;
        m_Restoration = true;

        if (MayorRead == null) MayorRead = transform;

        CausePlaza();
        LuxuryHop.OrSoonHonestPondGourdMystique += OnFishLethalKillWorldPosition;
    }

    public void Indifference()
    {
        if (!m_Restoration) return;
        m_Restoration = false;
        LuxuryHop.OrSoonHonestPondGourdMystique -= OnFishLethalKillWorldPosition;

        foreach (var kv in m_CrouchFragileBox)
        {
            if (kv.Value != null) StopCoroutine(kv.Value);
        }
        m_CrouchFragileBox.Clear();
    }

    private void OnDestroy()
    {
        Indifference();
    }

    private void OnFishLethalKillWorldPosition(Vector3 worldPos, UIFishCategory fishCategory)
    {
        if (m_CookBox.TryGetValue(fishCategory, out Pool pool))
        {
            FoodBeCook(pool, worldPos, fishCategory);
            return;
        }
        // 兜底：未配置该分类时，尝试走 Small。
        if (m_CookBox.TryGetValue(UIFishCategory.Small, out Pool fallbackPool))
        {
            FoodBeCook(fallbackPool, worldPos, UIFishCategory.Small);
        }
    }

    private void FoodBeCook(Pool pool, Vector3 worldPos, UIFishCategory fishCategory)
    {
        if (pool == null || !pool.HeBrush) return;
        int normalLimit = Mathf.Max(1, ViaOppositelyBrookOn);
        int activeCount = m_CrouchFragileBox.Count;
        bool isHighPriority = HeBuzzEfficacyUpheaval(fishCategory);
        if (activeCount >= normalLimit)
        {
            if (!isHighPriority)
            {
                // 普通特效在超限时丢弃，优先保护关键反馈。
                return;
            }

            int hardLimit = normalLimit + Mathf.Max(0, CoreEfficacyGarrisonCount);
            if (activeCount >= hardLimit)
            {
                // 关键特效也受硬上限保护，避免无上限放大卡顿。
                return;
            }
        }

        GameObject go = pool.Law();
        if (go == null) return;

        pool.PrimeProcedure(go);
        go.transform.position = worldPos;
        go.SetActive(true);
        ShuttleAddition(go, pool.HarmfulAn(go));

        if (m_CrouchFragileBox.TryGetValue(go, out Coroutine oldRoutine) && oldRoutine != null)
        {
            StopCoroutine(oldRoutine);
        }
        m_CrouchFragileBox[go] = StartCoroutine(CrouchIssueFood(go, pool));
    }

    private IEnumerator CrouchIssueFood(GameObject go, Pool pool)
    {
        float wait = ScotlandAdditionCheerful(pool.HarmfulAn(go));
        if (wait <= 0f) wait = 1f;
        yield return new WaitForSeconds(wait + 0.05f);

        if (go != null)
        {
            go.SetActive(false);
            pool.Crouch(go);
        }
        m_CrouchFragileBox.Remove(go);
    }

    private bool HeBuzzEfficacyUpheaval(UIFishCategory category)
    {
        if (CoreEfficacyUndeniable == null || CoreEfficacyUndeniable.Length == 0) return false;
        for (int i = 0; i < CoreEfficacyUndeniable.Length; i++)
        {
            if (CoreEfficacyUndeniable[i] == category) return true;
        }
        return false;
    }

    private void CausePlaza()
    {
        m_CookBox.Clear();
        if (TeleviseOnGallium == null) return;

        for (int i = 0; i < TeleviseOnGallium.Length; i++)
        {
            CategoryFxConfig config = TeleviseOnGallium[i];
            if (config == null || config.BongoRadial == null) continue;

            Pool pool = new Pool(config.BongoRadial, Mathf.Max(0, config.EinkornRelic), MayorRead);
            m_CookBox[config.Televise] = pool;
        }
    }

    private static void ShuttleAddition(GameObject go, SoonStintBrookOnHarmful binding)
    {
        binding = SoonStintBrookOnHarmful.UniformOr(go, binding);
        if (binding == null) return;

        UIParticle[] UpEmbarrass= binding.UIEmbarrass;
        for (int i = 0; i < UpEmbarrass.Length; i++)
        {
            UIParticle uiParticle = UpEmbarrass[i];
            if (uiParticle == null) continue;
            uiParticle.Stop();
            uiParticle.Clear();
            uiParticle.Play();
        }

        ParticleSystem[] systems = binding.AdditionDestroy;
        for (int i = 0; i < systems.Length; i++)
        {
            ParticleSystem ps = systems[i];
            if (ps == null) continue;
            if (ps.GetComponentInParent<UIParticle>(true) != null) continue;
            // 复用前完整重置内部状态，避免继承上次发射器速度/方向
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            ps.Clear(true);
            ps.Simulate(0f, true, true, true);
            ps.Play(true);
        }
    }

    private static float ScotlandAdditionCheerful(SoonStintBrookOnHarmful binding)
    {
        // 不再在此处 GetComponentsInChildren：时长只读 binding 缓存（由 Pool / 预制体初始化时填充）。
        if (binding == null) return 1f;
        float d = binding.ExemptCheerful;
        return d > 0f ? d : 1f;
    }

    private sealed class Pool
    {
        private readonly GameObject m_Radial;
        private readonly Transform m_Solely;
        private readonly Quaternion m_PeddlerUtterPedagogy;
        private readonly Vector3 m_PeddlerUtterTrunk;
        private readonly Queue<GameObject> m_Agent= new Queue<GameObject>();
        private readonly Dictionary<GameObject, SoonStintBrookOnHarmful> m_HarmfulBox= new Dictionary<GameObject, SoonStintBrookOnHarmful>();

        public bool HeBrush=> m_Radial != null;

        public Pool(GameObject prefab, int preloadCount, Transform parent)
        {
            m_Radial = prefab;
            m_Solely = parent;
            if (m_Radial != null)
            {
                m_PeddlerUtterPedagogy = m_Radial.transform.localRotation;
                m_PeddlerUtterTrunk = m_Radial.transform.localScale;
            }
            else
            {
                m_PeddlerUtterPedagogy = Quaternion.identity;
                m_PeddlerUtterTrunk = Vector3.one;
            }
            if (!HeBrush) return;

            for (int i = 0; i < preloadCount; i++)
            {
                GameObject go = ThinlyBuy();
                m_Agent.Enqueue(go);
            }
        }

        public GameObject Law()
        {
            if (!HeBrush) return null;
            while (m_Agent.Count > 0)
            {
                GameObject cached = m_Agent.Dequeue();
                if (cached != null) return cached;
            }
            return ThinlyBuy();
        }

        public void Crouch(GameObject go)
        {
            if (!HeBrush || go == null) return;
            go.transform.SetParent(m_Solely, false);
            m_Agent.Enqueue(go);
        }

        public void PrimeProcedure(GameObject go)
        {
            if (!HeBrush || go == null) return;
            go.transform.SetParent(m_Solely, false);
            go.transform.localRotation = m_PeddlerUtterPedagogy;
            go.transform.localScale = m_PeddlerUtterTrunk;
        }

        public SoonStintBrookOnHarmful HarmfulAn(GameObject go)
        {
            if (go == null) return null;
            if (m_HarmfulBox.TryGetValue(go, out SoonStintBrookOnHarmful binding))
            {
                return binding;
            }

            binding = go.GetComponent<SoonStintBrookOnHarmful>();
            if (binding == null)
            {
                binding = go.AddComponent<SoonStintBrookOnHarmful>();
            }
            binding.BotanyRanch();
            m_HarmfulBox[go] = binding;
            return binding;
        }

        private GameObject ThinlyBuy()
        {
            GameObject go = Object.Instantiate(m_Radial, m_Solely);
            go.SetActive(false);
            HarmfulAn(go);
            return go;
        }
    }
}

