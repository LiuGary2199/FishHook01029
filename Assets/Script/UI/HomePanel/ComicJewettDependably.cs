using UnityEngine;
using UnityEngine.UI;

public class ComicJewettDependably : MonoBehaviour
{
    [Header("波纹参数")]
    [Tooltip("波纹最大扩散半径（UV坐标，0-1）")]
[UnityEngine.Serialization.FormerlySerializedAs("maxRippleRadius")]    public float ViaRippleRadius= 0.5f;
    [Tooltip("波纹扩散速度")]
[UnityEngine.Serialization.FormerlySerializedAs("rippleSpeed")]    public float FlightModal= 0.1f;
    [Tooltip("波纹强度")]
[UnityEngine.Serialization.FormerlySerializedAs("rippleStrength")]    public float FlightDistance= 0.1f;
    [Tooltip("波纹衰减速度")]
[UnityEngine.Serialization.FormerlySerializedAs("rippleFalloff")]    public float FlightNoxious= 5f;

    private RawImage _CurlyTwain; // 水面UI
    private Material _CurlyMastodon; // 水面材质
    private bool _BeMilkweed= false; // 是否正在扩散波纹
    private float _NotableCarver= 0f; // 当前波纹半径
    private Vector2 _FlightEightyUV; // 波纹中心（UV坐标）

    void Start()
    {
        // 获取RawImage组件（确保挂载对象是RawImage）
        _CurlyTwain = GetComponent<RawImage>();
        if (_CurlyTwain == null)
        {
            Debug.LogError("请将脚本挂载到RawImage对象上！");
            return;
        }

        // 创建材质实例（避免修改共享材质）
        _CurlyMastodon = new Material(_CurlyTwain.material);
        _CurlyTwain.material = _CurlyMastodon;

        // 初始化材质参数
        PrimeJewettLizard();
    }

    void Update()
    {
        // 如果正在扩散波纹，更新参数
        if (_BeMilkweed)
        {
            _NotableCarver += FlightModal * Time.deltaTime;
            // 更新材质参数
            _CurlyMastodon.SetVector("_RippleCenter", _FlightEightyUV);
            _CurlyMastodon.SetFloat("_RippleRadius", _NotableCarver);
            _CurlyMastodon.SetFloat("_RippleStrength", FlightDistance);
            _CurlyMastodon.SetFloat("_RippleFalloff", FlightNoxious);

            // 当波纹扩散到最大半径，停止扩散
            if (_NotableCarver >= ViaRippleRadius)
            {
                _BeMilkweed = false;
                PrimeJewettLizard(); // 重置参数
            }
        }
    }

    /// <summary>
    /// 触发水波（箭入水时调用）
    /// </summary>
    /// <param name="worldPos">箭入水的世界坐标</param>
    public void SituateJewett(Vector3 worldPos)
    {
        // 将世界坐标转换为UI的UV坐标
        RectTransform rectTrans = _CurlyTwain.rectTransform;
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTrans,
            Camera.main.WorldToScreenPoint(worldPos),
            Camera.main,
            out localPos
        );

        // 转换为UV坐标（0-1范围）
        _FlightEightyUV.x = (localPos.x + rectTrans.rect.width / 2) / rectTrans.rect.width;
        _FlightEightyUV.y = (localPos.y + rectTrans.rect.height / 2) / rectTrans.rect.height;

        // 初始化波纹参数
        _NotableCarver = 0.01f;
        _BeMilkweed = true;
    }

    /// <summary>
    /// 重置波纹参数
    /// </summary>
    private void PrimeJewettLizard()
    {
        _CurlyMastodon.SetVector("_RippleCenter", Vector2.zero);
        _CurlyMastodon.SetFloat("_RippleRadius", 0f);
        _CurlyMastodon.SetFloat("_RippleStrength", 0f);
    }

    void OnDestroy()
    {
        // 销毁材质，避免内存泄漏
        if (_CurlyMastodon != null)
        {
            Destroy(_CurlyMastodon);
        }
    }
}