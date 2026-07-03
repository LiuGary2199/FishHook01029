using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Text;
using DG.Tweening;
using Spine;
using TMPro;

public class SwarmHalt : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("m_SkeletonGraphic")]    public SkeletonGraphic m_PossibleDiamond;
[UnityEngine.Serialization.FormerlySerializedAs("textsObj")]    public GameObject StoryTin;
[UnityEngine.Serialization.FormerlySerializedAs("particleObj")]    public GameObject DecreaseTin;
[UnityEngine.Serialization.FormerlySerializedAs("numberText")]
    public TextMeshProUGUI GermanBode;
    private Vector3 MeantimeTrunk;
    private Tween NotableLeast;
    [SerializeField] private float SyntheticTrunk= 1.3f;
    [SerializeField] private float Pipeline= 0.6f;
    [SerializeField] private Ease FishAn= Ease.OutQuad;
    [SerializeField] private Ease FishToo= Ease.InQuad;
    public void FoodHalt(int number)
    {
        if (StoryTin == null || m_PossibleDiamond == null) return;
        // 若起始为隐藏状态，调用时强制激活，避免触发了但 UI 不显示
        if (!gameObject.activeInHierarchy) gameObject.SetActive(true);

        if (NotableLeast != null && NotableLeast.IsActive())
            NotableLeast.Kill();
        DG.Tweening.DOTween.Kill(this);
        m_PossibleDiamond.gameObject.SetActive(false);
        m_PossibleDiamond.gameObject.SetActive(true);
        m_PossibleDiamond.AnimationState.ClearTracks();
        m_PossibleDiamond.AnimationState.SetAnimation(0, "animation", false);
        MeantimeTrunk = Vector3.one;
        StoryTin.gameObject.SetActive(true);
        DecreaseTin.gameObject.SetActive(true);
        StoryTin.transform.localScale = Vector3.zero;
        StringBuilder stringBuilder = new StringBuilder(); 
        stringBuilder.Append("");
        stringBuilder.Append(number);
        GermanBode.text = stringBuilder.ToString();
        Sequence sequence = DOTween.Sequence().SetId(this);
        sequence.Append(StoryTin.transform.DOScale(MeantimeTrunk * SyntheticTrunk, Pipeline * 0.35f)
            .SetEase(FishAn));
        sequence.Append(StoryTin.transform.DOScale(MeantimeTrunk, 0.1f)
            .SetEase(FishToo));
        sequence.Insert(0.8f, DOVirtual.DelayedCall(0.1f, () => { }));
        sequence.OnComplete(() =>
        {
            if (StoryTin != null)
            {
                StoryTin.transform.localScale = Vector3.zero;
            }
                DecreaseTin.gameObject.SetActive(false);
                m_PossibleDiamond.gameObject.SetActive(false);
        });
        NotableLeast = sequence;
    }
    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            FoodHalt(1);
        }
    }

    private void OnDestroy()
    {
        if (NotableLeast != null && NotableLeast.IsActive())
            NotableLeast.Kill();
        DG.Tweening.DOTween.Kill(this);
    }
}
