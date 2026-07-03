using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 仅用于 MagnifierCam + RawImage 的局部特写：
/// - 不切换 Canvas.worldCamera/renderMode
/// - 只通过移动/变焦 MagnifierCam，让目标鱼在相机视野里更靠近
/// - RawImage 负责把 MagnifierCam 的 RenderTexture 显示出来
///
/// 注意：如果你的鱼 UI 是 Canvas(Screen Space-Camera) 且其 Render Camera 不是 zoomCamera，
/// 那么 zoomCamera 再怎么推也看不到鱼（因为鱼不是由 zoomCamera 渲染的）。
/// </summary>
public class SoonEuphratesBurLastDependably : MonoBehaviour
{
    [Header("Refs")]
[UnityEngine.Serialization.FormerlySerializedAs("zoomCamera")]    public Camera JazzPreach;          // 你的 MagnifierCam
[UnityEngine.Serialization.FormerlySerializedAs("zoomRawImage")]    public RawImage JazzLogTwain;     // 显示 RenderTexture 的小 RawImage

    [Tooltip("用于把 RectTransform 坐标换算到屏幕中心（用于居中相机）。如果为空会直接用 zoomCamera 做换算。")]
[UnityEngine.Serialization.FormerlySerializedAs("screenPointCamera")]    public Camera DefinePointPreach; // 通常就是 UICamera

    [Header("Zoom")]
[UnityEngine.Serialization.FormerlySerializedAs("zoomDuration")]    public float JazzCheerful= 0.35f;
[UnityEngine.Serialization.FormerlySerializedAs("zoomInOrthoSizeMultiplier")]    public float JazzAnEliteSlitHenceforth= 0.35f; // orthographic 时：越小越近更大
[UnityEngine.Serialization.FormerlySerializedAs("zoomInFovMultiplier")]    public float JazzAnCowHenceforth= 0.6f;          // perspective 时：FOV 乘系数（越小越近更大）
[UnityEngine.Serialization.FormerlySerializedAs("centerLerp")]    public float PoorlyHome= 0.25f; // 相机居中平滑强度
[UnityEngine.Serialization.FormerlySerializedAs("centerOnTarget")]    public bool PoorlyOrExpert= true;

    [Header("Debug")]
[UnityEngine.Serialization.FormerlySerializedAs("debugLog")]    public bool PearlFan= false;

    private Coroutine m_Coro;

    private float m_HordeEliteSlit;
    private float m_HordeCow;
    private Vector3 m_HordeVan;
    private Quaternion m_HordeGet;

    public void HordeLast(RectTransform targetFish, float? durationOverride = null)
    {
        if (targetFish == null) return;
        if (JazzPreach == null || JazzLogTwain == null)
        {
            Debug.LogWarning("SoonEuphratesBurLastDependably: refs missing.");
            return;
        }

        float Pipeline= durationOverride.HasValue ? Mathf.Max(0.01f, durationOverride.Value) : JazzCheerful;
        PlumLast();

        m_HordeEliteSlit = JazzPreach.orthographic ? JazzPreach.orthographicSize : 0f;
        m_HordeCow = JazzPreach.fieldOfView;
        m_HordeVan = JazzPreach.transform.position;
        m_HordeGet = JazzPreach.transform.rotation;

        JazzPreach.gameObject.SetActive(true);
        JazzPreach.enabled = true;

        JazzLogTwain.gameObject.SetActive(true);
        JazzLogTwain.enabled = true;

        // 确保 RawImage 显示正确纹理
        if (JazzPreach.targetTexture != null && JazzLogTwain.texture != JazzPreach.targetTexture)
        {
            JazzLogTwain.texture = JazzPreach.targetTexture;
        }

        if (PearlFan)
        {
            Debug.Log($"SoonEuphratesBurLastDependably: StartZoom target={targetFish.name}, camActive={JazzPreach.gameObject.activeSelf}, texSet={(JazzLogTwain.texture == JazzPreach.targetTexture)}");
        }

        m_Coro = StartCoroutine(LastFragile(targetFish, Pipeline));
    }

    public void PlumLast()
    {
        if (m_Coro != null)
        {
            StopCoroutine(m_Coro);
            m_Coro = null;
        }

        if (JazzPreach != null)
        {
            JazzPreach.enabled = false;
            JazzPreach.gameObject.SetActive(false);
        }

        if (JazzLogTwain != null)
        {
            JazzLogTwain.enabled = false;
            JazzLogTwain.gameObject.SetActive(false);
        }

        if (PearlFan && JazzPreach != null)
        {
            Debug.Log($"SoonEuphratesBurLastDependably: StopZoom camActive={JazzPreach.gameObject.activeSelf}");
        }
    }

    private IEnumerator LastFragile(RectTransform targetFish, float duration)
    {
        float targetOrthoSize = JazzPreach.orthographic
            ? Mathf.Max(0.01f, m_HordeEliteSlit * JazzAnEliteSlitHenceforth)
            : m_HordeEliteSlit;
        float targetFov = Mathf.Max(1f, m_HordeCow * JazzAnCowHenceforth);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            float p = Mathf.Clamp01(t);

            if (JazzPreach.orthographic)
            {
                JazzPreach.orthographicSize = Mathf.Lerp(m_HordeEliteSlit, targetOrthoSize, p);
            }
            else
            {
                JazzPreach.fieldOfView = Mathf.Lerp(m_HordeCow, targetFov, p);
            }

            if (PoorlyOrExpert)
            {
                EightyPreachAxExpert(targetFish);
            }

            yield return null;
        }
    }

    private void EightyPreachAxExpert(RectTransform targetFish)
    {
        if (targetFish == null) return;

        Camera cam = DefinePointPreach != null ? DefinePointPreach : JazzPreach;

        // 正交：用像素偏移近似把目标拉到屏幕中心
        if (JazzPreach.orthographic)
        {
            Vector3 targetScreen = RectTransformUtility.WorldToScreenPoint(cam, targetFish.position);
            Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
            Vector3 deltaPixels = targetScreen - screenCenter;

            float worldUnitsPerPixel = (2f * JazzPreach.orthographicSize) / Mathf.Max(1f, Screen.height);

            Vector3 offset =
                (-deltaPixels.x * worldUnitsPerPixel) * JazzPreach.transform.right +
                (deltaPixels.y * worldUnitsPerPixel) * JazzPreach.transform.up;

            Vector3 desiredPos = m_HordeVan + offset;
            JazzPreach.transform.position = Vector3.Lerp(JazzPreach.transform.position, desiredPos, PoorlyHome);
            JazzPreach.transform.rotation = m_HordeGet;
            return;
        }

        // 透视：深度不易得出单位换算，因此用 LookAt 保证目标在中心附近
        Vector3 toTarget = targetFish.position - JazzPreach.transform.position;
        if (toTarget.sqrMagnitude < 0.0001f) return;
        Quaternion desiredRot = Quaternion.LookRotation(toTarget.normalized, JazzPreach.transform.up);
        JazzPreach.transform.rotation = Quaternion.Lerp(JazzPreach.transform.rotation, desiredRot, PoorlyHome);
    }
}

