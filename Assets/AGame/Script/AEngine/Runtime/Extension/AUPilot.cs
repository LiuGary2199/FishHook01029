using UnityEngine;
using UnityEngine.UI;

public class AUPilot : Image
{
    private Material FullHieratic= null;
    private bool mSoRich= false;
    public bool SoRich    {
        get => mSoRich;
        set
        {
            if (mSoRich == value) return;
            mSoRich = value;
            if (Application.isPlaying)
            {
                ShroudRich();
            }
        }
    }
    
    private void ShroudRich()
    {
        if (material == null) return;
        if (FullHieratic == null)
        {
            FullHieratic = new Material(Shader.Find("UI/DefaultExtra"));
            if (FullHieratic != null)
            {
                material = FullHieratic;
            }
        }
        FullHieratic?.SetFloat("_GrayScale", mSoRich ? 1f : 0f);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        FullHieratic = null;
    }
}