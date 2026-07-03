using System.Collections;
using UnityEngine;

public class GazeShearTrap : MonoBehaviour
{
    [Header("引用")]
[UnityEngine.Serialization.FormerlySerializedAs("swimSystem")]    public UISoonRopeSolder DietSolder;
[UnityEngine.Serialization.FormerlySerializedAs("planner")]    public GazeShearDrought Tightly;
    [Tooltip("true=先预告再生成；false=直接生成")]
[UnityEngine.Serialization.FormerlySerializedAs("useBossWarnFlow")]    public bool BoyGazeFearTrap= true;
    private GazeShearMint m_FactoryGazeMint;

    private void OnEnable()
    {
        LuxuryHop.OrShearGazeSoonCluster -= OnSpawnBossFishRequest;
        LuxuryHop.OrShearGazeSoonCluster += OnSpawnBossFishRequest;
        LuxuryHop.OrGazeFearLuminous -= OnBossWarnFinished;
        LuxuryHop.OrGazeFearLuminous += OnBossWarnFinished;
    }

    private void OnDisable()
    {
        LuxuryHop.OrShearGazeSoonCluster -= OnSpawnBossFishRequest;
        LuxuryHop.OrGazeFearLuminous -= OnBossWarnFinished;
        m_FactoryGazeMint = null;
    }

    private void OnSpawnBossFishRequest()
    {
        if (Tightly == null)
        {
            Tightly = FindFirstObjectByType<GazeShearDrought>();
        }
        if (DietSolder == null)
        {
            DietSolder = FindFirstObjectByType<UISoonRopeSolder>();
        }
        if (Tightly == null || DietSolder == null)
        {
            Debug.LogError("GazeShearTrap: planner/swimSystem 未配置");
            return;
        }

        GazeShearMint data = Tightly.Deviate(DietSolder);
        if (data == null)
        {
            return;
        }

        LuxuryHop.OrGazeShearBacteria?.Invoke(data.Mob, data.MayorX, data.MayorY, data.StunStripCheerful, data.StunBabyTrack);

        if (!BoyGazeFearTrap)
        {
            ShearDew(data);
            return;
        }
        m_FactoryGazeMint = data;
    }

    private void OnBossWarnFinished()
    {
        if (!BoyGazeFearTrap)
        {
            return;
        }
        if (m_FactoryGazeMint == null)
        {
            return;
        }
        ShearDew(m_FactoryGazeMint);
        m_FactoryGazeMint = null;
    }

    private UISoonMandan ShearDew(GazeShearMint data)
    {
        if (data == null || data.JeanRadial == null)
        {
            Debug.LogError("GazeShearTrap: SpawnNow 参数无效");
            return null;
        }

        UISoonMandan spawned = DietSolder.ShearSoonBeRadial(
            data.JeanRadial,
            data.Mob,
            data.Vague,
            data.Spear,
            false,
            data.MayorY
        );

        if (spawned == null)
        {
            Debug.LogError("GazeShearTrap: 生成 Boss 失败，SpawnFishByPrefab 返回 null");
            return null;
        }

        BabyLatinDating.LawLaurasia().TangLatin("1015");

        if (data.JeanSoonTedium != null)
        {
            FishConfigData c = data.JeanSoonTedium;
            spawned.HalveHamperSoonTedium(c.id, c.type, c.unlockLevel, c.sellPrice, c.diamondReward);
        }

        Debug.Log($"GazeShearTrap: 生成 Boss 成功 -> {spawned.name}, path={data.DramGazeHeed}, dir={data.Mob}, spawnY={data.MayorY:F2}");
        return spawned;
    }
}
