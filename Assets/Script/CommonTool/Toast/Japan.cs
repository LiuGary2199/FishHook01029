using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Japan : SeedUIHouse
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text JapanBode;

    

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        JapanBode.text = uiFormParams.ToString();
        StartCoroutine(nameof(SashDriftJapan));
    }

    private IEnumerator SashDriftJapan()
    {
        yield return new WaitForSeconds(2);
        DriftUIBard(GetType().Name);
    }

}
