using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BeneathInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("ADBtn")]    public AUIAlpine ADAny;
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    public AUIAlpine JobAny;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    public Text FootDrip;

    private int ReadWebArgon;
    public override void OnCreate()
    {
        base.OnCreate();
        ADAny.onClick.AddListener(() =>
        {
            ADStrange.Laurasia.DungTempleVigor((ok) =>
            {
                if (ok)
                {
                    MidstUI();
                    AReapEarning.Slowness.PlaySpur += ReadWebArgon * 2;
                }
                else
                {
                    KingUI<AFuelInner>("No ads right now, please try it later.");
                }

            }, "a3");
        });
        JobAny.onClick.AddListener(() =>
            {
                MidstUI();
                AReapEarning.Slowness.PlaySpur += ReadWebArgon;
            });
        }
    public override void OnRefresh()
    {
        base.OnRefresh();
        ReadWebArgon = (int)LimeErupt[0];
        FootDrip.text = ReadWebArgon.ToString();
    }
}


