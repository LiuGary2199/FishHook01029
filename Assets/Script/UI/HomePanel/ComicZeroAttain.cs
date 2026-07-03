using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 全屏点击水波纹效果（基于 UI/WaterWave Shader，扭曲 RawImage 自身贴图）。
/// 挂在一个铺满屏幕的 RawImage 上即可。
/// </summary>
[RequireComponent(typeof(RawImage))]
public class ComicZeroAttain : MonoBehaviour, IPointerDownHandler
{
    [Header("水波纹参数")]
    [Tooltip("波纹扩散速度（半径每秒增加量）")]
[UnityEngine.Serialization.FormerlySerializedAs("waveSpeed")]    public float HurlModal= 1.5f;

    [Tooltip("波纹宽度")]
    [Range(0.0f, 0.2f)]
[UnityEngine.Serialization.FormerlySerializedAs("waveWidth")]    public float HurlMetal= 0.05f;

    [Tooltip("波纹强度")]
    [Range(0.0f, 0.1f)]
[UnityEngine.Serialization.FormerlySerializedAs("waveStrength")]    public float HurlDistance= 0.02f;

    [Tooltip("波纹最大半径（0~1，按UV计算）")]
    [Range(0.0f, 1.5f)]
[UnityEngine.Serialization.FormerlySerializedAs("maxRadius")]    public float ViaCarver= 1.0f;

    private Material _Who;
    private Vector2 _PoorlyUV;
    private float _Icicle;
    private bool _Assume;

    // Shader 属性ID
    private static readonly int ID_WaveEighty= Shader.PropertyToID("_WaveCenter");
    private static readonly int ID_ZeroCarver= Shader.PropertyToID("_WaveRadius");
    private static readonly int ID_ZeroMetal= Shader.PropertyToID("_WaveWidth");
    private static readonly int ID_ZeroDistance= Shader.PropertyToID("_WaveStrength");

    private void Awake()
    {
        var img = GetComponent<RawImage>();

        // 为每个实例拷贝一份材质，避免修改到共享材质
        if (img.material != null)
        {
            _Who = Instantiate(img.material);
        }
        else
        {
            _Who = new Material(Shader.Find("UI/WaterWave"));
        }
        img.material = _Who;

        // 默认拉满全屏（如果你已经在 Inspector 里设好了，可以删掉这一段）
        var rt = img.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        img.uvRect = new Rect(0, 0, 1, 1);

        // 初始化材质参数
        _Who.SetFloat(ID_ZeroCarver, 0f);
        _Who.SetFloat(ID_ZeroMetal, HurlMetal);
        _Who.SetFloat(ID_ZeroDistance, HurlDistance);
    }

    private void Update()
    {
        if (!_Assume) return;

        _Icicle += HurlModal * Time.deltaTime;
        _Who.SetFloat(ID_ZeroCarver, _Icicle);

        if (_Icicle >= ViaCarver)
        {
            _Assume = false;
            _Icicle = 0f;
            _Who.SetFloat(ID_ZeroCarver, 0f);
        }
    }

    /// <summary>
    /// 点击屏幕时触发一次波纹（需要 Canvas + GraphicRaycaster）。
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransform Duct= transform as RectTransform;
        if (Duct == null || _Who == null) return;

        // 屏幕点 → Rect 本地坐标
        Vector2 localPoint;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                Duct,
                eventData.position,
                eventData.pressEventCamera,
                out localPoint))
        {
            return;
        }

        // 本地坐标 → 0~1 UV（左下为 0,0）
        Rect r = Duct.rect;
        _PoorlyUV.x = Mathf.Clamp01((localPoint.x - r.xMin) / r.width);
        _PoorlyUV.y = Mathf.Clamp01((localPoint.y - r.yMin) / r.height);

        _Who.SetVector(ID_WaveEighty, _PoorlyUV);
        _Who.SetFloat(ID_ZeroMetal, HurlMetal);
        _Who.SetFloat(ID_ZeroDistance, HurlDistance);

        _Icicle = 0f;
        _Who.SetFloat(ID_ZeroCarver, 0f);
        _Assume = true;
    }

    /// <summary>
    /// 通过代码触发，参数是屏幕坐标（像素）。
    /// </summary>
    public void SituateZero(Vector2 screenPos, Camera uiCamera = null)
    {
        RectTransform Duct= transform as RectTransform;
        if (Duct == null || _Who == null) return;

        Vector2 localPoint;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                Duct,
                screenPos,
                uiCamera,
                out localPoint))
        {
            return;
        }

        Rect r = Duct.rect;
        _PoorlyUV.x = Mathf.Clamp01((localPoint.x - r.xMin) / r.width);
        _PoorlyUV.y = Mathf.Clamp01((localPoint.y - r.yMin) / r.height);

        _Who.SetVector(ID_WaveEighty, _PoorlyUV);
        _Who.SetFloat(ID_ZeroMetal, HurlMetal);
        _Who.SetFloat(ID_ZeroDistance, HurlDistance);

        _Icicle = 0f;
        _Who.SetFloat(ID_ZeroCarver, 0f);
        _Assume = true;
    }

    private void OnDestroy()
    {
        if (_Who != null)
        {
            Destroy(_Who);
            _Who = null;
        }
    }
}
