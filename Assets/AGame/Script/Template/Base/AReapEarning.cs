using System;
using UnityEngine;

public class AReapEarning : AAuthorizeCriticize<AReapEarning>
{
    #region 金币
    public int PlaySpur    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.PlaySpur, 0);
        set
        {
            if (PlaySpur == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.PlaySpur, value);
            AWrongFamous.Port<int>(AWrongSeat.WeightSpur, value);
        }
    }
    #endregion
    public int PlayPlumb    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.PlayPlumb, Screen.height + 200);
        set
        {
            if (PlayPlumb == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.PlayPlumb, value);
        }
    }
    public int PlayCorpFee    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.PlayCorpFee, 1);
        set
        {
            if (PlayCorpFee == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.PlayCorpFee, value);
        }
    }
    public int PlayCone    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.PlayCone, 10);
        set
        {
            if (PlayCone == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.PlayCone, value);
        }
    }
    public int PlayRichArgon    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.PlayRichArgon, 1);
        set
        {
            if (PlayRichArgon == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.PlayRichArgon, value);
        }
    }

    public int CurrFishPrice
    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.CurrFishPrice, 50);
        set{
            if (CurrFishPrice == value && CurrFishPrice >= 500) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.CurrFishPrice, value);
        }
    }

    public int CurrdepthPrice
    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.CurrDepthPrice, 50);
        set
        {
            if (CurrdepthPrice == value && CurrdepthPrice >= 500) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.CurrDepthPrice, value);
        }
    }
    public int CurrEarnPrice
    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.CurrEarnPrice, 50);
        set
        {
            if (CurrEarnPrice == value && CurrEarnPrice >= 500) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.CurrEarnPrice, value);
        }
    }

    #region 等级
    public int PlayMercy    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.PlayMercy, 1);
        set
        {
            if (PlayMercy == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.PlayMercy, value);
            AWrongFamous.Port<int>(AWrongSeat.WeightMercy, value);
        }
    }
    #endregion
    
    #region 分数
    public int KingHence    {
        get => PlayerPrefs.GetInt(AConserve.ArchiveKey.KingHence, 0);
        set
        {
            if (KingHence == value) return;
            PlayerPrefs.SetInt(AConserve.ArchiveKey.KingHence, value);
            AWrongFamous.Port<int>(AWrongSeat.WeightKingHence, value);
        }
    }
    #endregion
    
    //#region 体力
    //public int CurrHP
    //{
    //    get => PlayerPrefs.GetInt(AConserve.ArchiveKey.CurrHP, MAX_HP);
    //    set
    //    {
    //        if (CurrHP == value) return;
            
    //        value = Mathf.Clamp(value, 0, MAX_HP);
    //        PlayerPrefs.SetInt(AConserve.ArchiveKey.CurrHP, value);
    //        PlayerPrefs.SetString(AConserve.ArchiveKey.RTOHPTime, DateTime.UtcNow.ToString());
    //        AWrongFamous.Port<int>(AWrongSeat.ChangeHP, value);
    //    }
    //}
    
    //public const int MAX_HP = 5;

    //public const int RTO_HP = 15 * 60;
    
    //#endregion

    public void Cook()
    {
        RoamLeisureReal();
        BoldZoology();
        
        AWrongFamous.PutWrong(AWrongSeat.AnReapSpatial, OnGameOutline);
    }

    protected override void OnDestroy()
    {
        AWrongFamous.DealerWrong(AWrongSeat.AnReapSpatial, OnGameOutline);
        base.OnDestroy();
    }

    private void OnGameOutline()
    {
        RoamZoology();
    }

    #region 存档
    public void BoldZoology()
    {
    }
    
    public void RoamZoology()
    {
        Debug.Log("存档");
        PlayerPrefs.Save();
    }
    #endregion
    
    #region 签到

    private void RoamLeisureReal()
    {
        if (!PlayerPrefs.HasKey(AConserve.ArchiveKey.LeisureReal))
        {
            PlayerPrefs.SetString(AConserve.ArchiveKey.LeisureReal, DateTime.Now.ToString("yyyy-MM-dd"));
        }
    }

    #endregion
    
}