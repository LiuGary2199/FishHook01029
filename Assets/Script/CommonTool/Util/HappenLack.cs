using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappenLack
{
    [HideInInspector] public static string Squeak_UtilizeCoin; //归因渠道名称 由NetInfoMgr的CheckAdjustNetwork方法赋值
    static string Airy_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string MalletObeyCoin= "pie"; //正常模式名称
    static string Unpopular; //距离黑名单位置的距离 打点用
    static string Myxoma; //进审理由 打点用
    [HideInInspector] public static string ToneFan= ""; //判断流程 打点用

    public static bool HeDaunt()
    {
        //测试
         //return true;

        if (Application.platform == RuntimePlatform.Android) //安卓平台无需判断ApplePie
            return false;

        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Airy_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Airy_AP)) //无本地存档 读取网络数据
            FenceKettleMint();

        if (Airy_AP != "P")
            return true;
        else
            return false;
    }
    public static void FenceKettleMint() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Airy_AP = "P";
        if (LopColeJar.instance.TediumMint.apple_pie != MalletObeyCoin) //审模式 
        {
            OtherChance = "YES";
            Airy_AP = "A";
            if (string.IsNullOrEmpty(Myxoma))
                Myxoma = "ApplePie";
        }
        ToneFan = "0:" + Airy_AP;
        //判断运营商信息
        if (LopColeJar.instance.SaveMint != null && LopColeJar.instance.SaveMint.IsHaveApple)
        {
            Airy_AP = "A";
            if (string.IsNullOrEmpty(Myxoma))
                Myxoma = "HaveApple";
            ToneFan += "1:" + Airy_AP;
        }
        if (LopColeJar.instance.EruptPalm != null)
        {
            //判断经纬度
            LocationData[] LocationDatas = LopColeJar.instance.EruptPalm.LocationList;
            if (LocationDatas != null && LocationDatas.Length > 0 && LopColeJar.instance.SaveMint != null && LopColeJar.instance.SaveMint.lat != 0 && LopColeJar.instance.SaveMint.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = LawSalinity((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)LopColeJar.instance.SaveMint.lat, (float)LopColeJar.instance.SaveMint.lon);
                    Unpopular += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Airy_AP = "A";
                        if (string.IsNullOrEmpty(Myxoma))
                            Myxoma = "Location";
                        break;
                    }
                }
            }
            ToneFan += "2:" + Airy_AP;
            //判断城市
            string[] HeiCityList = LopColeJar.instance.EruptPalm.CityList;
            if (!string.IsNullOrEmpty(LopColeJar.instance.SaveMint.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == LopColeJar.instance.SaveMint.regionName
                    || HeiCityList[i] == LopColeJar.instance.SaveMint.city)
                    {
                        Airy_AP = "A";
                        if (string.IsNullOrEmpty(Myxoma))
                            Myxoma = "City";
                        break;
                    }
                }
            }
            ToneFan += "3:" + Airy_AP;
            //判断黑名单
            string[] HeiIPs = LopColeJar.instance.EruptPalm.IPList;
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(LopColeJar.instance.SaveMint.query))
            {
                string[] IpNums = LopColeJar.instance.SaveMint.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Airy_AP = "A";
                        if (string.IsNullOrEmpty(Myxoma))
                            Myxoma = "IP";
                        break;
                    }
                }
            }
            ToneFan += "4:" + Airy_AP;
        }
        //判断自然量
        if (!string.IsNullOrEmpty(LopColeJar.instance.EruptPalm.fall_down))
        {
            // if (LopColeJar.instance.BlockRule.fall_down == "bottom") //仅判断Organic
            // {
            //     if (Adjust_TrackerName == "Organic") //打开自然量 且 归因渠道是Organic 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
            // else if (LopColeJar.instance.BlockRule.fall_down == "down") //判断Organic + NoUserConsent
            // {
            //     if (Adjust_TrackerName == "Organic" || Adjust_TrackerName == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
        }
        ToneFan += "5:" + Airy_AP;

        PlayerPrefs.SetString("Save_AP", Airy_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);

        //打点
        if (!string.IsNullOrEmpty(AiryMintStrange.GetString(CTedium.Dy_UtterHamperWe)))
            TangLatin();
    }
    static float LawSalinity(float lat1, float lon1, float lat2, float lon2) //判断玩家是否在区域内
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void TangLatin() //打点 3000是否进审及经纬度和ip等信息  3001是否进审及理由
    {
        //打点
        if (LopColeJar.instance.SaveMint != null)
        {
            string Info1 = "[" + (Airy_AP == "A" ? "审" : "正常") + "] [" + Myxoma + "]";
            string Info2 = "[" + LopColeJar.instance.SaveMint.lat + "," + LopColeJar.instance.SaveMint.lon + "] [" + LopColeJar.instance.SaveMint.regionName + "] [" + Unpopular + "]";
            string Info3 = "[" + LopColeJar.instance.SaveMint.query + "] [Null]";  // [" + Adjust_TrackerName + "]";
            BabyLatinDating.LawLaurasia().TangLatin("3000", Info1, Info2, Info3);
        }
        else
            BabyLatinDating.LawLaurasia().TangLatin("3000", "No UserData");
        BabyLatinDating.LawLaurasia().TangLatin("3001", (Airy_AP == "A" ? "审" : "正常"), ToneFan, LopColeJar.instance.MintCall);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }

    // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入 3002打点记录屏蔽原因
    public static bool BoredomEruptFence()
    {
        //测试
        // UIStrange.GetInstance().ShowUIForms(nameof(EruptStand)).GetComponent<EruptStand>().ShowInfo("测试");
        // return true;

        if (Application.platform == RuntimePlatform.Android && LopColeJar.instance.EruptPalm != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            string Myxoma= "";
            string Cole= "";

            if (LopColeJar.instance.EruptPalm.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                {
                    Myxoma += "VPN ";
                    Cole = "Please turn off your VPN, restart the game and try again.";
                }
            }
            if (LopColeJar.instance.EruptPalm.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                {
                    Myxoma += "模拟器 ";
                    Cole = "This game cannot be run on emulators.";
                }
            }
            if (LopColeJar.instance.EruptPalm.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                {
                    Myxoma += "Root ";
                    Cole = "This game cannot be played on rooted devices.";
                }
            }
            if (LopColeJar.instance.EruptPalm.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                {
                    Myxoma += "开发者 ";
                    Cole = "Please switch off Developer Option, restart the game and try again.";
                }
            }
            if (LopColeJar.instance.EruptPalm.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                {
                    Myxoma += "USB ";
                    Cole = "Please switch off USB debugging, restart the game and try again.";
                }
            }
            if (LopColeJar.instance.EruptPalm.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                {
                    Myxoma += "Sim卡 ";
                    Cole = "Please check if the SIM card is inserted, then restart the game and try again.";
                }
            }
            if (!string.IsNullOrEmpty(Cole))
            {
                UIStrange.LawLaurasia().BeatUIHouse(nameof(EruptStand)).GetComponent<EruptStand>().BeatCole(Cole);
                BabyLatinDating.LawLaurasia().TangLatin("3002", Myxoma);
                return true;
            }
        }
        return false;
    }


    public static bool HeTurkic()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool HeSkeletal()
    {
        return Screen.height > Screen.width;
    }

    /// <summary>
    /// UI的本地坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 UtterTrack2ObsessTrack(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为本地坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 ObsessTrack2UtterTrack(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public static Vector2 LawGourdMystiqueAnFearProcedure(RectTransform rectTransform)
    {
        // 从RectTransform开始，逐级向上遍历父级
        Vector2 worldPosition = rectTransform.anchoredPosition;
        for (RectTransform rt = rectTransform; rt != null; rt = rt.parent as RectTransform)
        {
            worldPosition += new Vector2(rt.localPosition.x, rt.localPosition.y);
            worldPosition += rt.pivot * rt.sizeDelta;

            // 考虑到UI元素的缩放
            worldPosition *= rt.localScale;

            // 如果父级不是Canvas，则停止遍历
            if (rt.parent != null && rt.parent.GetComponent<Canvas>() == null)
                break;
        }

        // 将结果从本地坐标系转换为世界坐标系
        return rectTransform.root.TransformPoint(worldPosition);
    }
}
