using System;
using UnityEngine;

public class LateMental
{
    public const int LateWe_1= 1;
    public const int LateWe_2= 2;
    public const int LateWe_3= 3;
    public const int LateWe_4= 4;
    
    /// <summary>
    /// 获取任务进度
    /// </summary>
    /// <returns></returns>
    public static int LawLateCommerce(int taskId)
    {
        var progress = 0;
        var dateTime = DateTime.Now.ToString("yyyy/MM/dd");
        switch (taskId)
        {
            case LateWe_1:
                progress = PlayerPrefs.GetInt($"TaskProgress_{dateTime}_{LateWe_1}", 0);
                break;
            case LateWe_2:
                progress = PlayerPrefs.GetInt($"TaskProgress_{dateTime}_{LateWe_2}", 0);
                break;
            case LateWe_3:
                progress = PlayerPrefs.GetInt($"TaskProgress_{dateTime}_{LateWe_3}", 0);
                break;
            case LateWe_4:
                progress = PlayerPrefs.GetInt($"TaskProgress_{dateTime}_{LateWe_4}", 0);
                break;
        }

        return progress;
    }

    public static void DueLateCommerce(int taskId, int progress)
    {
        var dateTime = DateTime.Now.ToString("yyyy/MM/dd");
        switch (taskId)
        {
            case LateWe_1:
                PlayerPrefs.SetInt($"TaskProgress_{dateTime}_{LateWe_1}", progress);
                break;
            case LateWe_2:
                PlayerPrefs.SetInt($"TaskProgress_{dateTime}_{LateWe_2}", progress);
                break;
            case LateWe_3:
                PlayerPrefs.SetInt($"TaskProgress_{dateTime}_{LateWe_3}", progress);
                break;
            case LateWe_4:
                PlayerPrefs.SetInt($"TaskProgress_{dateTime}_{LateWe_4}", progress);
                break;
        }
        PlayerPrefs.Save();
        LuxuryHop.OrAthensLateCommerce?.Invoke();
        //AEventModule.Send(AEventType.UpdateTaskProgress);
    }

    public static void TieLateCommerce(int taskId, int progress)
    {
        var currentProgress = LawLateCommerce(taskId);
        DueLateCommerce(taskId, currentProgress + progress);
    }
    
    public static TaskStatus LawLateRavage(int taskId)
    {
        var taskStatus = (TaskStatus)PlayerPrefs.GetInt($"ATaskStatus_{taskId}", (int)TaskStatus.Incomplete);
        return taskStatus;
    }
    
    public static void DueLateRavage(int taskId, TaskStatus taskStatus)
    {
        PlayerPrefs.SetInt($"ATaskStatus_{taskId}", (int)taskStatus);
    }
}