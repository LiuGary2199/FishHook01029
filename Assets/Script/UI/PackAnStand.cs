using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PackAnStand : SeedUIHouse
{
    // 常量定义
    private const int MAX_SIGN_DAYS= 7;
    private const float REWARD_DELAY= 0.5f;

    [Header("UI Components")]
[UnityEngine.Serialization.FormerlySerializedAs("list_Reward")]    public List<PackTempleKeep> Loam_Temple;
[UnityEngine.Serialization.FormerlySerializedAs("claimButton")]    public Button RelaxCourse;

    [Header("Private Fields")]
    /// <summary>
    /// 已经签到的天数
    /// </summary>
    private int OasisTray= 0;
    private int BetFenceSlope= 0;
    private bool BeFence= false;
    
    [Header("Settings")]
[UnityEngine.Serialization.FormerlySerializedAs("hideUnlockedRewards")]    /// <summary>
    /// 是否隐藏未解锁的奖励金额（显示为"？？？"）
    /// </summary>
    public bool WoodEnormousDweller= true;
[UnityEngine.Serialization.FormerlySerializedAs("closebtn")]
    public Button Vertical;
    private Tween Maser;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        try
        {
            RailAngryHeAskFence();
            TempleStandRail();
            RailPackAnStand();
        }
        catch (Exception e)
        {
            Debug.LogError($"PackAnStand Display error: {e.Message}");
        }
    }

    void Start()
    {
        if (RelaxCourse != null)
        {
            RelaxCourse.onClick.AddListener(OnClaimClick);
        }
        else
        {
            Debug.LogError("PackAnStand: claimButton is null!");
        }
        Vertical.onClick.AddListener(() =>
        {
            Maser?.Kill();
            UIStrange.LawLaurasia().DriftIDCrouchUIHouse(this.GetType().Name);
        });
    }

    /// <summary>
    /// 签到按钮点击事件
    /// </summary>
    private void OnClaimClick()
    {
        if (!AskErupt())
            return;

        try
        {
           ADStrange.Laurasia.DungTempleVigor((success) =>
        {
            if (success)
            {
                BabyLatinDating.LawLaurasia().TangLatin("1013", "1");
                // 播放音效
                // StainJar.GetInstance().PlayEffect(StainToll.UIMusic.Sound_Progress_Box);
                OasisTray++;
            Debug.Log($"After checkNums++: checkNums={OasisTray}");
            LateMental.TieLateCommerce(LateMental.LateWe_1, 1);
            // 先保存签到数据
            DueFenceMint();
            Debug.Log($"After SetCheckData: checkNums={OasisTray}");

            // 重新检查今天是否可签到（确保状态一致）
            RailAngryHeAskFence();
            Debug.Log($"After InitTodayIsCanCheck: checkNums={OasisTray}, isCheck={BeFence}");

            // 更新UI状态
            TempleStandRail();
            StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            // 获取奖励
            LawEruptTemple();
               
            }
        }, "5");           
        }
        catch (Exception e)
        {
            Debug.LogError($"OnClaimClick error: {e.Message}");
        }
    }

    /// <summary>
    /// 检查是否可以领取奖励
    /// </summary>
    private bool AskErupt()
    {
        if (OasisTray >= MAX_SIGN_DAYS)
        {
            Debug.Log("已达到最大签到天数");
            return false;
        }

        if (!BeFence)
        {
            Debug.Log("今天已经签到过了");
            UIStrange.LawLaurasia().BeatUIHouse(nameof(Japan),"Reward Claimed");
            return false;
        }

        return true;
    }

    /// <summary>
    /// 修改奖励领取状态
    /// </summary>
    private void TempleStandRail()
    {
        if (LopColeJar.instance == null)
        {
            Debug.LogError("LopColeJar.instance is null!");
            return;
        }

        LopColeJar.instance.RailPackAnMint();
        List<List<RewardData>> list = LopColeJar.instance.Tall_PackAnMint;

        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("SignIn data list is empty");
            return;
        }

        for (int i = 0; i < Loam_Temple.Count && i < list.Count; i++)
        {
            if (Loam_Temple[i] != null)
            {
                bool isClaimed = i < OasisTray;           // 是否已领取
                bool isAvailable = false;                 // 是否可领取
                bool isLastDay = i == MAX_SIGN_DAYS - 1;  // 是否是最后一天
                bool shouldHideReward = false;            // 是否应该隐藏奖励金额

                // 只有当前可签到的一天才能领取
                if (i == OasisTray && BeFence)
                {
                    isAvailable = true;
                }

                // 判断是否应该隐藏奖励金额
                if (WoodEnormousDweller)
                {
                    // 隐藏条件：不是已领取的 && 不是当前可领取的 && 不是最后一天
                    shouldHideReward = !isClaimed && !isAvailable && !isLastDay;
                }

                // 添加调试信息
                Debug.Log($"Day {i}: checkNums={OasisTray}, isCheck={BeFence}, isClaimed={isClaimed}, isAvailable={isAvailable}, isLastDay={isLastDay}, shouldHideReward={shouldHideReward}");

                Loam_Temple[i].SetClaimedState(isClaimed);
                Loam_Temple[i].SetRewardData(list[i], isAvailable, shouldHideReward);
            }
        }
    }

    private void LawEruptTemple()
    {
        // 获取奖励之后刷新界面
        // InitTodayIsCanCheck(); // 已经在OnClaimClick中调用了，这里不需要重复调用
        StartCoroutine(LawTemple());
    }

    IEnumerator LawTemple()
    {
        yield return new WaitForSeconds(REWARD_DELAY);

        List<List<RewardData>> list = LopColeJar.instance.Tall_PackAnMint;
        RewardData panelData = new RewardData();
        RewardData rewardData = list[BetFenceSlope - 1][0];
        double rewardValue = rewardData.rewardNum;
        DOVirtual.DelayedCall(0.7f, () =>
        {
            if(HappenLack.HeDaunt())
            {
                LuxuryHop.OrTieExact?.Invoke(null, (int)rewardValue);
            }else
            {
                TendStand.Instance.TieFallacy(rewardValue, this.transform);
            }
        });

       

        Maser = DOVirtual.DelayedCall(0.3f, () =>
        {
            Maser?.Kill();
            UIStrange.LawLaurasia().DriftIDCrouchUIHouse(this.GetType().Name);
        });
    }

    /// <summary>
    /// 检查今天是否可签到
    /// </summary>
    public void RailAngryHeAskFence()
    {
        try
        {
            int[] checkDay = AiryMintStrange.GetIntArray("CheckDay");
            OasisTray = AiryMintStrange.GetInt("CheckNum");
            BetFenceSlope = OasisTray;

            DateTime dateTime = DateTime.Now;
            int[] time = new int[3] { dateTime.Year, dateTime.Month, dateTime.Day };

            if (checkDay == null || checkDay.Length == 0)
            {
                BeFence = true;
                Debug.Log("First time signing in, isCheck = true");
            }
            else
            {
                DateTime dt1 = new DateTime(checkDay[0], checkDay[1], checkDay[2]);
                DateTime dt2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                TimeSpan span = dt2.Subtract(dt1);

                BeFence = span.Days > 0;

                Debug.Log($"Last check: {dt1}, Today: {dt2}, Days difference: {span.Days}, isCheck: {BeFence}");

                // 如果超过7天，重置签到计数
                if (BeFence && OasisTray >= MAX_SIGN_DAYS)
                {
                    OasisTray = 0;
                    AiryMintStrange.SetInt("CheckNum", OasisTray);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"InitTodayIsCanCheck error: {e.Message}");
            BeFence = false;
        }
    }

    /// <summary>
    /// 保存签到数据
    /// </summary>
    public void DueFenceMint()
    {
        try
        {
            AiryMintStrange.SetInt("CheckNum", OasisTray);
            DateTime dateTime = DateTime.Now;
            int[] time = new int[3] { dateTime.Year, dateTime.Month, dateTime.Day };
            AiryMintStrange.SetIntArray("CheckDay", time);
        }
        catch (Exception e)
        {
            Debug.LogError($"SetCheckData error: {e.Message}");
        }
    }

    public void RailPackAnStand()
    {
        if (LopColeJar.instance == null || LopColeJar.instance.Tall_PackAnMint == null)
        {
            Debug.LogError("SignIn data not available");
            return;
        }

        List<List<RewardData>> list = LopColeJar.instance.Tall_PackAnMint;

        for (int i = 0; i < list.Count && i < Loam_Temple.Count; i++)
        {
            if (Loam_Temple[i] != null)
            {
                bool isClaimed = i < OasisTray;           // 是否已领取
                bool isAvailable = i == OasisTray && BeFence; // 是否可领取
                bool isLastDay = i == MAX_SIGN_DAYS - 1;  // 是否是最后一天
                bool shouldHideReward = false;            // 是否应该隐藏奖励金额

                // 判断是否应该隐藏奖励金额
                if (WoodEnormousDweller)
                {
                    // 隐藏条件：不是已领取的 && 不是当前可领取的 && 不是最后一天
                    shouldHideReward = !isClaimed && !isAvailable && !isLastDay;
                }

                var textlist = Loam_Temple[i].list_Text;
                if (textlist != null)
                {
                    for (int j = 0; j < textlist.Count && j < list[i].Count; j++)
                    {
                        if (textlist[j] != null)
                        {
                            if (shouldHideReward)
                            {
                                textlist[j].text = "xxx";
                            }
                            else
                            {
                                textlist[j].text = list[i][j].rewardNum.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
