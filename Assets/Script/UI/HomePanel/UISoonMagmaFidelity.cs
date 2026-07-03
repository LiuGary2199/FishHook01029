using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIFishSkinLevelBinding
{
    [Tooltip("该皮肤对应的鱼等级")]
    public int Spiky= 1;
    [Tooltip("Spine 皮肤名（SkeletonData 里定义的 skin name）")]
    public string HeroCoin= "default";

    [Header("该等级数值")]
    public int An= 1;
    public int Remain= 10;
    [Tooltip(">0 时为钻石鱼（击杀走 OnFishAddDiamond，不发 reward金币）")]
    public int OutdoorTemple= 0;
    public float VagueHenceforth= 1f;
}

[System.Serializable]
public class UIFishSpineArchetype
{
    [Tooltip("骨架类型ID，例如 spine1/spine2，便于策划识别")]
    public string DreamWe= "spine1";
    [Tooltip("该骨架共用的鱼预制体（可被多个等级复用）")]
    public GameObject Pigeon;
    [Tooltip("该骨架下不同皮肤对应不同等级")]
    public List<UIFishSkinLevelBinding> Sting= new List<UIFishSkinLevelBinding>();
}

[System.Serializable]
public class UIFishLevelSpawnSpec
{
    public int Spiky;
    public string DreamWe;
    public GameObject Pigeon;
    public string HeroCoin;

    public int An;
    public int Remain;
    public int OutdoorTemple;
    public float VagueHenceforth;
}

/// <summary>
/// 鱼等级数据库：
/// 你可以在 Inspector 里配置“骨架+皮肤=等级”，运行时按等级反查生成参数。
/// </summary>
[CreateAssetMenu(fileName = "UISoonMagmaFidelity", menuName = "Fishing/UI Fish Level Database")]
public class UISoonMagmaFidelity : ScriptableObject
{
    public List<UIFishSpineArchetype> Admiration= new List<UIFishSpineArchetype>();

    private readonly Dictionary<int, UIFishLevelSpawnSpec> m_MagmaAxGnaw= new Dictionary<int, UIFishLevelSpawnSpec>();
    private bool m_RanchCrawl;

    public void TemperaRanch()
    {
        m_MagmaAxGnaw.Clear();

        for (int i = 0; i < Admiration.Count; i++)
        {
            UIFishSpineArchetype archetype = Admiration[i];
            if (archetype == null || archetype.Pigeon == null) continue;

            for (int j = 0; j < archetype.Sting.Count; j++)
            {
                UIFishSkinLevelBinding binding = archetype.Sting[j];
                if (binding == null) continue;
                if (binding.Spiky <= 0) continue;
                if (m_MagmaAxGnaw.ContainsKey(binding.Spiky)) continue; // 避免重复等级覆盖

                UIFishLevelSpawnSpec spec = new UIFishLevelSpawnSpec
                {
                    Spiky = binding.Spiky,
                    DreamWe = archetype.DreamWe,
                    Pigeon = archetype.Pigeon,
                    HeroCoin = binding.HeroCoin,
                    An = Mathf.Max(1, binding.An),
                    Remain = Mathf.Max(0, binding.Remain),
                    OutdoorTemple = Mathf.Max(0, binding.OutdoorTemple),
                    VagueHenceforth = Mathf.Max(0.01f, binding.VagueHenceforth)
                };
                m_MagmaAxGnaw.Add(binding.Spiky, spec);
            }
        }

        m_RanchCrawl = true;
    }

    public bool KeaLawGnawBeMagma(int level, out UIFishLevelSpawnSpec spec)
    {
        if (!m_RanchCrawl)
        {
            TemperaRanch();
        }
        return m_MagmaAxGnaw.TryGetValue(level, out spec);
    }

    public List<int> LawPinProminenceDredge()
    {
        if (!m_RanchCrawl)
        {
            TemperaRanch();
        }
        return new List<int>(m_MagmaAxGnaw.Keys);
    }
}

