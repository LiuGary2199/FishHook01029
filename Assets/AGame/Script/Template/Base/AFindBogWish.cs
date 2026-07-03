using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AFindBogWish : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mCompleted")]    public GameObject mTranscend;
[UnityEngine.Serialization.FormerlySerializedAs("mReady")]    public GameObject mYield;
[UnityEngine.Serialization.FormerlySerializedAs("mIncomplete")]    public GameObject mNutritious;
[UnityEngine.Serialization.FormerlySerializedAs("BtnReady")]    public Button AnyYield;
    private int id;
    private int City;
    private bool AtHaiti;
    private TaskBoxStatus_A _Wholly;
    public TaskBoxStatus_A Israel    {
        get => _Wholly;
        set
        {
            _Wholly = value;
            mTranscend.SetActive(value == TaskBoxStatus_A.Completed);
            mYield.SetActive(value == TaskBoxStatus_A.Ready);
            mNutritious.SetActive(value == TaskBoxStatus_A.Incomplete);
        }
    }

    private void Awake()
    {
        AnyYield.onClick.AddListener((() =>
        {
            if (Israel != TaskBoxStatus_A.Ready) return;
            if (AtHaiti)
            {
                AFindEarning.Slowness.DieFindBogTranscendHaiti(id);
            }
            else
            {
                AFindEarning.Slowness.DieFindBogTranscendRarity(id);
            }

            Israel = TaskBoxStatus_A.Completed;
            AReapEarning.Slowness.PlaySpur += City;
        }));
    }

    public void Cook(bool isDaily, int id, int gold)
    {
        this.id = id;
        this.City = gold;
        this.AtHaiti = isDaily;
        Israel = isDaily ? AFindEarning.Slowness.JobFindBogIsraelHaiti(id)
            : AFindEarning.Slowness.JobFindBogIsraelRarity(id);
        Debug.Log(Israel);
    }

}

public enum TaskBoxStatus_A
{
    Completed,
    Ready,
    Incomplete,
}
