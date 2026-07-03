using System.Collections;
using UnityEngine;
using Spine.Unity;

public class GazeSoonFear : MonoBehaviour
{
    [Header("引用")]
[UnityEngine.Serialization.FormerlySerializedAs("arrowRect")]    public RectTransform SheerFear;
[UnityEngine.Serialization.FormerlySerializedAs("arrowTipRect")]    public RectTransform SheerAlaFear;
[UnityEngine.Serialization.FormerlySerializedAs("rootRect")]    public RectTransform ChewFear;
[UnityEngine.Serialization.FormerlySerializedAs("swimSystem")]    public UISoonRopeSolder DietSolder;
[UnityEngine.Serialization.FormerlySerializedAs("warnSpine")]    public SkeletonGraphic StunStrip;
[UnityEngine.Serialization.FormerlySerializedAs("warnSpine2")]    public SkeletonGraphic StunStrip2;
[UnityEngine.Serialization.FormerlySerializedAs("particleRoot")]    public GameObject DecreaseRead;


    [Header("Spine 设置")]
    [Tooltip("预告动画名（播放一次）")]
[UnityEngine.Serialization.FormerlySerializedAs("warnAnimName")]    public string StunHaltCoin= "warn";
    [Tooltip("找不到动画时，是否回退到第一条动画")]
[UnityEngine.Serialization.FormerlySerializedAs("fallbackToFirstAnim")]    public bool PersuadeAxInnerHalt= true;

    [Header("边缘偏移")]
[UnityEngine.Serialization.FormerlySerializedAs("edgeInsetX")]    public float LiveInsetX= 40f;
    [Tooltip("两个警告 Spine 关闭后，箭头额外停留时长（秒）")]
[UnityEngine.Serialization.FormerlySerializedAs("arrowCloseDelayAfterSpine")]    public float SheerDriftTrackIssueStrip= 0.5f;

    private Coroutine m_FearFragile;

    private void OnEnable()
    {
        LuxuryHop.OrGazeShearBacteria -= OnBossSpawnPrepared;
        LuxuryHop.OrGazeShearBacteria += OnBossSpawnPrepared;
    }

    private void OnDisable()
    {
        LuxuryHop.OrGazeShearBacteria -= OnBossSpawnPrepared;
        if (m_FearFragile != null)
        {
            StopCoroutine(m_FearFragile);
            m_FearFragile = null;
        }
        if (SheerFear != null)
        {
            SheerFear.gameObject.SetActive(false);
        }
        if (StunStrip != null)
        {
            StunStrip.gameObject.SetActive(false);
            StunStrip2.gameObject.SetActive(false);
        }
        DecreaseRead.SetActive(false);
    }

    private void OnBossSpawnPrepared(int dir, float spawnX, float spawnY, float warnSpineDuration, float warnPostDelay)
    {
        if (DietSolder == null)
        {
            DietSolder = FindFirstObjectByType<UISoonRopeSolder>();
        }
        if (ChewFear == null)
        {
            ChewFear = transform as RectTransform;
        }

        FoodFearStrip();
        BeatLayer(dir, spawnX, spawnY);
        if (m_FearFragile != null)
        {
            StopCoroutine(m_FearFragile);
        }
        m_FearFragile = StartCoroutine(AxJoltLayerIssueTrack(Mathf.Max(0f, warnSpineDuration), Mathf.Max(0f, SheerDriftTrackIssueStrip)));
    }

    private IEnumerator AxJoltLayerIssueTrack(float spineDelay, float arrowDelay)
    {
        if (spineDelay > 0f)
        {
            yield return new WaitForSeconds(spineDelay);
        }
        if (StunStrip != null)
        {
            StunStrip.gameObject.SetActive(false);
            StunStrip2.gameObject.SetActive(false);
             DecreaseRead.SetActive(false);
        }
        if (arrowDelay > 0f)
        {
            yield return new WaitForSeconds(arrowDelay);
        }
        if (SheerFear != null)
        {
            SheerFear.gameObject.SetActive(false);
        }
        LuxuryHop.OrGazeFearLuminous?.Invoke();
        m_FearFragile = null;
    }

    private void BeatLayer(int dir, float spawnX, float spawnY)
    {
        if (SheerFear == null || ChewFear == null || DietSolder == null || DietSolder.DietFore == null)
        {
            return;
        }

        Rect area = DietSolder.DietFore.rect;
        float y= Mathf.Clamp(spawnY, area.yMin, area.yMax);
        float x = dir > 0 ? (area.xMin + LiveInsetX) : (area.xMax - LiveInsetX);
        SheerFear.anchoredPosition = new Vector2(x, y);
        Vector3 Spear= SheerFear.localScale;
        Spear.x = Mathf.Abs(Spear.x);
        SheerFear.localScale = Spear;
        if (SheerAlaFear != null)
        {
            Vector3 tipEuler = SheerAlaFear.localEulerAngles;
            tipEuler.z = dir > 0 ? -90f : 90f;
            SheerAlaFear.localEulerAngles = tipEuler;
        }
        SheerFear.gameObject.SetActive(true);
    }

    private void FoodFearStrip()
    {
        if (StunStrip == null)
        {
            return;
        }
 DecreaseRead.SetActive(true);
        StunStrip.gameObject.SetActive(true);
        StunStrip2.gameObject.SetActive(true);
        if (StunStrip.AnimationState == null || StunStrip.Skeleton == null)
        {
            return;
        }

        string anim = StunHaltCoin;
        if (string.IsNullOrEmpty(anim) && PersuadeAxInnerHalt)
        {
            if (StunStrip.Skeleton.Data != null && StunStrip.Skeleton.Data.Animations != null && StunStrip.Skeleton.Data.Animations.Count > 0)
            {
                anim = StunStrip.Skeleton.Data.Animations.Items[0].Name;
            }
        }
        if (string.IsNullOrEmpty(anim))
        {
            return;
        }

        StunStrip.AnimationState.SetAnimation(0, anim, false);
    }
}
