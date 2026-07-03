using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class BurgeonMint
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool SheetSlip;
    public bool SheetSlip2;
    public int SheetSpy;
    public int SheetSpy2;
    public int SheetSpy3;
    public float SheetChain;
    public float SheetChain2;
    public double SheetBelter;
    public double SheetBelter2;
    public string SheetBabble;
    public string SheetBabble2;
    public GameObject SheetRopeRation;
    public GameObject SheetRopeRation2;
    public GameObject SheetRopeRation3;
    public GameObject SheetRopeRation4;
    public Transform SheetProcedure;
    public List<string> SheetBabbleTall;
    public List<Vector2> SheetVec2Tall;
    public List<int> SheetSpyTall;
    public System.Action ReelectHideVent;
    public Vector2 Age2_1;
    public Vector2 Age2_2;
    public BurgeonMint()
    {
    }
    public BurgeonMint(Vector2 v2_1)
    {
        Age2_1 = v2_1;
    }
    public BurgeonMint(Vector2 v2_1, Vector2 v2_2)
    {
        Age2_1 = v2_1;
        Age2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BurgeonMint(bool value)
    {
        SheetSlip = value;
    }
    public BurgeonMint(bool value, bool value2)
    {
        SheetSlip = value;
        SheetSlip2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BurgeonMint(int value)
    {
        SheetSpy = value;
    }
    public BurgeonMint(int value, int value2)
    {
        SheetSpy = value;
        SheetSpy2 = value2;
    }
    public BurgeonMint(int value, int value2, int value3)
    {
        SheetSpy = value;
        SheetSpy2 = value2;
        SheetSpy3 = value3;
    }
    public BurgeonMint(List<int> value,List<Vector2> value2)
    {
        SheetSpyTall = value;
        SheetVec2Tall = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BurgeonMint(float value)
    {
        SheetChain = value;
    }
    public BurgeonMint(float value,float value2)
    {
        SheetChain = value;
        SheetChain = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BurgeonMint(double value)
    {
        SheetBelter = value;
    }
    public BurgeonMint(double value, double value2)
    {
        SheetBelter = value;
        SheetBelter = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public BurgeonMint(string value)
    {
        SheetBabble = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public BurgeonMint(string value1,string value2)
    {
        SheetBabble = value1;
        SheetBabble2 = value2;
    }
    public BurgeonMint(GameObject value1)
    {
        SheetRopeRation = value1;
    }

    public BurgeonMint(Transform transform)
    {
        SheetProcedure = transform;
    }
}

