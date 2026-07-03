using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.Playables;

public class ShipExpChangeResult
{
    public int BagMagma;
    public int CodMagma;
    public int BagLay;
    public int CodLay;
    public int SpikySoRelic;
    public int NileLay;
    public int FoghornMagmaSoRelic;
}

public enum UIFishCategory
{
    Small = 0,
    Medium = 1,
    Large = 2,
    Boss = 3,
    Ferver = 4,
    SurpriseDiamond = 5,
}

public class RopeMintStrange : MonoSnowstorm<RopeMintStrange>
{
    // Start is called before the first frame update
    public HPConfig m_HPTedium;
    public FerverTimeConfig m_BenignLineTedium;
    [Header("LittleGame（定时随机小游戏/Boss鱼）")]
    public LittleGameConfig m_SlightRopeTedium;
    [Header("KillInching（减速叠加配置）")]
    public KillInchingConfig m_PondPronounTedium;
    [Header("Home Panel Combo")]
    [Tooltip("连击数量达到(严格大于)后显示连击UI")]
    public int m_SwarmBeat= -1;
    [Tooltip("连击数量达到(严格大于)后触发转盘概率旋转")]
    public int m_SwarmGet= -1;
    [Tooltip("发射后下一发钩子生成间隔（秒），来自服务器 HookReloadSeconds，未配置时默认 0.5")]
    public float m_GrayPosterConfine= 0.5f;
    [Header("普通鱼惊喜钻石")]
    [Tooltip("普通模式普通鱼击杀触发“钻石替换奖励”的概率（万分比 0~10000）")]
    public int m_MalletSoonRegionalFallacyCelebrationBps= 0;
    [Tooltip("普通模式普通鱼命中惊喜后发放的钻石数量")]
    public int m_MalletSoonRegionalFallacyRelic= 0;
    [Tooltip("鱼潮刷新间隔（秒），来自服务器 GameData.fish_shoal_cd；<=0 时视为未配置。")]
    public float m_SoonNeverIt= 0f;
    [Header("鱼类型映射（type -> 枚举）")]
    [Tooltip("判定为小鱼的 type（例如 a,b,c）")]
    public string[] m_ForteSoonRayon= new string[] { "a", "b" };
    [Tooltip("判定为中鱼的 type（例如 d,e）")]
    public string[] m_AbruptSoonRayon= new string[] { "d", "e", "c" };
    [Tooltip("判定为大鱼的 type（例如 f,g）")]
    public string[] m_RelaySoonRayon= new string[] { "f", "g" };
    public int[] m_MagmaSoUtah= new int[0];
    private readonly List<FishConfigData> m_SoonGallium= new List<FishConfigData>();
    private readonly List<HomeWheelRewardData> m_TendGiantDweller= new List<HomeWheelRewardData>();

    private int m_UtahMagma= 1;
    private int m_UtahLay= 0;

    public int UtahMagma=> m_UtahMagma;
    // 兼容旧“经验”接口：当前船经验等于当前金币（向下取整并做非负保护）。
    public int UtahLay=> LawBalanceSeatWeUtahLay();
    public List<FishConfigData> SoonGallium=> m_SoonGallium;
    public List<HomeWheelRewardData> TendGiantDweller=> m_TendGiantDweller;

    public UIFishCategory ReplaceSoonUpheaval(string fishType)
    {
        string type = fishType == null ? string.Empty : fishType.Trim().ToLowerInvariant();
        if (string.IsNullOrEmpty(type))
        {
            return UIFishCategory.Small;
        }

        if (type == "z") return UIFishCategory.Boss;
        if (type == "x" || type == "y") return UIFishCategory.Ferver;

        if (BeringiaToll(m_ForteSoonRayon, type)) return UIFishCategory.Small;
        if (BeringiaToll(m_AbruptSoonRayon, type)) return UIFishCategory.Medium;
        if (BeringiaToll(m_RelaySoonRayon, type)) return UIFishCategory.Large;

        // 未配置映射时，普通鱼默认归到小鱼，避免出现未初始化枚举。
        return UIFishCategory.Small;
    }

    private static bool BeringiaToll(string[] types, string target)
    {
        if (types == null || types.Length == 0 || string.IsNullOrEmpty(target))
        {
            return false;
        }

        for (int i = 0; i < types.Length; i++)
        {
            string item = types[i];
            if (string.IsNullOrWhiteSpace(item)) continue;
            if (string.Equals(item.Trim(), target, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    public void RailTediumMint(GameDatas GameData, string fishConfigJson)
    {
        m_HPTedium = GameData.HPConfig;
        m_BenignLineTedium = GameData.FerverTimeConfig;
        m_SlightRopeTedium = GameData.LittleGameconfig;
        m_PondPronounTedium = GameData.KillInchingConfig;
        m_SwarmBeat = Mathf.Max(0, GameData.ComboShow);
        m_SwarmGet = Mathf.Max(0, GameData.ComboRot);
        m_GrayPosterConfine = GameData.HookReloadSeconds > 0f ? GameData.HookReloadSeconds : 0.5f;
        int dps =GameData.surprise_diamond_bps;
        if(HappenLack.HeDaunt())
        {
            dps = 0;
        }
        m_MalletSoonRegionalFallacyCelebrationBps = Mathf.Clamp(dps, 0, 10000);
        m_MalletSoonRegionalFallacyRelic = Mathf.Max(0, GameData.surprise_diamond_count);
        m_SoonNeverIt = Mathf.Max(0f, GameData.fish_shoal_cd);
        m_MagmaSoUtah = GameData.LevelUpShip ?? new int[0];
        RailTendGiantDweller(GameData.HomeWheelrewards);
        MoistSoonTedium(fishConfigJson);
        RopeStrange.Instance.RailGrayTediumOrReuse(GameData.HookHp);
        RopeStrange.Instance.RailBenignOrReuse();
        RailUtahCommerceOrReuse();
        RopeStrange.Instance.RailSailorOrReuse();
        RopeStrange.Instance.RailUtahCommerceOrReuse();
    }

    public int LawMalletSoonRegionalFallacyCelebrationYou()
    {
        return Mathf.Clamp(m_MalletSoonRegionalFallacyCelebrationBps, 0, 10000);
    }

    public int LawMalletSoonRegionalFallacyRelic()
    {
        return Mathf.Max(0, m_MalletSoonRegionalFallacyRelic);
    }

    public float LawSoonNeverIt()
    {
        return Mathf.Max(0f, m_SoonNeverIt);
    }

    private void RailTendGiantDweller(List<HomeWheelRewardData> rewards)
    {
        m_TendGiantDweller.Clear();
        if (rewards == null || rewards.Count == 0)
        {
            return;
        }

        for (int i = 0; i < rewards.Count; i++)
        {
            HomeWheelRewardData r = rewards[i];
            if (r == null || string.IsNullOrEmpty(r.id))
            {
                continue;
            }
            if(HappenLack.HeDaunt())
            {
               r.type = RewardType.Cash;
            }

            m_TendGiantDweller.Add(new HomeWheelRewardData
            {
                id = r.id,
                name = r.name,
                type = r.type,
                count = Mathf.Max(0, r.count),
                probability_bps = Mathf.Max(0, r.probability_bps)
            });
        }
    }

    private void MoistSoonTedium(string fishConfigJson)
    {
        m_SoonGallium.Clear();
        if (string.IsNullOrWhiteSpace(fishConfigJson))
        {
            return;
        }

        try
        {
            List<FishConfigData> parsed = JsonMapper.ToObject<List<FishConfigData>>(fishConfigJson);
            if (parsed != null)
            {
                m_SoonGallium.AddRange(parsed);
            }
        }
        catch (Exception ex)
        {
            Debug.LogWarning("RopeMintStrange fish_config parse failed: " + ex.Message);
        }
    }

    public int LawBalanceMagmaWoadLay()
    {
        return LawWoadLayBeMagma(m_UtahMagma);
    }

    public int LawWoadLayBeMagma(int level)
    {
        if (m_MagmaSoUtah == null || m_MagmaSoUtah.Length == 0)
        {
            return 0;
        }

        int safeLevel = Mathf.Max(1, level);
        int configIndex = Mathf.Clamp(safeLevel - 1, 0, m_MagmaSoUtah.Length - 1);
        return Mathf.Max(1, m_MagmaSoUtah[configIndex]);
    }

    public void RailUtahCommerceOrReuse()
    {
        int localLevel = AiryMintStrange.GetInt(CTedium.Dy_Tool_Spiky);

        m_UtahMagma = Mathf.Max(1, localLevel == 0 ? 1 : localLevel);
        m_UtahLay = LawBalanceSeatWeUtahLay();
        AiryUtahCommerce();
    }

    public ShipExpChangeResult MagmaSoUtahMoss()
    {
        int currentShipExp = LawBalanceSeatWeUtahLay();
        ShipExpChangeResult result = new ShipExpChangeResult
        {
            BagMagma = m_UtahMagma,
            CodMagma = m_UtahMagma,
            BagLay = currentShipExp,
            CodLay = currentShipExp,
            SpikySoRelic = 0,
            NileLay = LawWoadLayBeMagma(m_UtahMagma),
            FoghornMagmaSoRelic = LawFactoryMagmaSoRelic()
        };

        int NileLay= LawWoadLayBeMagma(m_UtahMagma);
        if (NileLay <= 0 || currentShipExp < NileLay)
        {
            return result;
        }

        m_UtahMagma++;
        addComa(-NileLay);
        m_UtahLay = LawBalanceSeatWeUtahLay();
        AiryUtahCommerce();

        result.CodMagma = m_UtahMagma;
        result.CodLay = m_UtahLay;
        result.SpikySoRelic = 1;
        result.NileLay = LawWoadLayBeMagma(m_UtahMagma);
        result.FoghornMagmaSoRelic = LawFactoryMagmaSoRelic();
        return result;
    }

    public int LawFactoryMagmaSoRelic()
    {
        int tempLevel = Mathf.Max(1, m_UtahMagma);
        int tempExp = LawBalanceSeatWeUtahLay();
        int pendingCount = 0;
        int safeCounter = 0;

        while (true)
        {
            int NileLay= LawWoadLayBeMagma(tempLevel);
            if (NileLay <= 0 || tempExp < NileLay)
            {
                break;
            }

            tempExp -= NileLay;
            tempLevel++;
            pendingCount++;

            safeCounter++;
            if (safeCounter > 10000)
            {
                Debug.LogWarning("Ship pending level-up count aborted by safe counter.");
                break;
            }
        }

        return pendingCount;
    }

    public bool AskUtahMagmaSoNow()
    {
        return LawFactoryMagmaSoRelic() > 0;
    }

    private void AiryUtahCommerce()
    {
        AiryMintStrange.SetInt(CTedium.Dy_Tool_Spiky, m_UtahMagma);
        // 兼容旧存档字段：同步写入当前金币映射值，避免历史读取路径出现异常值。
        AiryMintStrange.SetInt(CTedium.Dy_Tool_exp, LawBalanceSeatWeUtahLay());
    }


    // 金币
    public double LawComa()
    {
        return AiryMintStrange.GetDouble(CTedium.Dy_ComaSate);
    }
     public double LawInnovativeComa()
    {
        return AiryMintStrange.GetDouble(CTedium.Dy_InnovativeSeatSate);
    }
    public void addComa(double gold)
    {
        addComa(gold, HangStrange.instance.transform, true);
    }

    public void addComa(double gold, Transform startTransform)
    {
        addComa(gold, startTransform, true);
    }

    /// <param name="refreshHomeGoldText">为 false 时不立刻改首页金币数字（由飞币动画结束后再滚字），避免动画未播完 UI 已跳到最终值。</param>
    public void addComa(double gold, Transform startTransform, bool refreshHomeGoldText)
    {
        double oldGold = AiryMintStrange.GetDouble(CTedium.Dy_ComaSate);
        AiryMintStrange.SetDouble(CTedium.Dy_ComaSate, oldGold + gold);
        if (gold > 0)
        {
            AiryMintStrange.SetDouble(CTedium.Dy_InnovativeSeatSate, AiryMintStrange.GetDouble(CTedium.Dy_InnovativeSeatSate) + gold);
        }
        BurgeonMint md = new BurgeonMint(oldGold);
        md.SheetProcedure = startTransform;
        BurgeonEightyCharm.LawLaurasia().Tang(CTedium.Ax_Up_Woodlot, md);
        m_UtahLay = LawBalanceSeatWeUtahLay();
        // 钱变化即“经验”变化：无论来源是打鱼/任务/奖励，都刷新船升级进度UI。
        if (RopeStrange.Instance != null)
        {
            RopeStrange.Instance.ClusterUtahUIFlipper();
        }
        if (refreshHomeGoldText && TendStand.Instance != null)
        {
            TendStand.Instance.FlipperSeatBode();
        }
#if UNITY_IOS
  if (PlayerPrefs.GetInt("7sfuth") == 0)
        {
            if (AiryMintStrange.GetDouble(CTedium.Dy_InnovativeSeatSate) > 10)
            {
                AIRopeGiftStrange.LawLaurasia().TangLatin("7sfuth");
                PlayerPrefs.SetInt("7sfuth", 1);
            }
        }
#endif


    }

    private int LawBalanceSeatWeUtahLay()
    {
        double gold = AiryMintStrange.GetDouble(CTedium.Dy_ComaSate);
        return Mathf.Max(0, (int)Math.Floor(gold));
    }
    
    // 现金
    public double LawParty()
    {
        return CashOutManager.LawLaurasia().Money;
    }

    public void TinParty(double token)
    {
        CashOutManager.LawLaurasia().AddMoney((float)token);

        double oldToken = PlayerPrefs.HasKey(CTedium.Dy_Token) ? double.Parse(AiryMintStrange.GetString(CTedium.Dy_Token)) : 0;
        double newToken = oldToken + token;
        AiryMintStrange.SetDouble(CTedium.Dy_Token, newToken);
        if (token > 0)
        {
            double allToken = AiryMintStrange.GetDouble(CTedium.Dy_InnovativeParty);
            AiryMintStrange.SetDouble(CTedium.Dy_InnovativeParty, allToken + token);
        }
    }
}
