/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using LitJson;
using UnityEngine;
using UnityEngine.Playables;
//using MoreMountains.NiceVibrations;

public class LopColeJar : MonoBehaviour
{
    public static LopColeJar instance;
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("BaseUrl")]    //base
    public string SeedMaw;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string SeedReuseMaw;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string SeedTediumMaw;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string SeedLineMaw;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string SeedSqueakMaw;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string RopeKnow= "20000";
[UnityEngine.Serialization.FormerlySerializedAs("Surpass")]
    //channel渠道平台
#if UNITY_IOS
    public string Surpass = "AppStore";
#elif UNITY_ANDROID
    public string Surpass= "GooglePlay";
#else
    public string Surpass = "Other";
#endif
    //工程包名
    private string CuratorCoin{ get { return Application.identifier; } }
    //登录url
    private string ReuseMaw= "";
    //配置url
    private string TediumMaw= "";
    //更新AdjustId url
    private string SqueakMaw= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Referee= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public ServerData TediumMint;
[UnityEngine.Serialization.FormerlySerializedAs("GameData")]    //提现相关后台数据
#if ZT
    public CashOutData CashOut_Data;
#endif
#if JT
    public JT_CashOutData JT_CashOut_Data;
#endif
    //服务器Config数据
    public GameDatas RopeMint;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init RailMint;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    //ADStrange
    public GameObject IfStrange;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Head;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Beg;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Free;
    int Plank_Voice= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    
    public bool Plank= false;

[UnityEngine.Serialization.FormerlySerializedAs("BlockRule")]    //ios 获取idfa函数声明
  public BlockRuleData EruptPalm;
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void getIDFA();
#endif

    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string MintCall; //数据来源 打点用
[UnityEngine.Serialization.FormerlySerializedAs("List_SignInData")]
    //签到奖励
    public List<List<RewardData>> Tall_PackAnMint= new List<List<RewardData>>();
    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        ReuseMaw = SeedReuseMaw + RopeKnow + "&channel=" + Surpass + "&version=" + Application.version;
        TediumMaw = SeedTediumMaw + RopeKnow + "&channel=" + Surpass + "&version=" + Application.version;
        SqueakMaw = SeedSqueakMaw + RopeKnow;
    }
    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            AiryMintStrange.SetString("idfv", idfv);
#endif
        }
        else
        {
            Reuse();           //编辑器登录
        }
        //获取config数据
        LawTediumMint();

        //提现登录
        ZJT_Manager.LawLaurasia().Login();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void gaidAction(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Head = gaid_str;
        if (Head == null || Head == "")
        {
            Head = AiryMintStrange.GetString("gaid");
        }
        else
        {
            AiryMintStrange.SetString("gaid", Head);
        }
        Plank_Voice++;
        if (Plank_Voice == 2)
        {
            Reuse();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void aidAction(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Beg = aid_str;
        if (Beg == null || Beg == "")
        {
            Beg = AiryMintStrange.GetString("aid");
        }
        else
        {
            AiryMintStrange.SetString("aid", Beg);
        }
        Plank_Voice++;
        if (Plank_Voice == 2)
        {
            Reuse();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void idfaSuccess(string message)
    {
        Debug.Log("idfa success:" + message);
        Free = message;
        AiryMintStrange.SetString("idfa", Free);
        Reuse();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void idfaFail(string message)
    {
        Debug.Log("idfa fail");
        Free = AiryMintStrange.GetString("idfa");
        Reuse();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Reuse()
    {
        //获取本地缓存的Local用户ID
        string localId = AiryMintStrange.GetString(CTedium.Dy_UtterSaveWe);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            AiryMintStrange.SetString(CTedium.Dy_UtterSaveWe, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = ReuseMaw + "&" + "randomKey" + "=" + localId + "&idfa=" + Free + "&packageName=" + CuratorCoin;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = ReuseMaw + "&" + "randomKey" + "=" + localId + "&gaid=" + Head + "&androidId=" + Beg + "&packageName=" + CuratorCoin;
        }
        else //编辑器
        {
            url = ReuseMaw + "&" + "randomKey" + "=" + localId + "&packageName=" + CuratorCoin;
        }

        //获取国家信息
        LawVoyager(() =>
        {
            url += "&country=" + Referee;
            //登录请求
            LopTombStrange.LawLaurasia().CiteLaw(url,
                (data) =>
                {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    AiryMintStrange.SetString("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    AiryMintStrange.SetString(CTedium.Dy_UtterHamperWe, serverUserData.data.ToString());

                    TangSqueakRely();

                    if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(HappenLack.ToneFan))
                        HappenLack.TangLatin();
                },
                () =>
                {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void LawVoyager(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Referee))
        {
            LopTombStrange.LawLaurasia().CiteLaw("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Referee = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Referee);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
            },
            () =>
            {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Referee = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void LawTediumMint()
    {
        Debug.Log("GetConfigData:" + TediumMaw);
        //获取并存入Config
        LopTombStrange.LawLaurasia().CiteLaw(TediumMaw,
        (data) =>
        {
            MintCall = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            AiryMintStrange.SetString("OnlineData", data.downloadHandler.text);
            DueTediumMint(data.downloadHandler.text);
        },
        () =>
        {
            Debug.Log("ConfigData 失败");
            LawReferentMint();
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void LawReferentMint()
    {
        //是否有缓存
        if (AiryMintStrange.GetString("OnlineData") == "" || AiryMintStrange.GetString("OnlineData").Length == 0)
        {
            MintCall = "LocalData_Updated"; //已联网更新过的数据
            Debug.Log("本地数据");
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            DueTediumMint(json.text);
        }
        else
        {
            MintCall = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            DueTediumMint(AiryMintStrange.GetString("OnlineData"));
        }
    }

    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void DueTediumMint(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (TediumMint == null)
        {
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            TediumMint = rootData.data;
            string GameDataStr = BerlinPathMint(TediumMint.GameData); //处理json数据中，枚举和字符串转换问题
            RopeMint = JsonMapper.ToObject<GameDatas>(GameDataStr);
            RailMint = JsonMapper.ToObject<Init>(TediumMint.init);

            if (!string.IsNullOrEmpty(TediumMint.BlockRule))
                EruptPalm = JsonMapper.ToObject<BlockRuleData>(TediumMint.BlockRule);
#if ZT
            if (!string.IsNullOrEmpty(TediumMint.CashOut_Data))
                CashOut_Data = JsonMapper.ToObject<CashOutData>(TediumMint.CashOut_Data);
#endif

#if JT
            if (!string.IsNullOrEmpty(ConfigData.JT_CashOut_Data))
            {
                JT_CashOut_Data = JsonMapper.ToObject<JT_CashOutData>(ConfigData.JT_CashOut_Data);
                ZJT_Manager.GetInstance().Init();
            }
#endif

            //GameReady();
            LawSaveCole();
        }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void RopeCrawl()
    {
        //打开admanager
        IfStrange.SetActive(true);
        //进度条可以继续
        Plank = true;
        RopeMintStrange.LawLaurasia().RailTediumMint(RopeMint, TediumMint.fish_config);
    }

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void TangSqueakRely()
    {
        string serverId = AiryMintStrange.GetString(CTedium.Dy_UtterHamperWe);
        string adjustId = SqueakRailStrange.Instance.LawSqueakRely();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = SqueakMaw + "&serverId=" + serverId + "&adid=" + adjustId;
        LopTombStrange.LawLaurasia().CiteLaw(url,
            (data) =>
            {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () =>
            {
                Debug.Log("服务器更新adjust adid 失败");
            });
    }
[UnityEngine.Serialization.FormerlySerializedAs("UserDataStr")]

    //获取用户信息
    public string SaveMintNss= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData SaveMint;
    int LawSaveColeRelic= 0;
    void LawSaveCole()
    {
        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES")
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            RopeCrawl();
            return;
        }

        //检查归因渠道信息
        //CheckAdjustNetwork();
        //获取用户信息
        string CheckUrl = SeedMaw + "/api/client/user/checkUser";
        LopTombStrange.LawLaurasia().CiteLaw(CheckUrl,
        (data) =>
        {
            SaveMintNss = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + SaveMintNss);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(SaveMintNss);
            SaveMint = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (SaveMintNss.Contains("apple")
            || SaveMintNss.Contains("Apple")
            || SaveMintNss.Contains("APPLE"))
                SaveMint.IsHaveApple = true;
            RopeCrawl();
        }, () => { });
        Invoke(nameof(ReLawSaveCole), 1);
    }
    void ReLawSaveCole()
    {
        if (!Plank)
        {
            LawSaveColeRelic++;
            if (LawSaveColeRelic < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + LawSaveColeRelic);
                LawSaveCole();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                RopeCrawl();
            }
        }
    }
  
       public string BerlinPathMint(string jsonData)
   {
       jsonData = jsonData.Replace("\"type\": \"diamond\"", "\"type\":2"); 
       jsonData = jsonData.Replace("\"type\": \"cash\"", "\"type\":1"); 
       return jsonData;
   }
    public void RailPackAnMint()
    {
        Tall_PackAnMint.Clear();
        for (int i = 0; i < RopeMint.dailydatelist.Count; i++)
        {
            List<RewardData> list = new List<RewardData>();
            for (int j = 0; j < RopeMint.dailydatelist[i].Count; j++)
            {
                double num = RopeMint.dailydatelist[i][j].rewardNum;
                //num *= (int)InitData.gold_group[0].multi;
                var data = new RewardData();
                data.rewardNum = num;
                data.type = RewardType.Diamond;
                list.Add(data);
            }
            Tall_PackAnMint.Add(list);
        }
    }
}
