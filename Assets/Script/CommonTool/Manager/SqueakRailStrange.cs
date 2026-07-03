using System;
using System.Collections;
using com.adjust.sdk;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;

public class SqueakRailStrange : MonoBehaviour
{
    public static SqueakRailStrange Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string IntentID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string Dy_ADMossRailToll= "Dy_ADMossRailToll";

    //adjust 时间戳
    private string Dy_ADMossLine= "sv_ADJustTime";

    //adjust行为计数器
    public int _NotableRelic{ get; private set; }

    public double _NotableShorten{ get; private set; }

    double IntentRailSoShorten= 0;


    private void Awake()
    {
        Instance = this;
        AiryMintStrange.SetString(Dy_ADMossLine, MoodLack.Balance().ToString());

#if UNITY_IOS
        AiryMintStrange.SetString(Dy_ADMossRailToll, AdjustStatus.OpenAsAct.ToString());
        SqueakRail();
#endif
    }

    private void Start()
    {
        _NotableRelic = 0;
    }


    void SqueakRail()
    {
#if UNITY_EDITOR
        return;
#endif
        AdjustConfig adjustConfig = new AdjustConfig(IntentID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        adjustConfig.setEventBufferingEnabled(false);
        adjustConfig.setLaunchDeferredDeeplink(true);
        Adjust.start(adjustConfig);

        StartCoroutine(AirySqueakRely());
    }

    private IEnumerator AirySqueakRely()
    {
        while (true)
        {
            string adjustAdid = Adjust.getAdid();
            if (string.IsNullOrEmpty(adjustAdid))
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                AiryMintStrange.SetString(CTedium.Dy_SqueakRely, adjustAdid);
                LopColeJar.instance.TangSqueakRely();
                ZJT_Manager.LawLaurasia().ReportAdjustID();
                yield break;
            }
        }
    }

    public string LawSqueakRely()
    {
        return AiryMintStrange.GetString(CTedium.Dy_SqueakRely);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string LawSqueakRavage()
    {
        return AiryMintStrange.GetString(Dy_ADMossRailToll);
    }

    /*
     *  API
     *  Adjust 初始化
     */
    public void RailSqueakMint(bool isOldUser = false)
    {
        #if UNITY_IOS
            return;
        #endif
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(LopColeJar.instance.TediumMint.adjust_init_act_position) || int.Parse(LopColeJar.instance.TediumMint.adjust_init_act_position) <= 0)
        {
            AiryMintStrange.SetString(Dy_ADMossRailToll, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + AiryMintStrange.GetString(Dy_ADMossRailToll));
        //用户二次登录 根据标签初始化
        if (AiryMintStrange.GetString(Dy_ADMossRailToll) == AdjustStatus.OldUser.ToString() || AiryMintStrange.GetString(Dy_ADMossRailToll) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            SqueakRail();
        }
    }



    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void TieYouRelic(string param2 = "")
    {
#if UNITY_IOS
            return;
#endif
        if (AiryMintStrange.GetString(Dy_ADMossRailToll) != "") return;
        _NotableRelic++;
        print(" add up to :" + _NotableRelic);
        if (string.IsNullOrEmpty(LopColeJar.instance.TediumMint.adjust_init_act_position) || _NotableRelic == int.Parse(LopColeJar.instance.TediumMint.adjust_init_act_position))
        {
            GrabSqueakOrYou(param2);
        }
    }

    /// <summary>
    /// 记录广告行为累计次数，带广告收入
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="revenue"></param>
    public void TieSoRelic(string countryCode, double revenue)
    {
#if UNITY_IOS
            return;
#endif
        //if (AiryMintStrange.GetString(Dy_ADMossRailToll) != "") return;

        _NotableRelic++;
        _NotableShorten += revenue;
        print(" Ads count: " + _NotableRelic + ", Revenue sum: " + _NotableShorten);

        //如果后台有adjust_init_adrevenue数据 且 能找到匹配的countryCode，初始化adjustInitAdRevenue
        if (!string.IsNullOrEmpty(LopColeJar.instance.TediumMint.adjust_init_adrevenue))
        {
            JsonData jd = JsonMapper.ToObject(LopColeJar.instance.TediumMint.adjust_init_adrevenue);
            if (jd.ContainsKey(countryCode))
            {
                IntentRailSoShorten = double.Parse(jd[countryCode].ToString(), new System.Globalization.CultureInfo("en-US"));
            }
        }

        if (
            string.IsNullOrEmpty(LopColeJar.instance.TediumMint.adjust_init_act_position)                   //后台没有配置限制条件，直接走LoadAdjust
            || (_NotableRelic == int.Parse(LopColeJar.instance.TediumMint.adjust_init_act_position)         //累计广告次数满足adjust_init_act_position条件，且累计广告收入满足adjust_init_adrevenue条件，走LoadAdjust
                && _NotableShorten >= IntentRailSoShorten)
        )
        {
            GrabSqueakOrYou();
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void GrabSqueakOrYou(string param2 = "")
    {
        if (AiryMintStrange.GetString(Dy_ADMossRailToll) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(LopColeJar.instance.TediumMint.adjust_init_rate_act) || int.Parse(LopColeJar.instance.TediumMint.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            AiryMintStrange.SetString(Dy_ADMossRailToll, AdjustStatus.OpenAsAct.ToString());
            SqueakRail();

            // 上报点位 新用户达成 且 初始化
            BabyLatinDating.LawLaurasia().TangLatin("1091", LawSqueakLine(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            AiryMintStrange.SetString(Dy_ADMossRailToll, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            BabyLatinDating.LawLaurasia().TangLatin("1092", LawSqueakLine(), param2);
        }
    }

    
    /*
     * API
     *  重置当前次数
     */
    public void PrimeYouRelic()
    {
        print("clear current ");
        _NotableRelic = 0;
    }


    // 获取启动时间
    private string LawSqueakLine()
    {
        return MoodLack.Balance() - long.Parse(AiryMintStrange.GetString(Dy_ADMossLine)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}