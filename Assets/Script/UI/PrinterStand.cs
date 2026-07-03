using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrinterStand : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]    public Button Grass_Course;
[UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]    public Button Music_Course;
[UnityEngine.Serialization.FormerlySerializedAs("Vibrate_Button")]    public Button Kingdom_Course;
[UnityEngine.Serialization.FormerlySerializedAs("HowToPlayBtn")]    public Button HayAxFoodTin;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button DriftTin;


    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Grass_Course.transform.Find("ON").gameObject.SetActive(StainJar.LawLaurasia().AttainStainGuinea);
        Grass_Course.transform.Find("OFF").gameObject.SetActive(!StainJar.LawLaurasia().AttainStainGuinea);
        Music_Course.transform.Find("ON").gameObject.SetActive(StainJar.LawLaurasia().OnStainGuinea);
        Music_Course.transform.Find("OFF").gameObject.SetActive(!StainJar.LawLaurasia().OnStainGuinea);
        Kingdom_Course.transform.Find("ON").gameObject.SetActive(StainJar.LawLaurasia().KingdomGuinea);
        Kingdom_Course.transform.Find("OFF").gameObject.SetActive(!StainJar.LawLaurasia().KingdomGuinea);
        DriftTin.onClick.AddListener(() => { DriftUIBard(nameof(PrinterStand)); });
        HayAxFoodTin.onClick.AddListener(() =>
        {
            DriftUIBard(nameof(PrinterStand));
        });
    }


    void Start()
    {
        Music_Course.onClick.AddListener(() =>
        {
            StainJar.LawLaurasia().OnStainGuinea = !StainJar.LawLaurasia().OnStainGuinea;
            Music_Course.transform.Find("ON").gameObject.SetActive(StainJar.LawLaurasia().OnStainGuinea);
            Music_Course.transform.Find("OFF").gameObject.SetActive(!StainJar.LawLaurasia().OnStainGuinea);
        });
        Grass_Course.onClick.AddListener(() =>
        {
            StainJar.LawLaurasia().AttainStainGuinea = !StainJar.LawLaurasia().AttainStainGuinea;
            Grass_Course.transform.Find("ON").gameObject.SetActive(StainJar.LawLaurasia().AttainStainGuinea);
            Grass_Course.transform.Find("OFF").gameObject.SetActive(!StainJar.LawLaurasia().AttainStainGuinea);
        });
        Kingdom_Course.onClick.AddListener(() =>
        {
            StainJar.LawLaurasia().KingdomGuinea = !StainJar.LawLaurasia().KingdomGuinea;
            Kingdom_Course.transform.Find("ON").gameObject.SetActive(StainJar.LawLaurasia().KingdomGuinea);
            Kingdom_Course.transform.Find("OFF").gameObject.SetActive(!StainJar.LawLaurasia().KingdomGuinea);
        });
    }

}
