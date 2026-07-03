using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuneUsStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Onion;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Cart1Behind;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Cart2Behind;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Onion)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                WoodyHorde(index);
            });
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        for (int i = 0; i < 5; i++)
        {
            Onion[i].gameObject.GetComponent<Image>().sprite = Cart2Behind;
        }
    }


    private void WoodyHorde(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Onion[i].gameObject.GetComponent<Image>().sprite = i <= index ? Cart1Behind : Cart2Behind;
        }
        BabyLatinDating.LawLaurasia().TangLatin("1301", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(FrownStand());
        } else
        {
            // 跳转到应用商店
            DuneMeStrange.instance.TermAPPinBestow();
            StartCoroutine(FrownStand());
        }
#if UNITY_IOS
              PlayerPrefs.SetInt("da2prx", 1);
        AIRopeGiftStrange.LawLaurasia().TangLatin("da2prx");
#endif


        // 打点
        //BabyLatinDating.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator FrownStand(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        DriftUIBard(GetType().Name);
    }
}
