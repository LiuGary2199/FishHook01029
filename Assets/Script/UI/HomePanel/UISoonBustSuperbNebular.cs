using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 调试/编辑器快捷键：按键生成「鱼群形状」编队。
/// 仅保留 FishSchoolShape 方案；旧 V/双环鱼潮入口已移除。
/// </summary>
public class UISoonBustSuperbNebular : MonoBehaviour
{
    [Header("Target")]
[UnityEngine.Serialization.FormerlySerializedAs("fishSwimSystem")]    public UISoonRopeSolder SortRopeSolder;

    [Header("鱼群形状（FishSchoolShape）")]
    [Tooltip("可配置多个鱼群形状，自动刷新时会随机抽一个播放")]
[UnityEngine.Serialization.FormerlySerializedAs("fishSchoolShapes")]    public List<FishSchoolShape> SortIodineDanger= new List<FishSchoolShape>();
    [Tooltip("手动热键播放使用的索引（越界自动回 0）")]
[UnityEngine.Serialization.FormerlySerializedAs("manualShapeIndex")]    public int JewettDriveSlope= 0;
[UnityEngine.Serialization.FormerlySerializedAs("fishSchoolSpawnKey")]    public KeyCode SortIodineShearAil= KeyCode.Alpha3;

    [Header("自动鱼潮刷新")]
    [Tooltip("是否按服务器 GameData.fish_shoal_cd 定时刷新鱼潮")]
[UnityEngine.Serialization.FormerlySerializedAs("autoPlayFishShoal")]    public bool SashFoodSoonNever= true;
    [Tooltip("服务器未下发 fish_shoal_cd 时的本地兜底（秒）")]
    [Min(0.1f)]
[UnityEngine.Serialization.FormerlySerializedAs("fallbackFishShoalCd")]    public float PersuadeSoonNeverIt= 12f;

    private float m_SoonNeverTruth;
    private float m_SoonNeverIt;
    private int m_SinkCodifyDriveSlope= -1;
    /// <summary>应用处于后台/失焦：鱼群 CD 必须完全不计时（含 PC 仍跑 Update 的情况）。</summary>
    private bool m_CabAnSpeculator;

    private void Awake()
    {
        if (SortRopeSolder == null)
        {
            SortRopeSolder = FindFirstObjectByType<UISoonRopeSolder>();
        }

        FlipperSoonNeverIt();
        m_CabAnSpeculator = false;
    }

    private void OnEnable()
    {
        m_SoonNeverTruth = 0f;
        FlipperSoonNeverIt();
        m_CabAnSpeculator = false;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            OnEnterBackground();
        }
        else
        {
            OnLeaveBackground();
        }
    }

    /// <summary>Standalone / Editor 常靠失焦判断，不能只依赖 OnApplicationPause。</summary>
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            OnEnterBackground();
        }
        else
        {
            OnLeaveBackground();
        }
    }

    private void OnEnterBackground()
    {
        if (m_CabAnSpeculator)
        {
            return;
        }

        m_CabAnSpeculator = true;
    }

    private void OnLeaveBackground()
    {
        if (!m_CabAnSpeculator)
        {
            return;
        }

        m_CabAnSpeculator = false;
    }

    private void Update()
    {
        if (SortRopeSolder == null) return;

        bool isFerverTime = HeAnBenignLine();

        if (!isFerverTime && Input.GetKeyDown(SortIodineShearAil))
        {
            ShearSoonIodineCallDriveWhole(LawSaddenDrive());
        }

        if (SashFoodSoonNever)
        {
            bool freezeCountdown =
                m_CabAnSpeculator
                || (RopeStrange.Instance != null && RopeStrange.Instance.HeCylinderSuburb)
                || (RopeStrange.Instance != null && RopeStrange.Instance.HeBenignUnnaturalVarietyErupt());
            float dt = freezeCountdown ? 0f : Time.deltaTime;
            LawnAeroSoonNever(dt, isFerverTime);
        }
    }

    /// <summary>
    /// 按形状资源参数生成一整队（同速、同缩放、无个体弧线）。
    /// </summary>
    public void ShearSoonIodineCallDriveWhole(FishSchoolShape shape)
    {
        if (SortRopeSolder == null)
        {
            SortRopeSolder = FindFirstObjectByType<UISoonRopeSolder>();
        }
        if (SortRopeSolder == null || shape == null) return;

        int resolvedDir = shape.ResolveSpawnDir(shape.fallbackDir);
        bool mirrorX = FishSchoolShape.ResolveMirrorShapeX(shape.mirrorMode, resolvedDir);

        float cx = shape.manualCenterX;
        if (shape.autoCenterX)
        {
            cx = SortRopeSolder.LawHonorableSoonIodineEightyWildlifeX(
                shape,
                resolvedDir,
                shape.cellSpacingX,
                mirrorX);
        }

        if (shape.spawnStaggerSeconds > 0f)
        {
            SortRopeSolder.ShearSoonIodineCallDriveGalvanize(
                shape,
                cx,
                shape.centerY,
                resolvedDir,
                shape.speed,
                shape.cellSpacingX,
                shape.cellSpacingY,
                mirrorX,
                shape.spawnStaggerSeconds);
        }
        else
        {
            SortRopeSolder.ShearSoonIodineCallDrive(
                shape,
                cx,
                shape.centerY,
                resolvedDir,
                shape.speed,
                shape.cellSpacingX,
                shape.cellSpacingY,
                mirrorX);
        }
    }

    private void LawnAeroSoonNever(float deltaTime, bool isFerverTime)
    {
        if (SortIodineDanger == null || SortIodineDanger.Count == 0)
        {
            return;
        }

        // Ferver 期间暂停鱼潮倒计时，退出后继续剩余倒计时。
        if (isFerverTime)
        {
            return;
        }

        // 广告播放期间冻结鱼潮倒计时；广告结束后继续累计剩余时间。
        if (HeSoDevelop())
        {
            return;
        }

        if (m_SoonNeverIt <= 0f)
        {
            FlipperSoonNeverIt();
            if (m_SoonNeverIt <= 0f)
            {
                return;
            }
        }

        m_SoonNeverTruth += Mathf.Max(0f, deltaTime);
        if (m_SoonNeverTruth < m_SoonNeverIt)
        {
            return;
        }

        m_SoonNeverTruth = 0f;
        FishSchoolShape randomShape = LawCodifyDriveShoreReject();
        if (randomShape != null)
        {
            ShearSoonIodineCallDriveWhole(randomShape);
        }
    }

    private static bool HeSoDevelop()
    {
        return ADStrange.Laurasia != null && ADStrange.Laurasia.HePlayfulPot;
    }

    private static bool HeAnBenignLine()
    {
        return RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
    }

    private void FlipperSoonNeverIt()
    {
        float serverCd = RopeMintStrange.LawLaurasia() != null ? RopeMintStrange.LawLaurasia().LawSoonNeverIt() : 0f;
        m_SoonNeverIt = serverCd > 0f ? serverCd : Mathf.Max(0.1f, PersuadeSoonNeverIt);
    }

    private FishSchoolShape LawSaddenDrive()
    {
        if (SortIodineDanger == null || SortIodineDanger.Count == 0)
        {
            return null;
        }

        int safeIndex = Mathf.Clamp(JewettDriveSlope, 0, SortIodineDanger.Count - 1);
        return SortIodineDanger[safeIndex];
    }

    private FishSchoolShape LawCodifyDriveShoreReject()
    {
        if (SortIodineDanger == null || SortIodineDanger.Count == 0)
        {
            return null;
        }

        int count = SortIodineDanger.Count;
        List<int> validIndices = new List<int>(count);
        for (int i = 0; i < count; i++)
        {
            if (SortIodineDanger[i] != null)
            {
                validIndices.Add(i);
            }
        }

        if (validIndices.Count == 0)
        {
            return null;
        }

        // 可选项大于 1 时，避免与上一次相同。
        if (validIndices.Count > 1 && m_SinkCodifyDriveSlope >= 0)
        {
            for (int i = validIndices.Count - 1; i >= 0; i--)
            {
                if (validIndices[i] == m_SinkCodifyDriveSlope)
                {
                    validIndices.RemoveAt(i);
                    break;
                }
            }
        }

        int chosen = validIndices[Random.Range(0, validIndices.Count)];
        m_SinkCodifyDriveSlope = chosen;
        return SortIodineDanger[chosen];
    }

    public void ShearBurgherBust()
    {
        FishSchoolShape shape = LawCodifyDriveShoreReject();
        if (shape != null)
        {
            ShearSoonIodineCallDriveWhole(shape);
        }
    }
}

