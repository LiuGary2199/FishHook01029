using UnityEngine;
using UnityEngine.UI;

public class CoalBowWish : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("DotNormal")]    public GameObject BowInvite;
[UnityEngine.Serialization.FormerlySerializedAs("DotNumber")]    public GameObject BowWinner;
[UnityEngine.Serialization.FormerlySerializedAs("DotCountTxt")]    public Text BowHasteEre;

    private CoalRook Rook;
    
    private bool _JuryBow;
    public bool ShowBow    {
        get => _JuryBow;
        set
        {
            _JuryBow = value;
            RemodelBow();
        }
    }
    
    private DotStyle _NssDusty;

    private void OnDestroy()
    {
        Rook.OnDotNotice -= RemodelBow;
        Rook = null;
    }

    public virtual void Cook(CoalRook node, DotStyle style = DotStyle.Normal, bool showDot = true)
    {
        Rook = node;
        Rook.OnDotNotice -= RemodelBow;
        Rook.OnDotNotice += RemodelBow;
        _NssDusty = style;
        ShowBow = showDot;
    }

    public void RemodelBow()
    {
        BowInvite.SetActive(ShowBow && _NssDusty == DotStyle.Normal && Rook.SoKing);
        
        if (ShowBow && _NssDusty == DotStyle.Number && Rook.SoKing)
        {
            BowWinner.SetActive(true);
            BowHasteEre.text = Rook.BowHaste.ToString();
        }
        else
        {
            BowWinner.SetActive(false);
        }
    }
}

public enum DotStyle
{
    Normal = 0,
    Number = 1
}