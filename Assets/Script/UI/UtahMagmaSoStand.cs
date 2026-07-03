using Spine;
using Spine.Unity;
using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UtahMagmaSoStand : SeedUIHouse
{
    private const string SoonRadialHeedDevotion= "Prefab/Items/Fish/{0}/{2}_{0}_{1}";
    private const string SoonTollBenign= "y";
    private const string SoonTollGaze= "z";

    [Header("按钮")]
[UnityEngine.Serialization.FormerlySerializedAs("m_CleamBtn")]    public Button m_GripeTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_ADCleamBtn")]    public Button m_ADGripeTin;
[UnityEngine.Serialization.FormerlySerializedAs("pageOneButton")]    public Button SameBuyCourse;

    [Header("奖励")]
[UnityEngine.Serialization.FormerlySerializedAs("m_SlotGroup")]    public WaryKenya m_WaryKenya;
    [Tooltip("大奖金额文本（可选）")]
[UnityEngine.Serialization.FormerlySerializedAs("m_RewardText")]    public TextMeshProUGUI m_TempleBode;

    [Header("动画")]
[UnityEngine.Serialization.FormerlySerializedAs("m_ShipSkeleton")]    public SkeletonGraphic m_UtahPossible;

    [Header("页面")]
[UnityEngine.Serialization.FormerlySerializedAs("grtMoreRect")]    public RectTransform AntTrimFear;
[UnityEngine.Serialization.FormerlySerializedAs("ADText")]    public GameObject ADBode;
[UnityEngine.Serialization.FormerlySerializedAs("fishRoot")]    public Transform SortRead;
[UnityEngine.Serialization.FormerlySerializedAs("pageOne")]    public GameObject SameBuy;
[UnityEngine.Serialization.FormerlySerializedAs("pageTwo")]    public GameObject SameRay;
    [Tooltip("升级面板最多显示多少个“下一等级解锁鱼”预览。<=0 表示不限制。")]
[UnityEngine.Serialization.FormerlySerializedAs("maxPreviewFishCount")]    public int ViaDictateSoonRelic= 6;

    private readonly List<GameObject> m_DictateSoonPredation= new List<GameObject>();
    private bool m_BitterMethodical;
    private readonly string m_AdLatinWe= "1007";
    private double m_SeedTemple;
    private double m_BalanceTemple;
    private Tween m_WormBuyTrunkLeast;
    private string m_SolidAD= "0";
[UnityEngine.Serialization.FormerlySerializedAs("cashImage")]    
    public GameObject LingTwain;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondImage")]    public GameObject FallacyTwain;

    public void Start()
    {
        if (m_UtahPossible != null)
        {
            m_UtahPossible.AnimationState.Complete += OnShipAnimComplete;
        }

        if (SameBuyCourse != null)
        {
            SameBuyCourse.onClick.AddListener(OnPageOneButtonClicked);
        }

        if (m_GripeTin != null)
        {
            m_GripeTin.onClick.AddListener(OnClaimClicked);
        }

        if (m_ADGripeTin != null)
        {
            m_ADGripeTin.onClick.AddListener(OnAdClaimClicked);
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        if(HappenLack.HeDaunt()){
            LingTwain.SetActive(true);
            FallacyTwain.SetActive(false);
        }else{
            LingTwain.SetActive(false);
            FallacyTwain.SetActive(true);
        }
        SameBuyCourse.enabled = false;
        m_SeedTemple = LopColeJar.instance.RopeMint.LevelUprewards;
        m_BalanceTemple = m_SeedTemple;
        m_WaryKenya?.IronRadio();

        if (BeBedSave())
        {
            ADBode.SetActive(false);
            AntTrimFear.anchoredPosition = new Vector2(0, 6);
            m_GripeTin.gameObject.SetActive(false);
        }
        else
        {
            ADBode.SetActive(true);
            AntTrimFear.anchoredPosition = new Vector2(41.1f, 6);
            m_GripeTin.gameObject.SetActive(true);
        }

        RopeStrange.Instance?.EnsueBenignRejection();
        BrightlyBitterNoChance();
        AthensWormIncurOrHarness();
        FlipperLuck();
        DueDeceaseSubsequently(true);
        FoodUtahHordeHalt();
        FoodWormBuyTrunkAnHalt();
        FlipperTempleBode();
        DOVirtual.DelayedCall(1f, () =>
        {
            SameBuyCourse.enabled = true;
        });
    }

    private void OnDestroy()
    {
        PondWormBuyTrunkLeast();
        FoundationBitter();
        StudySoonDictatePredation();
    }

    private void OnClaimClicked()
    {
        m_SolidAD = "0";
        EruptSowDrift();
        ADStrange.Laurasia.NoPropelTieRelic();
    }

    private void OnAdClaimClicked()
    {
        DueDeceaseSubsequently(false);
        if (BeBedSave())
        {
            FoodWarySowAeroClaim();
        }
        else
        {
            ADStrange.Laurasia.DungTempleVigor((ok) =>
            {
                if (!ok)
                {

                    DueDeceaseSubsequently(true);
                    return;
                }
                m_SolidAD = "1";
                FoodWarySowAeroClaim();
            }, "3");
        }
    }

    private void OnPageOneButtonClicked()
    {
        if (SameBuy != null)
        {
            SameBuy.SetActive(false);
        }

        if (SameRay != null)
        {
            SameRay.SetActive(true);
        }
    }

    public void OnShipAnimComplete(TrackEntry trackEntry)
    {
        if (trackEntry == null || trackEntry.Animation == null)
        {
            return;
        }

        if (trackEntry.Animation.Name != "start" || m_UtahPossible == null)
        {
            return;
        }

        m_UtahPossible.gameObject.SetActive(true);
        m_UtahPossible.Skeleton.SetToSetupPose();
        m_UtahPossible.AnimationState.ClearTracks();
        m_UtahPossible.AnimationState.SetAnimation(0, "idle", true);
    }

    private void BrightlyBitterNoChance()
    {
        if (m_BitterMethodical)
        {
            return;
        }

        LuxuryHop.OrUtahLayAnother += OnShipDataChanged;
        LuxuryHop.OrUtahMagmaAnother += OnShipLevelChanged;
        LuxuryHop.OrUtahDeceiveIncurAnother += OnShipUpgradeStateChanged;
        m_BitterMethodical = true;
    }

    private void FoundationBitter()
    {
        if (!m_BitterMethodical)
        {
            return;
        }

        LuxuryHop.OrUtahLayAnother -= OnShipDataChanged;
        LuxuryHop.OrUtahMagmaAnother -= OnShipLevelChanged;
        LuxuryHop.OrUtahDeceiveIncurAnother -= OnShipUpgradeStateChanged;
        m_BitterMethodical = false;
    }

    private void OnShipDataChanged(int level, int exp, int needExp)
    {
        FlipperLuck();
    }

    private void OnShipLevelChanged(int oldLevel, int newLevel, int levelUpCount)
    {
        FlipperLuck();
    }

    private void OnShipUpgradeStateChanged(bool canUpgrade, int pendingLevelUpCount)
    {
        FlipperLuck();
    }

    private void FlipperLuck()
    {
        if (RopeStrange.Instance == null)
        {
            return;
        }

        int Spiky= RopeStrange.Instance.LawUtahMagma();
        int nextLevel = Spiky + 1;
        bool hasPreviewFish = LayDictateSoonEyeMagma(nextLevel);
        DueWormIncur(hasPreviewFish);
        FlipperSpinMagmaSoonDictate(nextLevel);
    }

    private void AthensWormIncurOrHarness()
    {
        if (RopeStrange.Instance == null)
        {
            DueWormIncur(false);
            return;
        }

        int Spiky= RopeStrange.Instance.LawUtahMagma();
        bool hasPreviewFish = LayDictateSoonEyeMagma(Spiky + 1);
        DueWormIncur(hasPreviewFish);
    }
    private bool BeBedSave()
    {
        return !PlayerPrefs.HasKey(CTedium.Dy_InnerMagmaUPWary + "Bool") || AiryMintStrange.GetBool(CTedium.Dy_InnerMagmaUPWary);
    }
    private void DueWormIncur(bool showUnlockPreviewPage)
    {
        if (SameBuy != null)
        {
            SameBuy.SetActive(showUnlockPreviewPage);
        }

        if (SameRay != null)
        {
            SameRay.SetActive(!showUnlockPreviewPage);
        }
    }

    private void FlipperSpinMagmaSoonDictate(int nextLevel)
    {
        StudySoonDictatePredation();

        if (SortRead == null)
        {
            return;
        }

        RopeMintStrange dataManager = RopeMintStrange.LawLaurasia();
        if (dataManager == null || dataManager.SoonGallium == null || dataManager.SoonGallium.Count == 0)
        {
            return;
        }

        List<FishConfigData> unlockedFishes = new List<FishConfigData>();
        for (int i = 0; i < dataManager.SoonGallium.Count; i++)
        {
            FishConfigData cfg = dataManager.SoonGallium[i];
            if (cfg == null) continue;
            if (Mathf.Max(1, cfg.unlockLevel) != nextLevel) continue;
            if (string.IsNullOrWhiteSpace(cfg.type) || string.IsNullOrWhiteSpace(cfg.id)) continue;
            if (FlavinDebtDictateSoonToll(cfg.type)) continue;
            unlockedFishes.Add(cfg);
        }

        unlockedFishes.Sort((a, b) =>
        {
            if (a == null && b == null) return 0;
            if (a == null) return 1;
            if (b == null) return -1;

            int orderCompare = a.sortOrder.CompareTo(b.sortOrder);
            if (orderCompare != 0) return orderCompare;

            int typeCompare = string.Compare(a.type, b.type, System.StringComparison.OrdinalIgnoreCase);
            if (typeCompare != 0) return typeCompare;

            return string.Compare(a.id, b.id, System.StringComparison.OrdinalIgnoreCase);
        });

        int shownCount = 0;
        for (int i = 0; i < unlockedFishes.Count; i++)
        {
            FishConfigData cfg = unlockedFishes[i];
            GameObject Pigeon= GrabSoonDictateRadial(cfg.type, cfg.id);
            if (Pigeon == null) continue;

            GameObject instance = Instantiate(Pigeon, SortRead, false);
            UISoonMandan uIFishEntity = instance.GetComponent<UISoonMandan>();
            if (uIFishEntity != null)
            {
                uIFishEntity.WaxBeGrayFew = false;
            }
            instance.name = "PreviewFish_" + cfg.type + "_" + cfg.id;
            m_DictateSoonPredation.Add(instance);
            shownCount++;

            if (ViaDictateSoonRelic > 0 && shownCount >= ViaDictateSoonRelic)
            {
                break;
            }
        }
    }

    private static bool LayDictateSoonEyeMagma(int level)
    {
        RopeMintStrange dataManager = RopeMintStrange.LawLaurasia();
        if (dataManager == null || dataManager.SoonGallium == null || dataManager.SoonGallium.Count == 0)
        {
            return false;
        }

        int targetLevel = Mathf.Max(1, level);
        for (int i = 0; i < dataManager.SoonGallium.Count; i++)
        {
            FishConfigData cfg = dataManager.SoonGallium[i];
            if (cfg == null) continue;
            if (Mathf.Max(1, cfg.unlockLevel) != targetLevel) continue;
            if (string.IsNullOrWhiteSpace(cfg.type) || string.IsNullOrWhiteSpace(cfg.id)) continue;
            if (FlavinDebtDictateSoonToll(cfg.type)) continue;
            return true;
        }

        return false;
    }

    private static bool FlavinDebtDictateSoonToll(string fishType)
    {
        string safeType = fishType == null ? string.Empty : fishType.Trim();
        if (string.IsNullOrEmpty(safeType))
        {
            return true;
        }

        return string.Equals(safeType, SoonTollBenign, System.StringComparison.OrdinalIgnoreCase)
               || string.Equals(safeType, SoonTollGaze, System.StringComparison.OrdinalIgnoreCase);
    }

    private static GameObject GrabSoonDictateRadial(string fishType, string fishId)
    {
        string safeType = fishType == null ? string.Empty : fishType.Trim();
        string safeId = fishId == null ? string.Empty : fishId.Trim();
        if (string.IsNullOrEmpty(safeType) || string.IsNullOrEmpty(safeId))
        {
            return null;
        }

        string path = string.Format(SoonRadialHeedDevotion, safeType, safeId, CTedium.SoonRadialCoinRunway);
        return Resources.Load<GameObject>(path);
    }

    private void StudySoonDictatePredation()
    {
        for (int i = 0; i < m_DictateSoonPredation.Count; i++)
        {
            if (m_DictateSoonPredation[i] != null)
            {
                Destroy(m_DictateSoonPredation[i]);
            }
        }

        m_DictateSoonPredation.Clear();
    }

    private void DueDeceaseSubsequently(bool interactable)
    {
        if (m_GripeTin != null)
        {
            m_GripeTin.interactable = interactable;
        }

        if (m_ADGripeTin != null)
        {
            m_ADGripeTin.interactable = interactable;
        }
    }

    private void FoodWarySowAeroClaim()
    {
        if (m_WaryKenya == null
            || LopColeJar.instance == null
            || LopColeJar.instance.RailMint == null
            || LopColeJar.instance.RailMint.slot_group == null
            || LopColeJar.instance.RailMint.slot_group.Count <= 0)
        {
            EruptSowDrift();
            return;
        }

        int index = LawWaryRadioSlope();
        m_WaryKenya.Beau(index, (multi) =>
        {
            m_BalanceTemple = m_SeedTemple * System.Math.Max(1d, multi);
            // RefreshRewardText();
            PredatoryDependably.UnjustSerene(m_SeedTemple, m_BalanceTemple, 0.1f, m_TempleBode, () =>
            {
                LineStrange.LawLaurasia().Track(0.5f, () =>
                {
                    EruptSowDrift();
                });
            });

        });
        AiryMintStrange.SetBool(CTedium.Dy_InnerMagmaUPWary, false);
    }

    private int LawWaryRadioSlope()
    {
        List<SlotItem> list = LopColeJar.instance.RailMint.slot_group;
        int sumWeight = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sumWeight += Mathf.Max(0, list[i].weight);
        }

        if (sumWeight <= 0)
        {
            return 0;
        }

        int randomValue = Random.Range(0, sumWeight);
        int nowWeight = 0;
        for (int i = 0; i < list.Count; i++)
        {
            nowWeight += Mathf.Max(0, list[i].weight);
            if (nowWeight > randomValue)
            {
                return i;
            }
        }

        return 0;
    }

    private void FlipperTempleBode()
    {
        if (m_TempleBode != null)
        {
            m_TempleBode.text = SereneLack.BelterAxNss(m_BalanceTemple);
        }
    }

    private void EruptSowDrift()
    {
        if (RopeStrange.Instance != null)
        {
            RopeStrange.Instance.KeaUtahMagmaSoMoss();
        }
        DOVirtual.DelayedCall(0.7f, () =>
        {
            TendStand.Instance.TieFallacy(m_BalanceTemple);
            bool IsRateUs = PlayerPrefs.GetInt("RateUs") == 1;
            if (!HappenLack.HeDaunt() && !IsRateUs)
            {
                TermUIBard(nameof(DuneUsStand));
                PlayerPrefs.SetInt("RateUs", 1);
                BabyLatinDating.LawLaurasia().TangLatin("1003");
            }
        });

        if (m_UtahPossible != null)
        {
            m_UtahPossible.gameObject.SetActive(false);
        }
        BabyLatinDating.LawLaurasia().TangLatin("1011", m_SolidAD);
        RopeStrange.Instance?.NormalBenignRejection();
        DriftUIBard(GetType().Name);
    }

    private void FoodUtahHordeHalt()
    {
        if (m_UtahPossible == null)
        {
            return;
        }

        m_UtahPossible.gameObject.SetActive(true);
        m_UtahPossible.Skeleton.SetToSetupPose();
        m_UtahPossible.AnimationState.ClearTracks();
        m_UtahPossible.AnimationState.SetAnimation(0, "start", false);
    }

    private void FoodWormBuyTrunkAnHalt()
    {
        if (SameBuy == null)
        {
            return;
        }

        RectTransform pageOneRect = SameBuy.transform as RectTransform;
        if (pageOneRect == null)
        {
            return;
        }

        PondWormBuyTrunkLeast();
        pageOneRect.localScale = Vector3.zero;
        m_WormBuyTrunkLeast = pageOneRect.DOScale(Vector3.one, 0.3f)
            .SetDelay(1.5f)
            .SetEase(Ease.OutBack)
            .SetUpdate(true);
    }

    private void PondWormBuyTrunkLeast()
    {
        if (m_WormBuyTrunkLeast == null)
        {
            return;
        }

        if (m_WormBuyTrunkLeast.IsActive())
        {
            m_WormBuyTrunkLeast.Kill();
        }

        m_WormBuyTrunkLeast = null;
    }

}
