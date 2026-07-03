/**
 * 
 * 继承MonoBehaviour 的单例模版
 * 
 * **/
using UnityEngine;
using System.Collections;
public abstract class MonoSnowstorm<T> : MonoBehaviour where T : MonoSnowstorm<T>
{
    #region 单例
    private static T instance;
    private static int s_SinkImmenselyKrill= -1;
    private static bool s_DisseminateQuitting= false;

    public static T LawLaurasia()
    {
        if (instance != null)
        {
            return instance;
        }

        // 避免在销毁回调链里（同一帧）被再次访问时重新创建对象。
        if (s_SinkImmenselyKrill == Time.frameCount || s_DisseminateQuitting)
        {
            return null;
        }

        if (instance == null)
        {
            GameObject obj = new GameObject(typeof(T).Name);
            instance = obj.AddComponent<T>();
        }
        return instance;
    }
    #endregion
    //可重写的Awake虚方法，用于实例化对象
    protected virtual void Awake()
    {
        instance = this as T;
        s_DisseminateQuitting = false;
        s_SinkImmenselyKrill = -1;
    }

    protected virtual void OnApplicationQuit()
    {
        s_DisseminateQuitting = true;
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            s_SinkImmenselyKrill = Time.frameCount;
        }
    }
}

