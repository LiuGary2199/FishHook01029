using DG.Tweening;
using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


/// <summary> 大奖面板 树升级和疯狂模式结束使用  基本逻辑和RewardPanel相同
/// </summary>
public class TempleStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("Gold")]
    public GameObject Seat;
[UnityEngine.Serialization.FormerlySerializedAs("GoldText")]    public TextMeshProUGUI SeatBode;
    double SeatTemple;
[UnityEngine.Serialization.FormerlySerializedAs("Cash")]    public GameObject Coma;
[UnityEngine.Serialization.FormerlySerializedAs("CashText")]    public TextMeshProUGUI ComaBode;
    double ComaTemple;
[UnityEngine.Serialization.FormerlySerializedAs("AdGetBtn")]    public Button SoLawTin;
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    public Button LawTin;
[UnityEngine.Serialization.FormerlySerializedAs("FinishEvent")]    public UnityAction TraderLatin;
[UnityEngine.Serialization.FormerlySerializedAs("RewardShowList")]    public List<GameObject> TempleBeatTall;
    Coroutine TrackBeatLawTin;
[UnityEngine.Serialization.FormerlySerializedAs("m_ShipSkeleton")]    public SkeletonGraphic m_UtahPossible;
[UnityEngine.Serialization.FormerlySerializedAs("rewaobj")]    public GameObject Secrecy;
    string HeWhoeverAD;
    string LatinID;


    void Start()
    {
        m_UtahPossible.AnimationState.Complete += OnShipAnimComplete;
        SoLawTin.onClick.AddListener(() =>
        {
            ADStrange.Laurasia.DungTempleVigor((ok) =>
            {
                if (ok)
                {
                    LineStrange.LawLaurasia().PlumTrack(TrackBeatLawTin);
                    SoLawTin.gameObject.SetActive(false);
                    LawTin.gameObject.SetActive(false);
                    HeWhoeverAD = "1";
                    PredatoryDependably.UnjustSerene(SeatTemple, SeatTemple * 2, 0.1f, SeatBode, null);
                    PredatoryDependably.UnjustSerene(ComaTemple, ComaTemple * 2, 0.1f, ComaBode, null);
                    SeatTemple = SeatTemple * 2;
                    ComaTemple = ComaTemple * 2;
                    LineStrange.LawLaurasia().Track(1f, () =>
                              {

                                  LawTempleSowTangLatinSowDrift();
                              });
                }
            }, LawLatinSlope());
        });
        LawTin.onClick.AddListener(() =>
        {
            HeWhoeverAD = "0";
            SeatTemple = SeatTemple;
            ComaTemple = ComaTemple;
            LineStrange.LawLaurasia().Track(0.5f, () =>
             {

                 LawTempleSowTangLatinSowDrift();
             });
            ADStrange.Laurasia.NoPropelTieRelic();
        });
    }
    public void OnShipAnimComplete(TrackEntry trackEntry)
    {
        if (trackEntry == null || trackEntry.Animation == null) return;
        if (trackEntry.Animation.Name == "start")
        {
            m_UtahPossible.AnimationState.SetAnimation(0, "idle", true);
        }
    }
    public void Rail(RewardData ColdDate, RewardData CashDate, UnityAction FinishEvent, string EventID = "")
    {
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.rewardPanel);
        Secrecy.gameObject.SetActive(false);
        SoLawTin.gameObject.SetActive(false);
        m_UtahPossible.gameObject.SetActive(true);
        m_UtahPossible.Skeleton.SetToSetupPose();
        m_UtahPossible.AnimationState.ClearTracks();
        m_UtahPossible.AnimationState.SetAnimation(0, "start", false);
        LineStrange.LawLaurasia().Track(0.6f, () =>
        {
            SoLawTin.gameObject.SetActive(true);
            Secrecy.gameObject.SetActive(true);
        });

        this.TraderLatin = FinishEvent;
        this.LatinID = EventID;
        if (HappenLack.HeDaunt() && CashDate != null) // 现金换成金币
        {
            ComaTemple = 0;
            if (ColdDate == null)
                ColdDate = new RewardData() { rewardNum = CashDate.rewardNum, type = RewardType.Cash };
            else
                ColdDate.rewardNum += CashDate.rewardNum;
            CashDate = null;
        }
        SeatTemple = ColdDate != null ? ColdDate.rewardNum : 0;
        ComaTemple = CashDate != null ? CashDate.rewardNum : 0;
        Seat.SetActive(false);
        Coma.SetActive(false);
        if (ColdDate != null && ColdDate.rewardNum > 0)
        {
            Seat.SetActive(true);
            PredatoryDependably.UnjustSerene(0, ColdDate.rewardNum, 0.1f, SeatBode, null);
        }
        if (CashDate != null && CashDate.rewardNum > 0)
        {
            Coma.SetActive(true);
            PredatoryDependably.UnjustSerene(0, CashDate.rewardNum, 0.1f, ComaBode, null);
        }
        //AdGetBtn.gameObject.SetActive(true);
        LawTin.gameObject.SetActive(false);
        TrackBeatLawTin = LineStrange.LawLaurasia().Track(2, () =>
        {
            LawTin.gameObject.SetActive(true);
            LawTin.transform.localScale = new Vector3(0, 0, 0);
            LawTin.transform.DOScale(1, 0.2f).SetEase(Ease.OutBack);
        });
        //  StainJar.GetInstance().PlayEffect(StainToll.UIMusic.SFX_BigWin);

    }

    void LawTempleSowTangLatinSowDrift()
    {
        if (SeatTemple > 0)
        {
            LuxuryHop.OrTieExact?.Invoke(null, (int)SeatTemple);
        }
        if (ComaTemple > 0)
        {
            GameObject Icon = TendStand.Instance.m_FallacyTwain.gameObject;
            DOVirtual.DelayedCall(0.7f, () =>
            {
                TendStand.Instance.TieFallacy(ComaTemple);
            });

        }

        TraderLatin?.Invoke();
        TraderLatin = null;
        m_UtahPossible.gameObject.SetActive(false);
        BabyLatinDating.LawLaurasia().TangLatin(LawRopeLatinSlope(),HeWhoeverAD);
        DriftUIBard(nameof(TempleStand));
    }

    string LawLatinSlope()
    {
        if (LatinID == "1004") //树升级
            return "1";
        else if (LatinID == "1006") //fever
            return "2";
        else if (LatinID == "1009") //转盘
            return "3";
        else if (LatinID == "1010") //刮刮卡
            return "4";
        else if (LatinID == "1017") //飞行气泡
            return "11";
        else
            return "0";
    }
     string LawRopeLatinSlope()
    {
        if (LatinID == "1004") //树升级
            return "1005";
        else if (LatinID == "1006") //fever
            return "1007";
        else if (LatinID == "1009") //转盘
            return "3";
        else if (LatinID == "1010") //刮刮卡
            return "4";
        else if (LatinID == "1017") //飞行气泡
            return "11";
        else
            return "0";
    }

    private void OnEnable()
    {
        float Delaytime = 1.5f;
        for (int i = 0; i < TempleBeatTall.Count; i++)
        {
            GameObject item = TempleBeatTall[i];
            item.transform.localScale = Vector3.zero;
            item.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(Delaytime);
            Delaytime += 0.1f;
        }
    }
}
