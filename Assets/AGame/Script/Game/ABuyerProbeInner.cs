using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABuyerProbeInner : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    public AUIAlpine Midst;
    // Start is called before the first frame update
    void Start()
    {
        Midst.onClick.AddListener(MidstUI);
    }
}
