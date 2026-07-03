/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermeateJar 
{
    public static PermeateJar _Component;
    //语言翻译的缓存集合
    private Dictionary<string, string> _PryPermeateRanch;

    private PermeateJar()
    {
        _PryPermeateRanch = new Dictionary<string, string>();
        //初始化语言缓存集合
        RailPermeateRanch();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static PermeateJar LawLaurasia()
    {
        if (_Component == null)
        {
            _Component = new PermeateJar();
        }
        return _Component;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string BeatBode(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_PryPermeateRanch!=null && _PryPermeateRanch.Count >= 1)
        {
            _PryPermeateRanch.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void RailPermeateRanch()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        ITediumStrange config = new TediumStrangeBePath("LauguageJSONConfig");
        if (config != null)
        {
            _PryPermeateRanch = config.CabPrinter;
        }
    }
}
