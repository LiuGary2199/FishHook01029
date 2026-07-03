using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TendGetKeep : MonoBehaviour
{
    public GameObject m_Cash;
    public GameObject m_Diamond;
    public TextMeshProUGUI RotText;

    private void Awake()
    {
        ResetDisplay();
    }

    private void OnEnable()
    {
        // 防止预制体默认勾选导致两张图同时显示
        ResetDisplay();
    }

    private void ResetDisplay()
    {
        if (m_Cash != null) m_Cash.SetActive(false);
        if (m_Diamond != null) m_Diamond.SetActive(false);
        if (RotText != null) RotText.text = string.Empty;
    }

    public void ClearDisplay()
    {
        ResetDisplay();
    }

    public void SetRewardDisplay(RewardType rewardType, int rewardCount)
    {
        if (m_Cash != null) m_Cash.SetActive(false);
        if (m_Diamond != null) m_Diamond.SetActive(false);
        if (m_Cash != null) m_Cash.SetActive(rewardType == RewardType.Cash);
        if (m_Diamond != null) m_Diamond.SetActive(rewardType == RewardType.Diamond);

        if (RotText == null) return;
        RotText.text = rewardCount > 0 ? $"x{rewardCount}" : string.Empty;
    }
}
