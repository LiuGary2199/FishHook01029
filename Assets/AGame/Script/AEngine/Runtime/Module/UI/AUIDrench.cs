using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster), typeof(CanvasGroup))]
public class AUIDrench : AUICoal
{
[UnityEngine.Serialization.FormerlySerializedAs("WindowLayer")]    public AUILayer DrenchViral= AUILayer.UI;
    
    public override UIType Seat=> UIType.Window;
    
    protected CanvasGroup mUnableDance;

    /// <summary>
    /// 窗口名称。
    /// </summary>
    public string DrenchDune{ private set; get; }
[UnityEngine.Serialization.FormerlySerializedAs("FullScreen")]    
    /// <summary>
    /// 是否为全屏窗口。
    /// </summary>
    public bool CashNarrow= false;
[UnityEngine.Serialization.FormerlySerializedAs("Mask")]    
    public bool Wavy= false;
[UnityEngine.Serialization.FormerlySerializedAs("OpenAnim")]    
    public bool RoteHalf= true;
[UnityEngine.Serialization.FormerlySerializedAs("CloseAnim")]    
    public bool MidstHalf= true;
    
    protected bool _Jewelry= false;
    /// <summary>
    /// 窗口可见性。
    /// </summary>
    public bool Exhaust    {
        get => _Jewelry;

        set
        {
            if (_Jewelry == value)
            {
                return;
            }
            _Jewelry = value;
            // transform.localScale = value ? Vector3.one : Vector3.zero;
            mUnableDance.alpha = _Jewelry ? 1 : 0;
            Horticulture = _Jewelry;
            mUnableDance.blocksRaycasts = _Jewelry;
            OnSetVisible(_Jewelry);
        }
    }

    public bool Horticulture    {
        get => mUnableDance.interactable;
        set => mUnableDance.interactable = value;
    }

#if UNITY_EDITOR
    private void Reset()
    {
        GetComponent<Canvas>().overrideSorting = false;
        var mGraphicRaycaster = GetComponent<GraphicRaycaster>();
        mGraphicRaycaster.blockingMask = LayerMask.GetMask("UI");
        mGraphicRaycaster.ignoreReversedGraphics = true;
        mGraphicRaycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;
    }
#endif

    public void Cook(string windowName, params System.Object[] userDatas)
    {
        DrenchDune = windowName;
        _SwimErupt = userDatas;
        gameObject.name = DrenchDune;
    }

    public override void OnCreate()
    {
        base.OnCreate();
        Debug.Log($"创建窗口：{DrenchDune}，FullScreen：{CashNarrow}，Mask：{Wavy}");
        mUnableDance = GetComponent<CanvasGroup>();
        Horticulture = false;
    }

    public override void OnClose()
    {
        base.OnClose();
        Debug.Log("关闭窗口：" + DrenchDune);
        
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        Debug.Log("刷新窗口：" + DrenchDune);
    }

    /// <summary>
    /// 当因为全屏遮挡触或者窗口可见性触发窗口的显隐。
    /// </summary>
    protected virtual void OnSetVisible(bool visible)
    {
        // ADebug.Log("窗口可见性：" + WindowName + "，" + visible);
    }

    public virtual void OnOpenAnim(Action callback = null)
    {
        if (!RoteHalf)
        {
            callback?.Invoke();
            return;
        }
        
        if (CashNarrow)
        {
            mUnableDance.DOFade(1, 0.3f).SetEase(Ease.InBack).OnStepComplete((() => { callback?.Invoke(); }));
        }
        else
        {
            transform.localScale = Vector3.one * 0.7f;
            transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
            mUnableDance.alpha = 0;
            mUnableDance.DOFade(1, 0.3f).SetEase(Ease.OutBack).OnStepComplete((() => { callback?.Invoke(); }));
        }
        
    }

    public virtual void OnCloseAnim(Action callback = null)
    {
        if (!MidstHalf)
        {
            callback?.Invoke();
            return;
        }
        
        Horticulture = false;
        if (CashNarrow)
        {
            mUnableDance.DOFade(0, 0.3f).SetEase(Ease.InBack).OnStepComplete((() => { callback?.Invoke(); }));
        }
        else
        {
            transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
            mUnableDance.DOFade(0, 0.3f).SetEase(Ease.InBack).OnStepComplete((() => { callback?.Invoke(); }));
        }
    }
    
    protected void MidstUI()
    {
        AReap.UI.MidstUI(this.GetType());
    }

    protected void MidstUI<T>()
    {
        AReap.UI.MidstUI(typeof(T));
    }

    protected AUIDrench KingUI<T>(params System.Object[] userDatas) where T : AUIDrench, new()
    {
        return AReap.UI.KingUI<T>(userDatas);
    }
    
}

/// <summary>
/// UI层级枚举。
/// </summary>
public enum AUILayer : int
{
    Bottom = 0,
    UI = 1,
    Top = 2,
    Tips = 3,
    System = 4,
}