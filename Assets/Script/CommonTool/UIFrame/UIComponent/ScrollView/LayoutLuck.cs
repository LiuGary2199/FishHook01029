/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LayoutLuck : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public LayoutLuckKeep MoonFeud;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect NinetyFear;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Welcome;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Fishery= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float FleetMetal;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float FleetAbroad;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int FanwiseRelic;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool BePelt= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int EagerSlope;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int SoloSlope;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float MoonAbroad= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<LayoutLuckKeep> MoonTall;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<LayoutLuckKeep> FanwiseTall;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> MayTall;

    void Start()
    {
        FleetAbroad = this.GetComponent<RectTransform>().sizeDelta.y;
        FleetMetal = this.GetComponent<RectTransform>().sizeDelta.x;
        Welcome = NinetyFear.content;
        RailMint();

    }
    //初始化
    public void RailMint()
    {
        FanwiseRelic = Mathf.CeilToInt(FleetAbroad / UponAbroad) + 1;
        for (int i = 0; i < FanwiseRelic; i++)
        {
            this.TieKeep();
        }
        EagerSlope = 0;
        SoloSlope = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        DueMint(numberList);
    }
    //设置数据
    void DueMint(List<int> list)
    {
        MayTall = list;
        EagerSlope = 0;
        if (MintRelic <= FanwiseRelic)
        {
            SoloSlope = MintRelic;
        }
        else
        {
            SoloSlope = FanwiseRelic - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = EagerSlope; i < SoloSlope; i++)
        {
            LayoutLuckKeep obj = PryKeep();
            if (obj == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                obj.gameObject.name = i.ToString();

                obj.gameObject.SetActive(true);
                obj.transform.localPosition = new Vector3(0, -i * UponAbroad, 0);
                FanwiseTall.Add(obj);
                AthensKeep(i, obj);
            }

        }
        Welcome.sizeDelta = new Vector2(FleetMetal, MintRelic * UponAbroad - Fishery);
        BePelt = true;
    }
    //更新item
    public void AthensKeep(int index, LayoutLuckKeep obj)
    {
        int d = MayTall[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public LayoutLuckKeep PryKeep()
    {
        LayoutLuckKeep obj = null;
        if (MoonTall.Count > 0)
        {
            obj = MoonTall[0];
            obj.gameObject.SetActive(true);
            MoonTall.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return obj;
    }
    //item进入itemlist
    public void BoilKeep(LayoutLuckKeep obj)
    {
        MoonTall.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int MintRelic    {
        get
        {
            return MayTall.Count;
        }
    }
    //每一行的高
    public float UponAbroad    {
        get
        {
            return MoonAbroad + Fishery;
        }
    }
    //添加item到缓存列表中
    public void TieKeep()
    {
        GameObject obj = Instantiate(MoonFeud.gameObject);
        obj.transform.SetParent(Welcome);
        RectTransform Duct= obj.GetComponent<RectTransform>();
        Duct.anchorMin = new Vector2(0.5f, 1);
        Duct.anchorMax = new Vector2(0.5f, 1);
        Duct.pivot = new Vector2(0.5f, 1);
        obj.SetActive(false);
        obj.transform.localScale = Vector3.one;
        LayoutLuckKeep o = obj.GetComponent<LayoutLuckKeep>();
        MoonTall.Add(o);
    }



    void Update()
    {
        if (BePelt)
        {
            Layout();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Layout()
    {
        float vy = Welcome.anchoredPosition.y;
        float rollUpTop = (EagerSlope + 1) * UponAbroad;
        float rollUnderTop = EagerSlope * UponAbroad;

        if (vy > rollUpTop && SoloSlope < MintRelic)
        {
            //上边界移除
            if (FanwiseTall.Count > 0)
            {
                LayoutLuckKeep obj = FanwiseTall[0];
                FanwiseTall.RemoveAt(0);
                BoilKeep(obj);
            }
            EagerSlope++;
        }
        float rollUpBottom = (SoloSlope - 1) * UponAbroad - Fishery;
        if (vy < rollUpBottom - FleetAbroad && EagerSlope > 0)
        {
            //下边界减少
            SoloSlope--;
            if (FanwiseTall.Count > 0)
            {
                LayoutLuckKeep obj = FanwiseTall[FanwiseTall.Count - 1];
                FanwiseTall.RemoveAt(FanwiseTall.Count - 1);
                BoilKeep(obj);
            }

        }
        float rollUnderBottom = SoloSlope * UponAbroad - Fishery;
        if (vy > rollUnderBottom - FleetAbroad && SoloSlope < MintRelic)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            LayoutLuckKeep go = PryKeep();
            FanwiseTall.Add(go);
            go.transform.localPosition = new Vector3(0, -SoloSlope * UponAbroad);
            AthensKeep(SoloSlope, go);
            SoloSlope++;
        }


        if (vy < rollUnderTop && EagerSlope > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            EagerSlope--;
            LayoutLuckKeep go = PryKeep();
            FanwiseTall.Insert(0, go);
            AthensKeep(EagerSlope, go);
            go.transform.localPosition = new Vector3(0, -EagerSlope * UponAbroad);
        }

    }
}
