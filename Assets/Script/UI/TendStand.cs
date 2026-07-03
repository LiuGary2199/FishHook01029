using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static MaxSdkBase;

public class TendStand : SeedUIHouse
{
    public static TendStand Instance;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("_GuidePanel")]public TightStand _TightStand;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("GuideIndex")]public int TightSlope;
[UnityEngine.Serialization.FormerlySerializedAs("CashOutBtn")]    public Transform ComaTooTin;
[UnityEngine.Serialization.FormerlySerializedAs("ClickBtn")]    public Transform LeakyTin;
[UnityEngine.Serialization.FormerlySerializedAs("ferverslider")]    public Transform Speechwriter;
[UnityEngine.Serialization.FormerlySerializedAs("AutoBtn")]
    public Transform AeroTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_SettingBtn")]

    public Button m_PrinterTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_DailyBtn")]    public Button m_UnityTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_TaskBtn")]    public Button m_LateTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_CashTrans")]
    public RectTransform m_ComaCrane;

    [Header("钩子系统")]
    [Tooltip("新版系统根节点（含 UITwainNorthBed + HitArea）")]
[UnityEngine.Serialization.FormerlySerializedAs("m_NewSwingRoot")]    public GameObject m_BedNorthRead;
[UnityEngine.Serialization.FormerlySerializedAs("m_UIImageSwingNew")]
    public UITwainNorthBed m_UITwainNorthBed;
[UnityEngine.Serialization.FormerlySerializedAs("m_DiamondImage")]    public Image m_FallacyTwain;
[UnityEngine.Serialization.FormerlySerializedAs("m_GoldImage")]
    public Image m_SeatTwain;
    [Tooltip("鱼金币动画专用图标（可选，空则回退 m_GoldImage；需要拖带 Image 组件的物体，而不是 Sprite 资源）")]
[UnityEngine.Serialization.FormerlySerializedAs("m_FishGoldImage")]    public Image m_SoonSeatTwain;
    [Tooltip("鱼金币飞币的 Sprite 覆盖（可直接拖 Sprite 资源；空则不覆盖）")]
[UnityEngine.Serialization.FormerlySerializedAs("m_FishGoldCoinSprite")]    public Sprite m_SoonSeatSateBehind;
    [Tooltip("鱼钻石飞入动画用的 PigKeep 模板（可选，空则用 m_DiamondImage 所在物体）")]
[UnityEngine.Serialization.FormerlySerializedAs("m_FishDiamondImage")]    public Image m_SoonFallacyTwain;
[UnityEngine.Serialization.FormerlySerializedAs("m_GoldText")]    public TextMeshProUGUI m_SeatBode;
[UnityEngine.Serialization.FormerlySerializedAs("m_HPImage")]
    public Image m_HPTwain;
[UnityEngine.Serialization.FormerlySerializedAs("m_HPText")]    public TextMeshProUGUI m_HPBode;
[UnityEngine.Serialization.FormerlySerializedAs("energyTextTMP")]    public TMP_Text PurelyBodeTMP; // TextMeshPro（二选一）
[UnityEngine.Serialization.FormerlySerializedAs("countdownTextTMP")]    public TMP_Text SequesterBodeTMP; // 倒计时文本（TMP）
[UnityEngine.Serialization.FormerlySerializedAs("shipLevelView")]    public TendUtahMagmaLuck ToolMagmaLuck;
[UnityEngine.Serialization.FormerlySerializedAs("ferverTimeView")]    public TendBenignLineLuck SpinalLineLuck;
[UnityEngine.Serialization.FormerlySerializedAs("fishDeathMoneyBurstFxView")]    public SoonStintExactBrookOnCook SortStintExactBrookOnLuck;
[UnityEngine.Serialization.FormerlySerializedAs("homeRotWheel")]    public TendGetGiant OvalGetGiant;
    [Header("鱼群生成控制")]
[UnityEngine.Serialization.FormerlySerializedAs("m_FishSwimSystem")]    public UISoonRopeSolder m_SoonSwimSolder;
    [Tooltip("进入 TendStand 时是否重置场上鱼并重启开场鱼潮流程")]
[UnityEngine.Serialization.FormerlySerializedAs("m_ResetFishOnHomeDisplay")]    public bool m_PrimeSoonOrTendHarness= true;

    [Header("LittleGame 调度器")]
    [Tooltip("把“定时随机小游戏/Boss鱼”逻辑从 TendStand 抽离出来的组件")]
[UnityEngine.Serialization.FormerlySerializedAs("m_LittleGameScheduler")]    public TendStandSlightRopeColorless m_SlightRopeColorless;
    [Header("Ferver 结算UI")]
[UnityEngine.Serialization.FormerlySerializedAs("FeverMode_GroundMoney")]    public Transform OtherObey_ImposeExact; //疯狂模式 地面堆积的钱
    List<Transform> OtherObey_ImposeExactTall= new List<Transform>(); //疯狂模式 地面堆积的钱
[UnityEngine.Serialization.FormerlySerializedAs("FX_Cash")]
    public GameObject FX_Coma; //金币收集父级
[UnityEngine.Serialization.FormerlySerializedAs("FX_Collect")]    public GameObject FX_Crustal;
    [Tooltip("钻石飞入 HUD 时落地粒子（可选；空则复用 FX_Collect）")]
[UnityEngine.Serialization.FormerlySerializedAs("FX_DiamondCollect")]    public GameObject FX_FallacyCrustal;

    private Action<Transform, int> onUiStingerTieExactMixture;
    private Action<Transform, int> ItSoonPondComaTempleMixture;
    private Action<Transform, int> ItSoonPondFallacyTempleMixture;
    private Action<Transform, Transform> ItGazeSoonGlobeEightyTightMixture;
    private Action ItBenignLineHaltTraderMixture;
    private Action ItUtahDeceiveLiterClusterMixture;
    private int m_BenignFactoryExact;
    private bool m_HeBenignObey;
    private float m_BenignImposeExactHaltCheerful;
[UnityEngine.Serialization.FormerlySerializedAs("m_UIShake")]    public UIAural m_UIAural;
    private bool m_SoonStintOnAccept;
    private Coroutine m_HelpfulGetGiantFlipperFragile;

    // ===== 普通模式：按“本发钩子 shotId”做延迟入账（飞币照常播，入账/滚字在回收点统一处理）=====
    private class PendingShotSettlement
    {
        public int Ling;
        public int Outdoor;
        public double VehicleBridge;
        public bool VehicleBridgeAccept;
        public int CensusSoonPondRelic;
        public bool JeanStride;
    }

    private readonly Dictionary<int, PendingShotSettlement> m_MalletGolfFactory= new Dictionary<int, PendingShotSettlement>();
    private Action<int> ItMalletDebtorGrayGolfDemobilizeMixture;
    private Action<UISoonMandan> ItMalletSoonStintEyeGolfDemobilizeMixture;

    protected override void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(HappenLack.HeDaunt()){
            m_ComaCrane.gameObject.SetActive(false);
        
        }else
        {
#if UNITY_IOS
            AIRopeGiftStrange.LawLaurasia().TangLatin("8emkyx");
            #endif
        }
        m_PrinterTin.onClick.AddListener(() =>
        {
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            TermPrinterStand();
        });
        m_UnityTin.onClick.AddListener(() =>
        {
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            TermUIBard(nameof(PackAnStand));
        });
        m_LateTin.onClick.AddListener(() =>
        {
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            TermUIBard(nameof(LateStand));
        });
        TightSlope = 0;
        onUiStingerTieExactMixture = BerlinItStingerTieExactTemple;
        ItSoonPondComaTempleMixture = BerlinSoonPondComaTemple;
        ItSoonPondFallacyTempleMixture = BerlinSoonPondFallacyTemple;
        LuxuryHop.OrTieExact += onUiStingerTieExactMixture;
        LuxuryHop.OrSoonTieExact += ItSoonPondComaTempleMixture;
        LuxuryHop.OrSoonTieFallacy += ItSoonPondFallacyTempleMixture;
        LuxuryHop.OrSailorAnother += OnEnergyUpdate;
        LuxuryHop.OrRopeTollAnother += OnGameTypeChanged;
        ItMalletDebtorGrayGolfDemobilizeMixture = OnNormalPierceHookShotSettlement;
        LuxuryHop.OrMalletDebtorGrayGolfDemobilize += ItMalletDebtorGrayGolfDemobilizeMixture;
        ItMalletSoonStintEyeGolfDemobilizeMixture = OnNormalFishDeathForShotSettlement;
        LuxuryHop.OrMalletSoonStintEyeGolfDemobilize += ItMalletSoonStintEyeGolfDemobilizeMixture;
        ItBenignLineHaltTraderMixture = OnFerverTimeAnimFinish;
        LuxuryHop.OrBenignLineHaltTrader += ItBenignLineHaltTraderMixture;
        ItUtahDeceiveLiterClusterMixture = OnShipUpgradePopupRequest;
        LuxuryHop.OrUtahDeceiveLiterCluster += ItUtahDeceiveLiterClusterMixture;
        ItGazeSoonGlobeEightyTightMixture = OnBossFishCrossCenterGuideRequest;
        LuxuryHop.OrGazeSoonGlobeEightyTightCluster += ItGazeSoonGlobeEightyTightMixture;
        ToolMagmaLuck?.Earthquake();
        SpinalLineLuck?.Earthquake();
        if (SortStintExactBrookOnLuck == null)
        {
            SortStintExactBrookOnLuck = FindFirstObjectByType<SoonStintExactBrookOnCook>();
        }
        // 爆钱特效改为懒初始化，避免首屏同帧大量 Instantiate。
        m_SoonStintOnAccept = false;
        EarthquakeBenignTempleUI();
        EarthquakeBenignImposeExact();
        bool IsGuideCashOut = AiryMintStrange.GetBool("IsGuideCashOut");
        if (!HappenLack.HeDaunt() && !IsGuideCashOut)
        {
            Tight_1();
        }
        //  AiryMintStrange.SetBool(CTedium.sv_guide_boss_center_done, false);

    }
    private void Tight_1()
    {
        LineStrange.LawLaurasia().Track(1, () =>
        {
            TightSlope = 1;
            _TightStand = TermUIBard(nameof(TightStand)).GetComponent<TightStand>();
            _TightStand.BeatStud(ComaTooTin);
            _TightStand.BeatCole("Help you understand how to withdraw cash", 220);
            _TightStand.BeatRoot(new Vector2[] { ComaTooTin.position });
            AiryMintStrange.SetBool("IsGuideCashOut", true);
        });
    }
    public void Tight_2()
    {
        TightSlope = 2;
        _TightStand.Jolt(true);
        LineStrange.LawLaurasia().Track(.5f, () =>
        {
            //nsform Target = transform.Find("引导区域-点击猪");
            _TightStand.BeatStud(LeakyTin,1,0);
            _TightStand.BeatCole("Click to fire the harpoon", -450);
            _TightStand.BeatRoot(new Vector2[] { LeakyTin.position });
        });
    }

    public void Tight_3()
    {
        TightSlope = 3;
        _TightStand.Jolt(true);
        LineStrange.LawLaurasia().Track(1f, () =>
        {
            _TightStand.BeatStud(LeakyTin,1,0);
            _TightStand.BeatCole("Hold the button, aim and fire", -450);
            _TightStand.BeatRoot(new Vector2[] { LeakyTin.position });
        });
    }
    public void Tight_4()
    {
        TightSlope = 4;
        if(LopColeJar.instance.RopeMint.guide_click_auto>0)
        {
            _TightStand.Jolt(true);
            LineStrange.LawLaurasia().Track(.5f, () =>
            {
                _TightStand.BeatStud(AeroTin);
                _TightStand.BeatCole("Click auto fire", 0);
                _TightStand.BeatRoot(new Vector2[] { AeroTin.position });
            });
        }
        else
        {
            BabyLatinDating.LawLaurasia().TangLatin("1001","2");
            Tight_Drift();
        }
    }
    //boss鱼  引导
    public void Tight_GazeUpEighty(Transform mainBossTf, Transform miaoBossTf)
    {
        if (mainBossTf == null && miaoBossTf == null)
        {
            return;
        }
        _TightStand = TermUIBard(nameof(TightStand)).GetComponent<TightStand>();
        RopeStrange.Instance?.EnsueCylinder();
        TightSlope = 6;
        _TightStand.Jolt(true);
        LineStrange.LawLaurasia().Track(.3f, () =>
        {
            _TightStand.BeatStud(mainBossTf, 1.2f);
            _TightStand.BeatCole("Defeat it for a huge reward.", +550);
            _TightStand.BeatSpinTin(() =>
            {
                if (_TightStand == null) return;
                _TightStand.BeatStud(miaoBossTf, 1.2f);
                _TightStand.BeatCole("Only hits here can defeat the boss.", +550);
                _TightStand.BeatSpinTin(() =>
                    {
                        Tight_Drift();
                        BabyLatinDating.LawLaurasia().TangLatin("1001", "3");
                        RopeStrange.Instance?.NormalCylinder();
                    });
            });
        });
    }

    private void OnFerverTimeAnimFinish()
    {
        if (AiryMintStrange.GetBool(CTedium.Dy_Niche_Spinal_first_Slot))
        {
            return;
        }
        AiryMintStrange.SetBool(CTedium.Dy_Niche_Spinal_first_Slot, true);
        Tight_BenignInner();
    }

    private void Tight_BenignInner()
    {
        _TightStand = TermUIBard(nameof(TightStand)).GetComponent<TightStand>();
         RopeStrange.Instance?.EnsueCylinder();
        _TightStand.Jolt(true);
        LineStrange.LawLaurasia().Track(.5f, () =>
        {
            TightSlope = 8;
            _TightStand.BeatStud(LeakyTin);
            _TightStand.BeatCole("Rewards drop on every click", -450);
            _TightStand.BeatRoot(new Vector2[] { LeakyTin.position });
        });
    }

   public void Tight_DriftOther()
    {
        TightSlope = 0;
        _TightStand.Jolt(false);
        LineStrange.LawLaurasia().Track(.5f, () =>
        {
            BabyLatinDating.LawLaurasia().TangLatin("1001", "4");
            RopeStrange.Instance?.NormalCylinder();
            UIStrange.LawLaurasia().DriftIDCrouchUIHouse(nameof(TightStand));   
        });
    }




    public void Tight_Drift()
    {
        TightSlope = 0;
        _TightStand.Jolt(false);
        LineStrange.LawLaurasia().Track(.5f, () =>
        {
            UIStrange.LawLaurasia().DriftIDCrouchUIHouse(nameof(TightStand));
        });
    }




    //public void Guide_3()
    //{
    //    GuideIndex = 0;
    //    _GuidePanel.Hide(false);
    //    LineStrange.GetInstance().Delay(.5f, () =>
    //    {
    //        UIStrange.GetInstance().CloseOrReturnUIForms(nameof(TightStand));
    //    });
    //}





    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        FlipperSeatBode();
        DOVirtual.DelayedCall(2f, () =>
{
    DriftUIBard(nameof(GarlandMask));
});

        if (m_BedNorthRead != null)
        {
            m_BedNorthRead.SetActive(true);
        }

        if (m_UITwainNorthBed != null)
        {
            m_UITwainNorthBed.Rail();
        }

        if (RopeStrange.Instance != null)
        {
            RopeStrange.Instance.ClusterSailorUIFlipper();
            RopeStrange.Instance.ClusterUtahUIFlipper();
        }

        if (OvalGetGiant != null)
        {
            if (m_HelpfulGetGiantFlipperFragile != null)
            {
                StopCoroutine(m_HelpfulGetGiantFlipperFragile);
                m_HelpfulGetGiantFlipperFragile = null;
            }
            m_HelpfulGetGiantFlipperFragile = StartCoroutine(AxHelpfulGetGiantFlipper(5));
        }

        ToolMagmaLuck?.FlipperDew();
        SpinalLineLuck?.FlipperDew();

        if (RopeStrange.Instance != null)
        {
            RopeStrange.Instance.DueRopeToll(GameType.Normal);
        }

        if (m_SoonSwimSolder == null)
        {
            m_SoonSwimSolder = FindFirstObjectByType<UISoonRopeSolder>();
        }
        if (m_SoonSwimSolder != null)
        {
            m_SoonSwimSolder.HordeShearElectric(m_PrimeSoonOrTendHarness);
            if (m_SlightRopeColorless == null)
            {
                m_SlightRopeColorless = GetComponent<TendStandSlightRopeColorless>();
                if (m_SlightRopeColorless == null)
                {
                    m_SlightRopeColorless = FindFirstObjectByType<TendStandSlightRopeColorless>();
                }
            }
            m_SlightRopeColorless?.OnHomePanelDisplay(m_PrimeSoonOrTendHarness);
        }
    }

    public void FlipperSeatBode()
    {
        if (m_SeatBode == null || RopeMintStrange.LawLaurasia() == null)
        {
            return;
        }

        m_SeatBode.text = SereneLack.BelterAxNss(RopeMintStrange.LawLaurasia().LawComa());
    }

    /// <summary>
    /// 非鱼来源（任务/奖励等）：Instantiate 飞金币图标 +，不使用 cash 对象池。
    /// </summary>
    private void FoodItStingerComaPigSodaGenuBode(Transform startTransform, int cashAmount, double balanceBefore, double balanceAfter)
    {
        GameObject iconObj = m_SeatTwain != null ? m_SeatTwain.gameObject : null;
        FoodComaPigSodaGenuBodeHuge(startTransform, iconObj, m_SeatTwain != null ? m_SeatTwain.transform : null, m_SeatBode, cashAmount, balanceBefore, balanceAfter, useFishKillCashPool: false);
    }

    /// <summary>
    /// 击杀鱼掉金币：<see cref="RopeStrange.CashPoolPrefab"/> + <see cref="PredatoryDependably.FishGoldMove"/>。
    /// </summary>
    private void FoodSoonPondComaPigSodaGenuBode(Transform startTransform, int cashAmount, double balanceBefore, double balanceAfter)
    {
        GameObject iconObj = (m_SoonSeatTwain != null) ? m_SoonSeatTwain.gameObject : (m_SeatTwain != null ? m_SeatTwain.gameObject : null);
        FoodComaPigSodaGenuBodeHuge(startTransform, iconObj, m_SeatTwain != null ? m_SeatTwain.transform : null, m_SeatBode, cashAmount, balanceBefore, balanceAfter, useFishKillCashPool: true);
    }

    /// <summary>金币飞入结束后滚余额；balanceBefore/After 为入账前/后展示值（与存档一致）。</summary>
    private void FoodComaPigSodaGenuBodeHuge(Transform startTransform, GameObject flyIconTemplate, Transform balanceIconTransform, TextMeshProUGUI balanceText, int flyParticleCount, double balanceBefore, double balanceAfter, bool useFishKillCashPool)
    {
        if (balanceText == null || RopeMintStrange.LawLaurasia() == null)
        {
            FlipperSeatBode();
            return;
        }

        Action onFlyComplete = () =>
        {
            balanceText.text = SereneLack.BelterAxNss(balanceBefore);
            PredatoryDependably.UnjustSerene(balanceBefore, balanceAfter, 0.1f, balanceText,
                () => { balanceText.text = SereneLack.BelterAxNss(balanceAfter); });
        };

        if (startTransform == null || flyIconTemplate == null || balanceIconTransform == null)
        {
            onFlyComplete();
            return;
        }

        int n = Mathf.Max(flyParticleCount, 1);
        if (useFishKillCashPool)
        {
            PredatoryDependably.SoonSeatPeat(flyIconTemplate, n, startTransform, balanceIconTransform, onFlyComplete);
        }
        else
        {
            //PredatoryDependably.GoldMoveBest(flyIconTemplate, n, startTransform, balanceIconTransform, onFlyComplete);
            PredatoryDependably.UIComaPeatWeed(flyIconTemplate, n, startTransform, balanceIconTransform, onFlyComplete);
        }
    }

    /// <summary>
    /// 击杀钻石鱼：<see cref="RopeStrange.DiamondPoolPrefab"/> + <see cref="PredatoryDependably.FishDiamondMove"/>，到账与 <see cref="AddDiamond"/> 一致（ZJT）。
    /// </summary>
    private void FoodSoonPondFallacyPigSodaMarry(Transform startTransform, int diamondAmount)
    {
        GameObject iconObj = m_SoonFallacyTwain != null ? m_SoonFallacyTwain.gameObject : (m_FallacyTwain != null ? m_FallacyTwain.gameObject : null);
        Transform endTf = m_FallacyTwain != null ? m_FallacyTwain.transform : null;
        if (startTransform == null || iconObj == null || endTf == null)
        {
            ZJT_Manager.LawLaurasia().AddMoney((float)diamondAmount);
            return;
        }

        int n = Mathf.Max(diamondAmount, 1);
        PredatoryDependably.SoonFallacyPeat(iconObj, n, startTransform, endTf, () =>
        {
            ZJT_Manager.LawLaurasia().AddMoney((float)diamondAmount);
        });
    }

    /// <summary>
    /// 收到体力事件后，更新当前场景的UI
    /// </summary>
    private void OnEnergyUpdate(int currentEnergy, float remainingTime, int maxEnergy)
    {
        string energyStr = currentEnergy.ToString();
        if (PurelyBodeTMP != null) PurelyBodeTMP.text = energyStr;
        int threshold = (RopeStrange.Instance != null) ? RopeStrange.Instance.LongingConsensus : 50;
        bool needShowCountdown = currentEnergy <= threshold && remainingTime > 0f;
        DueRejectionPotash(needShowCountdown);
        if (needShowCountdown)
        {
            // 格式化倒计时（显示整数秒）
            int showSeconds = Mathf.CeilToInt(remainingTime);
            string countdownStr = showSeconds.ToString() + "s";
            if (SequesterBodeTMP != null) SequesterBodeTMP.text = countdownStr;
        }
    }

    /// <summary>
    /// 显示/隐藏倒计时UI
    /// </summary>
    private void DueRejectionPotash(bool active)
    {
        if (SequesterBodeTMP != null) SequesterBodeTMP.gameObject.SetActive(active);
    }

    private void TermPrinterStand()
    {
        TermUIBard(nameof(PrinterStand));
    }

    /// <summary>金币（船经验）增加后首次达到可升级时，自动打开船坞升级面板。</summary>
    private void OnShipUpgradePopupRequest()
    {
        if (RopeStrange.Instance == null || !RopeStrange.Instance.AskUtahDeceiveDew())
        {
            return;
        }
        bool isGamePanelTop = UIStrange.LawLaurasia().HeTendStandAnt();
        if (isGamePanelTop)
        {
            BabyLatinDating.LawLaurasia().TangLatin("1010");
            TermUIBard(nameof(UtahMagmaSoStand));
        }
        else
        {
            DOVirtual.DelayedCall(5f, () =>
            {
                OnShipUpgradePopupRequest();
            });
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
        if (m_HelpfulGetGiantFlipperFragile != null)
        {
            StopCoroutine(m_HelpfulGetGiantFlipperFragile);
            m_HelpfulGetGiantFlipperFragile = null;
        }
        if (onUiStingerTieExactMixture != null)
        {
            LuxuryHop.OrTieExact -= onUiStingerTieExactMixture;
            onUiStingerTieExactMixture = null;
        }
        if (ItSoonPondComaTempleMixture != null)
        {
            LuxuryHop.OrSoonTieExact -= ItSoonPondComaTempleMixture;
            ItSoonPondComaTempleMixture = null;
        }
        if (ItSoonPondFallacyTempleMixture != null)
        {
            LuxuryHop.OrSoonTieFallacy -= ItSoonPondFallacyTempleMixture;
            ItSoonPondFallacyTempleMixture = null;
        }
        LuxuryHop.OrSailorAnother -= OnEnergyUpdate;
        LuxuryHop.OrRopeTollAnother -= OnGameTypeChanged;
        if (ItMalletDebtorGrayGolfDemobilizeMixture != null)
        {
            LuxuryHop.OrMalletDebtorGrayGolfDemobilize -= ItMalletDebtorGrayGolfDemobilizeMixture;
            ItMalletDebtorGrayGolfDemobilizeMixture = null;
        }
        if (ItMalletSoonStintEyeGolfDemobilizeMixture != null)
        {
            LuxuryHop.OrMalletSoonStintEyeGolfDemobilize -= ItMalletSoonStintEyeGolfDemobilizeMixture;
            ItMalletSoonStintEyeGolfDemobilizeMixture = null;
        }
        if (ItBenignLineHaltTraderMixture != null)
        {
            LuxuryHop.OrBenignLineHaltTrader -= ItBenignLineHaltTraderMixture;
            ItBenignLineHaltTraderMixture = null;
        }
        if (ItUtahDeceiveLiterClusterMixture != null)
        {
            LuxuryHop.OrUtahDeceiveLiterCluster -= ItUtahDeceiveLiterClusterMixture;
            ItUtahDeceiveLiterClusterMixture = null;
        }
        if (ItGazeSoonGlobeEightyTightMixture != null)
        {
            LuxuryHop.OrGazeSoonGlobeEightyTightCluster -= ItGazeSoonGlobeEightyTightMixture;
            ItGazeSoonGlobeEightyTightMixture = null;
        }
        ToolMagmaLuck?.Indifference();
        SpinalLineLuck?.Indifference();
        SortStintExactBrookOnLuck?.Indifference();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            UISoonMandan.ClusterShearGazeSoon();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LuxuryHop.OrSoonTieExact?.Invoke(transform, 20);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LuxuryHop.OrTendGetMustByCelebrationCluster?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            OvalGetGiant.GetComponent<TendGetGiant>().FoodJoltHalt();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UIStrange.LawLaurasia().BeatUIHouse(nameof(WaryStand));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            UIStrange.LawLaurasia().BeatUIHouse(nameof(CouldZeroStand));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UIStrange.LawLaurasia().BeatUIHouse(nameof(HisRowStand), 5000);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RewardData Rewards = new RewardData();
            Rewards.rewardNum = 11;
            Rewards.type = RewardType.Diamond;
            UIStrange.LawLaurasia().BeatUIHouse(nameof(TempleStand)).GetComponent<TempleStand>().Rail(null, Rewards,
           () =>
           {
               LuxuryHop.OrSlightRopeLuminous?.Invoke();
           }, "1011");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UIStrange.LawLaurasia().BeatUIHouse(nameof(UtahMagmaSoStand));
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TieFallacy(1000);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            RopeStrange.Instance?.EnsueBenignRejection();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            RopeStrange.Instance?.NormalBenignRejection();
        }
    }

    /// <summary>任务/奖励等界面加金币（非击杀鱼）。疯狂模式仍记入待结算金币。</summary>
    private void BerlinItStingerTieExactTemple(Transform startTransform, int cashAmount)
    {
        if (cashAmount <= 0)
        {
            return;
        }

        RopeMintStrange gdm = RopeMintStrange.LawLaurasia();
        double VehicleBridge= SereneLack.Juicy(gdm.LawComa());
        gdm.addComa(cashAmount, HangStrange.instance.transform, false);
        double balanceAfter = SereneLack.Juicy(gdm.LawComa());
        FoodItStingerComaPigSodaGenuBode(startTransform, cashAmount, VehicleBridge, balanceAfter);
    }

    /// <summary>击杀普通鱼掉金币：爆钱粒子池 + cash 对象池飞币 + 入账。</summary>
    private void BerlinSoonPondComaTemple(Transform startTransform, int cashAmount)
    {
        if (cashAmount <= 0)
        {
            return;
        }

        if (HeAnBenignLine())
        {
            m_BenignFactoryExact += cashAmount;
            return;
        }

        BotanySoonStintOnRestoration();
        m_UIAural.HordeAural();

        // 普通模式：如果能识别到 shotId，则“先播飞币，后入账（回收点统一）”
        int shotId = KeaLawMalletFewGolfWeCallProcedure(startTransform);
        if (shotId > 0)
        {
            FoodSoonPondComaPigClub(startTransform, cashAmount);
            EukaryoticMalletGolfComa(shotId, cashAmount);
            return;
        }

        // 兜底：无法识别 shotId 时保持原逻辑（避免漏账）
        RopeMintStrange gdm = RopeMintStrange.LawLaurasia();
        double VehicleBridge= SereneLack.Juicy(gdm.LawComa());
        gdm.addComa(cashAmount, HangStrange.instance.transform, false);
        double balanceAfter = SereneLack.Juicy(gdm.LawComa());
        FoodSoonPondComaPigSodaGenuBode(startTransform, cashAmount, VehicleBridge, balanceAfter);
    }

    /// <summary>击杀钻石鱼：与金币鱼分流；疯狂模式下也即时发钻（不计入 m_FerverPendingMoney）。</summary>
    private void BerlinSoonPondFallacyTemple(Transform startTransform, int diamondAmount)
    {
        if (diamondAmount <= 0)
        {
            return;
        }

        BotanySoonStintOnRestoration();
        m_UIAural.HordeAural();

        // 普通模式：shotId 可用则延迟发钻到“回收点统一”
        int shotId = KeaLawMalletFewGolfWeCallProcedure(startTransform);
        if (!HeAnBenignLine() && shotId > 0)
        {
            FoodSoonPondFallacyPigClub(startTransform, diamondAmount);
            EukaryoticMalletGolfFallacy(shotId, diamondAmount);
            return;
        }

        FoodSoonPondFallacyPigSodaMarry(startTransform, diamondAmount);
    }

    private int KeaLawMalletFewGolfWeCallProcedure(Transform startTransform)
    {
        if (startTransform == null) return 0;
        UISoonMandan fish = startTransform.GetComponentInParent<UISoonMandan>();
        if (fish == null) return 0;
        return Mathf.Max(0, fish.SinkMalletFewGolfWe);
    }

    private void EukaryoticMalletGolfComa(int shotId, int cashAmount)
    {
        if (shotId <= 0 || cashAmount <= 0) return;
        if (!m_MalletGolfFactory.TryGetValue(shotId, out PendingShotSettlement pending) || pending == null)
        {
            pending = new PendingShotSettlement();
            m_MalletGolfFactory[shotId] = pending;
        }
        if (!pending.VehicleBridgeAccept)
        {
            pending.VehicleBridgeAccept = true;
            pending.VehicleBridge = SereneLack.Juicy(RopeMintStrange.LawLaurasia().LawComa());
        }
        pending.Ling += cashAmount;
    }

    private void EukaryoticMalletGolfFallacy(int shotId, int diamondAmount)
    {
        if (shotId <= 0 || diamondAmount <= 0) return;
        if (!m_MalletGolfFactory.TryGetValue(shotId, out PendingShotSettlement pending) || pending == null)
        {
            pending = new PendingShotSettlement();
            m_MalletGolfFactory[shotId] = pending;
        }
        pending.Outdoor += diamondAmount;
    }

    private void OnNormalPierceHookShotSettlement(int shotId)
    {
        if (HeAnBenignLine()) return;
        if (shotId <= 0) return;
        if (!m_MalletGolfFactory.TryGetValue(shotId, out PendingShotSettlement pending) || pending == null)
        {
            ProudlyMalletGolfTanEfficacyDeco(shotId, true);
            return;
        }
        m_MalletGolfFactory.Remove(shotId);

        int Ling= Mathf.Max(0, pending.Ling);
        int Outdoor= Mathf.Max(0, pending.Outdoor);
        int CensusSoonPondRelic= Mathf.Max(0, pending.CensusSoonPondRelic);
        bool JeanStride= pending.JeanStride;

        // 同一发内击杀 Boss：只保留 Boss->BigWin，抑制本发的其它收益/进度。
        if (JeanStride)
        {
            ProudlyMalletGolfTanEfficacyDeco(shotId, false);
            return;
        }

        if (Ling <= 0 && Outdoor <= 0 && CensusSoonPondRelic <= 0)
        {
            ProudlyMalletGolfTanEfficacyDeco(shotId, true);
            return;
        }

        RopeMintStrange gdm = RopeMintStrange.LawLaurasia();
        int pendingShipBefore = gdm != null ? gdm.LawFactoryMagmaSoRelic() : 0;

        // 升级 > Fever：先入账，再判断是否「首次可升级」；若升级占优则本发丢弃 Fever 击杀进度。
        if (Ling > 0 && gdm != null)
        {
            double VehicleBridge= pending.VehicleBridgeAccept ? pending.VehicleBridge : SereneLack.Juicy(gdm.LawComa());
            gdm.addComa(Ling, HangStrange.instance != null ? HangStrange.instance.transform : transform, false);
            double balanceAfter = SereneLack.Juicy(gdm.LawComa());
            GenuSeatBode(VehicleBridge, balanceAfter);
        }

        int pendingShipAfterCash = gdm != null ? gdm.LawFactoryMagmaSoRelic() : 0;
        bool upgradeWon = pendingShipBefore == 0 && pendingShipAfterCash > 0;

        bool feverWon = false;
        if (!upgradeWon && CensusSoonPondRelic > 0 && RopeStrange.Instance != null)
        {
            bool feverPendingBefore = RopeStrange.Instance.HeBenignPriorEquatorialAircraft;
            for (int i = 0; i < CensusSoonPondRelic; i++)
            {
                RopeStrange.Instance.AbsentSoonStride();
            }
            bool feverPendingAfter = RopeStrange.Instance.HeBenignPriorEquatorialAircraft;
            feverWon = feverPendingAfter && !feverPendingBefore;
        }

        if (Outdoor > 0)
        {
            ZJT_Manager.LawLaurasia().AddMoney((float)Outdoor);
        }

        // Fever > 小游戏：本发若触发进 Fever 过渡，则丢弃小游戏/定时 Boss 预触发。
        bool allowLowPriority = !upgradeWon && !feverWon;
        ProudlyMalletGolfTanEfficacyDeco(shotId, allowLowPriority);
    }

    private void ProudlyMalletGolfTanEfficacyDeco(int shotId, bool allowLowPriority)
    {
        if (shotId <= 0) return;
        LuxuryHop.OrMalletGolfUnifyTanEfficacyLocation?.Invoke(shotId, allowLowPriority);
    }


    private void OnNormalFishDeathForShotSettlement(UISoonMandan fish)
    {
        if (fish == null) return;
        if (HeAnBenignLine()) return;

        int shotId = Mathf.Max(0, fish.SinkMalletFewGolfWe);
        if (shotId <= 0)
        {
            // 兜底：无法拿到 shotId 时，仍按旧路径累计 Ferver，避免漏进度。
            RopeStrange.Instance?.AbsentSoonStride();
            return;
        }

        if (!m_MalletGolfFactory.TryGetValue(shotId, out PendingShotSettlement pending) || pending == null)
        {
            pending = new PendingShotSettlement();
            m_MalletGolfFactory[shotId] = pending;
        }

        if (fish.BeGazeSoon)
        {
            pending.JeanStride = true;
            return;
        }

        pending.CensusSoonPondRelic++;
    }

    private void GenuSeatBode(double balanceBefore, double balanceAfter)
    {
        if (m_SeatBode == null)
        {
            FlipperSeatBode();
            return;
        }

        m_SeatBode.text = SereneLack.BelterAxNss(balanceBefore);
        PredatoryDependably.UnjustSerene(balanceBefore, balanceAfter, 0.1f, m_SeatBode,
            () => { m_SeatBode.text = SereneLack.BelterAxNss(balanceAfter); });
    }

    /// <summary>
    /// 普通模式延迟入账时：只播飞币，不滚字/不改余额（等回收点统一结算）。
    /// </summary>
    private void FoodSoonPondComaPigClub(Transform startTransform, int cashAmount)
    {
        GameObject iconObj = (m_SoonSeatTwain != null) ? m_SoonSeatTwain.gameObject : (m_SeatTwain != null ? m_SeatTwain.gameObject : null);
        Transform endTf = m_SeatTwain != null ? m_SeatTwain.transform : null;
        if (startTransform == null || iconObj == null || endTf == null)
        {
            return;
        }
        int n = Mathf.Max(cashAmount, 1);
        PredatoryDependably.SoonSeatPeat(iconObj, n, startTransform, endTf, null);
    }

    /// <summary>
    /// 普通模式延迟入账时：只播飞钻，不立即发钻（等回收点统一结算）。
    /// </summary>
    private void FoodSoonPondFallacyPigClub(Transform startTransform, int diamondAmount)
    {
        GameObject iconObj = m_SoonFallacyTwain != null ? m_SoonFallacyTwain.gameObject : (m_FallacyTwain != null ? m_FallacyTwain.gameObject : null);
        Transform endTf = m_FallacyTwain != null ? m_FallacyTwain.transform : null;
        if (startTransform == null || iconObj == null || endTf == null)
        {
            return;
        }
        int n = Mathf.Max(diamondAmount, 1);
        PredatoryDependably.SoonFallacyPeat(iconObj, n, startTransform, endTf, null);
    }

    private void BotanySoonStintOnRestoration()
    {
        if (m_SoonStintOnAccept)
        {
            return;
        }

        if (SortStintExactBrookOnLuck == null)
        {
            SortStintExactBrookOnLuck = FindFirstObjectByType<SoonStintExactBrookOnCook>();
        }
        if (SortStintExactBrookOnLuck == null)
        {
            return;
        }

        SortStintExactBrookOnLuck.Earthquake();
        m_SoonStintOnAccept = true;
    }

    private IEnumerator AxHelpfulGetGiantFlipper(int frameCount)
    {
        int safeFrameCount = Mathf.Max(0, frameCount);
        while (safeFrameCount-- > 0)
        {
            yield return null;
        }

        if (OvalGetGiant != null && OvalGetGiant.gameObject.activeInHierarchy)
        {
            OvalGetGiant.TemperaSowHalveHarnessGlide();
        }
        m_HelpfulGetGiantFlipperFragile = null;
    }

    private bool HeAnBenignLine()
    {
        return RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;
    }

    private void OnGameTypeChanged(GameType gameType)
    {
        bool isNowFerver = gameType == GameType.FerverTime;

        if (!m_HeBenignObey && isNowFerver)
        {
            // 首次直接进入 Ferver 时也要初始化爆钱粒子池，避免未订阅击杀粒子事件。
            BotanySoonStintOnRestoration();
            BeatBenignImposeExact();
        }
        else if (m_HeBenignObey && !isNowFerver)
        {
            VariableBenignDemobilize();
            JoltBenignImposeExact();
        }

        m_HeBenignObey = isNowFerver;
    }

    private void OnBossFishCrossCenterGuideRequest(Transform mainBossTf, Transform miaoBossTf)
    {
        Tight_GazeUpEighty(mainBossTf, miaoBossTf);
    }



    private void EarthquakeBenignTempleUI()
    {
        m_HeBenignObey = HeAnBenignLine();

        if (m_HeBenignObey)
        {
            BeatBenignImposeExact();
        }
        else
        {
            JoltBenignImposeExact();
        }
    }

    private void VariableBenignDemobilize()
    {
        int settleMoney = Mathf.Max(0, m_BenignFactoryExact);
        if (settleMoney <= 0)
        {
            PrimeBenignFactoryUI();
            return;
        }

        double oldGold = RopeMintStrange.LawLaurasia().LawComa();
        double targetGold = oldGold + settleMoney;
        RopeMintStrange.LawLaurasia().addComa(settleMoney);
        m_SeatBode.text = SereneLack.BelterAxNss(targetGold);

        UIStrange.LawLaurasia().BeatUIHouse(nameof(HisRowStand), new HisRowStand.OpenArgs
        {
            Scout = settleMoney,
            fromGazeSoonStint = false,
            IfLatinWe = "1009"
        });
        PrimeBenignFactoryUI();
    }

    private void PrimeBenignFactoryUI()
    {
        m_BenignFactoryExact = 0;
    }

    private void EarthquakeBenignImposeExact()
    {
        OtherObey_ImposeExactTall.Clear();
        if (OtherObey_ImposeExact == null)
        {
            return;
        }

        for (int i = 0; i < OtherObey_ImposeExact.childCount; i++)
        {
            Transform child = OtherObey_ImposeExact.GetChild(i);
            OtherObey_ImposeExactTall.Add(child);
        }

        Vector3 pivotPos = transform.position;
        if (m_UITwainNorthBed != null)
        {
            pivotPos = m_UITwainNorthBed.transform.position;
        }

        OtherObey_ImposeExactTall.Sort((a, b) =>
        {
            float da = Vector2.Distance(a.position, pivotPos);
            float db = Vector2.Distance(b.position, pivotPos);
            return db.CompareTo(da);
        });

        FerverTimeConfig cfg = RopeMintStrange.LawLaurasia() != null ? RopeMintStrange.LawLaurasia().m_BenignLineTedium : null;
        m_BenignImposeExactHaltCheerful = cfg == null ? 4f : Mathf.Max(1f, cfg.FerverCountDownTime - 1f);

        JoltBenignImposeExact();
    }

    public void TieFallacy(double num, Transform flyTransform = null)
    {
        PredatoryDependably.UIFallacyPeatWeed(m_FallacyTwain.gameObject, Mathf.Min((int)num, 10), Vector2.zero, m_FallacyTwain.transform.position, () =>
        {
            ZJT_Manager.LawLaurasia().AddMoney((float)num);
        });
    }

    private void BeatBenignImposeExact()
    {
        if (OtherObey_ImposeExact == null)
        {
            return;
        }

        OtherObey_ImposeExact.gameObject.SetActive(true);
        if (OtherObey_ImposeExactTall.Count <= 0)
        {
            return;
        }

        float delayTime = m_BenignImposeExactHaltCheerful / OtherObey_ImposeExactTall.Count;
        for (int i = 0; i < OtherObey_ImposeExactTall.Count; i++)
        {
            Transform item = OtherObey_ImposeExactTall[i];
            if (item == null)
            {
                continue;
            }

            item.DOKill();
            item.localScale = Vector3.zero;
            item.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.3f).SetEase(Ease.OutBack).SetDelay(delayTime * i);
        }
    }

    private void JoltBenignImposeExact()
    {
        if (OtherObey_ImposeExact == null)
        {
            return;
        }

        OtherObey_ImposeExact.gameObject.SetActive(false);
    }
}
