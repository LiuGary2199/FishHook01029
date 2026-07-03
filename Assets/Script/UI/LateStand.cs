using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LateStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("BtnClose")]    public Button TinDrift;
[UnityEngine.Serialization.FormerlySerializedAs("TaskItemParent")]    public Transform LateKeepSolely;
    
    private List<LateKeep> NeonAgent= new List<LateKeep>();
    
    private Transform mSeatCrane;

    private void Awake()
    {
        LuxuryHop.OrAthensLateLaw += OnGetTask;
        //AddUIEvent(AEventType.UpdateTaskProgress, InitTaskItems);
        LuxuryHop.OrAthensLateCommerce += RailLateAgent;
        TinDrift.onClick.AddListener(() =>
        {StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
            DriftUIBard(GetType().Name);
        });
        NeonAgent = MoistLateAgent();
    }
    private void OnGetTask()
    {
        //AGoldFlayCtrl.GoldFlayAnim(mGoldTrans.gameObject, transform, transform.position, mGoldTrans.position);
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RailLateAgent();
    }

    private void OnDestroy()
    {
        LuxuryHop.OrAthensLateLaw -= OnGetTask;
        LuxuryHop.OrAthensLateCommerce -= RailLateAgent;
    }

    private void RailLateAgent()
    {
        var serverTasks = LopColeJar.instance != null ? LopColeJar.instance.RopeMint?.task_list : null;
        for (int i = 0; i < NeonAgent.Count; i++)
        {
            var taskId = i + 1;
            var progress = LateMental.LawLateCommerce(taskId);
            var taskData = LawLateMintBeWe(serverTasks, taskId);
            var total = taskData != null ? Mathf.Max(1, taskData.target) : 1;
            var gold = taskData != null ? Mathf.Max(0, taskData.rewardGold) : 0;
            NeonAgent[i].Init(taskId, progress, total, gold);
        }
    }

    private static TaskData LawLateMintBeWe(List<TaskData> serverTasks, int taskId)
    {
        if (serverTasks == null || serverTasks.Count == 0)
        {
            return null;
        }

        for (int i = 0; i < serverTasks.Count; i++)
        {
            var task = serverTasks[i];
            if (task != null && task.taskId == taskId)
            {
                return task;
            }
        }

        return null;
    }

    private List<LateKeep> MoistLateAgent()
    {
        var NeonAgent= new List<LateKeep>();
        for (int i = 0; i < LateKeepSolely.childCount; i++)
        {
            var taskItem = LateKeepSolely.GetChild(i).GetComponent<LateKeep>();
            NeonAgent.Add(taskItem);
        }
        return NeonAgent;
    }
}