using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class InedibleLatinPlantlike : MonoBehaviour, ICanvasRaycastFilter
{
    private Image LitterTwain;
    public void DueExpertTwain(Image target)
    {
        LitterTwain = target;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (LitterTwain == null)
        {
            return true;
        }
        return !RectTransformUtility.RectangleContainsScreenPoint(LitterTwain.rectTransform, sp, eventCamera);
    }
}