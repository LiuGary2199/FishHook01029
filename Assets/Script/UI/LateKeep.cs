using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LateKeep : MonoBehaviour
{
    //已完成
    public GameObject mCompleted;
    //可领取
    public GameObject mReady;
    //未达成
    public GameObject mIncomplete;
    //已领取
    public GameObject mFinish;
    public Button BtnCompleted;
    public Button BtnReady;
    public Text TaskText;
    public Text GoldText;
    public Text ProgressText;
    public Image ProgressImage;
    public int ProgressNum;
    public int Total;
    public int Gold;
    public int TaskId;
            public GameObject cashImage;
    public GameObject DiamondImage;
    private TaskStatus _status;
    public TaskStatus Status
    {
        get => _status;
        set
        {
            _status = value;
            mCompleted.SetActive(value == TaskStatus.Completed);
            mReady.SetActive(value == TaskStatus.Ready);
            mIncomplete.SetActive(value == TaskStatus.Incomplete);
            if (mFinish != null)
                mFinish.SetActive(value == TaskStatus.Get);
            LateMental.DueLateRavage(TaskId, _status);
        }
    }

    private void Awake()
    {
        BtnCompleted.onClick.AddListener(() =>
        {StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            if (Status != TaskStatus.Completed) return;
            ADStrange.Laurasia.DungTempleVigor((ok) =>
            {
                if (ok)
                {
                         BabyLatinDating.LawLaurasia().TangLatin("1014", "1");
                    Status = TaskStatus.Ready;
                }
            }, "6");
        });
        
        BtnReady.onClick.AddListener((() =>
        {StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            if (Status != TaskStatus.Ready) return;

            DOVirtual.DelayedCall(0.7f, () =>
            {
                 if(HappenLack.HeDaunt())
            {
                LuxuryHop.OrTieExact?.Invoke(null, (int)Gold);
            }else
            {
         TendStand.Instance.TieFallacy(Gold, this.transform);
            }

              
            });
            Status = TaskStatus.Get;
            LuxuryHop.OrAthensLateLaw.Invoke();
            //AEventModule.Send(AEventType.TaskGet_B);
        }));
        
    }

    public void Init(int taskId, int progressNum, int total, int gold)
    {
        if(HappenLack.HeDaunt())
        {
            cashImage.SetActive(true);
            DiamondImage.SetActive(false);
        }
        else
        {
            cashImage.SetActive(false);
            DiamondImage.SetActive(true);
        }
        TaskId = taskId;
        ProgressNum = progressNum;
        Total = total;
        //ProgressText.text = $"{ProgressNum}/{Total}";
        ProgressImage.fillAmount = (float)ProgressNum / Total;
        Gold = gold;
        GoldText.text = $"X{Gold}";
        switch (taskId)
        {
            case LateMental.LateWe_1:
                TaskText.text = $"Complete Daily Check-in ({ProgressNum}/{Total})";
                break;
            case LateMental.LateWe_2:
                TaskText.text = $"Defeat Boss ({ProgressNum}/{Total}) Time";
                break;
            case LateMental.LateWe_3:
                TaskText.text = $"Watch ({ProgressNum}/{Total}) Ads in Total";
                break;
            case LateMental.LateWe_4:
                TaskText.text = $"Fire ({ProgressNum}/{Total}) Times in Total";
                break;
        }
        UpdateState();
    }

    public void UpdateState()
    {
        var cacheState = LateMental.LawLateRavage(TaskId);
        if (cacheState == TaskStatus.Incomplete)
        {
            Status = ProgressNum >= Total ? TaskStatus.Completed : TaskStatus.Incomplete;
            
        }
        else
        {
            Status = cacheState;
        }
    }
    
}

public enum TaskStatus
{
    Completed,
    Ready,
    Incomplete,
    Get,
}
