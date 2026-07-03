using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StudFreight : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform Bond;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public WormLuck Shoemaking;
    private void Awake()
    {
        Shoemaking.OrWormUnjust = Inaugurate;
    }

    void Inaugurate(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        Bond.GetComponent<RectTransform>().position = pos;
    }
}
