using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;
public class TendBenignLineLuck : MonoBehaviour
{
    [Header("UI")]
    [Tooltip("用于显示进度/倒计时的填充图片（Filled Image）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverProgressImage")]    public Image SpinalCommerceTwain;

    [Header("Animation")]
    [Tooltip("FillAmount 动画速度（每秒变化量）")]
[UnityEngine.Serialization.FormerlySerializedAs("fillAnimSpeed")]    public float TubeHaltModal= 2.5f;

    [Header("Transition")]
    [Tooltip("进入 FerverTime 的过渡动画物体（激活后由 Animator 播放）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverTransitionObject")]    public GameObject SpinalEquatorialRation;
    [Tooltip("过渡动画 Animator（为空时自动从过渡动画物体上获取）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverTransitionAnimator")]    public Animator SpinalEquatorialPriority;
    [Tooltip("进入动画状态名（留空则播放默认状态）")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverTransitionStateName")]    public string SpinalEquatorialIncurCoin= "ANI_Transition";
    [Tooltip("动画结束后是否自动隐藏过渡动画物体")]
[UnityEngine.Serialization.FormerlySerializedAs("hideTransitionObjectOnFinish")]    public bool WoodEquatorialRationOrTrader= true;
    [Tooltip("粒子1：与过渡动画同时打开/关闭")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverTransitionParticle1")]    public GameObject SpinalEquatorialAddition1;
    [Tooltip("粒子2：过渡动画结束后打开，FerverTime 结束后关闭")]
[UnityEngine.Serialization.FormerlySerializedAs("ferverFerverActiveParticle2")]    public GameObject SpinalBenignPotashAddition2;
[UnityEngine.Serialization.FormerlySerializedAs("m_LangSkeleton")]    public SkeletonGraphic m_ShedPossible;
    private bool m_Restoration;
    private bool m_HeBenignObey;
    private int m_BalanceCommerce;
    private int m_WoadCommerce;
    private float m_SixteenthConfine;
    private float m_PulseConfine;
    private float m_ExpertDamp;
    private bool m_HePriorEquatorialDevelop;

    public void Earthquake()
    {
        if (m_Restoration) return;
        if(HappenLack.HeDaunt()){
            return;
        }
        if (SpinalCommerceTwain == null)
        {
            SpinalCommerceTwain = GetComponent<Image>();
        }

        LuxuryHop.OrBenignCommerceAnother += OnFerverProgressChanged;
        LuxuryHop.OrBenignRelicLoveAnother += OnFerverCountDownChanged;
        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
        LuxuryHop.OrBenignPriorEquatorialCluster += OnFerverEnterTransitionRequest;
        LuxuryHop.OrBenignLineHaltTrader += OnFerverTimeAnimFinish;
        m_Restoration = true;

        FlipperDew();
    }

    public void FlipperDew()
    {
         if(HappenLack.HeDaunt()){
            return;
        }
        m_HeBenignObey = RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
        ImplicationExpertDamp();
        if (SpinalCommerceTwain != null)
        {
            SpinalCommerceTwain.fillAmount = Mathf.Clamp01(m_ExpertDamp);
        }
        RopeStrange.Instance?.ClusterBenignUIFlipper();
    }

    public void Indifference()
    {
        if (!m_Restoration) return;
        LuxuryHop.OrBenignCommerceAnother -= OnFerverProgressChanged;
        LuxuryHop.OrBenignRelicLoveAnother -= OnFerverCountDownChanged;
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        LuxuryHop.OrBenignPriorEquatorialCluster -= OnFerverEnterTransitionRequest;
        LuxuryHop.OrBenignLineHaltTrader -= OnFerverTimeAnimFinish;
        PlumPriorEquatorial();
        m_Restoration = false;
    }

    private void Update()
    {
        if (!m_Restoration || SpinalCommerceTwain == null) return;
        if (m_HePriorEquatorialDevelop) return;
        float current = SpinalCommerceTwain.fillAmount;
        float Litter= Mathf.Clamp01(m_ExpertDamp);
        SpinalCommerceTwain.fillAmount = Mathf.MoveTowards(current, Litter, Mathf.Max(0f, TubeHaltModal) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Indifference();
    }

    private void OnFerverProgressChanged(int current, int need)
    {
        if(HappenLack.HeDaunt()){
            return;
        }
        m_BalanceCommerce = Mathf.Max(0, current);
        m_WoadCommerce = Mathf.Max(0, need);
        if (!m_HeBenignObey)
        {
            ImplicationExpertDamp();
        }
    }

    private void OnFerverCountDownChanged(float remaining, float total)
    {
        m_SixteenthConfine = Mathf.Max(0f, remaining);
        m_PulseConfine = Mathf.Max(0f, total);
        if (m_HeBenignObey)
        {
            ImplicationExpertDamp();
        }
    }

    private void OnGameTypeChanged(GameType gameType)
    {
        m_HeBenignObey = gameType == GameType.FerverTime;
        if (m_HeBenignObey)
        {
            PlumPriorEquatorial();
            LateMental.TieLateCommerce(LateMental.LateWe_2, 1);
            AiryMintStrange.SetInt(CTedium.Dy_Fleet_Freshwater, AiryMintStrange.GetInt(CTedium.Dy_Fleet_Freshwater) + 1);
            BabyLatinDating.LawLaurasia().TangLatin("1008");
        }
        else
        {
            DueAddition2Potash(false);
        }
        ImplicationExpertDamp();
    }

    private void OnFerverEnterTransitionRequest()
    {
        if (!m_Restoration) return;
        FoodPriorBenignEquatorial();
    }

    private void OnFerverTimeAnimFinish()
    {
        if (!m_HePriorEquatorialDevelop) return;
   
    VariablePriorEquatorial();



    }

    private void ImplicationExpertDamp()
    {
        if (m_HeBenignObey)
        {
            m_ExpertDamp = m_PulseConfine > 0f ? m_SixteenthConfine / m_PulseConfine : 0f;
        }
        else
        {
            m_ExpertDamp = m_WoadCommerce > 0 ? m_BalanceCommerce / (float)m_WoadCommerce : 0f;
        }
    }

    private void FoodPriorBenignEquatorial()
    {
        PlumPriorEquatorial();
        m_HePriorEquatorialDevelop = true;
        m_ShedPossible.Skeleton.SetToSetupPose();
        m_ShedPossible.AnimationState.ClearTracks();
        m_ShedPossible.AnimationState.SetAnimation(0, "animation", true);
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.transModle);
        SpinalEquatorialRation.SetActive(true);
        DueAddition1Potash(true);
        DueAddition2Potash(false);
        if (SpinalEquatorialPriority == null)
        {
            SpinalEquatorialPriority = SpinalEquatorialRation.GetComponent<Animator>();
        }

        SpinalEquatorialPriority.enabled = true;
        SpinalEquatorialPriority.Rebind();
        SpinalEquatorialPriority.Update(0f);
        if (string.IsNullOrEmpty(SpinalEquatorialIncurCoin))
        {
            SpinalEquatorialPriority.Play(0, 0, 0f);
        }
        else
        {
            SpinalEquatorialPriority.Play(SpinalEquatorialIncurCoin, 0, 0f);
        }
        DOVirtual.DelayedCall(0.3f, () =>
        {
            DueAddition2Potash(true);
        });

    }

    private void VariablePriorEquatorial()
    {
        m_HePriorEquatorialDevelop = false;
        if (WoodEquatorialRationOrTrader && SpinalEquatorialRation != null)
        {
            RopeStrange.Instance?.KinsmanPriorBenignLine();
            DOVirtual.DelayedCall(2f, () =>
            {
                SpinalEquatorialRation.SetActive(false);
            });
            DueAddition1Potash(false);
            // SetParticle2Active(true);
        }
    }

    private void PlumPriorEquatorial()
    {
        m_HePriorEquatorialDevelop = false;
        if (WoodEquatorialRationOrTrader && SpinalEquatorialRation != null)
        {
            DOVirtual.DelayedCall(2f, () =>
            {
                SpinalEquatorialRation.SetActive(false);
            });

        }
        DueAddition1Potash(false);
    }

    private void DueAddition1Potash(bool active)
    {
        if (SpinalEquatorialAddition1 != null)
        {
            SpinalEquatorialAddition1.SetActive(active);
        }
    }

    private void DueAddition2Potash(bool active)
    {
        if (SpinalBenignPotashAddition2 != null)
        {
            SpinalBenignPotashAddition2.SetActive(active);
        }
    }
}
