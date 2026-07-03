using UnityEngine;
using TMPro;
using Spine.Unity;
using Spine;
using UnityEngine.UI;


[DisallowMultipleComponent]
public class StripCrewAxUGUITMP : MonoBehaviour
{
    [Header("Spine 骨骼对象（UGUI 版）")]
[UnityEngine.Serialization.FormerlySerializedAs("skeletonGraphic")]    public SkeletonGraphic HoloceneDiamond;

    [Header("要跟随的骨骼名字")]
[UnityEngine.Serialization.FormerlySerializedAs("boneName")]    public string MindCoin;

    [Header("位置偏移")]
    public Vector2 offset;

    [Header("调试：放大骨骼位移（x/y）")]
    [Tooltip("把骨骼相对 skeletonGraphic.transform 的局部位移 x/y 放大该倍数。\n例如 10=放大10倍，用于修正“只动小数点”的现象。")]
[UnityEngine.Serialization.FormerlySerializedAs("boneWorldXYScale")]    public float MindGourdXYTrunk= 10f;

    private RectTransform _Duct;
    private Bone _Mind;
    private Canvas _Ballad;
    private Camera _uiBur;

    void Awake()
    {
        _Duct = GetComponent<RectTransform>();
        _Ballad = GetComponentInParent<Canvas>();
        if (_Ballad == null) _Ballad = FindObjectOfType<Canvas>();
        _uiBur = _Ballad.renderMode == RenderMode.ScreenSpaceOverlay ? null : _Ballad.worldCamera;
    }

    void OnEnable()
    {
        EditCrew();
    }

    void EditCrew()
    {
        _Mind = null;
        if (HoloceneDiamond == null || string.IsNullOrEmpty(MindCoin)) return;
        _Mind = HoloceneDiamond.Skeleton.FindBone(MindCoin);
    }

    void LateUpdate()
    {
        if (_Mind == null)
        {
            EditCrew();
            return;
        }
        if (_Ballad == null) return;

        // 1) 获取 bone 世界坐标（Unity 2D 体系）
        Vector3 boneWorld = HoloceneDiamond.transform.TransformPoint(new Vector3(_Mind.WorldX, _Mind.WorldY, 0f));

        // 1.1) 对 bone 的 x/y 位移做放大（相对 skeletonGraphic 自身坐标原点）
        // 避免把世界绝对坐标直接乘导致整体跑飞。
        if (!Mathf.Approximately(MindGourdXYTrunk, 1f))
        {
            Vector3 boneLocal = HoloceneDiamond.transform.InverseTransformPoint(boneWorld);
            boneLocal.x *= MindGourdXYTrunk;
            boneLocal.y *= MindGourdXYTrunk;
            boneWorld = HoloceneDiamond.transform.TransformPoint(boneLocal);
        }

        // 2) 世界坐标 -> 屏幕坐标
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(_uiBur, boneWorld);

        // 3) 屏幕坐标 -> 当前 RectTransform 父级的局部坐标（更贴合 UI 结构）
        RectTransform refRect = (_Duct.parent as RectTransform) != null ? (_Duct.parent as RectTransform) : _Duct;

        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(refRect, screenPos, _uiBur, out localPos);

        // 4) 设置 anchoredPosition + offset（offset 直接按 UI 局部单位叠加）
        _Duct.anchoredPosition = localPos + offset;
    }
}