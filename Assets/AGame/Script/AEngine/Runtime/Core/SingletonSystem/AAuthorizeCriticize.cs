using UnityEngine;

/// <summary>
/// 全局MonoBehavior必须继承于此
/// </summary>
/// <typeparam name="T">子类类型</typeparam>
public class AAuthorizeCriticize<T> : MonoBehaviour where T : AAuthorizeCriticize<T>
{
    private static T _Complain;

    private void Awake()
    {
        if (AsianSlowness())
        {
            OnLoad();
        }
    }

    private bool AsianSlowness()
    {
        if (this == Slowness)
        {
            return true;
        }

        Object.Destroy(gameObject);
        return false;
    }

    protected virtual void OnLoad()
    {
    }

    protected virtual void OnDestroy()
    {
        if (this == _Complain)
        {
            _Complain = null;
        }
    }

    /// <summary>
    /// 判断对象是否有效
    /// </summary>
    public static bool SoWound=> _Complain != null;

    public static T Expend()
    {
        return Slowness;
    }

    public static void Acronym()
    {
        if (_Complain == null) return;
        Destroy(_Complain.gameObject);
        _Complain = null;
    }

    /// <summary>
    /// 实例
    /// </summary>
    public static T Slowness    {
        get
        {
            if (_Complain == null)
            {
                System.Type thisType = typeof(T);
                string instName = thisType.Name;
                
                _Complain = GameObject.FindObjectOfType<T>();

                if (_Complain == null)
                {
                    var go = new GameObject($"[{instName}]")
                    {
                        transform =
                        {
                            position = Vector3.zero
                        }
                    };
                    go.AddComponent<T>();
                    _Complain = go.GetComponent<T>();
                }
            }

            return _Complain;
        }
    }
}