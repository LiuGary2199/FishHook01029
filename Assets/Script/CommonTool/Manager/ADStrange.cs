using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.adjust.sdk;
using LitJson;

public class ADStrange : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool BeFill= false;
    public static ADStrange Laurasia{ get; private set; }

    private int HumanBurgeon;   // 广告加载失败后，重新加载广告次数
    private bool BePlayfulSo;     // 是否正在播放广告，用于判断切换前后台时是否增加计数
    public bool HePlayfulPot=> BePlayfulSo;

    public int SoloFoodLineFestive{ get; private set; }   // 距离上次广告的时间间隔
    public int Utensil101{ get; private set; }     // 定时插屏(101)计数器
    public int Utensil102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Utensil103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string RemainAnemoneCoin;
    private Action<bool> RemainHideVentEmpire;    // 激励视频回调
    private bool RemainPresage;     // 激励视频是否成功收到奖励
    private string RemainSlope;     // 激励视频的打点

    private string PrerequisiteAnemoneCoin;
    private int PrerequisiteToll;      // 当前播放的插屏类型，101/102/103
    private string PrerequisiteSlope;     // 插屏广告的的打点
    public bool SlushLineOccupational{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> IfDevelopPerformer;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long PenetrationEnsueBoulevard;     // 切后台时的时间戳
    private Ad_CustomData TempleSoModernMint; //激励视频自定义数据
    private Ad_CustomData OccupationalSoModernMint; //插屏自定义数据

    private void Awake()
    {
        Laurasia = this;
    }

    private void OnEnable()
    {
        SlushLineOccupational = false;
        BePlayfulSo = false;
        SoloFoodLineFestive = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        RemainPresage = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
//#if UNITY_ANDROID
        MaxSdk.SetSdkKey(LawSolderMint.WeekendDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = AiryMintStrange.GetString(CTedium.Dy_SqueakRely);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            AiryMintStrange.SetString(CTedium.Dy_SqueakRely, adjustId);
        }
        else
        {
            StartCoroutine(PegSqueakRely());
        }
/*
#else
        MaxSdk.SetSdkKey(LawSolderMint.DecryptDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(AiryMintStrange.GetString(CTedium.sv_LocalUserId));
        MaxSdk.InitializeSdk();
#endif
*/

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            EarthquakeAmericanPot();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(RejectPollen), 1, 1);
        };
    }

    IEnumerator PegSqueakRely()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (HappenLack.HeTurkic())
            {
                MaxSdk.SetUserId(AiryMintStrange.GetString(CTedium.Dy_UtterSaveWe));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                string adjustId = Adjust.getAdid();
                if (!string.IsNullOrEmpty(adjustId))
                {
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    AiryMintStrange.SetString(CTedium.Dy_SqueakRely, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(AiryMintStrange.GetString(CTedium.Dy_UtterSaveWe));
            MaxSdk.InitializeSdk();
        }
    }

    public void EarthquakeAmericanPot()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        GrabAmericanSo();

        // Load the first interstitial
        GrabOccupational();
    }

    private void GrabAmericanSo()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void GrabOccupational()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        HumanBurgeon = 0;
        RemainAnemoneCoin = adInfo.NetworkName;

        TempleSoModernMint = new Ad_CustomData();
        TempleSoModernMint.user_id = ZJT_Manager.LawLaurasia().GetUserID();
        TempleSoModernMint.version = Application.version;
        TempleSoModernMint.request_id = ZJT_Manager.LawLaurasia().GetEcpmRequestID();
        TempleSoModernMint.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        HumanBurgeon++;
        double retryDelay = Math.Pow(2, Math.Min(6, HumanBurgeon));

        Invoke(nameof(GrabAmericanSo), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        StainJar.LawLaurasia().OnStainGuinea = !StainJar.LawLaurasia().OnStainGuinea;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        GrabAmericanSo();
        BePlayfulSo = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        StainJar.LawLaurasia().OnStainGuinea = !StainJar.LawLaurasia().OnStainGuinea;
#endif

        BePlayfulSo = false;
        GrabAmericanSo();
        if (RemainPresage)
        {
            RemainPresage = false;
            RemainHideVentEmpire?.Invoke(true);

            IssueSoFoodPresage(ADType.Rewarded);
            BabyLatinDating.LawLaurasia().TangLatin("9007", RemainSlope);
        }
        else
        {
            RemainHideVentEmpire?.Invoke(false);
        }
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        RemainPresage = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        BabyLatinDating.LawLaurasia().TangLatin("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //SqueakRailStrange.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        string adjustAdid = SqueakRailStrange.Instance.LawSqueakRely();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        HumanBurgeon = 0;
        PrerequisiteAnemoneCoin = adInfo.NetworkName;

        OccupationalSoModernMint = new Ad_CustomData();
        OccupationalSoModernMint.user_id = ZJT_Manager.LawLaurasia().GetUserID();
        OccupationalSoModernMint.version = Application.version;
        OccupationalSoModernMint.request_id = ZJT_Manager.LawLaurasia().GetEcpmRequestID();
        OccupationalSoModernMint.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        HumanBurgeon++;
        double retryDelay = Math.Pow(2, Math.Min(6, HumanBurgeon));

        Invoke(nameof(GrabOccupational), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        StainJar.LawLaurasia().OnStainGuinea = !StainJar.LawLaurasia().OnStainGuinea;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        GrabOccupational();
        BePlayfulSo = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        BabyLatinDating.LawLaurasia().TangLatin("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //SqueakRailStrange.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(SqueakRailStrange.Instance.LawSqueakRely()))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = SqueakRailStrange.Instance.LawSqueakRely();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        StainJar.LawLaurasia().OnStainGuinea = !StainJar.LawLaurasia().OnStainGuinea;
#endif
        GrabOccupational();

        IssueSoFoodPresage(ADType.Interstitial);
        BabyLatinDating.LawLaurasia().TangLatin("9107", PrerequisiteSlope);
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void DungTempleVigor(Action<bool> callBack, string index)
    {
        if (BeFill)
        {
            callBack(true);
            IssueSoFoodPresage(ADType.Rewarded);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        RemainHideVentEmpire = callBack;
        if (rewardVideoReady)
        {
            LateMental.TieLateCommerce(LateMental.LateWe_3, 1);
            // 打点
            RemainSlope = index;
            BabyLatinDating.LawLaurasia().TangLatin("9002", index);
            BePlayfulSo = true;
            RemainPresage = false;
            string placement = index + "_" + RemainAnemoneCoin;
            TempleSoModernMint.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(TempleSoModernMint));
        }
        else
        {
            JapanStrange.LawLaurasia().BeatJapan("No ads right now, please try it later.");
            RemainHideVentEmpire(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void DungOccupationalSo(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        DungOccupational(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void DungOccupational(int index, int customIndex = 0)
    {
        PrerequisiteToll = index;

        if (BePlayfulSo)
        {
            return;
        }

        //这个参数很少有游戏会用 需要的时候自己再打开
        // 当用户船等级 < trial_MaxNum 时，不弹插屏广告
        int currentShipLevel = RopeMintStrange.LawLaurasia() != null ? RopeMintStrange.LawLaurasia().UtahMagma : 0;
        int trial_MaxNum = int.Parse(LopColeJar.instance.TediumMint.trial_MaxNum);
        if (currentShipLevel < trial_MaxNum)
        {
            return;
        }

        // 时间间隔低于阈值，不播放广告
        if (SoloFoodLineFestive < int.Parse(LopColeJar.instance.TediumMint.inter_freq))
        {
            return;
        }

        if (BeFill)
        {
            IssueSoFoodPresage(ADType.Interstitial);
            return;
        }

        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            BePlayfulSo = true;
            // 打点
            string point = index.ToString();
            if (customIndex > 0)
            {
                point += customIndex.ToString().PadLeft(2, '0');
            }
            PrerequisiteSlope = point;
            BabyLatinDating.LawLaurasia().TangLatin("9102", point);
            string placement = point + "_" + PrerequisiteAnemoneCoin;
            OccupationalSoModernMint.placement_id = placement;
            MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(OccupationalSoModernMint));
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void RejectPollen()
    {
        SoloFoodLineFestive++;

        int relax_interval = int.Parse(LopColeJar.instance.TediumMint.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || BePlayfulSo)
        {
            return;
        }
        else
        {
            Utensil101++;
            if (Utensil101 >= relax_interval && !SlushLineOccupational)
            {
                if (BePlayfulSo)
                {
                    return;
                }
                // 时间间隔低于阈值，不播放广告
                if (SoloFoodLineFestive < int.Parse(LopColeJar.instance.TediumMint.inter_freq))
                {
                    return;
                }
                bool isGamePanelTop = UIStrange.LawLaurasia().HeTendStandAnt();
                bool isFerverMode = RopeStrange.Instance != null && RopeStrange.Instance.RopeToll == GameType.FerverTime;

                //print("游戏面板是否在最上层： " + isGamePanelTop);
                if (!isGamePanelTop || isFerverMode)
                {
                    Utensil101 -= 5;
                   return;
               }
                //计时插屏 弹出提示
                bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
                if (!HappenLack.HeDaunt() && interstitialVideoReady)
                {
                    Utensil101 = 0;

                    UIStrange.LawLaurasia().BeatUIHouse(nameof(OccupationalSoAlaStand));
                    LineStrange.LawLaurasia().Track_LateLine(3, () =>
                    {
                        UIStrange.LawLaurasia().DriftIDCrouchUIHouse(nameof(OccupationalSoAlaStand));
                        DungOccupational(101);
                    });
                    return;
                }

                DungOccupational(101);
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void NoPropelTieRelic(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(LopColeJar.instance.TediumMint.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Utensil102 = AiryMintStrange.GetInt("NoThanksCount") + 1;
            AiryMintStrange.SetInt("NoThanksCount", Utensil102);
            if (Utensil102 >= nextlevel_interval)
            {
                DungOccupational(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!BePlayfulSo)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (PenetrationEnsueBoulevard > 0)
                {
                    SoloFoodLineFestive += (int)(MoodLack.Balance() - PenetrationEnsueBoulevard);
                    PenetrationEnsueBoulevard = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(LopColeJar.instance.TediumMint.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Utensil103++;
                    if (Utensil103 >= inter_b2f_count)
                    {
                        DungOccupational(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            PenetrationEnsueBoulevard = MoodLack.Balance();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void EnsueLineOccupational()
    {
        SlushLineOccupational = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void NormalLineOccupational()
    {
        SlushLineOccupational = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void AthensLabelWad(int num)
    {
        AiryMintStrange.SetInt(CTedium.Dy_If_Midst_Bad, num);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void BrightlyFoodDiscrete(Action<ADType> callback)
    {
        if (IfDevelopPerformer == null)
        {
            IfDevelopPerformer = new List<Action<ADType>>();
        }

        if (!IfDevelopPerformer.Contains(callback))
        {
            IfDevelopPerformer.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void IssueSoFoodPresage(ADType adType)
    {
        BePlayfulSo = false;
        // 播放间隔计数器清零
        SoloFoodLineFestive = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (PrerequisiteToll == 101)
            {
                Utensil101 = 0;
            }
            else if (PrerequisiteToll == 102)
            {
                Utensil102 = 0;
                AiryMintStrange.SetInt("NoThanksCount", 0);
            }
            else if (PrerequisiteToll == 103)
            {
                Utensil103 = 0;
            }
        }

        // 看广告总数+1
        AiryMintStrange.SetInt(CTedium.Dy_Fleet_If_Bad + adType.ToString(), AiryMintStrange.GetInt(CTedium.Dy_Fleet_If_Bad + adType.ToString()) + 1);
        // 提现任务 
        if (adType == ADType.Rewarded)
            ZJT_Manager.LawLaurasia().AddTaskValue("Ad",1);

        // 回调
        if (IfDevelopPerformer != null && IfDevelopPerformer.Count > 0)
        {
            foreach (Action<ADType> callback in IfDevelopPerformer)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int LawPulseSoWad(ADType adType)
    {
        return AiryMintStrange.GetInt(CTedium.Dy_Fleet_If_Bad + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}