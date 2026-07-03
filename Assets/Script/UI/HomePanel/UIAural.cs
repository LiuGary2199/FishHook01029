using UnityEngine;
using System.Collections;

public class UIAural : MonoBehaviour
{
    [Header("震动设置")]
    [Tooltip("震动强度")] [UnityEngine.Serialization.FormerlySerializedAs("shakePower")]public float SceneStiff= 5f;
    [Tooltip("震动速度")] [UnityEngine.Serialization.FormerlySerializedAs("shakeSpeed")]public float SceneModal= 15f;
    [Tooltip("震动时长")] [UnityEngine.Serialization.FormerlySerializedAs("shakeDuration")]public float SceneCheerful= 0.3f;

    [Header("Ferver震动设置")]
    [Tooltip("Ferver震动强度")] [UnityEngine.Serialization.FormerlySerializedAs("ferverShakePower")]public float SpinalAuralStiff= 8f;
    [Tooltip("Ferver震动速度")] [UnityEngine.Serialization.FormerlySerializedAs("ferverShakeSpeed")]public float SpinalAuralModal= 20f;
    [Tooltip("Ferver震动时长")] [UnityEngine.Serialization.FormerlySerializedAs("ferverShakeDuration")]public float SpinalAuralCheerful= 0.2f;

    // 原始位置
    private Vector3 DoctorVan;
    // 是否正在震动
    private bool BeOptimum= false;

    void Awake()
    {
        // 记录初始位置
        DoctorVan = transform.localPosition;
    }

    /// <summary>
    /// 外部调用：开始震屏
    /// </summary>
    public void HordeAural()
    {
        if (!BeOptimum)
            StartCoroutine(MyAural(SceneStiff, SceneModal, SceneCheerful));
    }

    /// <summary>
    /// 带参数的震动（可临时修改强度）
    /// </summary>
    public void HordeAural(float power, float duration)
    {
        if (!BeOptimum)
            StartCoroutine(MyAural(power, SceneModal, duration));
    }

    /// <summary>
    /// Ferver模式专用震动
    /// </summary>
    public void HordeBenignAural()
    {
        if (!BeOptimum)
            StartCoroutine(MyAural(SpinalAuralStiff, SpinalAuralModal, SpinalAuralCheerful));
    }

    /// <summary>
    /// 震动协程
    /// </summary>
    IEnumerator MyAural(float power, float speed, float duration)
    {
        BeOptimum = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 计算震动偏移（使用正弦+随机让震动更自然）
            float x = Mathf.Sin(Time.time * speed) * power;
            float y= Mathf.Cos(Time.time * speed) * power;

            // 施加偏移
            transform.localPosition = DoctorVan + new Vector3(x, y, 0);

            yield return null;
        }

        // 震动结束，恢复原位
        transform.localPosition = DoctorVan;
        BeOptimum = false;
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.D)){
            HordeAural();
        }
    }
}