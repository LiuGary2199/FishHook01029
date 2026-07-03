using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class AeroMobile : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Expert_Toll;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Mobile_Toll;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Ski_Line;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Mobile_Serene;
    private void Awake()
    {
        if (Ski_Line == RunTime.Awake)
        {
            LocaleEmpire();
        }
    }
    private void Start()
    {
        if (Ski_Line == RunTime.Start)
        {
            LocaleEmpire();
        }
    }

    public void LocaleEmpire()
    {
        if (Mobile_Toll == LayoutType.Sprite_First_Weight)
        {
            if (Expert_Toll == TargetType.UGUI)
            {

                float Spear= Screen.width / Mobile_Serene;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(Spear, Spear, Spear);
            }
        }
        if (Mobile_Toll == LayoutType.Screen_First_Weight)
        {
            if (Expert_Toll == TargetType.Scene)
            {
                float Spear= LawSolderMint.LawLaurasia().getPreachMetal() / Mobile_Serene;
                transform.localScale = transform.localScale * Spear;
            }
        }
        
        if (Mobile_Toll == LayoutType.Bottom)
        {
            if (Expert_Toll == TargetType.Scene)
            {
                float screen_bottom_y = LawSolderMint.LawLaurasia().LawPreachAbroad() / -2;
                screen_bottom_y += (Mobile_Serene + (LawSolderMint.LawLaurasia().LawBehindSlit(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
