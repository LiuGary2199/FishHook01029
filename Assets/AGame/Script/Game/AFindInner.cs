using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AFindInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("BtnClose")]    public Button AnyMidst;
[UnityEngine.Serialization.FormerlySerializedAs("DailyToggle")]    public Toggle HaitiHelium;
[UnityEngine.Serialization.FormerlySerializedAs("DailyView")]    public GameObject HaitiLate;
[UnityEngine.Serialization.FormerlySerializedAs("DailyTaskTrans")]    public Transform HaitiFindShelf;
[UnityEngine.Serialization.FormerlySerializedAs("DailyTaskProgressBar")]    public Image HaitiFindAnteaterLot;
[UnityEngine.Serialization.FormerlySerializedAs("DailyTaskBoxes")]    public List<AFindBogWish> HaitiFindDaily;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyView")]    public GameObject RarityLate;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyTaskTrans")]    public Transform RarityFindShelf;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyTaskProgressBar")]    public Image RarityFindAnteaterLot;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyTaskBoxes")]    public List<AFindBogWish> RarityFindDaily;
[UnityEngine.Serialization.FormerlySerializedAs("DailyLabelOn")]    public GameObject HaitiWhereAn;
[UnityEngine.Serialization.FormerlySerializedAs("DailyLabelOff")]    public GameObject HaitiWhereIcy;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyLabelOn")]    public GameObject RarityWhereAn;
[UnityEngine.Serialization.FormerlySerializedAs("WeeklyLabelOff")]    public GameObject RarityWhereIcy;

    private List<AFindWish> HaitiPitch;
    private List<AFindWish> RarityPitch;

    public override void OnCreate()
    {
        base.OnCreate();
        AnyMidst.onClick.AddListener(MidstUI);

        HaitiHelium.onValueChanged.AddListener((isOn) =>
        {
            HaitiLate.SetActive(isOn);
            RarityLate.SetActive(!isOn);
            HaitiWhereAn.SetActive(isOn);
            RarityWhereAn.SetActive(!isOn);
            HaitiWhereIcy.SetActive(!isOn);
            RarityWhereIcy.SetActive(isOn);
        });

        PutUIWrong<int>(AWrongSeat.HaitiFindTranscend_A, ShroudBogAnteater);
        PutUIWrong<int>(AWrongSeat.RarityFindTranscend_A, ShroudBogAnteater);

        HaitiHelium.isOn = true;
    }

    public override void OnRefresh()
    {
        base.OnRefresh();

        HaitiPitch?.Clear();
        HaitiPitch = WharfPitch(HaitiFindShelf);
        RarityPitch?.Clear();
        RarityPitch = WharfPitch(RarityFindShelf);

        for (int i = 0; i < HaitiPitch.Count; i++)
        {
            HaitiPitch[i].Cook(true, i, AFindEarning.Slowness.JobHaitiBundle(i));
        }
        for (int i = 0; i < RarityPitch.Count; i++)
        {
            RarityPitch[i].Cook(false, i, AFindEarning.Slowness.JobRarityBundle(i));
        }

        ShroudBogAnteater(0);

    }

    private void ShroudBogAnteater(int id)
    {
        for (int i = 0; i < HaitiFindDaily.Count; i++)
        {
            HaitiFindDaily[i].Cook(true, i, AFindEarning.Slowness.JobHaitiBogSpur(i));
        }

        for (int i = 0; i < RarityFindDaily.Count; i++)
        {
            RarityFindDaily[i].Cook(false, i, AFindEarning.Slowness.JobRarityBogSpur(i));
        }

        HaitiFindAnteaterLot.fillAmount = AFindEarning.Slowness.HaitiAnteater;
        RarityFindAnteaterLot.fillAmount = AFindEarning.Slowness.RarityAnteater;
    }

    private List<AFindWish> WharfPitch(Transform parent)
    {
        var tasks = new List<AFindWish>();
        foreach (Transform child in parent)
        {
            tasks.Add(child.GetComponent<AFindWish>());
        }
        return tasks;
    }
}
