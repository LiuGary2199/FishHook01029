/*
 * 
 *  管理多个对象池的管理类
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RationCookStrange : MonoSnowstorm<RationCookStrange>
{
    //管理objectpool的字典
    private Dictionary<string, ObjectPool> m_CookPry;
    private Transform m_ReadProcedure=null;
    //构造函数
    public RationCookStrange()
    {
        m_CookPry = new Dictionary<string, ObjectPool>();      
    }
    
    //创建一个新的对象池
    public T ThinlyRationCook<T>(string poolName) where T : ObjectPool, new()
    {
        if (m_CookPry.ContainsKey(poolName))
        {
            return m_CookPry[poolName] as T;
        }
        if (m_ReadProcedure == null)
        {
            m_ReadProcedure = this.transform;
        }      
        GameObject obj = new GameObject(poolName);
        obj.transform.SetParent(m_ReadProcedure);
        T pool = new T();
        pool.Init(poolName, obj.transform);
        m_CookPry.Add(poolName, pool);
        return pool;
    }
    //取对象
    public GameObject LawRopeRation(string poolName)
    {
        if (m_CookPry.ContainsKey(poolName))
        {
            return m_CookPry[poolName].Get();
        }
        return null;
    }
    //回收对象
    public void CalciteRopeRation(string poolName,GameObject go)
    {
        if (m_CookPry.ContainsKey(poolName))
        {
            m_CookPry[poolName].Recycle(go);
        }
    }
    //销毁所有的对象池
    public void OnDestroy()
    {
        m_CookPry.Clear();
        GameObject.Destroy(m_ReadProcedure);
    }
    /// <summary>
    /// 查询是否有该对象池
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public bool ChartCook(string poolName)
    {
        return m_CookPry.ContainsKey(poolName) ? true : false;
    }
}
