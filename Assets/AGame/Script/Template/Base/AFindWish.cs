using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AFindWish : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mCompleted")]    public GameObject mTranscend;
[UnityEngine.Serialization.FormerlySerializedAs("mReady")]    public GameObject mYield;
[UnityEngine.Serialization.FormerlySerializedAs("mIncomplete")]    public GameObject mNutritious;
[UnityEngine.Serialization.FormerlySerializedAs("BtnReady")]    public Button AnyYield;
[UnityEngine.Serialization.FormerlySerializedAs("TxtTarget")]    public Text EreBundle;

    private int id;
    private int _Growth;
    private TaskStatus_A _Wholly;
    private bool _AtHaiti;
    public TaskStatus_A Israel    {
        get => _Wholly;
        set
        {
            _Wholly = value;
            mTranscend.SetActive(value == TaskStatus_A.Completed);
            mYield.SetActive(value == TaskStatus_A.Ready);
            mNutritious.SetActive(value == TaskStatus_A.Incomplete);
        }
    }

    private void Awake()
    {
        AnyYield.onClick.AddListener(() =>
        {
            // ����Ƿ������
            if (Israel == TaskStatus_A.Completed)
            {
                return;
            }
            Israel = TaskStatus_A.Completed;
            // �������
            if (_AtHaiti)
            {
                AFindEarning.Slowness.DieFindTranscendHaiti(id);
                AWrongFamous.Port(AWrongSeat.HaitiFindTranscend_A, id);
            }
            else
            {
                AFindEarning.Slowness.DieFindTranscendRarity(id);
                AWrongFamous.Port(AWrongSeat.RarityFindTranscend_A, id);
            }
        });
    }

    public void Cook(bool isDaily, int id, int target)
    {
        this.id = id;
        _Growth = target;
        _AtHaiti = isDaily;

        Israel = isDaily ? AFindEarning.Slowness.JobFindIsraelHaiti(id)
            : AFindEarning.Slowness.JobFindIsraelRarity(id);
        var count = isDaily ? AFindEarning.Slowness.JobHaitiBundleHaste(id)
            : AFindEarning.Slowness.JobRarityBundleHaste(id);

        if (_AtHaiti)
        {
            switch (id)
            {
                case AFindEarning.HaitiCoaxUp_Id:
                    EreBundle.text = $"Daily Check-in ({count}/{_Growth})";
                    break;
                case AFindEarning.HaitiAD_So:
                    EreBundle.text = $"Watch Ads ({count}/{_Growth})";
                    break;
                case AFindEarning.HaitiSteer_So:
                    EreBundle.text = $"Use Stamina ({count}/{_Growth})";
                    break;
                case AFindEarning.HaitiReap_So:
                    EreBundle.text = $"Clear Level ({count}/{_Growth})";
                    break;
            }
        }
        else
        {
            switch (id)
            {
                case AFindEarning.RarityCoaxUp_So:
                    EreBundle.text = $"Daily Check-in ({count}/{_Growth})";
                    break;
                case AFindEarning.RarityAD_So:
                    EreBundle.text = $"Watch Ads ({count}/{_Growth})";
                    break;
                case AFindEarning.RaritySteer_So:
                    EreBundle.text = $"Use Stamina ({count}/{_Growth})";
                    break;
                case AFindEarning.RarityReap_So:
                    EreBundle.text = $"Clear Level ({count}/{_Growth})";
                    break;
            }
        }
    }

}

public enum TaskStatus_A
{
    Completed,
    Ready,
    Incomplete,
}
