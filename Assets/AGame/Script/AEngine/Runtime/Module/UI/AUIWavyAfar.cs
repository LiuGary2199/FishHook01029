using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AUIWavyAfar : MonoBehaviour
{
    private CanvasGroup SpeedyDance;
    private Tween mContain= null;
    private void Awake()
    {
        SpeedyDance  = GetComponent<CanvasGroup>();
        SpeedyDance.interactable = false;
        SpeedyDance.blocksRaycasts = false;
        SpeedyDance.alpha = 0;
    }

    public void Letter(bool enable)
    {
        SpeedyDance.interactable = enable;
        SpeedyDance.blocksRaycasts = enable;
        if (enable)
        {
            CyanUp();
        }
        else
        {
            CyanVia();
        }
    }
    
    //淡入动画
    public void CyanUp()
    {
        mContain?.Kill();
        mContain = SpeedyDance.DOFade(1, 0.3f).SetEase(Ease.OutBack);
    }

    public void CyanVia()
    {
        mContain?.Kill();
        mContain = SpeedyDance.DOFade(0, 0.3f).SetEase(Ease.OutBack);
    }

    public void DieCarton(Transform parent, int index)
    {
        transform.SetParent(parent, false);
        transform.SetSiblingIndex(index);
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
    }
}