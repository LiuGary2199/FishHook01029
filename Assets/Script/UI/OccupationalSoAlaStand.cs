using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary> 插屏广告前奖励提示 </summary>
public class OccupationalSoAlaStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("Cahnobj")]    public GameObject Acetate;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondObj")]    public GameObject FallacyObj;
[UnityEngine.Serialization.FormerlySerializedAs("NumText")]    public Text WadBode;
    RewardData Mint;


    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RopeStrange.Instance?.EnsueBenignRejection();
        Mint = MoodLack.LawTempleMintBeGeyserSowDegas(LopColeJar.instance.RopeMint.interAdReward);
        if (Mint.type == RewardType.Cash)
        {
            Acetate.SetActive(true);
            FallacyObj.SetActive(false);
        }
        else if (Mint.type == RewardType.Diamond)
        {
            Acetate.SetActive(false);
            FallacyObj.SetActive(true);
        }
        WadBode.text = Mint.rewardNum.ToString("F2");
    }

    public override void Hidding()
    {
        base.Hidding();
        RopeStrange.Instance?.NormalBenignRejection();
        if (Mint.type == RewardType.Cash)
        {
            // GamePanel.Instance.AddTreeMoney(Data.num);
            LuxuryHop.OrTieExact?.Invoke(null, (int)Mint.rewardNum);
        }
        else if (Mint.type == RewardType.Diamond)
        {
            //ZJT_Manager.GetInstance().AddMoney(Data.num);
            //TendStand.Instance.AddDiamond(Data.rewardNum);
            DOVirtual.DelayedCall(0.7f, () =>
            {
                TendStand.Instance.TieFallacy(Mint.rewardNum);
            });
        }
    }
}

