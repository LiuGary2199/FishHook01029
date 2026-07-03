using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GazeShearDrought : MonoBehaviour
{
    private const string GazeSoonToll= "z";
    private const string SoonRadialHeedDevotion= "Prefab/Items/Fish/{0}/{2}_{0}_{1}";

    [Header("预告时序")]
[UnityEngine.Serialization.FormerlySerializedAs("bossWarnSpineDuration")]    public float JeanFearStripCheerful= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("bossWarnPostDelay")]    public float JeanFearBabyTrack= 1f;

    private readonly Dictionary<string, GameObject> m_GazeRadialRanchBox= new Dictionary<string, GameObject>();

    public GazeShearMint Deviate(UISoonRopeSolder swimSystem)
    {
        if (swimSystem == null || swimSystem.DietFore == null)
        {
            Debug.LogError("GazeShearDrought: swimSystem/swimArea 为空，无法计算 Boss 出现位置");
            return null;
        }

        string DramGazeHeed;
        FishConfigData bossCfg;
        GameObject JeanRadial= ReplaceGazeRadialCallTedium(out DramGazeHeed, out bossCfg);
        if (JeanRadial == null)
        {
            Debug.LogError("GazeShearDrought: 从 fish_config(type=z) 生成 Boss 失败，未找到可用预制体");
            return null;
        }
        UISoonMandan bossEntityCfg = JeanRadial.GetComponent<UISoonMandan>();
        if (bossEntityCfg == null)
        {
            Debug.LogError("GazeShearDrought: Boss 预制体缺少 UISoonMandan，无法读取生成参数");
            return null;
        }

        int finalDir = Random.value < 0.5f ? 1 : -1;
        Rect Duct= swimSystem.DietFore.rect;
        float yMin = Duct.yMin + swimSystem.CollapseInclude;
        float yMax = Duct.yMax - swimSystem.CollapseInclude;
        if (yMax < yMin)
        {
            yMax = yMin;
        }

        float finalY = AccuseShearYEyeMudflatsPivot(bossEntityCfg.CollapseShearPivot, yMin, yMax);
        float totalSpawnBuffer = Mathf.Max(0f, swimSystem.MayorQuaker) + Mathf.Max(0f, bossEntityCfg.MayorPlumbQuaker);
        float finalSpawnX = finalDir > 0
            ? (Duct.xMin - totalSpawnBuffer)
            : (Duct.xMax + totalSpawnBuffer);

        Vector2 VagueDegas= LoathsomeDegas(bossEntityCfg.VagueDegas, 0f);
        Vector2 SpearDegas= LoathsomeDegas(bossEntityCfg.SpearDegas, 0.01f);

        float finalSpeed = Random.Range(VagueDegas.x, VagueDegas.y);
        float finalScale = Random.Range(SpearDegas.x, SpearDegas.y);

        return new GazeShearMint
        {
            JeanRadial = JeanRadial,
            DramGazeHeed = DramGazeHeed,
            JeanSoonTedium = bossCfg,
            Mob = finalDir,
            MayorY = finalY,
            MayorX = finalSpawnX,
            Vague = finalSpeed,
            Spear = finalScale,
            StunStripCheerful = Mathf.Max(0f, JeanFearStripCheerful),
            StunBabyTrack = Mathf.Max(0f, JeanFearBabyTrack)
        };
    }

    private static Vector2 LoathsomeDegas(Vector2 value, float minClamp)
    {
        float minVal = Mathf.Max(minClamp, Mathf.Min(value.x, value.y));
        float maxVal = Mathf.Max(minVal, Mathf.Max(value.x, value.y));
        return new Vector2(minVal, maxVal);
    }

    private static float AccuseShearYEyeMudflatsPivot(UIFishSpawnVerticalBands bands, float yMin, float yMax)
    {
        if (yMax < yMin)
        {
            float t = yMin;
            yMin = yMax;
            yMax = t;
        }

        if (!bands.LayCopWarn())
        {
            return Random.Range(yMin, yMax);
        }

        int count = (bands.近水面 ? 1 : 0)
                    + (bands.偏上 ? 1 : 0)
                    + (bands.中间 ? 1 : 0)
                    + (bands.偏下 ? 1 : 0)
                    + (bands.近水底 ? 1 : 0);
        if (count <= 0)
        {
            return Random.Range(yMin, yMax);
        }

        int pick = Random.Range(0, count);
        int segmentIndex = 0;
        for (int si = 0; si < 5; si++)
        {
            bool on = false;
            switch (si)
            {
                case 0:
                    on = bands.近水面;
                    break;
                case 1:
                    on = bands.偏上;
                    break;
                case 2:
                    on = bands.中间;
                    break;
                case 3:
                    on = bands.偏下;
                    break;
                case 4:
                    on = bands.近水底;
                    break;
            }
            if (!on) continue;
            if (pick == 0)
            {
                segmentIndex = si;
                break;
            }
            pick--;
        }

        float h = yMax - yMin;
        if (h <= 0f)
        {
            return yMin;
        }

        const int segmentCount = 5;
        float segH = h / segmentCount;
        float hi = yMax - segH * segmentIndex;
        float lo = yMax - segH * (segmentIndex + 1);
        lo = Mathf.Max(lo, yMin);
        hi = Mathf.Min(hi, yMax);
        if (hi <= lo)
        {
            return (lo + hi) * 0.5f;
        }
        return Random.Range(lo, hi);
    }

    private GameObject ReplaceGazeRadialCallTedium(out string usedPath, out FishConfigData selectedConfig)
    {
        usedPath = string.Empty;
        selectedConfig = null;
        RopeMintStrange dm = RopeMintStrange.LawLaurasia();
        if (dm == null || dm.SoonGallium == null || dm.SoonGallium.Count == 0)
        {
            Debug.LogError("GazeShearDrought: fish_config 为空，无法按 type=z 生成 Boss");
            return null;
        }

        List<FishConfigData> bossCandidates = new List<FishConfigData>();
        for (int i = 0; i < dm.SoonGallium.Count; i++)
        {
            FishConfigData cfg = dm.SoonGallium[i];
            if (cfg == null) continue;
            if (string.IsNullOrWhiteSpace(cfg.id) || string.IsNullOrWhiteSpace(cfg.type)) continue;
            if (!string.Equals(cfg.type.Trim(), GazeSoonToll, StringComparison.OrdinalIgnoreCase)) continue;
            bossCandidates.Add(cfg);
        }

        if (bossCandidates.Count == 0)
        {
            Debug.LogError("GazeShearDrought: fish_config 中没有 type=z，无法生成 Boss");
            return null;
        }

        int EagerSlope= Random.Range(0, bossCandidates.Count);
        for (int offset = 0; offset < bossCandidates.Count; offset++)
        {
            FishConfigData cfg = bossCandidates[(EagerSlope + offset) % bossCandidates.Count];
            string path = CauseSoonRadialHeed(cfg.type, cfg.id);
            if (string.IsNullOrWhiteSpace(path)) continue;

            if (!m_GazeRadialRanchBox.TryGetValue(path, out GameObject prefab))
            {
                prefab = Resources.Load<GameObject>(path);
                m_GazeRadialRanchBox[path] = prefab;
            }

            if (prefab != null)
            {
                usedPath = path;
                selectedConfig = cfg;
                return prefab;
            }
        }

        Debug.LogError("GazeShearDrought: type=z 配置存在，但对应 Resources 预制体都加载失败");
        selectedConfig = null;
        return null;
    }

    private static string CauseSoonRadialHeed(string fishType, string fishId)
    {
        string safeType = fishType == null ? string.Empty : fishType.Trim();
        string safeId = fishId == null ? string.Empty : fishId.Trim();
        if (string.IsNullOrWhiteSpace(safeType) || string.IsNullOrWhiteSpace(safeId))
        {
            return string.Empty;
        }
        return string.Format(SoonRadialHeedDevotion, safeType, safeId, CTedium.SoonRadialCoinRunway);
    }
}
