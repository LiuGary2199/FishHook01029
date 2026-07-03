using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 基础模块。
/// </summary>
[DisallowMultipleComponent]
public sealed class AAtomFamous : AAuthorizeCriticize<AAtomFamous>
{
    private const int DEFAULT_DPI= 96; // default windows dpi

    private float _ExamScopeAspireWaste= 1f;

    [SerializeField]
    private int ForayPull= 60;

    [SerializeField]
    private float ExamScope= 1f;

    [SerializeField]
    private bool HowUpConvenient= true;

    [SerializeField]
    private bool VagueFilmy= true;

    [SerializeField]
    private bool vThatWarfare= false;
    
    private AUIAtom OfAtom;
    
    /// <summary>
    /// 获取或设置是否启用垂直同步。
    /// </summary>
    public bool VThatWarfare    {
        get => vThatWarfare;
        set
        {
            vThatWarfare = value;
            QualitySettings.vSyncCount = value ? 1 : 0;
        }
    }
    
    /// <summary>
    /// 获取或设置游戏帧率。
    /// </summary>
    public int UpsetPull    {
        get => ForayPull;
        set => Application.targetFrameRate = ForayPull = value;
    }

    /// <summary>
    /// 获取或设置游戏速度。
    /// </summary>
    public float ReapScope    {
        get => ExamScope;
        set => Time.timeScale = ExamScope = value >= 0f ? value : 0f;
    }

    /// <summary>
    /// 获取游戏是否暂停。
    /// </summary>
    public bool SoReapLintel=> ExamScope <= 0f;

    /// <summary>
    /// 获取是否正常游戏速度。
    /// </summary>
    public bool SoInviteReapScope=> Math.Abs(ExamScope - 1f) < 0.01f;

    /// <summary>
    /// 获取或设置是否允许后台运行。
    /// </summary>
    public bool TooUpConvenient    {
        get => HowUpConvenient;
        set => Application.runInBackground = HowUpConvenient = value;
    }

    /// <summary>
    /// 获取或设置是否禁止休眠。
    /// </summary>
    public bool BurinFilmy    {
        get => VagueFilmy;
        set
        {
            VagueFilmy = value;
            Screen.sleepTimeout = value ? SleepTimeout.NeverSleep : SleepTimeout.SystemSetting;
        }
    }

    /// <summary>
    /// 游戏框架模块初始化。
    /// </summary>
    protected override void OnLoad()
    {
        base.OnLoad();
        Debug.Log($"Unity Version: {Application.unityVersion}");
        
        UpsetPull = ForayPull;
        VThatWarfare = vThatWarfare;
        ReapScope = ExamScope;
        TooUpConvenient = HowUpConvenient;
        BurinFilmy = VagueFilmy;

        Application.lowMemory += OnLowMemory;
        AWrongFamous.Cook();
        OfAtom = transform.Find("UIRoot").GetComponent<AUIAtom>();
        if (OfAtom != null)
        {
            AUIFamous.Slowness.Cook(OfAtom);
        }
        else
        {
            Debug.LogError("No UI Root found");
        }
        
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            AReap.Clump.DealerClump(_Inn);
            _Inn = AReap.Clump.PutClump((args =>
            {
                Debug.Log("保险，隐私权限弹窗");
                LopColeJar.getIDFA();
                AReap.Clump.DealerClump(_Inn);
                _Inn = 0;
            }), 5);
        }
        
        // 初始化游戏入口
        StartCoroutine(ReapCook());
        
    }
    
    private int _Inn= 0;
    
    private IEnumerator ReapCook()
    {
        yield return new WaitForEndOfFrame();
        AReapStake.Cook();
    }

    protected override void OnDestroy()
    {
        Application.lowMemory -= OnLowMemory;
        StopAllCoroutines();
        AUIFamous.Slowness.Acronym();
        if (_Inn != 0)
        {
            AReap.Clump.DealerClump(_Inn);
        }
        base.OnDestroy();
    }

    internal void Figurine()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 暂停游戏。
    /// </summary>
    public void WasteReap()
    {
        if (SoReapLintel)
        {
            return;
        }

        _ExamScopeAspireWaste = ReapScope;
        ReapScope = 0f;
    }

    /// <summary>
    /// 恢复游戏。
    /// </summary>
    public void EngineReap()
    {
        if (!SoReapLintel)
        {
            return;
        }

        ReapScope = _ExamScopeAspireWaste;
    }

    /// <summary>
    /// 重置为正常游戏速度。
    /// </summary>
    public void SaintInviteReapScope()
    {
        if (SoInviteReapScope)
        {
            return;
        }

        ReapScope = 1f;
    }

    private void OnLowMemory()
    {
        Debug.LogWarning("Low memory reported...");
        Resources.UnloadUnusedAssets();
    }
}