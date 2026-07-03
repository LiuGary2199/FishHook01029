using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACorpTomb : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("NullIcon")]    public GameObject BlowTomb;
[UnityEngine.Serialization.FormerlySerializedAs("Unlock")]    public int Causal;

    private void Start()
    {
        BlowTomb.SetActive(!(AReapEarning.Slowness.PlayPlumb >= Causal));
    }
}
