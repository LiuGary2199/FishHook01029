using System;
using UnityEngine;
using UnityEngine.UI;
using Lofelt.NiceVibrations;

public class AAttractInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("SoundOn")]    public GameObject EnjoyAn;
[UnityEngine.Serialization.FormerlySerializedAs("SoundOff")]    public GameObject EnjoyIcy;
[UnityEngine.Serialization.FormerlySerializedAs("SoundBtn")]    public Button EnjoyAny;
[UnityEngine.Serialization.FormerlySerializedAs("BackGameBtn")]    public Button LawnReapAny;
[UnityEngine.Serialization.FormerlySerializedAs("ReplayBtn")]    public Button GoldenAny;

    private Action AnReapMotion;

    public override void OnCreate()
    {
        base.OnCreate();

        LawnReapAny.onClick.AddListener((() =>
        {
            MidstUI();
        }));
        EnjoyAny.onClick.AddListener((() =>
        {
            Enjoy();
            Extol();
        }));
        GoldenAny.onClick.AddListener(() =>
        {
            MidstUI();
            AnReapMotion?.Invoke();
        });

    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        EnjoyAn.SetActive(A_HavenEarning.Slowness.AtEnjoyAn);
        EnjoyIcy.SetActive(!A_HavenEarning.Slowness.AtEnjoyAn);

        AnReapMotion = LimeErupt.Length > 1 ? LimeErupt[0] as Action : null;
    }

    public void Extol()
    {
        A_HavenEarning.Slowness.HeliumExtol();
    }

    public void Enjoy()
    {
        A_HavenEarning.Slowness.HeliumEnjoy();
        var sound = A_HavenEarning.Slowness.AtEnjoyAn;
        EnjoyAn.SetActive(sound);
        EnjoyIcy.SetActive(!sound);

    }
}
