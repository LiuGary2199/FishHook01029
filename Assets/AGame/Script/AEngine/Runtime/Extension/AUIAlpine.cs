using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AUIAlpine : Button
{
    public bool KnifeHalf= true;
    public bool Enjoy= true;

    private float mFloutSlayKnife= 0.9f;
    private Vector3 mInviteKnife= Vector3.zero;
    private Tween mContain= null;
    private Material mDrillGrayHieratic= null;
    private List<Graphic> mSpacious= null;
    private bool mSoRich= false;
    
    public bool SoRich    {
        get => mSoRich;
        set
        {
            if (mSoRich == value) return;
            mSoRich = value;
            if (Application.isPlaying)
            {
                ShroudRich();
            }
        }
    }
    
#if UNITY_EDITOR
    protected override void Reset()
    {
        base.Reset();
        this.transition = Transition.None;
    }
#endif

    protected override void Start()
    {
        base.Start();
        mInviteKnife = transform.localScale;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        
        if (!interactable || !KnifeHalf) return;

        mContain?.Kill();
        mContain = transform.DOScale(mInviteKnife * mFloutSlayKnife, 0.1f)
            .SetEase(Ease.InQuart);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (!interactable || !KnifeHalf) return;
        
        mContain?.Kill();
        mContain = transform.DOScale(mInviteKnife, 0.05f)
            .SetEase(Ease.OutQuart)
            .OnComplete((() =>
            {
                transform.localScale = mInviteKnife;
            }))
            .OnKill((() =>
            {
                transform.localScale = mInviteKnife;
            }));
        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if (!interactable || !Enjoy) return;
        A_HavenEarning.Slowness.BulkAscribeAlpineEnjoy();
    }

    private void ShroudRich()
    {
        
        if (mSoRich)
        {
            if (mDrillGrayHieratic == null)
            {
                mDrillGrayHieratic = new Material(Shader.Find("UI/DefaultExtra"));
            }
            
            if (mDrillGrayHieratic != null)
            {
                if (mSpacious == null)
                {
                    mSpacious = new List<Graphic>();
                    GetComponentsInChildren<Graphic>(true, mSpacious);
                }
                foreach (var graphic in mSpacious)
                {
                    graphic.material = mDrillGrayHieratic;
                }
            }
        }
        mDrillGrayHieratic?.SetFloat("_GrayScale", mSoRich ? 1f : 0f);
    }
    
    protected override void OnDestroy()
    {
        base.OnDestroy();
        mContain?.Kill();
        mContain = null;
        mDrillGrayHieratic = null;
    }
}