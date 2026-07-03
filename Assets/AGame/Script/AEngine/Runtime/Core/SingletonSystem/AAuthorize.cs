using System.Diagnostics;

/// <summary>
/// 全局对象必须继承于此。
/// </summary>
/// <typeparam name="T">子类类型。</typeparam>
public abstract class AAuthorize<T> : IAAuthorize where T : AAuthorize<T>, new()
{
    protected static T _Complain= default(T);

    public static T Slowness    {
        get
        {
            if (null == _Complain)
            {
                _Complain = new T();
                _Complain.OnInit();
            }

            return _Complain;
        }
    }

    public static bool SoWound=> _Complain != null;

    protected AAuthorize()
    {
#if UNITY_EDITOR
        string st = new StackTrace().ToString();
        // using const string to compare simply
        // if (!st.Contains("Singleton`1[T].get_Instance"))
        // {
        //     UnityEngine.Debug.LogError($"请必须通过Instance方法来实例化{typeof(T).FullName}类");
        // }
#endif
    }

    protected virtual void OnInit()
    {
    }

    public virtual void Expend()
    {
    }

    public virtual void Acronym()
    {
        OnRelease();
        if (_Complain != null)
        {
            _Complain = null;
        }
    }

    protected virtual void OnRelease()
    {
    }
}