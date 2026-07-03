using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaryKenya : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject RailKenya;

    private GameObject CohesionRadioRation;
    private float MoonMetal= 120f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        CohesionRadioRation = RailKenya.transform.Find("SlotCard_1").gameObject;
        float x = MoonMetal * 3;
        int multiCount = LopColeJar.instance.RailMint.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(CohesionRadioRation, RailKenya.transform);
                fangkuai.transform.localPosition = new Vector3(x + MoonMetal * multiCount * i + MoonMetal * j, CohesionRadioRation.transform.localPosition.y, 0);
                double multi = LopColeJar.instance.RailMint.slot_group[j].multi;
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + multi.ToString("0.##");
            }
        }
    }

    public void IronRadio()
    {
        RailKenya.GetComponent<RectTransform>().localPosition = new Vector3(0, -14, 0);
    }

    public void Beau(int index, Action<double> finish)
    {
        StainJar.LawLaurasia().FoodAttain(StainToll.UIMusic.Sound_OneArmBandit);
        PredatoryDependably.AutonomousLayout(RailKenya, -(MoonMetal * 2 + MoonMetal * LopColeJar.instance.RailMint.slot_group.Count * 3 + MoonMetal * (index + 1)), () =>
        {
            finish?.Invoke(LopColeJar.instance.RailMint.slot_group[index].multi);
        });
    }
}
