using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LuckyCardController : MonoBehaviour
{
    public GameObject DaimImg;
    public GameObject CashImg;
    public GameObject overImg;
    public TextMeshProUGUI rewardText;
    public RewardType rewardType;
    public double rewardNum;
    public Animator m_FlipAnimator;
    public Button cardBtn;
    public bool isThanksCard;
    public void CloseObj()
    {
        HideRewardLayer();
        if (rewardText != null)
            rewardText.text = "";
        CloseImg();
    }

    private void HideRewardLayer()
    {
        if (CashImg != null) CashImg.SetActive(false);
        if (DaimImg != null) DaimImg.SetActive(false);
        if (overImg != null) overImg.SetActive(false);
    }

    public void InitRewardObjData(LuckyObjData luckyObjData, bool resetAnimToIdle = true)
    {
        isThanksCard = false;
        cardBtn.onClick.RemoveAllListeners();
        cardBtn.onClick.AddListener(OnCardButtonClick);
        cardBtn.interactable = true;
        rewardType = luckyObjData.LuckyObjType;
        rewardNum = luckyObjData.RewardNum;

        HideRewardLayer();

        if (resetAnimToIdle)
        {
            CloseImg();
            if (rewardText != null)
                rewardText.text = "";
        }
        else
        {
            if (rewardText != null)
                rewardText.text = rewardNum + "";
            switch (rewardType)
            {
                case RewardType.Cash:
                    if (CashImg != null) CashImg.SetActive(true);
                    break;
                case RewardType.Diamond:
                    if (DaimImg != null) DaimImg.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void InitThanksObjData()
    {
        isThanksCard = true;
        cardBtn.onClick.RemoveAllListeners();
        cardBtn.onClick.AddListener(OnCardButtonClick);
        cardBtn.interactable = true;
        HideRewardLayer();
        if (rewardText != null)
            rewardText.text = "";
        CloseImg();
    }

    public void ShowThanksFace()
    {
        HideRewardLayer();
        if (overImg != null)
            overImg.SetActive(true);
    }

    public void ShowCurrentFace()
    {
        HideRewardLayer();
        if (isThanksCard)
        {
            if (overImg != null) overImg.SetActive(true);
            if (rewardText != null) rewardText.text = "";
            return;
        }

        if (rewardText != null)
            rewardText.text = rewardNum .ToString();

        switch (rewardType)
        {
            case RewardType.Cash:
                if (CashImg != null) CashImg.SetActive(true);
                break;
            case RewardType.Diamond:
                if (DaimImg != null) DaimImg.SetActive(true);
                break;
        }
    }

    private void OnCardButtonClick()
    {
        var panel = CouldZeroStand.Instance;
        if (panel == null) return;
        // 对齐旧版：解锁前不允许点击翻牌
        if (panel.BeRule) return;
        if (panel.LoggerTinTall.Contains(gameObject)) return;

        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_PopShow);
        panel.TieMidwayTall(gameObject);
    }

    private void CloseImg()
    {
        m_FlipAnimator.Play("idleCard", 0, 0f);
    }
    public void PlayAnim()
    {
        m_FlipAnimator.Play("FlipTheCard", 0, 0f);
    }

    public void SetInteractable(bool value)
    {
        if (cardBtn != null)
            cardBtn.interactable = value;
    }
}