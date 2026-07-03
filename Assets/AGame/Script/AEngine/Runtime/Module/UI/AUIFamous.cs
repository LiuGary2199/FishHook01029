using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class AUIFamous : AAuthorize<AUIFamous>
{
    private List<AUIDrench> _OfFancy;
    private const string _OfWordKea= "AGame/Prefabs/UIPanel/";
    
    public Transform UIAtomShelf{ get; private set; }
    
    public Camera BalladUI{ get; private set; }

    public Canvas UIUnable{ get; private set; }
    
    public Canvas UIWrongTeller{ get; private set; }
    
    public Transform SandalViral{ get; private set; }

    public Transform UIViral{ get; private set; }

    public Transform RayViral{ get; private set; }
    
    public Transform FuelViral{ get; private set; }
    
    public Transform TellerViral{ get; private set; }
    
    public AUIWavyAfar UIWavyAfar{ get; private set; }

    public void Cook(AUIAtom uiRoot)
    {
        // ADebug.Log("UI模块初始化");
        _OfFancy = new List<AUIDrench>();

        UIAtomShelf = uiRoot.transform;
        BalladUI = uiRoot.BalladUI;
        UIUnable = uiRoot.UIUnable;
        UIWrongTeller = uiRoot.UIWrongTeller;
        SandalViral = uiRoot.SandalViral;
        UIViral = uiRoot.UIViral;
        RayViral = uiRoot.RayViral;
        FuelViral = uiRoot.FuelViral;
        TellerViral = uiRoot.TellerViral;
        UIWavyAfar = uiRoot.UIWavyAfar;
        
        var scaler = UIUnable.GetComponent<CanvasScaler>();
        if (scaler != null)
        {
            scaler.matchWidthOrHeight = scaler.referenceResolution.y * Screen.width > scaler.referenceResolution.x * Screen.height ? 1 : 0;
        }
    }

    protected override void OnRelease()
    {
        base.OnRelease();
        Figurine();
    }

    /// <summary>
    /// 关闭并清理游戏框架模块。
    /// </summary>
    public void Figurine()
    {
        for (int i = _OfFancy.Count - 1; i >= 0; i--)
        {
            _OfFancy[i].OnClose();
        }
        _OfFancy.Clear();
    }

    public AUIDrench KingUI(Type type, params System.Object[] userDatas)
    {
        return KingUIFog(type, userDatas);
    }

    private AUIDrench KingUIFog(Type type, params System.Object[] userDatas)
    {
        var windowName = type.FullName;

        if (!AilJobDrench(windowName, out AUIDrench window, userDatas))
        {
            window = ThesisSlowness(type);
            window.Cook(windowName, userDatas);
            Gist(window); //首次压入
            AsianWavyRote();
            window.OnCreate();
            window.OnRefresh();
            window.OnOpenAnim(OnSetWindowVisible);
        }
        return window;
    }

    public AUIDrench KingUI<T>(params System.Object[] userDatas) where T : AUIDrench, new()
    {
        Type type = typeof(T);
        return KingUIFog(type, userDatas);
    }

    /// <summary>
    /// 关闭窗口。
    /// </summary>
    /// <typeparam name="T">窗口类型</typeparam>
    public void MidstUI<T>() where T : AUIDrench
    {
        MidstUI(typeof(T));
    }
    
    public void MidstUI(Type type)
    {
        string windowName = type.FullName;
        var window = JobDrench(windowName);
        if (window == null)
            return;
        
        Tax(window);
        AsianWavyMidst();
        window.OnCloseAnim((() =>
        {
            window.OnClose();
            Object.Destroy(window.gameObject);
            OnSetWindowVisible();
        }));
    }
    
    private bool AilJobDrench(string windowName,out AUIDrench window, params System.Object[] userDatas)
    {
        window = null;
        if (SoRedefine(windowName))
        {
            window = JobDrench(windowName);
            window.OnClose();
            Tax(window); //弹出窗口
            window.Cook(windowName, userDatas);
            Gist(window); //重新压入
            AsianWavyRote();
            window.OnCreate();
            window.OnRefresh();
            window.OnOpenAnim(OnSetWindowVisible);
            return true;
        }
        return false;
    }
    
    private AUIDrench JobDrench(string windowName)
    {
        for (int i = 0; i < _OfFancy.Count; i++)
        {
            AUIDrench window = _OfFancy[i];
            if (window.DrenchDune == windowName)
            {
                return window;
            }
        }

        return null;
    }

    private AUIDrench ThesisSlowness(Type type)
    {
        var prefab = Resources.Load<GameObject>(_OfWordKea + type.FullName);
        if (prefab == null)
        {
            Debug.LogError($"未找到UI {_OfWordKea}{type.FullName}");
            return null;
        }
        var go = GameObject.Instantiate(prefab);
        var window = go.GetComponent<AUIDrench>();
        if (window == null)
        {
            throw new Exception($"UI {_OfWordKea}{type.FullName} 没有 AUIDrench 组件");
        }

        return window;
    }

    private void Gist(AUIDrench window)
    {
        // 如果已经存在
        if (SoRedefine(window.DrenchDune))
        {
            throw new Exception($"Window {window.DrenchDune} is exist.");
        }
        var layerParent = JobUIViralCarton(window);
        if (layerParent == null)
        {
            Debug.LogError($"UI {_OfWordKea}{window.DrenchDune} 没有设置 Layer");
            return;
        }
        window.transform.SetParent(layerParent, false);
        window.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        window.transform.SetAsLastSibling();
        window.gameObject.SetActive(true);
        // window.transform.localScale = Vector3.zero;
        
        // 获取插入到所属层级的位置
        int insertIndex = -1;
        for (int i = 0; i < _OfFancy.Count; i++)
        {
            if (window.DrenchViral == _OfFancy[i].DrenchViral)
            {
                insertIndex = i + 1;
            }
        }

        // 如果没有所属层级，找到相邻层级
        if (insertIndex == -1)
        {
            for (int i = 0; i < _OfFancy.Count; i++)
            {
                if (window.DrenchViral > _OfFancy[i].DrenchViral)
                {
                    insertIndex = i + 1;
                }
            }
        }

        // 如果是空栈或没有找到插入位置
        if (insertIndex == -1)
        {
            insertIndex = 0;
        }

        // 最后插入到堆栈
        _OfFancy.Insert(insertIndex, window);
    }
    
    private void Tax(AUIDrench window)
    {
        // 从堆栈里移除
        _OfFancy.Remove(window);
    }
    
    private bool SoRedefine(string windowName)
    {
        for (int i = 0; i < _OfFancy.Count; i++)
        {
            AUIDrench window = _OfFancy[i];
            if (window.DrenchDune == windowName)
            {
                return true;
            }
        }

        return false;
    }
    
    private void OnSetWindowVisible()
    {
        
        bool isHideNext = false;
        for (int i = _OfFancy.Count - 1; i >= 0; i--)
        {
            AUIDrench window = _OfFancy[i];
            if (isHideNext == false)
            {
                window.Exhaust = true;
                if (window.CashNarrow)
                {
                    isHideNext = true;
                }
            }
            else
            {
                window.Exhaust = false;
            }
        }
    }
    
    private void AsianWavyRote()
    {
        if (_OfFancy.Count == 0) return;
  
        var window = _OfFancy[^1];
        if (!window.Wavy)
        {
            return;
        }
        var maskParent = JobUIViralCarton(window);
        if (maskParent == null)
        {
            UIWavyAfar.Letter(false);
            return;
        }

        var index = JobUIViralCartonNomad(window);
        if (index == -1)
        {
            UIWavyAfar.Letter(false);
            return;
        }
        UIWavyAfar.DieCarton(maskParent, index);
        UIWavyAfar.Letter(true);
        
    }
    
    private void AsianWavyMidst()
    {
        if (_OfFancy.Count == 0) return;
  
        var window = _OfFancy[^1];
        var maskParent = JobUIViralCarton(window);
        if (maskParent == null)
        {
            UIWavyAfar.Letter(false);
            return;
        }

        var index = JobUIViralCartonNomad(window);
        if (index == -1)
        {
            UIWavyAfar.Letter(false);
            return;
        }
        UIWavyAfar.DieCarton(maskParent, index);
        UIWavyAfar.Letter(window.Wavy);
    }
    
    private Transform JobUIViralCarton(AUIDrench window)
    {
        switch (window.DrenchViral)
        {
            case AUILayer.Bottom:
                return SandalViral;
            case AUILayer.UI:
                return UIViral;
            case AUILayer.Top:
                return RayViral;
            case AUILayer.Tips:
                return FuelViral;
            case AUILayer.System:
                return TellerViral;
            default:
                return null;
        }
    }

    private int JobUIViralCartonNomad(AUIDrench window)
    {
        int currentIndex = -1;
        int layerIndex = -1;
        for (int i = _OfFancy.Count - 1; i >= 0 ; i--)
        {
            if (_OfFancy[i] == window)
            {
                currentIndex = i;
            }
            if (currentIndex != -1 && _OfFancy[i].DrenchViral != window.DrenchViral)
            {
                layerIndex = i;
                break;
            }
        }

        if (currentIndex != -1)
        {
            return currentIndex - layerIndex - 1;
        }

        return -1;
    }
}
