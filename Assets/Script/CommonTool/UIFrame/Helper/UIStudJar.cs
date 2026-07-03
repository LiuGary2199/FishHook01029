/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIStudJar : MonoBehaviour
{
    private static UIStudJar _Laurasia= null;
    //ui根节点对象
    private GameObject _MeShroudRead= null;
    //ui脚本节点对象
    private Transform _RatUIGinghamWest= null;
    //顶层面板
    private GameObject _MeAxStand;
    //遮罩面板
    private GameObject _MeStudStand;
    //ui摄像机
    private Camera _UIPreach;
    //ui摄像机原始的层深
    private float _PresenceUIPreachCarol;
    //获取实例
    public static UIStudJar LawLaurasia()
    {
        if (_Laurasia == null)
        {
            _Laurasia = new GameObject("_UIMaskMgr").AddComponent<UIStudJar>();
        }
        return _Laurasia;
    }
    private void Awake()
    {
        _MeShroudRead = GameObject.FindGameObjectWithTag(RawDisuse.SYS_TAG_CANVAS);
        _RatUIGinghamWest = MaybeCarbon.EditPutVenueWest(_MeShroudRead, RawDisuse.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        MaybeCarbon.TieVenueWestAxSolelyWest(_RatUIGinghamWest, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _MeAxStand = _MeShroudRead;
        _MeStudStand = MaybeCarbon.EditPutVenueWest(_MeShroudRead, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UIPreach = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UIPreach != null)
        {
            //得到ui相机原始的层深
            _PresenceUIPreachCarol = _UIPreach.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void DueStudParlor(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _MeAxStand.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _MeStudStand.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _MeStudStand.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _MeStudStand.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _MeStudStand.GetComponent<Image>().color = newColor2;
                BurgeonEightyCharm.LawLaurasia().Tang(CTedium.mg_ParlorTerm);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _MeStudStand.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _MeStudStand.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_MeStudStand.activeInHierarchy)
                {
                    _MeStudStand.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _MeStudStand.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UIPreach != null)
        {
            _UIPreach.depth = _UIPreach.depth + 100;
        }
    }
    public void JoltStudParlor()
    {
        if (UIStrange.LawLaurasia().PondUIHouse.Count > 0 || UIStrange.LawLaurasia().LawBalanceBardSyrup().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_MeStudStand.GetComponent<Image>().color.r, _MeStudStand.GetComponent<Image>().color.g, _MeStudStand.GetComponent<Image>().color.b,0);
        _MeStudStand.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void MalletStudParlor()
    {
        if (UIStrange.LawLaurasia().PondUIHouse.Count > 0 || UIStrange.LawLaurasia().LawBalanceBardSyrup().Count > 0)
        {
            return;
        }
        // 检查是否有其他 PopUp 窗口正在显示
        bool hasOtherPopUp = false;
        var openingPanels = UIStrange.LawLaurasia().LawBurgherInject(true);
        foreach (var panel in openingPanels)
        {
            var baseUIForm = panel.GetComponent<SeedUIHouse>();
            if (baseUIForm != null && baseUIForm.BalanceUIToll.UIForms_Type == UIFormType.PopUp)
            {
                hasOtherPopUp = true;
                // 将遮罩放在最后一个 PopUp 窗口下面
                _MeStudStand.transform.SetAsLastSibling();
                panel.transform.SetAsLastSibling();
                break;
            }
        }

        // 只有在没有其他 PopUp 窗口时才关闭遮罩
        if (!hasOtherPopUp)
        {
            //顶层窗体上移
            _MeAxStand.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            if (_MeStudStand.activeInHierarchy)
            {
                _MeStudStand.SetActive(false);
                BurgeonEightyCharm.LawLaurasia().Tang(CTedium.Ax_ParlorDrift);
            }
            //恢复当前ui摄像机的层深
            if (_UIPreach != null)
            {
                _UIPreach.depth = _PresenceUIPreachCarol;
            }
        }
    }
}
