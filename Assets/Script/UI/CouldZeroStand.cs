using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Spine.Unity;

public class CouldZeroStand : SeedUIHouse
{
    public static CouldZeroStand Instance;
[UnityEngine.Serialization.FormerlySerializedAs("luckyCardList")]    public List<GameObject> PinchZeroTall;
[UnityEngine.Serialization.FormerlySerializedAs("selectObjList")]    public List<GameObject> LoggerTinTall;
[UnityEngine.Serialization.FormerlySerializedAs("rewardMap")]    public Dictionary<RewardType, double> RemainBox;
[UnityEngine.Serialization.FormerlySerializedAs("luckyObjDataList")]    public List<LuckyObjData> PinchTinMintTall;
[UnityEngine.Serialization.FormerlySerializedAs("isLock")]    public bool BeRule;
    private bool BeOver;
[UnityEngine.Serialization.FormerlySerializedAs("onThanksWeight")]    public int ItPropelGeyser;

    private int DrawRelic;
    private int SewTheRelic;
    RewardData Temple;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        SewTheRelic = LopColeJar.instance.RopeMint.lucky_card_win_max_count;
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        AiryMintStrange.SetInt(CTedium.Dy_Fleet_Deterrent, AiryMintStrange.GetInt(CTedium.Dy_Fleet_Deterrent) + 1);
        BabyLatinDating.LawLaurasia().TangLatin("1004");
        ADStrange.Laurasia.EnsueLineOccupational();
        RailCouldZero();
       // StainJar.GetInstance().PlayEffect(StainToll.UIMusic.sound_littlegame_show);
    }
    public override void Hidding()
    {
        base.Hidding();
        ADStrange.Laurasia.NormalLineOccupational();
    }

    private void DriftCouldZeroStand()
    {
        if (!gameObject.activeInHierarchy) return;
        DriftUIBard(GetType().Name);
    }

    public void RailCouldZero()
    {
        CancelInvoke(nameof(DoAct));
        CancelInvoke(nameof(TermRule));

        int maxExclusive = Mathf.Max(3, SewTheRelic);
        DrawRelic = Mathf.Max(2, Random.Range(2, maxExclusive) + 1);
        PinchTinMintTall = new List<LuckyObjData>();
        BeRule = true;
        BeOver = false;
        for (int i = 0; i < PinchZeroTall.Count; i++)
        {
            GameObject obj = PinchZeroTall[i].gameObject;
            if (i == 4)
            {
                obj.GetComponent<LuckyCardController>().InitThanksObjData();
            }
            else
            {
                LuckyObjData objData = GameUtil.GetLuckyCardObjData();
                PinchTinMintTall.Add(objData);
                obj.GetComponent<LuckyCardController>().InitRewardObjData(objData);
            }
        }

        LoggerTinTall = new List<GameObject>();
        RemainBox = new Dictionary<RewardType, double>();

        Invoke(nameof(DoAct), 0.5f);
    }


    private void DoAct()
    {
        for (int i = 0; i < PinchZeroTall.Count; i++)
        {
            GameObject obj = PinchZeroTall[i].gameObject;
            // 避免玩家在 DoAct 执行前已翻开的卡被强制复位翻回去
            if (LoggerTinTall != null && LoggerTinTall.Contains(obj))
                continue;
            obj.GetComponent<LuckyCardController>().CloseObj();
        }
        Invoke(nameof(TermRule), 0.5f);
    }

    private void TermRule()
    {
        BeRule = false;
    }

    private void TieTempleBox(LuckyObjData rewardObj)
    {
        RewardType RemainToll= rewardObj.LuckyObjType;
        if (RemainBox.ContainsKey(RemainToll))
        {
            RemainBox[RemainToll] =
                RemainBox[RemainToll] + rewardObj.RewardNum;
        }
        else
        {
            RemainBox.Add(RemainToll, rewardObj.RewardNum);
        }
    }

    private void BeatPupilStand()
    {
        RemainBox.TryGetValue(RewardType.Diamond, out double diamondTotal);
        Temple = diamondTotal > 0
            ? new RewardData { type = RewardType.Diamond, rewardNum = diamondTotal }
            : null;

       DriftUIBard(nameof(CouldZeroStand));
            UIStrange.LawLaurasia().BeatUIHouse(nameof(TempleStand)).GetComponent<TempleStand>().Rail(null, Temple, 
            ()=>{
                        LuxuryHop.OrSlightRopeLuminous?.Invoke();
            }, "1004");
    }

    public void TieMidwayTall(GameObject obj)
    {
        if (BeRule) return;
        if (BeOver) return;
        if (LoggerTinTall.Contains(obj)) return;

        LoggerTinTall.Add(obj);
        var ctrl = obj.GetComponent<LuckyCardController>();
        if (LoggerTinTall.Count < DrawRelic && !BeOver)
        {
            if (PinchTinMintTall.Count == 0)
            {
                ctrl.PlayAnim();
                ctrl.SetInteractable(false);
            }
            else
            {
                int num = Random.Range(0, PinchTinMintTall.Count);
                LuckyObjData objData = PinchTinMintTall[num];
                ctrl.PlayAnim();
                ctrl.InitRewardObjData(objData, resetAnimToIdle: false);
                TieTempleBox(objData);
                PinchTinMintTall.Remove(objData);
                ctrl.SetInteractable(false);
            }
        }
        else
        {
            BeOver = true;
            BeRule = true;
            Debug.Log($"[LuckyCard] 游戏结束: 已翻牌数={LoggerTinTall.Count}, 目标次数={DrawRelic}, 奖励种类数={RemainBox.Count}");
            ctrl.PlayAnim();
            ctrl.ShowThanksFace();
            ctrl.SetInteractable(false);
            Invoke(nameof(BeatPupilStand), 2f);
        }
    }
}