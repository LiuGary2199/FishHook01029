using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;


/// <summary> 引导面板 </summary>
public class TightStand : SeedUIHouse
{
    Image Erupt;
[UnityEngine.Serialization.FormerlySerializedAs("MaskImages")]    public Image[] StudTomato;
    [Range(0f, 1f)] [SerializeField] float PeddlerStudSpend= 0.78f;
[UnityEngine.Serialization.FormerlySerializedAs("Center")]    public RectTransform Eighty;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    public Transform Root;
[UnityEngine.Serialization.FormerlySerializedAs("InfoBg")]    public Transform ColeBg;
[UnityEngine.Serialization.FormerlySerializedAs("Info")]    public Text Cole;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("GuideIndex")]public int TightSlope;
[UnityEngine.Serialization.FormerlySerializedAs("NextBtn")]    public Button SpinTin;
    Coroutine ColePeatIE;


    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Erupt = GetComponent<Image>();
        Jolt(true);
    }

    public void BeatStud(Transform Target, float Scale = 1, float? alpha = null)
    {
        RectTransform TargetRect = Target.GetComponent<RectTransform>();
        BeatStud(TargetRect.position, TargetRect.sizeDelta * Target.localScale * Scale, alpha);
    }
    void BeatStud(Vector2 Pos, Vector2 Size, float? alpha = null)
    {
        DueStudSpend(alpha ?? PeddlerStudSpend);
        Erupt.raycastTarget = true;
        Eighty.DOKill();
        Eighty.DOMove(Pos, .5f);
        Eighty.DOSizeDelta(Size, .7f).OnComplete(() =>
        {
            Erupt.raycastTarget = false;
        });
    }

    public void BeatStud_Utter(Vector2 Pos, Vector2 Size, float? alpha = null)
    {
        DueStudSpend(alpha ?? PeddlerStudSpend);
        Erupt.raycastTarget = true;
        Eighty.DOKill();
        Eighty.DOLocalMove(Pos, .5f);
        Eighty.DOSizeDelta(Size, .7f).OnComplete(() =>
        {
            Erupt.raycastTarget = false;
        });
    }

    public void BeatRoot(Vector2[] Poss)
    {
        Root.DOKill();
        Root.gameObject.SetActive(true);
        Root.position = Poss[0];
        if (Poss.Length > 1)
            RootHalt(Poss, 0);
    }
    void RootHalt(Vector2[] Poss, int Index)
    {
        Root.DOMove(Poss[Index], .4f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (Root.gameObject.activeSelf)
            {
                if (Index < Poss.Length - 1)
                    RootHalt(Poss, Index + 1);
                else
                    RootHalt(Poss, 0);
            }
        });
    }

    public void BeatCole(string Text, int PosY = 0)
    {
        Cole.DOKill();
        ColeBg.DOKill();
        Cole.text = "";
        ColeBg.gameObject.SetActive(true);
        ColeBg.localScale = new Vector2(0, 1);
        ColeBg.DOScale(Vector2.one, .3f);
        Cole.DOText(Text, .3f).SetDelay(.3f);

        if (ColePeatIE != null)
            StopCoroutine(ColePeatIE);
        if (ColeBg.localPosition.y != PosY)
            ColePeatIE = StartCoroutine(nameof(ColePeat), PosY);
    }
    IEnumerator ColePeat(int PosY)
    {
        Vector2 UpdatePos = ColeBg.localPosition;
        Vector2 TargetPos = new Vector2(0, PosY);
        while (true)
        {
            yield return null;
            TargetPos.y = PosY;
            UpdatePos.y = Mathf.Lerp(UpdatePos.y, TargetPos.y, Time.deltaTime * 10);
            ColeBg.localPosition = UpdatePos;
            if (Mathf.Abs(UpdatePos.y - TargetPos.y) < 1)
                break;
        }
    }

    public void BeatSpinTin(Action OnBtnClick)
    {
        SpinTin.onClick.RemoveAllListeners();
        SpinTin.onClick.AddListener(() =>
        {
            SpinTin.onClick.RemoveAllListeners();
            OnBtnClick();
        });
        SpinTin.gameObject.SetActive(false);
        Invoke(nameof(BeatSpinTin), 1f);
    }
    void BeatSpinTin()
    {
        SpinTin.gameObject.SetActive(true);
    }

    void DueStudSpend(float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        if (StudTomato != null && StudTomato.Length > 0)
        {
            for (int i = 0; i < StudTomato.Length; i++)
            {
                if (StudTomato[i] == null)
                    continue;
                Color color = StudTomato[i].color;
                color.a = alpha;
                StudTomato[i].color = color;
            }
            return;
        }

        if (Erupt == null)
            return;
        Color blockColor = Erupt.color;
        blockColor.a = alpha;
        Erupt.color = blockColor;
    }

    public void Jolt(bool IsBlcok)
    {
        Root.DOKill();
        Cole.DOKill();
        ColeBg.DOKill();
        Eighty.DOKill();
        Root.gameObject.SetActive(false);
        Cole.text = "";
        ColeBg.gameObject.SetActive(false);
        SpinTin.gameObject.SetActive(false);
        Eighty.localPosition = Vector2.zero;
        Eighty.sizeDelta = Vector2.one * 3000;
        Erupt.raycastTarget = IsBlcok;
    }

}
