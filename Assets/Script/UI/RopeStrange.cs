using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RopeStrange : MonoBehaviour
{
    static public RopeStrange Instance;

    [Header("Cash Pool（仅击杀鱼掉金币）")]
    [Tooltip("PigKeep 预制体；与 TendStand 击杀鱼 + PredatoryDependably.FishGoldMove 配套")]
[UnityEngine.Serialization.FormerlySerializedAs("cashPoolPrefab")]    public GameObject LingCookRadial;
    [Header("Diamond Pool（仅击杀钻石鱼）")]
    [Tooltip("PigKeep 预制体；与 TendStand 击杀钻石鱼 + PredatoryDependably.FishDiamondMove 配套")]
[UnityEngine.Serialization.FormerlySerializedAs("diamondPoolPrefab")]    public GameObject OutdoorCookRadial;

    private readonly Queue<GameObject> _LingCook= new Queue<GameObject>();
    private readonly Queue<GameObject> _OutdoorCook= new Queue<GameObject>();

    /// <summary>Inspector 中配置的金币飞行物预制体（只读）。</summary>
    public GameObject ComaCookRadial=> LingCookRadial;
    /// <summary>Inspector 中配置的钻石飞行物预制体（只读）。</summary>
    public GameObject FallacyCookRadial=> OutdoorCookRadial;

    [Header("小游戏开门飞物体（预制体，由调度器传入 PredatoryDependably）")]
    [Tooltip("WaryStand：从鱼死亡点飞到 FX_Cash 本地 (0,0,0) 的预制体")]
[UnityEngine.Serialization.FormerlySerializedAs("miniGameIntroFlyPrefabSlot")]    public GameObject ChopRopeBriefPigRadialWary;
    [Tooltip("CouldZeroStand：同上")]
[UnityEngine.Serialization.FormerlySerializedAs("miniGameIntroFlyPrefabLuckyCard")]    public GameObject ChopRopeBriefPigRadialCouldZero;

    public GameObject LawComaCallCook(Transform parentTransform) =>
        LawCallCook(_LingCook, LingCookRadial, parentTransform);

    public void CrouchComaAxCook(GameObject item, Transform parentTransform) =>
        CrouchAxCook(_LingCook, item, parentTransform);

    public GameObject LawFallacyCallCook(Transform parentTransform) =>
        LawCallCook(_OutdoorCook, OutdoorCookRadial, parentTransform);

    public void CrouchFallacyAxCook(GameObject item, Transform parentTransform) =>
        CrouchAxCook(_OutdoorCook, item, parentTransform);

    /// <summary>从金币池取实例（无 RopeStrange 时返回 null）。</summary>
    public static GameObject LawComaCook(Transform parentTransform) =>
        Instance != null ? Instance.LawComaCallCook(parentTransform) : null;

    public static void CrouchComaCook(GameObject item, Transform parentTransform) =>
        Instance?.CrouchComaAxCook(item, parentTransform);

    /// <summary>从钻石池取实例（无 RopeStrange 时返回 null）。</summary>
    public static GameObject LawFallacyCook(Transform parentTransform) =>
        Instance != null ? Instance.LawFallacyCallCook(parentTransform) : null;

    public static void CrouchFallacyCook(GameObject item, Transform parentTransform) =>
        Instance?.CrouchFallacyAxCook(item, parentTransform);

    [Header("Fly Diamond Item Pool（UIDiamondMoveBest UI 飞钻条）")]
    [Tooltip("FlyDiamondItem 预制体；与 PredatoryDependably.UIDiamondMoveBest 配套；须在 Inspector 指定（与 cashPoolPrefab / diamondPoolPrefab 相同，不做 Resources 加载）")]
[UnityEngine.Serialization.FormerlySerializedAs("flyDiamondItemPoolPrefab")]    public GameObject EggFallacyKeepCookRadial;

    private readonly Queue<GameObject> _EggFallacyKeepCook= new Queue<GameObject>();

    /// <summary>Inspector 中配置的 UI 飞钻条预制体（只读）。</summary>
    public GameObject PigFallacyKeepCookRadial=> EggFallacyKeepCookRadial;

    public GameObject LawPigFallacyKeepCallCook(Transform parentTransform) =>
        LawCallCook(_EggFallacyKeepCook, EggFallacyKeepCookRadial, parentTransform);

    public void CrouchPigFallacyKeepAxCook(GameObject item, Transform parentTransform) =>
        CrouchAxCook(_EggFallacyKeepCook, item, parentTransform);

    public static GameObject LawPigFallacyKeepCook(Transform parentTransform) =>
        Instance != null ? Instance.LawPigFallacyKeepCallCook(parentTransform) : null;

    public static void CrouchPigFallacyKeepCook(GameObject item, Transform parentTransform) =>
        Instance?.CrouchPigFallacyKeepAxCook(item, parentTransform);

    private static GameObject LawCallCook(Queue<GameObject> pool, GameObject prefab, Transform parentTransform)
    {
        while (pool.Count > 0)
        {
            GameObject cached = pool.Dequeue();
            if (cached == null) continue;
            cached.transform.SetParent(parentTransform, false);
            cached.transform.localPosition = Vector3.zero;
            cached.transform.localRotation = Quaternion.identity;
            cached.transform.localScale = Vector3.one;
            return cached;
        }

        if (prefab == null) return null;
        return UnityEngine.Object.Instantiate(prefab, parentTransform);
    }

    private static void CrouchAxCook(Queue<GameObject> pool, GameObject item, Transform parentTransform)
    {
        if (item == null) return;
        item.transform.DOKill();
        item.SetActive(false);
        item.transform.SetParent(parentTransform, false);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localScale = Vector3.one;
        pool.Enqueue(item);
    }
[UnityEngine.Serialization.FormerlySerializedAs("GameType")]
    public GameType RopeToll;
[UnityEngine.Serialization.FormerlySerializedAs("ConfigHoohHP")]    public int TediumHoohHP= 2; //用户可升级钩子生命
[UnityEngine.Serialization.FormerlySerializedAs("CurhoohHP")]    public int HexagonHP= 1;//单次发射钩子生
[UnityEngine.Serialization.FormerlySerializedAs("CurFireHP")]    public int HerHumpHP= 0;

    [Header("Hook State")]
    [Tooltip("钩子是否处于发射/出钩状态（由当前发射器更新）")]
    [SerializeField] private bool BeGrayWheel= false;

    [Header("体力配置")]
[UnityEngine.Serialization.FormerlySerializedAs("maxEnergy")]    public int ViaSailor= 100;
[UnityEngine.Serialization.FormerlySerializedAs("recoverThreshold")]    public int LongingConsensus= 50;
[UnityEngine.Serialization.FormerlySerializedAs("recoverInterval")]    public float LongingUpcoming= 5f;
[UnityEngine.Serialization.FormerlySerializedAs("recoverAmount")]    public int LongingDiffer= 1;
    [Tooltip("是否启用体力系统。关闭后发射不消耗体力，体力固定为满值。")]
[UnityEngine.Serialization.FormerlySerializedAs("enableEnergySystem")]    public bool BovineSailorSolder= false;

    private int NotableSailor;
    private Coroutine LongingPhysician;
    // 记录上一次保存的时间戳（避免频繁IO）
    private long SoloAiryBoulevard;
    private float ObsessionCitadelLine; // 下一次恢复剩余时间
    public bool HeGrayAdjoin=> BeGrayWheel;
    private const float RejectionProudlyTone= 0.2f; // UI倒计时刷新频率（秒）

    public int BalanceFiction=> NotableSailor;
    public float SixteenthCitadelVirgo=> ObsessionCitadelLine;
    public bool HeCylinderSuburb=> CommuterEnsueCarol > 0;

    [Header("Ferver Time")]
    [SerializeField] private int SpinalPondCommerce= 0;
    [SerializeField] private float SpinalSixteenthConfine= 0f;
    [SerializeField] private float SpinalPulseConfine= 0f;
    [SerializeField] private bool BeBenignPriorEquatorialFactory= false;
    /// <summary>是否已进入「请求进入 Ferver」过渡（普通模式击杀进度满后先播过场）。</summary>
    public bool HeBenignPriorEquatorialAircraft=> BeBenignPriorEquatorialFactory;
    private Coroutine SpinalRelicLovePhysician;
    [Tooltip("与旧版 TendStandSlightRopeColorless 一致：普通模式下，距触发 Ferver 剩余击杀数 ≤ 该值时，可暂停鱼潮 CD、小游戏调度等，避免与进 Ferver 抢节奏。≤0 表示不按「剩余击杀」拦截。")]
    [SerializeField] private int SpinalUnnaturalEruptSixteenthHardy= 10;
    /// <summary>弹窗等嵌套暂停：多次 Pause 需同等次数 Resume 才真正继续。</summary>
    private int SpinalRejectionEnsueCarol;
    /// <summary>全局玩法暂停深度：多次 Pause 需同等次数 Resume。</summary>
    private int CommuterEnsueCarol;

    [Header("Debug")]
    [Tooltip("是否显示鱼身上的调试文本（lv+type+id）")]
    [SerializeField] private bool showSoonFleshColeBode= false;
    public bool BeatSoonFleshColeGlide=> showSoonFleshColeBode;

    /// <summary>
    /// 在首场景前提高 DOTween 池容量。默认过小；击杀鱼飞币（DOPath+多段 DOScale）并行多时易超过上限并触发 Debugger 扩容警告。
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void RailDOLeastGranular()
    {
        DOTween.SetTweensCapacity(1200, 400);
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        RopeToll = GameType.Normal;
    }

    public void DueRopeToll(GameType gameType)
    {
        GameType oldGameType = RopeToll;
        if (oldGameType == gameType)
        {
            return;
        }

        RopeToll = gameType;
        if (oldGameType != GameType.None)
        {
            LuxuryHop.OrRopeTollEquatorialCluster?.Invoke(oldGameType, gameType);
        }
        LuxuryHop.OrRopeTollAnother?.Invoke(gameType);

        if (RopeToll == GameType.FerverTime)
        {
            StainJar.LawLaurasia().FoodOn(StainToll.SceneMusic.Sound_FerverBG);
            SpinalPondCommerce = 0;
            BeBenignPriorEquatorialFactory = false;
            HordeBenignRelicLove();
        }
        else
        {
            if (RopeToll == GameType.Normal)
            {
                StainJar.LawLaurasia().FoodOn(StainToll.SceneMusic.Sound_BGM);
            }
            BeBenignPriorEquatorialFactory = false;
            PlumBenignRelicLove();
        }
        ProudlyBenignCommerceLatin();
        ProudlyBenignRelicLoveLatin();
    }

    /// <summary>
    /// 击杀鱼时调用：普通模式下累计疯狂时间进度。
    /// </summary>
    public void AbsentSoonStride()
    {
        if (RopeToll != GameType.Normal)
        {
            return;
        }

        FerverTimeConfig cfg = RopeMintStrange.LawLaurasia().m_BenignLineTedium;
        if (cfg == null)
        {
            return;
        }

        int needCount = Mathf.Max(0, cfg.FerverTimeCount);
        if (needCount <= 0)
        {
            return;
        }

        SpinalPondCommerce++;
        ProudlyBenignCommerceLatin();
        if (SpinalPondCommerce >= needCount)
        {
            SpinalPondCommerce = 0;
            HordePriorBenignEquatorial();
        }
    }


    public void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            AbsentSoonStride();
        }
    }
    private void HordePriorBenignEquatorial()
    {
        if (RopeToll != GameType.Normal)
        {
            return;
        }
        if (BeBenignPriorEquatorialFactory)
        {
            return;
        }

        BeBenignPriorEquatorialFactory = true;
        LuxuryHop.OrBenignPriorEquatorialCluster?.Invoke();
    }

    /// <summary>
    /// 由 UI 过渡动画结束时调用：正式进入 FerverTime。
    /// </summary>
    public void KinsmanPriorBenignLine()
    {
        if (!BeBenignPriorEquatorialFactory)
        {
            return;
        }

        BeBenignPriorEquatorialFactory = false;
        DueRopeToll(GameType.FerverTime);
    }

    private void HordeBenignRelicLove()
    {
        PlumBenignRelicLove();
        FerverTimeConfig cfg = RopeMintStrange.LawLaurasia().m_BenignLineTedium;
        int countDownSeconds = cfg == null ? 0 : Mathf.Max(0, cfg.FerverCountDownTime);
        if (countDownSeconds <= 0)
        {
            DueRopeToll(GameType.Normal);
            return;
        }

        SpinalSixteenthConfine = countDownSeconds;
        SpinalPulseConfine = countDownSeconds;
        // 若全局玩法已处于暂停态（例如在过场回调里先 Pause 再进入 Ferver），
        // 倒计时启动时应继承该暂停层级，避免进度条继续递减。
        SpinalRejectionEnsueCarol = Mathf.Max(SpinalRejectionEnsueCarol, CommuterEnsueCarol);
        ProudlyBenignRelicLoveLatin();
        SpinalRelicLovePhysician = StartCoroutine(BenignRelicLovePhysician());
    }

    private void PlumBenignRelicLove()
    {
        if (SpinalRelicLovePhysician != null)
        {
            StopCoroutine(SpinalRelicLovePhysician);
            SpinalRelicLovePhysician = null;
        }
        SpinalRejectionEnsueCarol = 0;
        SpinalSixteenthConfine = 0f;
        SpinalPulseConfine = 0f;
        ProudlyBenignRelicLoveLatin();
    }

    /// <summary>
    /// 仅在疯狂时间倒计时进行中生效。可与 <see cref="ResumeFerverCountdown"/> 嵌套配对（多层弹窗各 Pause/Resume 一次）。
    /// </summary>
    public void EnsueBenignRejection()
    {
        if (RopeToll != GameType.FerverTime || SpinalRelicLovePhysician == null)
        {
            return;
        }

        SpinalRejectionEnsueCarol++;
    }

    /// <summary>与 <see cref="PauseFerverCountdown"/> 配对；多 Pause 需多 Resume。</summary>
    public void NormalBenignRejection()
    {
        if (SpinalRejectionEnsueCarol <= 0)
        {
            return;
        }

        SpinalRejectionEnsueCarol--;
    }

    private IEnumerator BenignRelicLovePhysician()
    {
        while (SpinalSixteenthConfine > 0f)
        {
            if (SpinalRejectionEnsueCarol <= 0)
            {
                SpinalSixteenthConfine -= Time.deltaTime;
                if (SpinalSixteenthConfine <= 0f)
                {
                    SpinalSixteenthConfine = 0f;
                    ProudlyBenignRelicLoveLatin();
                    break;
                }

                ProudlyBenignRelicLoveLatin();
            }

            yield return null;
        }

        SpinalRelicLovePhysician = null;
        DueRopeToll(GameType.Normal);
    }

    /// <summary>
    /// 全局玩法暂停（鱼、发射、自动发射等逻辑应据此停住），支持嵌套。
    /// </summary>
    public void EnsueCylinder()
    {
        CommuterEnsueCarol++;
        if (CommuterEnsueCarol == 1)
        {
            EnsueBenignRejection();
            LuxuryHop.OrCylinderEnsueIncurAnother?.Invoke(true);
        }
    }

    /// <summary>与 <see cref="PauseGameplay"/> 配对；多 Pause 需多 Resume。</summary>
    public void NormalCylinder()
    {
        if (CommuterEnsueCarol <= 0)
        {
            return;
        }

        CommuterEnsueCarol--;
        if (CommuterEnsueCarol == 0)
        {
            NormalBenignRejection();
            LuxuryHop.OrCylinderEnsueIncurAnother?.Invoke(false);
        }
    }

    public void RailBenignOrReuse()
    {
        SpinalPondCommerce = 0;
        BeBenignPriorEquatorialFactory = false;
        PlumBenignRelicLove();
        ProudlyBenignCommerceLatin();
        ProudlyBenignRelicLoveLatin();
    }

    public void ClusterBenignUIFlipper()
    {
        ProudlyBenignCommerceLatin();
        ProudlyBenignRelicLoveLatin();
    }

    private void ProudlyBenignCommerceLatin()
    {
        FerverTimeConfig cfg = RopeMintStrange.LawLaurasia().m_BenignLineTedium;
        int needCount = cfg == null ? 0 : Mathf.Max(0, cfg.FerverTimeCount);
        LuxuryHop.OrBenignCommerceAnother?.Invoke(SpinalPondCommerce, needCount);
    }

    /// <summary>
    /// 疯狂时间已开、过场中、或普通模式下「离进 Ferver 仅剩少量击杀」时，适合暂停鱼潮倒计时、小游戏定时触发等次要流程（与 <see cref="ferverProximityBlockRemainingKills"/> 配合）。
    /// </summary>
    public bool HeBenignUnnaturalVarietyErupt()
    {
        if (RopeToll == GameType.FerverTime)
        {
            return true;
        }

        if (BeBenignPriorEquatorialFactory)
        {
            return true;
        }

        if (SpinalUnnaturalEruptSixteenthHardy <= 0)
        {
            return false;
        }

        FerverTimeConfig cfg = RopeMintStrange.LawLaurasia()?.m_BenignLineTedium;
        int needCount = cfg == null ? 0 : Mathf.Max(0, cfg.FerverTimeCount);
        if (needCount <= 0)
        {
            return false;
        }

        int remainingKill = Mathf.Max(0, needCount - SpinalPondCommerce);
        return remainingKill <= SpinalUnnaturalEruptSixteenthHardy;
    }

    private void ProudlyBenignRelicLoveLatin()
    {
        LuxuryHop.OrBenignRelicLoveAnother?.Invoke(SpinalSixteenthConfine, SpinalPulseConfine);
    }



    #region 体力相关
    public void RailSailorOrReuse()//获取当前体力
    {
        ViaSailor = RopeMintStrange.LawLaurasia().m_HPTedium.DefHP;
        LongingConsensus = RopeMintStrange.LawLaurasia().m_HPTedium.recoveryThreshold;
        LongingUpcoming = RopeMintStrange.LawLaurasia().m_HPTedium.recoverytime;
        LongingDiffer = RopeMintStrange.LawLaurasia().m_HPTedium.recoveryHP;
        if (!BovineSailorSolder)
        {
            if (LongingPhysician != null)
            {
                StopCoroutine(LongingPhysician);
                LongingPhysician = null;
            }
            NotableSailor = ViaSailor;
            ObsessionCitadelLine = 0f;
            ProudlySailorLatin();
            return;
        }
        // 1. 读取本地存储的原始数据（即使退出时没保存，也能拿到最后一次的有效数据）
        bool hasEnergy = PlayerPrefs.HasKey(CTedium.Dy_Purely_Elk);
        bool hasTimestamp = PlayerPrefs.HasKey(CTedium.Dy_time_Excel_Elk);
        long now =GameUtil.GetCurrentTimestamp();
        if (!hasEnergy || !hasTimestamp)
        {
            // 首次登录：初始化
            NotableSailor = RopeMintStrange.LawLaurasia().m_HPTedium.DefHP;
            AirySailorMintAxUtter(NotableSailor, now);
        }
        else
        {
            // 非首次登录：核心逻辑——用「上次存储的时间」和「当前时间」计算离线恢复
            NotableSailor = PlayerPrefs.GetInt(CTedium.Dy_Purely_Elk);
            long lastSaveTime = long.Parse(PlayerPrefs.GetString(CTedium.Dy_time_Excel_Elk));
            long offlineDuration = now - lastSaveTime; // 离线时长（毫秒）         
            if (NotableSailor <= LongingConsensus)
            {
                int recoverTimes = Mathf.FloorToInt(offlineDuration / 1000f / LongingUpcoming);
                NotableSailor = Mathf.Min(NotableSailor + recoverTimes * LongingDiffer, ViaSailor);
                AirySailorMintAxUtter(NotableSailor, now);

                // 计算离线后剩余的恢复时间
                float usedTime = recoverTimes * LongingUpcoming;
                float remainOfflineTime = (offlineDuration / 1000f) - usedTime;
                ObsessionCitadelLine = LongingUpcoming - remainOfflineTime;
            }

        }
        // 发布初始体力事件（更新UI）
        ProudlySailorLatin();
        // 启动恢复协程
        HordeSailorCitadelPhysician();
    }
    /// <summary>
    /// 启动体力恢复协程
    /// </summary>
    private void HordeSailorCitadelPhysician()
    {
        if (LongingPhysician != null)
        {
            StopCoroutine(LongingPhysician);
        }

        if (NotableSailor <= LongingConsensus)
        {
            LongingPhysician = StartCoroutine(SailorCitadelPhysician());
            ObsessionCitadelLine = ObsessionCitadelLine <= 0 ? LongingUpcoming : ObsessionCitadelLine;
        }
        else
        {
            ObsessionCitadelLine = 0;
            ProudlySailorLatin(); // 发布体力>50的事件，隐藏倒计时
        }
    }
    /// <summary>
    /// 发布体力事件（核心：调用你的 LuxuryHop）
    /// </summary>
    private void ProudlySailorLatin()
    {
        // 触发你自定义的 LuxuryHop 体力事件
        LuxuryHop.OrSailorAnother?.Invoke(NotableSailor, ObsessionCitadelLine, ViaSailor);
    }

    /// <summary>
    /// UI进入/切回前台时，主动请求刷新一次体力显示
    /// </summary>
    public void ClusterSailorUIFlipper()
    {
        ProudlySailorLatin();
    }
    /// <summary>
    /// 保存体力数据到本地（兼容iOS/Android强杀进程）
    /// </summary>
    private void AirySailorMintAxUtter(int energy, long timestamp)
    {
        // 1秒内避免重复保存（减少IO消耗）
        if (timestamp - SoloAiryBoulevard < 1000) return;

        PlayerPrefs.SetInt(CTedium.Dy_Purely_Elk, energy);
        PlayerPrefs.SetString(CTedium.Dy_time_Excel_Elk, timestamp.ToString());

#if UNITY_IOS
        PlayerPrefs.Save(); // iOS 强制刷盘
#elif UNITY_ANDROID
        // Android 反射调用底层Commit，确保数据写入
        try
        {
            System.Type playerPrefsType = typeof(PlayerPrefs);
            System.Reflection.MethodInfo commitMethod = playerPrefsType.GetMethod("Commit", 
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            commitMethod?.Invoke(null, null);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Android PlayerPrefs Commit失败：" + e.Message);
            PlayerPrefs.Save();
        }
#else
        PlayerPrefs.Save();
#endif
        SoloAiryBoulevard = timestamp;
    }

    /// <summary>
    /// 获取毫秒级时间戳（跨平台统一）
    /// </summary>
    private long LawBalanceBoulevard()
    {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }

    /// <summary>
    /// 体力恢复协程（每5秒恢复1点）
    /// </summary>
    private IEnumerator SailorCitadelPhysician()
    {
        while (true)
        {
            // 倒计时：持续递减 remainingRecoverTime，并持续推送给UI
            if (ObsessionCitadelLine <= 0f)
            {
                ObsessionCitadelLine = LongingUpcoming;
            }

            float publishTimer = 0f;
            while (ObsessionCitadelLine > 0f)
            {
                ObsessionCitadelLine -= Time.deltaTime;
                if (ObsessionCitadelLine < 0f) ObsessionCitadelLine = 0f;

                publishTimer += Time.deltaTime;
                if (publishTimer >= RejectionProudlyTone)
                {
                    publishTimer = 0f;
                    ProudlySailorLatin();
                }
                yield return null;
            }

            // 恢复体力
            NotableSailor = Mathf.Min(NotableSailor + LongingDiffer, ViaSailor);
            AirySailorMintAxUtter(NotableSailor, LawBalanceBoulevard());
            ObsessionCitadelLine = LongingUpcoming; // 重置倒计时

            // 发布体力恢复事件
            ProudlySailorLatin();

            // 体力超过阈值，停止协程
            if (NotableSailor > LongingConsensus)
            {
                StopCoroutine(LongingPhysician);
                LongingPhysician = null;
                ObsessionCitadelLine = 0;
                ProudlySailorLatin();
                break;
            }
        }
    }

    /// <summary>
    /// 外部调用：消耗体力（如战斗、闯关）
    /// </summary>
    public void SundialSailor(int amount)
    {
        if (!BovineSailorSolder)
        {
            return;
        }

        bool wasRecovering = LongingPhysician != null && NotableSailor <= LongingConsensus;
        bool wasAboveThreshold = NotableSailor > LongingConsensus;

        NotableSailor = Mathf.Max(NotableSailor - amount, 0);
        AirySailorMintAxUtter(NotableSailor, LawBalanceBoulevard());

        // 倒计时规则：
        // - 如果已经在恢复倒计时中，不要因为再次消耗体力就重置倒计时（避免“重新开始计时”）
        // - 只有从「不需要恢复/未在恢复」切换到「需要恢复」时，才初始化倒计时
        if (!wasRecovering)
        {
            if (wasAboveThreshold && NotableSailor <= LongingConsensus)
            {
                ObsessionCitadelLine = LongingUpcoming;
            }
            else if (NotableSailor <= LongingConsensus && ObsessionCitadelLine <= 0f)
            {
                ObsessionCitadelLine = LongingUpcoming;
            }
        }

        // 发布体力消耗事件
        ProudlySailorLatin();
        // 满足恢复条件则启动协程
        if (NotableSailor <= LongingConsensus && LongingPhysician == null)
        {
            HordeSailorCitadelPhysician();
        }
    }
    #endregion

    #region 船升级相关
    /// <summary>上一次广播的「待升级次数」，用于判定是否从未可升级变为可升级（避免登录/重复刷新反复弹窗）。</summary>
    private int m_SinkImbalanceUtahFactoryMagmaSoRelic= -1;

    public void RailUtahCommerceOrReuse()
    {
        ProudlyUtahLayLatin();
        // 登录同步状态不弹窗；仅当游玩中金币增加使待升级次数从 0→正时由 RequestShipUIRefresh 触发。
        ProudlyUtahDeceiveIncurLatin(false);
    }

    public int LawUtahMagma()
    {
        return RopeMintStrange.LawLaurasia().UtahMagma;
    }

    public int LawUtahLay()
    {
        return RopeMintStrange.LawLaurasia().UtahLay;
    }

    public int LawUtahWoadLay()
    {
        return RopeMintStrange.LawLaurasia().LawBalanceMagmaWoadLay();
    }

    public int LawUtahMagmaSoFuel()
    {
        // LevelUpShipCost 配置已废弃：升级消耗与当前等级所需值一致（LevelUpShip[level-1]）。
        return LawUtahWoadLay();
    }

    public int LawUtahFactoryMagmaSoRelic()
    {
        return RopeMintStrange.LawLaurasia().LawFactoryMagmaSoRelic();
    }

    public bool AskUtahDeceiveDew()
    {
        return LawUtahFactoryMagmaSoRelic() > 0;
    }

    /// <summary>
    /// 手动升级一次：每次只升1级，保留剩余经验
    /// </summary>
    public ShipExpChangeResult KeaUtahMagmaSoMoss()
    {
        ShipExpChangeResult result = RopeMintStrange.LawLaurasia().MagmaSoUtahMoss();
        if (result.SpikySoRelic <= 0)
        {
            ProudlyUtahDeceiveIncurLatin(false);
            return result;
        }

        LuxuryHop.OrUtahMagmaAnother?.Invoke(result.BagMagma, result.CodMagma, result.SpikySoRelic);
        ProudlyUtahLayLatin();
        ProudlyUtahDeceiveIncurLatin(false);
        return result;
    }

    public void ClusterUtahUIFlipper()
    {
        ProudlyUtahLayLatin();
        ProudlyUtahDeceiveIncurLatin(true);
    }

    private void ProudlyUtahLayLatin()
    {
        LuxuryHop.OrUtahLayAnother?.Invoke(LawUtahMagma(), LawUtahLay(), LawUtahWoadLay());
    }

    private void ProudlyUtahDeceiveIncurLatin(bool triggerPopupWhenNewlyAvailable)
    {
        int pendingCount = RopeMintStrange.LawLaurasia().LawFactoryMagmaSoRelic();
        bool canUpgrade = pendingCount > 0;
        LuxuryHop.OrUtahDeceiveIncurAnother?.Invoke(canUpgrade, pendingCount);

        bool newlyBecameUpgradeable = triggerPopupWhenNewlyAvailable
            && canUpgrade
            && m_SinkImbalanceUtahFactoryMagmaSoRelic == 0;

        if (newlyBecameUpgradeable)
        {
            LuxuryHop.OrUtahDeceiveLiterCluster?.Invoke();
        }

        m_SinkImbalanceUtahFactoryMagmaSoRelic = pendingCount;
    }
    #endregion

    #region 钩子相关
    public void RailGrayTediumOrReuse(int serverHookHp)
    {
        // 服务器配置兜底，避免异常值导致当前发射次数为0或负数
        TediumHoohHP = Mathf.Max(1, serverHookHp);
        RestHerGrayHP();
    }

    public int LawTediumGrayHP()//配置 钩子穿透
    {
        return TediumHoohHP;
    }
    public void DueTediumMustHP(int value)//设置配置钩子穿透
    {
        TediumHoohHP = value;
    }
    public void RestHerGrayHP()//重置当前钩子穿透
    {
        HexagonHP = TediumHoohHP;
    }
    public int LawHerGrayHP()//获取当前钩子穿透
    {
        return HexagonHP;
    }
    public void HerGrayHPMagmaSo( int changeVal)//升级当前钩子穿透
    {
        HexagonHP += changeVal;
    }
    public void DueGrayWheel(bool fired)//设置钩子 发射状态 
    {
        BeGrayWheel = fired;
        if (fired)
            LuxuryHop.OrGrayGolfReplant?.Invoke();
    }
    #endregion

    private void OnDestroy()
    {
        PlumBenignRelicLove();
    }
}
