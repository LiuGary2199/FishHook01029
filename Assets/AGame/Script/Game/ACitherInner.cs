using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ACitherInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("GoldTxt")]    public Text SpurEre;
[UnityEngine.Serialization.FormerlySerializedAs("GetAD")]    public Button JobAD;
[UnityEngine.Serialization.FormerlySerializedAs("GetNextLevel")]    public Button JobMoonMercy;
    private int City;

    public override void OnCreate()
    {
        base.OnCreate();

        JobAD.onClick.AddListener(() =>
        {
            ADStrange.Laurasia.DungTempleVigor((ok) =>
            {
                if (ok)
                {
                    MidstUI();
                    AReapEarning.Slowness.PlaySpur += City * 2;
                }
                else
                {
                    KingUI<AFuelInner>("No ads right now, please try it later.");
                }
            },"a2");
        });
        JobMoonMercy.onClick.AddListener(() =>
        {
            MidstUI();
            AReapEarning.Slowness.PlaySpur += City;
        });
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        City = (int)LimeErupt[0];
        SpurEre.text = City.ToString();
    }
}
