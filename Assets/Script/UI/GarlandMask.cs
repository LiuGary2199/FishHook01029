using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlandMask : SeedUIHouse
{
    public void Start()
    {
        m_PredatoryDiscrete.OrGarlandStyTrader += OnLoadingAniFinish;
    }
    public void OnLoadingAniFinish()
    {
       
    }
[UnityEngine.Serialization.FormerlySerializedAs("m_AnimationCallback")]    public PredatoryDiscrete  m_PredatoryDiscrete;
    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        m_PredatoryDiscrete.FoodFoodGarlandStyTrader();
    }
}
