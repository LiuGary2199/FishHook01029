/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LatinSituateDisguise : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate ItLeaky;
    public VoidDelegate ItLove;
    public VoidDelegate ItPrior;
    public VoidDelegate ItLean;
    public VoidDelegate ItSo;
    public VoidDelegate ItMidway;
    public VoidDelegate ItAthensMidway;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static LatinSituateDisguise Law(GameObject go)
    {
        LatinSituateDisguise listener = go.GetComponent<LatinSituateDisguise>();
        if (listener == null)
        {
            listener = go.AddComponent<LatinSituateDisguise>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (ItLeaky != null)
        {
            ItLeaky(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (ItLove != null)
        {
            ItLove(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (ItPrior != null)
        {
            ItPrior(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (ItLean != null)
        {
            ItLean(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (ItSo != null)
        {
            ItSo(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (ItMidway != null)
        {
            ItMidway(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (ItAthensMidway != null)
        {
            ItAthensMidway(gameObject);
        }
    }
}
