/*
*
*   功能：整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能。  
*           功能1：关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
*                 入栈状态：
*                     Freeze();   （上一个UI窗体）冻结
*                     Display();  （本UI窗体）显示
*                 出栈状态： 
*                     Hiding();    (本UI窗体) 隐藏
*                     Redisplay(); (上一个UI窗体) 重新显示
*          功能2：增加“非栈”缓存集合。 
* 
* 
* ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// 主要负责UI窗体的加载、缓存、以及对于“UI窗体基类”的各种生命周期的操作（显示、隐藏、重新显示、冻结）。
/// </summary>
public class UIStrange : MonoBehaviour
{
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("MainCanvas")]    public Canvas HangShroud;
    private static UIStrange _Laurasia= null;
    //ui窗体预设路径（参数1，窗体预设名称，2，表示窗体预设路径）
    private Dictionary<string, string> _PryHouseChina;
    //缓存所有的ui窗体
    private Dictionary<string, SeedUIHouse> _PryALLUIHouse;
    //栈结构标识当前ui窗体的集合
    private Stack<SeedUIHouse> _OwnBalanceUIHouse;
    //当前显示的ui窗体
    private Dictionary<string, SeedUIHouse> _PryBalanceBeatUIHouse;
    //临时关闭窗口
    private List<UIFormParams> _PondUIHouse;
    //ui根节点
    private Transform _RatShroudCollision= null;
    //全屏幕显示的节点
    private Transform _RatMallet= null;
    //固定显示的节点
    private Transform _RatCrash= null;
    //弹出节点
    private Transform _RatPopSo= null;
    //ui特效节点
    private Transform _Ant= null;
    //ui管理脚本的节点
    private Transform _RatUIGingham= null;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("_TraUICamera")]    public Transform _RatUIPreach= null;
    public Camera UIPreach{ get; private set; }
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("PanelName")]    public string StandCoin;
    List<string> StandCoinTall;
    public List<UIFormParams> PondUIHouse    {
        get
        {
            return _PondUIHouse;
        }
    }
    //得到实例
    public static UIStrange LawLaurasia()
    {
        if (_Laurasia == null)
        {
            _Laurasia = new GameObject("_UIManager").AddComponent<UIStrange>();
            
        }
        return _Laurasia;
    }
    //初始化核心数据，加载ui窗体路径到集合中
    public void Awake()
    {
        StandCoinTall = new List<string>();
        //字段初始化
        _PryALLUIHouse = new Dictionary<string, SeedUIHouse>();
        _PryBalanceBeatUIHouse = new Dictionary<string, SeedUIHouse>();
        _PondUIHouse = new List<UIFormParams>();
        _PryHouseChina = new Dictionary<string, string>();
        _OwnBalanceUIHouse = new Stack<SeedUIHouse>();
        //初始化加载（根ui窗体）canvas预设
        RailReadShroudGarland();
        //得到UI根节点，全屏节点，固定节点，弹出节点
        //Debug.Log("this.gameobject" + this.gameObject.name);
        _RatShroudCollision = GameObject.FindGameObjectWithTag(RawDisuse.SYS_TAG_CANVAS).transform;
        _RatMallet = MaybeCarbon.EditPutVenueWest(_RatShroudCollision.gameObject,RawDisuse.SYS_NORMAL_NODE);
        _RatCrash = MaybeCarbon.EditPutVenueWest(_RatShroudCollision.gameObject, RawDisuse.SYS_FIXED_NODE);
        _RatPopSo = MaybeCarbon.EditPutVenueWest(_RatShroudCollision.gameObject,RawDisuse.SYS_POPUP_NODE);
        _Ant = MaybeCarbon.EditPutVenueWest(_RatShroudCollision.gameObject, RawDisuse.SYS_TOP_NODE);
        _RatUIGingham = MaybeCarbon.EditPutVenueWest(_RatShroudCollision.gameObject,RawDisuse.SYS_SCRIPTMANAGER_NODE);
        _RatUIPreach = MaybeCarbon.EditPutVenueWest(_RatShroudCollision.gameObject, RawDisuse.SYS_UICAMERA_NODE);
        //把本脚本作为“根ui窗体”的子节点
        MaybeCarbon.TieVenueWestAxSolelyWest(_RatUIGingham, this.gameObject.transform);
        //根UI窗体在场景转换的时候，不允许销毁
        DontDestroyOnLoad(_RatShroudCollision);
        //初始化ui窗体预设路径数据
        RailUIHouseChinaMint();
        //初始化UI相机参数，主要是解决URP管线下UI相机的问题
        RailPreach();
    }
    private void TieStand(string name)
    {
        if (!StandCoinTall.Contains(name))
        {
            StandCoinTall.Add(name);
            StandCoin = name;
        }
    }
    private void SubStand(string name)
    {
        if (StandCoinTall.Contains(name))
        {
            StandCoinTall.Remove(name);
        }
        if (StandCoinTall.Count == 0)
        {
            StandCoin = "";
        }
        else
        {
            StandCoin = StandCoinTall[0];
        }
    }
    public void DueLatin(string event_id)
    {
        
    }
    //初始化加载（根ui窗体）canvas预设
    private void RailReadShroudGarland()
    {
        HangShroud = OvercrowdJar.LawLaurasia().GrabWhole(RawDisuse.SYS_PATH_CANVAS, false).GetComponent<Canvas>();
    }
    /// <summary>
    /// 显示ui窗体
    /// 功能：1根据ui窗体的名称，加载到所有ui窗体缓存集合中
    /// 2,根据不同的ui窗体的显示模式，分别做不同的加载处理
    /// </summary>
    /// <param name="uiFormName">ui窗体预设的名称</param>
    public GameObject BeatUIHouse(string uiFormName, object uiFormParams = null)
    {
        //参数的检查
        if (string.IsNullOrEmpty(uiFormName)) return null;
        //根据ui窗体的名称，把加载到所有ui窗体缓存集合中
        //ui窗体的基类
        SeedUIHouse baseUIForms = GrabHouseAxALLUIHouseIdiom(uiFormName);
        if (baseUIForms == null) return null;

        TieStand(uiFormName);
        
        //判断是否清空“栈”结构体集合
        if (baseUIForms.BalanceUIToll.HeStudyPersianUnjust)
        {
            StudySyrupLoyal();
        }
        //根据不同的ui窗体的显示模式，分别做不同的加载处理
        switch (baseUIForms.BalanceUIToll.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                PriorUIHouseRanch(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.ReverseChange:
                BoilUIHouse(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.HideOther:
                PriorUISalmonAxRanchJoltDutch(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.Wait:
                PriorUIHouseRanchPondDrift(uiFormName, uiFormParams);
                break;
            default:
                break;
        }
        return baseUIForms.gameObject;
    }

    /// <summary>
    /// 关闭或返回上一个ui窗体（关闭当前ui窗体）
    /// </summary>
    /// <param name="strUIFormsName"></param>
    public void DriftIDCrouchUIHouse(string strUIFormsName)
    {
        SubStand(strUIFormsName);
        //Debug.Log("关闭窗体的名字是" + strUIFormsName);
        //ui窗体的基类
        SeedUIHouse baseUIForms = null;
        if (string.IsNullOrEmpty(strUIFormsName)) return;
        _PryALLUIHouse.TryGetValue(strUIFormsName,out baseUIForms);
        //所有窗体缓存中没有记录，则直接返回
        if (baseUIForms == null) return;
        //判断不同的窗体显示模式，分别处理
        switch (baseUIForms.BalanceUIToll.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                LeanUIHouseRanch(strUIFormsName);
                break;
            
            case UIFormShowMode.ReverseChange:
                PryUIHouse();
                break;
            case UIFormShowMode.HideOther:
                LeanUIHouseCallRanchSowBeatDutch(strUIFormsName);
                break;
            case UIFormShowMode.Wait:
                LeanUIHouseRanch(strUIFormsName);
                break;
            default:
                break;
        }
        
    }
    /// <summary>
    /// 显示下一个弹窗如果有的话
    /// </summary>
    public void BeatSpinPrySo()
    {
        if (_PondUIHouse.Count > 0)
        {
            BeatUIHouse(_PondUIHouse[0].UpBardCoin, _PondUIHouse[0].UpBardLizard);
            _PondUIHouse.RemoveAt(0);
        }
    }

    /// <summary>
    /// 清空当前等待中的UI
    /// </summary>
    public void StudyPondUIHouse()
    {
        if (_PondUIHouse.Count > 0)
        {
            _PondUIHouse = new List<UIFormParams>();
        }
    }
     /// <summary>
     /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
      /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
      /// </summary>
      /// <param name="uiFormsName">UI窗体（预设）的名称</param>
      /// <returns></returns>
    private SeedUIHouse GrabHouseAxALLUIHouseIdiom(string uiFormName)
    {
        //加载的返回ui窗体基类
        SeedUIHouse baseUIResult = null;
        _PryALLUIHouse.TryGetValue(uiFormName, out baseUIResult);
        if (baseUIResult == null)
        {
            //加载指定名称ui窗体
            baseUIResult = GrabUIBard(uiFormName);

        }
        return baseUIResult;
    }
    /// <summary>
    /// 加载指定名称的“UI窗体”
    /// 功能：
    ///    1：根据“UI窗体名称”，加载预设克隆体。
    ///    2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点。
    ///    3：隐藏刚创建的UI克隆体。
    ///    4：把克隆体，加入到“所有UI窗体”（缓存）集合中。
    /// 
    /// </summary>
    /// <param name="uiFormName">UI窗体名称</param>
    private SeedUIHouse GrabUIBard(string uiFormName)
    {
        string strUIFormPaths = null;
        GameObject goCloneUIPrefabs = null;
        SeedUIHouse baseUIForm = null;
        //根据ui窗体名称，得到对应的加载路径
        _PryHouseChina.TryGetValue(uiFormName, out strUIFormPaths);
        if (!string.IsNullOrEmpty(strUIFormPaths))
        {
            //加载预制体
           goCloneUIPrefabs= OvercrowdJar.LawLaurasia().GrabWhole(strUIFormPaths, false);
        }
        //设置ui克隆体的父节点（根据克隆体中带的脚本中不同的信息位置信息）
        if(_RatShroudCollision!=null && goCloneUIPrefabs != null)
        {
            baseUIForm = goCloneUIPrefabs.GetComponent<SeedUIHouse>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 uiFormName="+uiFormName);
                return null;
            }
            switch (baseUIForm.BalanceUIToll.UIForms_Type)
            {
                case UIFormType.Normal:
                    goCloneUIPrefabs.transform.SetParent(_RatMallet, false);
                    break;
                case UIFormType.Fixed:
                    goCloneUIPrefabs.transform.SetParent(_RatCrash, false);
                    break;
                case UIFormType.PopUp:
                    goCloneUIPrefabs.transform.SetParent(_RatPopSo, false);
                    break;
                case UIFormType.Top:
                    goCloneUIPrefabs.transform.SetParent(_Ant, false);
                    break;
                default:
                    break;
            }
            //设置隐藏
            goCloneUIPrefabs.SetActive(false);
            //把克隆体，加入到所有ui窗体缓存集合中
            _PryALLUIHouse.Add(uiFormName, baseUIForm);
            return baseUIForm;
        }
        else
        {
            Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数uiFormName=" + uiFormName);
        }
        Debug.Log("出现不可以预估的错误，请检查，参数 uiFormName=" + uiFormName);
        return null;
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void PriorUIHouseRanch(string uiFormName, object uiFormParams)
    {
        //ui窗体基类
        SeedUIHouse baseUIForm;
        //从所有窗体集合中得到的窗体
        SeedUIHouse baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _PryBalanceBeatUIHouse.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        //把当前窗体，加载到正在显示集合中
        _PryALLUIHouse.TryGetValue(uiFormName, out baseUIFormFromAllCache);
        if (baseUIFormFromAllCache != null)
        {
            _PryBalanceBeatUIHouse.Add(uiFormName, baseUIFormFromAllCache);
            //显示当前窗体
            baseUIFormFromAllCache.Display(uiFormParams);
            
        }
    }

    /// <summary>
    /// 卸载ui窗体从当前显示的集合缓存中
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void LeanUIHouseRanch(string strUIFormsName)
    {
        //ui窗体基类
        SeedUIHouse baseUIForms;
        //正在显示ui窗体缓存集合没有记录，则直接返回
        _PryBalanceBeatUIHouse.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体，运行隐藏，且从正在显示ui窗体缓存集合中移除
        baseUIForms.Hidding();
        _PryBalanceBeatUIHouse.Remove(strUIFormsName);
    }

    /// <summary>
    /// 加载ui窗体到当前显示窗体集合，且，隐藏其他正在显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void PriorUISalmonAxRanchJoltDutch(string strUIFormsName, object uiFormParams)
    {
        //窗体基类
        SeedUIHouse baseUIForms;
        //所有窗体集合中的窗体基类
        SeedUIHouse baseUIFormsFromAllCache;
        _PryBalanceBeatUIHouse.TryGetValue(strUIFormsName, out baseUIForms);
        //正在显示ui窗体缓存集合里有记录，直接返回
        if (baseUIForms != null) return;
        Debug.Log("关闭其他窗体");
        //正在显示ui窗体缓存 与栈缓存集合里所有的窗体进行隐藏处理
        List<SeedUIHouse> ShowUIFormsList = new List<SeedUIHouse>(_PryBalanceBeatUIHouse.Values);
        foreach (SeedUIHouse baseUIFormsItem in ShowUIFormsList)
        {
            //Debug.Log("_DicCurrentShowUIForms---------" + baseUIFormsItem.transform.name);
            if (baseUIFormsItem.BalanceUIToll.UIForms_Type == UIFormType.PopUp)
            {
                //baseUIFormsItem.Hidding();
                LeanUIHouseCallRanchSowBeatDutch(baseUIFormsItem.GetType().Name);
            }
        }
        List<SeedUIHouse> CurrentUIFormsList = new List<SeedUIHouse>(_OwnBalanceUIHouse);
        foreach (SeedUIHouse baseUIFormsItem in CurrentUIFormsList)
        {
            //Debug.Log("_StaCurrentUIForms---------"+baseUIFormsItem.transform.name);
            //baseUIFormsItem.Hidding();
            LeanUIHouseCallRanchSowBeatDutch(baseUIFormsItem.GetType().Name);
        }
        //把当前窗体，加载到正在显示ui窗体缓存集合中 
        _PryALLUIHouse.TryGetValue(strUIFormsName, out baseUIFormsFromAllCache);
        if (baseUIFormsFromAllCache != null)
        {
            _PryBalanceBeatUIHouse.Add(strUIFormsName, baseUIFormsFromAllCache);
            baseUIFormsFromAllCache.Display(uiFormParams);
        }
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void PriorUIHouseRanchPondDrift(string uiFormName, object uiFormParams)
    {
        //ui窗体基类
        SeedUIHouse baseUIForm;
        //从所有窗体集合中得到的窗体
        SeedUIHouse baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _PryBalanceBeatUIHouse.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        bool havePopUp = false;
        foreach (SeedUIHouse uiforms in _PryBalanceBeatUIHouse.Values)
        {
            if (uiforms.BalanceUIToll.UIForms_Type == UIFormType.PopUp)
            {
                havePopUp = true;
                break;
            }
        }
        if (!havePopUp)
        {
            //把当前窗体，加载到正在显示集合中
            _PryALLUIHouse.TryGetValue(uiFormName, out baseUIFormFromAllCache);
            if (baseUIFormFromAllCache != null)
            {
                _PryBalanceBeatUIHouse.Add(uiFormName, baseUIFormFromAllCache);
                //显示当前窗体
                baseUIFormFromAllCache.Display(uiFormParams);

            }
        }
        else
        {
            _PondUIHouse.Add(new UIFormParams() { UpBardCoin = uiFormName, UpBardLizard = uiFormParams });
        }
        
    }
    /// <summary>
    /// 卸载ui窗体从当前显示窗体集合缓存中，且显示其他原本需要显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void LeanUIHouseCallRanchSowBeatDutch(string strUIFormsName)
    {
        //ui窗体基类
        SeedUIHouse baseUIForms;
        _PryBalanceBeatUIHouse.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体 ，运行隐藏状态，且从正在显示ui窗体缓存集合中删除
        baseUIForms.Hidding();
        _PryBalanceBeatUIHouse.Remove(strUIFormsName);
        //正在显示ui窗体缓存与栈缓存集合里素有窗体进行再次显示
        //foreach (SeedUIHouse baseUIFormsItem in _DicCurrentShowUIForms.Values)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
        //foreach (SeedUIHouse baseUIFormsItem in _StaCurrentUIForms)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
    }
    /// <summary>
    /// ui窗体入栈
    /// 功能：1判断栈里是否已经有窗体，有则冻结
    ///   2先判断ui预设缓存集合是否有指定的ui窗体，有则处理
    ///   3指定ui窗体入栈
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void BoilUIHouse(string strUIFormsName, object uiFormParams)
    {
        //ui预设窗体
        SeedUIHouse baseUI;
        //判断栈里是否已经有窗体,有则冻结
        if (_OwnBalanceUIHouse.Count > 0)
        {
            SeedUIHouse topUIForms = _OwnBalanceUIHouse.Peek();
            topUIForms.Thresh();
            //Debug.Log("topUIForms是" + topUIForms.name);
        }
        //先判断ui预设缓存集合是否有指定ui窗体，有则处理
        _PryALLUIHouse.TryGetValue(strUIFormsName, out baseUI);
        if (baseUI != null)
        {
            baseUI.Display(uiFormParams);
        }
        else
        {
            Debug.Log(string.Format("/PushUIForms()/ baseUI==null! 核心错误，请检查 strUIFormsName={0} ", strUIFormsName));
        }
        //指定ui窗体入栈
        _OwnBalanceUIHouse.Push(baseUI);
       
    }

    /// <summary>
    /// ui窗体出栈逻辑
    /// </summary>
    private void PryUIHouse()
    {

        if (_OwnBalanceUIHouse.Count >= 2)
        {
            //出栈逻辑
            SeedUIHouse topUIForms = _OwnBalanceUIHouse.Pop();
            //出栈的窗体进行隐藏
            topUIForms.Hidding(() => {
                //出栈窗体的下一个窗体逻辑
                SeedUIHouse nextUIForms = _OwnBalanceUIHouse.Peek();
                //下一个窗体重新显示处理
                nextUIForms.Redisplay();
            });
        }
        else if (_OwnBalanceUIHouse.Count == 1)
        {
            SeedUIHouse topUIForms = _OwnBalanceUIHouse.Pop();
            //出栈的窗体进行隐藏处理
            topUIForms.Hidding();
        }
    }


    /// <summary>
    /// 初始化ui窗体预设路径数据
    /// </summary>
    private void RailUIHouseChinaMint()
    {
        ITediumStrange configMgr = new TediumStrangeBePath(RawDisuse.SYS_PATH_UIFORMS_CONFIG_INFO);
        if (_PryHouseChina != null)
        {
            _PryHouseChina = configMgr.CabPrinter;
        }
    }

    /// <summary>
    /// 初始化UI相机参数
    /// </summary>
    private void RailPreach()
    {
        //当渲染管线为URP时，将UI相机的渲染方式改为Overlay，并加入主相机堆栈
        RenderPipelineAsset currentPipeline = GraphicsSettings.renderPipelineAsset;
        if (currentPipeline != null && currentPipeline.name == "UniversalRenderPipelineAsset")
        {
            UIPreach = _RatUIPreach.GetComponent<Camera>();
            UIPreach.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_RatUIPreach.GetComponent<Camera>());
        }
    }

    /// <summary>
    /// 清空栈结构体集合
    /// </summary>
    /// <returns></returns>
    private bool StudySyrupLoyal()
    {
        if(_OwnBalanceUIHouse!=null && _OwnBalanceUIHouse.Count >= 1)
        {
            _OwnBalanceUIHouse.Clear();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前弹框ui的栈
    /// </summary>
    /// <returns></returns>
    public Stack<SeedUIHouse> LawBalanceBardSyrup()
    {
        return _OwnBalanceUIHouse;
    }


    /// <summary>
    /// 根据panel名称获取panel gameObject
    /// </summary>
    /// <param name="uiFormName"></param>
    /// <returns></returns>
    public GameObject LawStandBeCoin(string uiFormName)
    {
        //ui窗体基类
        SeedUIHouse baseUIForm;
        //如果正在显示的集合中存在该窗体，直接返回
        _PryALLUIHouse.TryGetValue(uiFormName, out baseUIForm);
        return baseUIForm?.gameObject;
    }

    /// <summary>
    /// 获取所有打开的panel（不包括Normal）
    /// </summary>
    /// <returns></returns>
    public List<GameObject> LawBurgherInject(bool containNormal = false)
    {
        List<GameObject> openingPanels = new List<GameObject>();
        List<SeedUIHouse> allUIFormsList = new List<SeedUIHouse>(_PryALLUIHouse.Values);
        foreach(SeedUIHouse panel in allUIFormsList)
        {
            if (panel.gameObject.activeInHierarchy)
            {
                if (containNormal || panel._BalanceUIToll.UIForms_Type != UIFormType.Normal)
                {
                    openingPanels.Add(panel.gameObject);
                }
            }
        }

        return openingPanels;
    }
      public SeedUIHouse LawAntStand() //获得最上层的打开的面板
  {
      SeedUIHouse TopPanel = null;
      List<SeedUIHouse> allUIFormsList = new List<SeedUIHouse>(_PryALLUIHouse.Values);
      foreach (SeedUIHouse panel in allUIFormsList)
      {
          if (panel.gameObject.activeInHierarchy)
          {
              //MaybeCarbon.Print("打开的面板 ：" + panel.name);
              TopPanel = panel;
          }
      }
      //MaybeCarbon.Print("最上层面板：  " + TopPanel.name,1);
      return TopPanel;
  }

  public bool HeTendStandAnt() //判断游戏面板是否在最上层
  {
      SeedUIHouse TopPanel = LawAntStand();
      if (TopPanel.name != nameof(TendStand) + "(Clone)")
          return false;
      return true;
  }
}

public class UIFormParams
{
    public string UpBardCoin;   // 窗体名称
    public object UpBardLizard; // 窗体参数
}
