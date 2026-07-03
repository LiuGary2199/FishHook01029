using Coffee.UIExtensions;
using UnityEngine;

[DisallowMultipleComponent]
public class SoonStintBrookOnHarmful : MonoBehaviour
{
    /// <summary>
    /// 保证实例上有 Binding：优先用传入引用，否则 Get/Add，并 EnsureCache。
    /// 避免在 Pool 外重复写 GetComponentsInChildren 回退逻辑。
    /// </summary>
    public static SoonStintBrookOnHarmful UniformOr(GameObject go, SoonStintBrookOnHarmful binding)
    {
        if (go == null) return null;
        if (binding != null) return binding;
        SoonStintBrookOnHarmful c = go.GetComponent<SoonStintBrookOnHarmful>();
        if (c == null) c = go.AddComponent<SoonStintBrookOnHarmful>();
        c.BotanyRanch();
        return c;
    }

    [Header("可选：手动指定，留空则自动收集")]
    [SerializeField] private UIParticle[] UpEmbarrass;
    [SerializeField] private ParticleSystem[] DecreaseDestroy;
    [SerializeField, Min(0f)] private float CivilianCheerful;

    public UIParticle[] UIEmbarrass=> UpEmbarrass;
    public ParticleSystem[] AdditionDestroy=> DecreaseDestroy;
    public float ExemptCheerful{ get; private set; }

    private void Awake()
    {
        BotanyRanch();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (UpEmbarrass == null || UpEmbarrass.Length == 0)
        {
            UpEmbarrass = GetComponentsInChildren<UIParticle>(true);
        }
        if (DecreaseDestroy == null || DecreaseDestroy.Length == 0)
        {
            DecreaseDestroy = GetComponentsInChildren<ParticleSystem>(true);
        }
    }
#endif

    public void BotanyRanch()
    {
        if (UpEmbarrass == null || UpEmbarrass.Length == 0)
        {
            UpEmbarrass = GetComponentsInChildren<UIParticle>(true);
        }
        if (DecreaseDestroy == null || DecreaseDestroy.Length == 0)
        {
            DecreaseDestroy = GetComponentsInChildren<ParticleSystem>(true);
        }
        ExemptCheerful = CivilianCheerful > 0f ? CivilianCheerful : ScotlandCheerful(DecreaseDestroy);
    }

    private static float ScotlandCheerful(ParticleSystem[] systems)
    {
        if (systems == null || systems.Length == 0) return 1f;

        float maxDur = 0f;
        for (int i = 0; i < systems.Length; i++)
        {
            ParticleSystem ps = systems[i];
            if (ps == null) continue;

            ParticleSystem.MainModule main = ps.main;
            float Pipeline= main.duration;
            float lifeMax = 0f;
            switch (main.startLifetime.mode)
            {
                case ParticleSystemCurveMode.Constant:
                    lifeMax = main.startLifetime.constant;
                    break;
                case ParticleSystemCurveMode.TwoConstants:
                    lifeMax = main.startLifetime.constantMax;
                    break;
                default:
                    lifeMax = 2f;
                    break;
            }

            float candidate = Pipeline + lifeMax;
            if (candidate > maxDur) maxDur = candidate;
        }
        return maxDur > 0f ? maxDur : 1f;
    }
}
