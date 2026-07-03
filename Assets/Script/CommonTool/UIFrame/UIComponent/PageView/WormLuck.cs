/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WormLuck : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Duct;
    //求出每页的临界角，页索引从0开始
    List<float> posTall= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool BeGrit= false;
    bool PlotPeat= true;
    //滑动的起始坐标  
    float LitterAutonomous= 0;
    float EagerGritAutonomous;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float December= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Domesticate= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> OrWormUnjust;
    //当前页面下标
    int NotableWormSlope= -1;
    void Start()
    {
        Duct = this.GetComponent<ScrollRect>();
        float horizontalLength = Duct.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        posTall.Add(0);
        for(int i = 1; i < Duct.content.childCount - 1; i++)
        {
            posTall.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        posTall.Add(1);
    }

    
    void Update()
    {
        if(!BeGrit && !PlotPeat)
        {
            startTime += Time.deltaTime;
            float t = startTime * December;
            Duct.horizontalNormalizedPosition = Mathf.Lerp(Duct.horizontalNormalizedPosition, LitterAutonomous, t);
            if (t >= 1)
            {
                PlotPeat = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void DueWormSlope(int index)
    {
        if (NotableWormSlope != index)
        {
            NotableWormSlope = index;
            if (OrWormUnjust != null)
            {
                OrWormUnjust(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeGrit = true;
        EagerGritAutonomous = Duct.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Duct.horizontalNormalizedPosition;
        posX += ((posX - EagerGritAutonomous) * Domesticate);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float offset = Mathf.Abs(posTall[index] - posX);
        for(int i = 0; i < posTall.Count; i++)
        {
            float temp = Mathf.Abs(posTall[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        DueWormSlope(index);
        LitterAutonomous = posTall[index];
        BeGrit = false;
        startTime = 0f;
        PlotPeat = false;
    }
}
