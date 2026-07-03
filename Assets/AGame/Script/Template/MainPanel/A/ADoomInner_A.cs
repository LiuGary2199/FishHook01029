using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏主界面
/// </summary>
public class ADoomInner_A : AUIDrench
{
    public static ADoomInner_A Slowness{ get; private set; }
[UnityEngine.Serialization.FormerlySerializedAs("mGoldBarItem")]
    public ASpurLotWish mSpurLotWish;
[UnityEngine.Serialization.FormerlySerializedAs("mScoreTxt")]    public Text mHenceEre;
[UnityEngine.Serialization.FormerlySerializedAs("mLevelTxt")]    public Text mMercyEre;
[UnityEngine.Serialization.FormerlySerializedAs("mBtnSettings")]    //public Text mHPTxt;
    //public Text mHPTimeTxt;
    //public Button mBtnRank;
    public Button mAnyCreditor;
[UnityEngine.Serialization.FormerlySerializedAs("mBtnSignIn")]    //public Button mBtnShop;
    public Button mAnyCoaxUp;
[UnityEngine.Serialization.FormerlySerializedAs("mBtnTask")]    public Button mAnyFind;
[UnityEngine.Serialization.FormerlySerializedAs("BtnPlay")]    //public Button mBtnMission;
    //public Button BtnAchievement;
    public AUIAlpine AnyBulk;
    //public Button BtnBuyHP;

    private int OnClumpSo= 0;
        
    public override void OnCreate()
    {
        base.OnCreate();
        
        //mBtnRank.onClick.AddListener(OnRankClick);
        mAnyCreditor.onClick.AddListener(OnSettingsClick);
        //mBtnShop.onClick.AddListener(OnShopClick);
        mAnyCoaxUp.onClick.AddListener(OnSignInClick);
        mAnyFind.onClick.AddListener(OnTaskClick);
        //mBtnMission.onClick.AddListener(OnMissionClick);
        //BtnAchievement.onClick.AddListener(OnAchievementClick);
        AnyBulk.onClick.AddListener(OnPlayClick);
        //BtnBuyHP.onClick.AddListener(OnBuyHPClick);

        PutUIWrong<int>(AWrongSeat.WeightMercy, OnLevelChange);
        //PutUIWrong<int>(AWrongSeat.ChangeHP, OnHPChange);
        
    }

    //private void OnHPChange(int obj)
    //{
    //    //BtnBuyHP.gameObject.SetActive(AReapEarning.Instance.CurrHP < AReapEarning.MAX_HP);
    //    mHPTxt.text = AReapEarning.Instance.CurrHP.ToString();

    //    if (AReapEarning.Instance.CurrHP == AReapEarning.MAX_HP)
    //    {
    //        mHPTimeTxt.gameObject.SetActive(false);
    //        RemoveTimer(hpTimerId);
    //        hpTimerId = 0;
    //    }
    //    else
    //    {
    //        mHPTimeTxt.gameObject.SetActive(true);
    //        ShowHpTime();
    //        RemoveTimer(hpTimerId);
    //        hpTimerId = AddTimer((args =>
    //        {
    //            ShowHpTime();
    //        }), 1f, true);
    //    }
    //}

    //private void ShowHpTime()
    //{
    //    var time = DateTime.UtcNow;
    //    var lastHpTime = DateTime.Parse(PlayerPrefs.GetString(AConserve.ArchiveKey.RTOHPTime, DateTime.MinValue.ToString()));
    //    var delta = time - lastHpTime;
    //    var hpCount = (int)(delta.TotalSeconds / AReapEarning.RTO_HP);
    //    if (hpCount > 0)
    //    {
    //        AReapEarning.Instance.CurrHP += hpCount;
    //    }
    //    var newTime = AReapEarning.RTO_HP - (int)delta.TotalSeconds % AReapEarning.RTO_HP;
    //    mHPTimeTxt.text = $"{(newTime / 60):00}:{(newTime % 60):00}";
    //}

    //private void OnBuyHPClick()
    //{
    //     KingUI<ARevivePanel>(3, 200);
    //}

    private void OnLevelChange(int obj)
    {
        mMercyEre.text = $"Level {AReapEarning.Slowness.PlayMercy}";
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        
        mHenceEre.text = AReapEarning.Slowness.KingHence.ToString();
        mMercyEre.text = $"Level {AReapEarning.Slowness.PlayMercy}";
        //OnHPChange(5);
    }

    private void OnSettingsClick()
    {
        KingUI<AAttractInner>();
    }

    //private void OnShopClick()
    //{
    //    throw new System.NotImplementedException();
    //}

    private void OnSignInClick()
    {
         KingUI<ACoaxUpInner>(mSpurLotWish.CityFootLondon);
    }

    private void OnTaskClick()
    {
        KingUI<AFindInner>(mSpurLotWish.CityFootLondon);
    }

    private void OnPlayClick()
    {
        var btn = AnyBulk as AUIAlpine;
        btn.SoRich = !btn.SoRich;
        MidstUI();
         KingUI<AReapInner_A>();
    }

    public void AgeFoot(Transform StartPostion, int gold, Action finish = null)
    {
        mSpurLotWish.SpurEyeballHalf(StartPostion.position, () => {
            if (finish != null)
            {
                finish();
            }
            AReapEarning.Slowness.PlaySpur += gold;
        });
    }
}