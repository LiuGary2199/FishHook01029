using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TendUtahMagmaLuck : MonoBehaviour
{
    [Header("UI")]
[UnityEngine.Serialization.FormerlySerializedAs("ShipLvText")]    public TMP_Text UtahOfBode;
[UnityEngine.Serialization.FormerlySerializedAs("ShipLvProgressImage")]    public Image UtahOfCommerceTwain;
[UnityEngine.Serialization.FormerlySerializedAs("ProgressPercentText")]    public TMP_Text CommerceShowmanBode;
[UnityEngine.Serialization.FormerlySerializedAs("UpgradeButton")]    public Button DeceiveCourse;

    [Header("经验条动画")]
[UnityEngine.Serialization.FormerlySerializedAs("ProgressAnimDuration")]    public float CommerceHaltCheerful= 0.25f;

    private bool m_Accept;
    private bool m_HeProficiency;
    private Coroutine m_DampHaltPhysician;
    private float m_DevastateDamp;
[UnityEngine.Serialization.FormerlySerializedAs("clickhand")]
    public GameObject Incapable;

    public void Earthquake()
    {
        if (m_Accept)
        {
            return;
        }

        LuxuryHop.OrUtahLayAnother += OnShipExpChanged;
        LuxuryHop.OrUtahMagmaAnother += OnShipLevelChanged;
        LuxuryHop.OrUtahDeceiveIncurAnother += OnShipUpgradeStateChanged;
        m_Accept = true;

        if (DeceiveCourse != null)
        {
            DeceiveCourse.onClick.AddListener(OnUpgradeButtonClick);
        }

        FlipperDew();
    }

    public void Indifference()
    {
        if (!m_Accept)
        {
            return;
        }

        LuxuryHop.OrUtahLayAnother -= OnShipExpChanged;
        LuxuryHop.OrUtahMagmaAnother -= OnShipLevelChanged;
        LuxuryHop.OrUtahDeceiveIncurAnother -= OnShipUpgradeStateChanged;

        if (DeceiveCourse != null)
        {
            DeceiveCourse.onClick.RemoveListener(OnUpgradeButtonClick);
        }

        if (m_DampHaltPhysician != null)
        {
            StopCoroutine(m_DampHaltPhysician);
            m_DampHaltPhysician = null;
        }

        m_Accept = false;
    }

    public void FlipperDew()
    {
        if (RopeStrange.Instance == null)
        {
            return;
        }

        int Spiky= RopeStrange.Instance.LawUtahMagma();
        int exp = RopeStrange.Instance.LawUtahLay();
        int NileLay= RopeStrange.Instance.LawUtahWoadLay();
        FlipperUtahMagmaUI(Spiky, exp, NileLay, true);
        int pendingCount = RopeMintStrange.LawLaurasia().LawFactoryMagmaSoRelic();
        OnShipUpgradeStateChanged(pendingCount > 0, pendingCount);
    }

    private void OnShipExpChanged(int level, int exp, int needExp)
    {
        FlipperUtahMagmaUI(level, exp, needExp, false);
    }

    private void OnShipLevelChanged(int oldLevel, int newLevel, int levelUpCount)
    {
        FlipperDew();
    }

    private void OnShipUpgradeStateChanged(bool canUpgrade, int pendingLevelUpCount)
    {
        m_HeProficiency = canUpgrade;
        DueLeakyRootPotash(m_HeProficiency);
    }

    private void FlipperUtahMagmaUI(int level, int exp, int needExp, bool instant)
    {
        if (UtahOfBode != null)
        {
            UtahOfBode.text = "Lv." + Mathf.Max(1, level);
        }
        AIRopeGiftStrange.LawLaurasia().TangMagmaAnother(level);
        // needExp 可能在服务器配置尚未初始化时为 0：
        // 这里不要显示“满进度”，而是显示 0% 等待配置到位后再刷新。
        float targetFill = needExp > 0 ? Mathf.Clamp01((float)exp / needExp) : 0f;

        if (CommerceShowmanBode != null)
        {
            int percent = needExp > 0 ? Mathf.RoundToInt(targetFill * 100f) : 0;
            CommerceShowmanBode.text = percent + "%";
        }

        HarvardCommerce(targetFill, instant);
    }

    private void HarvardCommerce(float targetFill, bool instant)
    {
        if (UtahOfCommerceTwain == null)
        {
            return;
        }

        if (instant || CommerceHaltCheerful <= 0f)
        {
            if (m_DampHaltPhysician != null)
            {
                StopCoroutine(m_DampHaltPhysician);
                m_DampHaltPhysician = null;
            }
            m_DevastateDamp = targetFill;
            UtahOfCommerceTwain.fillAmount = m_DevastateDamp;
            return;
        }

        if (m_DampHaltPhysician != null)
        {
            StopCoroutine(m_DampHaltPhysician);
        }
        m_DampHaltPhysician = StartCoroutine(FoodCommerceHalt(targetFill));
    }

    private IEnumerator FoodCommerceHalt(float targetFill)
    {
        float start = m_DevastateDamp;
        float Krill= 0f;
        float Pipeline= Mathf.Max(0.01f, CommerceHaltCheerful);

        while (Krill < Pipeline)
        {
            Krill += Time.deltaTime;
            float t = Mathf.Clamp01(Krill / Pipeline);
            m_DevastateDamp = Mathf.Lerp(start, targetFill, t);
            if (UtahOfCommerceTwain != null)
            {
                UtahOfCommerceTwain.fillAmount = m_DevastateDamp;
            }
            yield return null;
        }

        m_DevastateDamp = targetFill;
        if (UtahOfCommerceTwain != null)
        {
            UtahOfCommerceTwain.fillAmount = m_DevastateDamp;
        }
        m_DampHaltPhysician = null;
    }

    public void OnUpgradeButtonClick()
    {
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_UIButton);
        if (!m_HeProficiency)
        {
            return;
        }
        TermDeceiveStand();
    }

    public void KinsmanMagmaSoMoss()
    {
        if (RopeStrange.Instance == null)
        {
            return;
        }

        RopeStrange.Instance.KeaUtahMagmaSoMoss();
    }

    private void DueLeakyRootPotash(bool active)
    {
        if (Incapable == null)
        {
            return;
        }

        if (Incapable.activeSelf != active)
        {
            Incapable.SetActive(active);
        }
    }

    private void TermDeceiveStand()
    {
        if (string.IsNullOrEmpty(nameof(UtahMagmaSoStand)))
        {
            return;
        }

        UIStrange manager = UIStrange.LawLaurasia();
        if (manager != null)
        {
            manager.BeatUIHouse(nameof(UtahMagmaSoStand));
        }
    }

    private void OnDestroy()
    {
        DueLeakyRootPotash(false);
        Indifference();
    }
}
