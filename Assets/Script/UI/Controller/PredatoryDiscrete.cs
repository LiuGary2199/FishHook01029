using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PredatoryDiscrete : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ferverTransitionAnimator")]    public Animator SpinalEquatorialPriority;
[UnityEngine.Serialization.FormerlySerializedAs("OnLoadingAniFinish")]    public Action OrGarlandStyTrader;
    public void OnFercverAniOver()
    {
        Debug.Log("ferver animation over");
        LuxuryHop.OrBenignLineHaltTrader?.Invoke();
    }

    // 供 Ferver 过渡动画中段关键帧调用：提前清场
    public void OnFerverPreClear()
    {
        Debug.Log("ferver pre-clear");
        LuxuryHop.OrBenignTowStudyCluster?.Invoke();
    }
    public void OnLoadingAniOver()
    {
        Debug.Log("loading animation over");
        OrGarlandStyTrader?.Invoke();
    }
    public void FoodFoodGarlandStyTrader()
    {
        SpinalEquatorialPriority.enabled = true;
        SpinalEquatorialPriority.Rebind();
        SpinalEquatorialPriority.Update(0f);
        if (string.IsNullOrEmpty("LoadingAni"))
        {
            SpinalEquatorialPriority.Play(0, 0, 0f);
        }
        else
        {
            SpinalEquatorialPriority.Play("LoadingAni", 0, 0f);
        }
    }
     public void OnEnterGame()
    {
        Debug.Log("loading OnEnterGame");
        LuxuryHop.OrPriorRope?.Invoke();
    }    
}
