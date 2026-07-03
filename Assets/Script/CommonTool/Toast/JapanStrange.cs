using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapanStrange : MonoSnowstorm<JapanStrange>
{
    public void BeatJapan(string info)
    {
        UIStrange.LawLaurasia().BeatUIHouse(nameof(Japan), info);
    }
}
